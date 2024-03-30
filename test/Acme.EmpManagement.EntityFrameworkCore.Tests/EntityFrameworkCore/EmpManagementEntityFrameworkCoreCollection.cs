using Xunit;

namespace Acme.EmpManagement.EntityFrameworkCore;

[CollectionDefinition(EmpManagementTestConsts.CollectionDefinitionName)]
public class EmpManagementEntityFrameworkCoreCollection : ICollectionFixture<EmpManagementEntityFrameworkCoreFixture>
{

}
