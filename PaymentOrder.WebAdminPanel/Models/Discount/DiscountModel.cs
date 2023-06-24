using System;

namespace PaymentOrder.WebAdminPanel.Models.Discount
{
    public class DiscountModel : BaseModel
    {
        public int Discount { get; set; }
        public DateTime DiscountStartDate { get; set; }
        public DateTime DiscountEndDate { get; set; }
        public DateTime IsModified { get; set; }
        public DateTime IsCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
