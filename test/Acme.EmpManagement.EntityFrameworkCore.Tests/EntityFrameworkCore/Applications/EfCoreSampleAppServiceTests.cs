using Acme.EmpManagement.Samples;
using Xunit;

namespace Acme.EmpManagement.EntityFrameworkCore.Applications;

[Collection(EmpManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleAppServiceTests : SampleAppServiceTests<EmpManagementEntityFrameworkCoreTestModule>
{

}
