using PaymentOrder.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrder.Core.Domain.Abstract.Products
{
    public class ProductsEntity : BaseEntity
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
