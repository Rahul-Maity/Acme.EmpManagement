using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Acme.EmpManagement.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.EmpManagement.EntityFrameworkCore;

public class EntityFrameworkCoreEmpManagementDbSchemaMigrator
    : IEmpManagementDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreEmpManagementDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the EmpManagementDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<EmpManagementDbContext>()
            .Database
            .MigrateAsync();
    }
}
