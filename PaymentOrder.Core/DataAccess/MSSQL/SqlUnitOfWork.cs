using PaymentOrder.Core.DataAccess.MSSQL.Auth;
using PaymentOrder.Core.DataAccess.MSSQL.Customers;
using PaymentOrder.Core.DataAccess.MSSQL.Discount;
using PaymentOrder.Core.DataAccess.MSSQL.Employees;
using PaymentOrder.Core.DataAccess.MSSQL.Products;
using PaymentOrder.Core.Domain.Abstract;
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

namespace PaymentOrder.Core.DataAccess.MSSQL
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly string connectionString;

        public SqlUnitOfWork(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IAuthRepository AuthRepository => new AuthRepository(connectionString);
        public IEmployeesRepository EmployeesRepository => new EmployeesRepository(connectionString);
        public ICustomersRepository CustomersRepository => new CustomersRepository(connectionString);
        public IProductRepository ProductRepository => new ProductsRepository(connectionString);
        public IDiscountRepository DiscountRepository => new DiscountRepository(connectionString);
    }
}
