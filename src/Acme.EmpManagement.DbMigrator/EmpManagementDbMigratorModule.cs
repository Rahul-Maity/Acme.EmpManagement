using Acme.EmpManagement.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Acme.EmpManagement.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(EmpManagementEntityFrameworkCoreModule),
    typeof(EmpManagementApplicationContractsModule)
    )]
public class EmpManagementDbMigratorModule : AbpModule
{
}
