using PaymentOrder.Core.Domain.Entities.Auth;

namespace PaymentOrder.Core.Domain.Entities.Role
{
    public class UserRole : BaseEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }

        public AuthEntity User { get; set; }
        public RoleEntity Role { get; set; }
    }
}
