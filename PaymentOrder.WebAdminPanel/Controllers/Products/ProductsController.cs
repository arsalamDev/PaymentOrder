using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PaymentOrder.Core.Domain.Abstract;
using PaymentOrder.WebAdminPanel.Mapper.Products;
using PaymentOrder.WebAdminPanel.Models.Products;
using System;
using System.Collections.Generic;

namespace PaymentOrder.WebAdminPanel.Controllers.Products
{
    public class ProductsController : Controller
    {
        public readonly IUnitOfWork db;
        public ProductsController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var products = db.ProductRepository.Get();
            var productMapper = new ProductsMapper();
            List<ProductsModel> productsList = new List<ProductsModel>();

            for(int i = 0; i < products.Count; i++)
            {
                var product = products[i];
                var model = productMapper.Map(product);

                model.No = i + 1;
                productsList.Add(model);
            }

            ProductsViewModel viewModel = new ProductsViewModel()
            {
                Products = productsList,
            };

            return View(viewModel);
        }

        public IActionResult Save(int Id)
        {
            SaveProductsViewModel viewModel = new SaveProductsViewModel();
            var products = db.ProductRepository.Get();
            viewModel.ProductsList = new SelectList(products, "Id", "Name");

            if (Id != 0)
            {
                var productMapper = new ProductsMapper();
                var product = db.ProductRepository.Get(Id);
                var productModel = productMapper.Map(product);

                viewModel.Products = productModel;
            }

            return PartialView(viewModel);
        }

        public IActionResult Submit(SaveProductsViewModel viewModel)
        {
            try
            {
                var model = viewModel.Products;
                var productMapper = new ProductsMapper();
                var products = productMapper.Map(model);
                
                if(products.Id == 0)
                {
                    products.IsCreated = DateTime.Now;
                }

                products.IsModified = DateTime.Now;
                products.IsDeleted = false;

                if(products.Id != 0)
                {
                    db.ProductRepository.Update(products);
                }
                else
                {
                    db.ProductRepository.Insert(products);
                }
                TempData["Message"] = "Operation successfully";
            }
            catch
            {
                TempData["Message"] = "Operation unsuccessfully";
            }
            return RedirectToAction("Index");
        }
    }
}
