using Microsoft.AspNetCore.Mvc.Rendering;

namespace PaymentOrder.WebAdminPanel.Models.Products
{
    public class SaveProductsViewModel
    {
        public SelectList ProductsList { get; set; }
        public ProductsModel Products { get; set; }
    }
}
