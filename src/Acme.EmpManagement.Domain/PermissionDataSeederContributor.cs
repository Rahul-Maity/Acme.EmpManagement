using Acme.EmpManagement.Permissions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.AutoMapper;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;


namespace Acme.EmpManagement
{
    internal class PermissionDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        private readonly PermissionService _permissionService;
        public PermissionDataSeederContributor(PermissionService permissionService)
        {

            _permissionService = permissionService;

        }
        public async Task SeedAsync(DataSeedContext context)
        {
            await _permissionService.GrantRolePermissionDemoAsync("HR", EmpManagementPermissions.Employees.Default);
            await _permissionService.GrantRolePermissionDemoAsync("HR", EmpManagementPermissions.Employees.Create);
            await _permissionService.GrantRolePermissionDemoAsync("HR", EmpManagementPermissions.Employees.Edit);
            await _permissionService.GrantRolePermissionDemoAsync("HR", EmpManagementPermissions.Employees.Delete);
            await _permissionService.GrantRolePermissionDemoAsync("HR", EmpManagementPermissions.Dashboard.DashboardGroup);
            await _permissionService.GrantRolePermissionDemoAsync("HR", EmpManagementPermissions.Dashboard.Tenant);
            await _permissionService.GrantRolePermissionDemoAsync("HR", EmpManagementPermissions.Dashboard.Host);


            Guid userId = new Guid("11c085fb-1170-42ef-83ec-f3d85c690a5a");
            await _permissionService.GrantUserPermissionDemoAsync(userId, "HR", EmpManagementPermissions.Employees.Default);
            await _permissionService.GrantUserPermissionDemoAsync(userId, "HR", EmpManagementPermissions.Employees.Create);
            await _permissionService.GrantUserPermissionDemoAsync(userId, "HR", EmpManagementPermissions.Employees.Edit);
            await _permissionService.GrantUserPermissionDemoAsync(userId, "HR", EmpManagementPermissions.Employees.Delete);
            await _permissionService.GrantUserPermissionDemoAsync(userId, "HR", EmpManagementPermissions.Dashboard.DashboardGroup);
            await _permissionService.GrantUserPermissionDemoAsync(userId, "HR", EmpManagementPermissions.Dashboard.Tenant);
            await _permissionService.GrantUserPermissionDemoAsync(userId, "HR", EmpManagementPermissions.Dashboard.Host);

        }
    }

    internal class PermissionService
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
