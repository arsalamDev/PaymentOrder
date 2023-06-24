using PaymentOrder.Core.Domain.Entities.Customers;
using PaymentOrder.Core.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrder.Core.Domain.Abstract.Customers
{
    public interface ICustomersRepository : ICrudRepository<CustomersEntity>
    {
        CustomersEntity Get(int id);

    }
}
