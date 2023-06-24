using PaymentOrder.Core.Domain.Abstract.Auth;
using PaymentOrder.Core.Domain.Abstract.Customers;
using PaymentOrder.Core.Domain.Abstract.Discount;
using PaymentOrder.Core.Domain.Abstract.Employees;
using PaymentOrder.Core.Domain.Abstract.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrder.Core.Domain.Abstract
{
    public interface IUnitOfWork
    {
        public IAuthRepository AuthRepository { get; }
        public IEmployeesRepository EmployeesRepository { get; }
        public ICustomersRepository CustomersRepository { get; }
        public IProductRepository ProductRepository { get; }
        public IDiscountRepository DiscountRepository { get; }
    }
}
