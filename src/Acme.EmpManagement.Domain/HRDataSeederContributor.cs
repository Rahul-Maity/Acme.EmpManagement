using Acme.EmpManagement.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Identity;
using Volo.Abp.PermissionManagement;

namespace Acme.EmpManagement
{
    internal class HRDataSeederContributor: IDataSeedContributor, ITransientDependency
    {
        private readonly IdentityUserManager _identityUserManager;
     
      
        private readonly IdentityRoleManager _identityRoleManager;
        public HRDataSeederContributor(
       
          IdentityUserManager identityUserManager,
          IdentityRoleManager identityRoleManager
         )
        {
          
            _identityUserManager = identityUserManager;
            _identityRoleManager = identityRoleManager;
            
        }

        public async Task SeedAsync(DataSeedContext context)
        {
            var hrRole = await _identityRoleManager.FindByNameAsync("HR");
            if (hrRole == null)
            {
                var identityResult = await _identityRoleManager.CreateAsync(new IdentityRole(Guid.NewGuid(), "HR"));
                if (!identityResult.Succeeded)
                {
                    // Handle role creation failure
                    throw new Exception("Failed to create HR role.");
                }
            }


            IdentityUser identityUser3 = new IdentityUser(Guid.NewGuid(), "HR", "hremail@email.com");
            await _identityUserManager.CreateAsync(identityUser3, "1q2w3E*");
            await _identityUserManager.AddToRoleAsync(identityUser3, "HR");

           
        }
    }
}
