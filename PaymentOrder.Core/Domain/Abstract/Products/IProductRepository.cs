using PaymentOrder.Core.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrder.Core.Domain.Abstract.Products
{
    public interface IProductRepository : ICrudRepository<ProductsEntity>
    {
        ProductsEntity Get(int id);
    }
}
