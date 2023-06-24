using System;

namespace PaymentOrder.WebAdminPanel.Models.Customers
{
    public class CustomersModel : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public int Telephone { get; set; }
        public DateTime IsModified { get; set; }
        public DateTime IsCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
