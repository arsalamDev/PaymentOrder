using Microsoft.AspNetCore.Mvc.Rendering;

namespace PaymentOrder.WebAdminPanel.Models.Discount
{
    public class SaveDiscountViewModel
    {
        public SelectList DiscountList { get; set; }
        public DiscountModel Discount { get; set; }
    }
}
