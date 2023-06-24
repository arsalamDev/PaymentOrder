using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using PaymentOrder.Core.Domain.Abstract;
using PaymentOrder.WebAdminPanel.Mapper.Employees;
using PaymentOrder.WebAdminPanel.Models;
using PaymentOrder.WebAdminPanel.Models.Employees;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace PaymentOrder.WebAdminPanel.Controllers.Employees
{
    [Authorize(Roles = "A, B")]
    public class EmployeesController : Controller
    {
        private readonly IUnitOfWork db;
        public EmployeesController(IUnitOfWork db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var employees = db.EmployeesRepository.Get();
            EmployeeMapper employeeMapper = new EmployeeMapper();
            List<EmployeesModel> employeesModels = new List<EmployeesModel>();

            for (int i = 0; i < employees.Count; i++)
            {
                var employee = employees[i];
                var model = employeeMapper.Map(employee);

                model.No = i + 1;
                employeesModels.Add(model);
            }
            EmployeesViewModel viewModel = new EmployeesViewModel()
            {
                Employees = employeesModels
            };
            return View(viewModel);
        }

        public IActionResult Save(int id)
        {
            SaveEmployeesViewModel viewModel = new SaveEmployeesViewModel();

            var employees = db.EmployeesRepository.Get();

            viewModel.EmployeeList = new SelectList(employees, "Id", "Name");

            if (id != 0)
            {
                var employeeMapper = new EmployeeMapper();
                var employee = db.EmployeesRepository.Get(id);
                var employeeModel = employeeMapper.Map(employee);

                viewModel.Employee = employeeModel;
            }

            return PartialView(viewModel);
        }


        public IActionResult Submit(SaveEmployeesViewModel viewModel)
        {
            try
            {
                var model = viewModel.Employee;
                var employeeMapper = new EmployeeMapper();
                var employees = employeeMapper.Map(model);

                if(model.Id == 0)
                {
                    employees.IsCreated = DateTime.Now;
                }

                employees.IsModified = DateTime.Now;
                employees.IsDeleted = false;

                if (model.Id != 0)
                {
                    db.EmployeesRepository.Update(employees);
                }
                else
                {
                    db.EmployeesRepository.Insert(employees);
                }

                TempData["Message"] = "Operation successfully";
            }
            catch
            {
                TempData["Message"] = "Operation unsuccessfully";
            }

            return RedirectToAction("Index");
        }

        public IActionResult Delete(EmployeesViewModel viewModel)
        {
            var deletedId = viewModel.Deleted.Id;

            var card = db.EmployeesRepository.Get(deletedId);

            card.IsDeleted = true;

            db.EmployeesRepository.Update(card);

            TempData["Message"] = "Operation successfully";

            return RedirectToAction("Index");
        }
    }
}
