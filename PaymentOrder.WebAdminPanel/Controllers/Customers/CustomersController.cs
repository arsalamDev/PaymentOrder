using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PaymentOrder.Core.Domain.Abstract;
using PaymentOrder.WebAdminPanel.Mapper.Customers;
using PaymentOrder.WebAdminPanel.Mapper.Employees;
using PaymentOrder.WebAdminPanel.Models.Customers;
using PaymentOrder.WebAdminPanel.Models.Employees;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Data;

namespace PaymentOrder.WebAdminPanel.Controllers.Customers
{
    [Authorize(Roles = "A, B")]
    public class CustomersController : Controller
    {
        public readonly IUnitOfWork db;
        public CustomersController(IUnitOfWork db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            var customers = db.CustomersRepository.Get();
            CustomersMapper customerMapper = new CustomersMapper();
            List<CustomersModel> customerModels = new List<CustomersModel>();

            for (int i = 0; i < customers.Count; i++)
            {
                var customer = customers[i];
                var model = customerMapper.Map(customer);

                model.No = i + 1;
                customerModels.Add(model);
            }
            CustomersViewModel viewModel = new CustomersViewModel()
            {
                Customers = customerModels
            };
            return View(viewModel);
        }

        public IActionResult Save(int Id)
        {
            SaveCustomersViewModel viewModel = new SaveCustomersViewModel();
            var customers = db.CustomersRepository.Get();
            viewModel.CustomerList = new SelectList(customers, "Id", "Name");

            if(Id != 0)
            {
                var customerMapper = new CustomersMapper();
                var customer = db.CustomersRepository.Get(Id);
                var customerModel = customerMapper.Map(customer);

                viewModel.Customer = customerModel;
            }

            return PartialView(viewModel);
        }

        public IActionResult Submit(SaveCustomersViewModel viewModel)
        {
            try
            {
                var model = viewModel.Customer;
                var customerMapper = new CustomersMapper();
                var customers = customerMapper.Map(model);

                if (model.Id == 0)
                {
                    customers.IsCreated = DateTime.Now;
                }

                customers.IsModified = DateTime.Now;
                customers.IsDeleted = false;

                if (model.Id != 0)
                {
                    db.CustomersRepository.Update(customers);
                }
                else
                {
                    db.CustomersRepository.Insert(customers);
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
