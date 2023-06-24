using Microsoft.AspNetCore.Mvc.Rendering;
using PaymentOrder.WebAdminPanel.Models.Employees;

namespace PaymentOrder.WebAdminPanel.Models.Customers
{
    public class SaveCustomersViewModel 
    {
        public SelectList CustomerList { get; set; }

        public CustomersModel Customer { get; set; }
    }
}
