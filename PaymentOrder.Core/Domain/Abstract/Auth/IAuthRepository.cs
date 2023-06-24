using PaymentOrder.Core.Domain.Entities.Auth;
using PaymentOrder.Core.Domain.Entities.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrder.Core.Domain.Abstract.Auth
{
    public interface IAuthRepository : ICrudRepository<AuthEntity>
    {
        AuthEntity GetEmail(string email);
        AuthEntity Get(int id);
    }
}
