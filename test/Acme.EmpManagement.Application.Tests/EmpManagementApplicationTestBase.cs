using Volo.Abp.Modularity;

namespace Acme.EmpManagement;

public abstract class EmpManagementApplicationTestBase<TStartupModule> : EmpManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
