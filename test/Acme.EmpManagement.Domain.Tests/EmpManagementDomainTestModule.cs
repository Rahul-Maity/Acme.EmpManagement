using Volo.Abp.Modularity;

namespace Acme.EmpManagement;

[DependsOn(
    typeof(EmpManagementDomainModule),
    typeof(EmpManagementTestBaseModule)
)]
public class EmpManagementDomainTestModule : AbpModule
{

}
