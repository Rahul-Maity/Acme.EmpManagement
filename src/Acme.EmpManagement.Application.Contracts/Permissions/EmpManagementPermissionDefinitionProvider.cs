using Acme.EmpManagement.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;
using Volo.Abp.MultiTenancy;

namespace Acme.EmpManagement.Permissions;

public class EmpManagementPermissionDefinitionProvider : PermissionDefinitionProvider
{   
    public override void Define(IPermissionDefinitionContext context)
    {
        var EmpManagementGroup = context.AddGroup(EmpManagementPermissions.GroupName, L("Permission:EmpManagement"));
        //Define your own permissions here. Example:
        //myGroup.AddPermission(EmpManagementPermissions.MyPermission1, L("Permission:MyPermission1"));

        EmpManagementGroup.AddPermission(EmpManagementPermissions.Dashboard.Host, L("Permission:Dashboard"), MultiTenancySides.Host);
        EmpManagementGroup.AddPermission(EmpManagementPermissions.Dashboard.Tenant, L("Permission:Dashboard"), MultiTenancySides.Tenant);

        var EmployeesPermission = EmpManagementGroup.AddPermission(EmpManagementPermissions.Employees.Default, L("Permission:Employees"));

        EmployeesPermission.AddChild(EmpManagementPermissions.Employees.Create, L("Permission:Employees.Create"));
        EmployeesPermission.AddChild(EmpManagementPermissions.Employees.Edit, L("Permission:Employees.Edit"));
        EmployeesPermission.AddChild(EmpManagementPermissions.Employees.Delete, L("Permission:Employees.Delete"));



    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<EmpManagementResource>(name);
    }
}
