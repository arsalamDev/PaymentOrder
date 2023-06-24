using System.Collections.Generic;

namespace PaymentOrder.WebAdminPanel.Models.Employees
{
    public class EmployeesViewModel
    {
        public List<EmployeesModel> Employees { get; set; }
        public EmployeesModel Deleted { get; set; }

    }
}
