using Microsoft.AspNetCore.Mvc.Rendering;

namespace PaymentOrder.WebAdminPanel.Models.Employees
{
    public class SaveEmployeesViewModel
    {
        public SelectList EmployeeList { get; set; }
        public EmployeesModel Employee { get; set; }
    }
}
