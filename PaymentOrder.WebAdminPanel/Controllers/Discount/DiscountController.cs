using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PaymentOrder.Core.Domain.Abstract;
using PaymentOrder.WebAdminPanel.Mapper.Discount;
using PaymentOrder.WebAdminPanel.Models.Discount;
using System;
using System.Collections.Generic;

namespace PaymentOrder.WebAdminPanel.Controllers.Discount
{
    public class DiscountController : Controller
    {
        public readonly IUnitOfWork db;
        public DiscountController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var discounts = db.DiscountRepository.Get();
            var discountMapper = new DiscountMapper();
            List<DiscountModel> discountModels = new List<DiscountModel>();

            for (int i = 0; i < discounts.Count; i++)
            {
                var discount = discounts[i];
                var model = discountMapper.Map(discount);

                model.No = i + 1;

                discountModels.Add(model);
            }
            DiscountViewModel viewModel = new DiscountViewModel()
            {
                Discounts = discountModels
            };
            return View(viewModel);
        }

        public IActionResult Save(int Id)
        {
            SaveDiscountViewModel viewModel = new SaveDiscountViewModel();
            var discounts = db.DiscountRepository.Get();

            viewModel.DiscountList = new SelectList(discounts, "Id", "Discount");

            if (Id != 0)
            {
                var discountMapper = new DiscountMapper();
                var discount = db.DiscountRepository.Get(Id);
                var discountModel = discountMapper.Map(discount);

                viewModel.Discount = discountModel;
            }

            return PartialView(viewModel);
        }

        public IActionResult Submit(SaveDiscountViewModel viewModel)
        {
            try
            {
                var model = viewModel.Discount;
                var discountMapper = new DiscountMapper();
                var discounts = discountMapper.Map(model);

                if (discounts.Id == 0)
                {
                    discounts.IsCreated = DateTime.Now;
                }

                discounts.IsModified = DateTime.Now;
                discounts.IsDeleted = false;

                if (discounts.Id == 0)
                {
                    if (discounts.DiscountStartDate > discounts.DiscountEndDate)
                    {
                        return Content("Start date cannot be greater than end date");
                    }
                    if (discounts.Discount < 0)
                    {
                        return Content("Percentage cannot be negative");
                    }
                    else
                    {
                        db.DiscountRepository.Insert(discounts);
                    }
                }
                else
                {
                    if (discounts.DiscountStartDate > discounts.DiscountEndDate)
                    {
                        return Content("Start date cannot be greater than end date");
                    }
                    if (discounts.Discount < 0)
                    {
                        return Content("Percentage cannot be negative");

                    }
                    else
                    {
                        db.DiscountRepository.Update(discounts);
                    }
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
