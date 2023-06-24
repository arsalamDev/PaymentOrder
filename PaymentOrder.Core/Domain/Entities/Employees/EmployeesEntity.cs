using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentOrder.Core.Domain.Entities.Employees
{
    public class EmployeesEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public DateTime IsModified { get; set; }
        public DateTime IsCreated { get; set; }
        public bool IsDeleted { get; set; }
    }
}
