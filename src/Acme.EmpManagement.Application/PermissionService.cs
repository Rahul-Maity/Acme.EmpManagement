using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.PermissionManagement;

namespace Acme.EmpManagement
{
    internal class PermissionService : ITransientDependency
    {
        private readonly IPermissionManager _permissionManager;
        public PermissionService(IPermissionManager permissionManager)
        {
            _permissionManager = permissionManager;
        }
        public async Task GrantRolePermissionDemoAsync(
        string roleName, string permission)
        {
            await _permissionManager
                .SetForRoleAsync(roleName, permission, true);
        }


        public async Task GrantUserPermissionDemoAsync(
       Guid userId, string roleName, string permission)
        {
            await _permissionManager
                .SetForUserAsync(userId, permission, true);
        }

       
    }
}
