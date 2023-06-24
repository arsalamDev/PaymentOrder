using PaymentOrder.Core.DataAccess.MSSQL;
using PaymentOrder.Core.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrder.Core.Factory
{
    public class DbFactory
    {
        public static IUnitOfWork Create(string connectionString)
        {
            return new SqlUnitOfWork(connectionString);
        }
    }
}
