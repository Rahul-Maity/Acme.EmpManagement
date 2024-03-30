using Volo.Abp.Modularity;

namespace Acme.EmpManagement;

/* Inherit from this class for your domain layer tests. */
public abstract class EmpManagementDomainTestBase<TStartupModule> : EmpManagementTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
