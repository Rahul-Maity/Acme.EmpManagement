using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace Acme.EmpManagement;

[Dependency(ReplaceServices = true)]
public class EmpManagementBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "EmpManagement";
}
