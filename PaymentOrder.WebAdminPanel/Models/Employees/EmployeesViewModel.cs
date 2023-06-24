using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace PaymentOrder.WebAdminPanel.Models.Employees
{
    public class EmployeesViewModel
    {
        public List<EmployeesModel> Employees { get; set; }
        public EmployeesModel Deleted { get; set; }

    }
}
