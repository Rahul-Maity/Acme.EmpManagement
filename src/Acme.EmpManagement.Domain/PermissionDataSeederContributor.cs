using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace Acme.EmpManagement
{
    internal class PermissionDataSeederContributor : IDataSeedContributor, ITransientDependency
    {
        
        public Task SeedAsync(DataSeedContext context)
        {
           
        }
    }
}
