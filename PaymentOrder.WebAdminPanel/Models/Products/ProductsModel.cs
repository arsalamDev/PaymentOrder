using PaymentOrder.Core.Domain.Entities.Discount;
using System;

namespace PaymentOrder.WebAdminPanel.Models.Products
{
    public class ProductsModel : BaseModel
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public int IdDiscount { get; set; }
        public DiscountEntity Discount { get; set; }
        public DateTime IsModified { get; set; }
        public DateTime IsCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
