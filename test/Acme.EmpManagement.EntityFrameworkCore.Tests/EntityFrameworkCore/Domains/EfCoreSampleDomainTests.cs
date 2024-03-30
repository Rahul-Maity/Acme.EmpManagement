using Acme.EmpManagement.Samples;
using Xunit;

namespace Acme.EmpManagement.EntityFrameworkCore.Domains;

[Collection(EmpManagementTestConsts.CollectionDefinitionName)]
public class EfCoreSampleDomainTests : SampleDomainTests<EmpManagementEntityFrameworkCoreTestModule>
{

}
