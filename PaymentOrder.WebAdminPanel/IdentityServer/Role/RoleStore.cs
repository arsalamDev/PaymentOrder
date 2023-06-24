using Microsoft.AspNetCore.Identity;
using PaymentOrder.Core.Domain.Entities;
using PaymentOrder.Core.Domain.Entities.Auth;
using PaymentOrder.Core.Domain.Entities.Role;
using System.Threading;
using System.Threading.Tasks;

namespace PaymentOrder.WebAdminPanel.IdentityServer.Role
{
    public class RoleStore : IRoleStore<RoleEntity>
    {
        public Task<IdentityResult> CreateAsync(RoleEntity role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> DeleteAsync(RoleEntity role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public void Dispose()
        {
            
        }

        public Task<RoleEntity> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<RoleEntity> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetNormalizedRoleNameAsync(RoleEntity role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetRoleIdAsync(RoleEntity role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<string> GetRoleNameAsync(RoleEntity role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetNormalizedRoleNameAsync(RoleEntity role, string normalizedName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task SetRoleNameAsync(RoleEntity role, string roleName, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }

        public Task<IdentityResult> UpdateAsync(RoleEntity role, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
