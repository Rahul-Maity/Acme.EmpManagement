using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Authorization;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace Acme.EmpManagement
{
    public class IdentityAppService:IdentityUserAppService
    {
        private readonly ICurrentUser _currentUser;
        public IdentityAppService(IdentityUserManager userManager,
            IIdentityUserRepository userRepository,
            IIdentityRoleRepository roleRepository,
              IOptions<IdentityOptions> options,
            ICurrentUser currentUser):base(userManager, userRepository, roleRepository,options)
        {
            _currentUser = currentUser;
        }
        public override async Task<IdentityUserDto> CreateAsync(IdentityUserCreateDto input)
        {
            var isAdmin = _currentUser.IsInRole("admin");
            var userRole = input.RoleNames.Any(x => x != "HR");
            if (isAdmin == true && userRole == false)
            {

                return await base.CreateAsync(input);
            }
            else
            {
                throw new AbpAuthorizationException();
            }

        }
    }
}
