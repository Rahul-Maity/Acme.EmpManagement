using System.Threading.Tasks;

namespace Acme.EmpManagement.Data;

public interface IEmpManagementDbSchemaMigrator
{
    Task MigrateAsync();
}
