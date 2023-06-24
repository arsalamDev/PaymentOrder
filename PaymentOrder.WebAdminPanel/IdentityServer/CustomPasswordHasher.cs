using Microsoft.AspNetCore.Identity;
using PaymentOrder.Core.Domain.Entities;
using PaymentOrder.Core.Domain.Entities.Auth;
using PaymentOrder.Core.Utils;
using PaymentOrder.Core.Utils.Security;

namespace PaymentOrder.WebAdminPanel.IdentityServer
{
    public class CustomPasswordHasher : IPasswordHasher<AuthEntity>
    {
        public string HashPassword(AuthEntity user, string password)
        {
            throw new System.NotImplementedException();
        }

        public PasswordVerificationResult VerifyHashedPassword(AuthEntity user, string hashedPassword, string providedPassword)
        {
            var providedPasswordHash = SecurityUtil.ComputeSha256Hash(providedPassword);

            if (hashedPassword == providedPasswordHash)
                return PasswordVerificationResult.Success;

            return PasswordVerificationResult.Failed;
        }
    }
}
