using System;

namespace PaymentOrder.WebAdminPanel.Models.Products
{
    public class ProductsModel : BaseModel
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int Discount { get; set; }
        public DateTime DiscountStartDate { get; set; }
        public DateTime DiscountEndDate { get; set; }
        public DateTime IsModified { get; set; }
        public DateTime IsCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
