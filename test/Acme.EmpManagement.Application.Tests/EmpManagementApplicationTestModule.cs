using Volo.Abp.Modularity;

namespace Acme.EmpManagement;

[DependsOn(
    typeof(EmpManagementApplicationModule),
    typeof(EmpManagementDomainTestModule)
)]
public class EmpManagementApplicationTestModule : AbpModule
{

}
