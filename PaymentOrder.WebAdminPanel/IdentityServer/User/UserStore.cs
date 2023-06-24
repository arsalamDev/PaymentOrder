using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PaymentOrder.Core.Domain.Abstract;
using PaymentOrder.Core.Domain.Entities.Auth;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentOrder.WebAdminPanel.IdentityServer.User
{
    public class UserStore : IUserStore<AuthEntity> , IUserPasswordStore<AuthEntity>, IUserRoleStore<AuthEntity>
    {
        public readonly IUnitOfWork db;
        public UserStore(IUnitOfWork db)
        {
            this.db = db;
        }

        #region Email
        public Task<IdentityResult> CreateAsync(AuthEntity user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(AuthEntity user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public Task<AuthEntity> FindByIdAsync(string userId, CancellationToken cancellationToken)
        {
            int id = Convert.ToInt32(userId);

            AuthEntity user = db.AuthRepository.Get(id);

            return Task.FromResult(user); ;
        }

        public Task<AuthEntity> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
        {
            var user = db.AuthRepository.GetEmail(normalizedUserName);
            
            return Task.FromResult(user);
        }

        public Task<string> GetNormalizedUserNameAsync(AuthEntity user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetUserIdAsync(AuthEntity user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Id.ToString());
        }

        public Task<string> GetUserNameAsync(AuthEntity user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.Email);
        }

        public Task SetNormalizedUserNameAsync(AuthEntity user, string normalizedName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetUserNameAsync(AuthEntity user, string userName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(AuthEntity user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Password
        public Task<string> GetPasswordHashAsync(AuthEntity user, CancellationToken cancellationToken)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(AuthEntity user, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetPasswordHashAsync(AuthEntity user, string passwordHash, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region IUserRoleStore implementation

        public Task AddToRoleAsync(AuthEntity user, string roleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IList<string>> GetRolesAsync(AuthEntity user, CancellationToken cancellationToken)
        {
            IList<string> roles = new List<string>
            {
                "A", "B"
            };

            return Task.FromResult(roles);
        }

        public Task<IList<AuthEntity>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsInRoleAsync(AuthEntity user, string roleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveFromRoleAsync(AuthEntity user, string roleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
