using PaymentOrder.Core.Domain.Abstract.Products;
using PaymentOrder.Core.Domain.Entities.Discount;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrder.Core.Domain.Abstract.Discount
{
    public interface IDiscountRepository : ICrudRepository<DiscountEntity>
    {
        DiscountEntity Get(int id);
    }
}
