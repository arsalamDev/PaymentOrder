using PaymentOrder.WebAdminPanel.Models.Discount;
using System.Collections.Generic;

namespace PaymentOrder.WebAdminPanel.Models.Products
{
    public class ProductsViewModel
    {
        public List<ProductsModel> Products { get; set; }
        public DiscountModel Discount { get; set; }
    }
}
