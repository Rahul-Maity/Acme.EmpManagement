using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Guids;
using Volo.Abp.MultiTenancy;
using Volo.Abp.PermissionManagement;

namespace Acme.EmpManagement
{
    internal class CustomPermissionManagementProvider:PermissionManagementProvider
    {
        public override string Name => "Custom";
        public CustomPermissionManagementProvider(IPermissionGrantRepository permissionGrantRepository,
        IGuidGenerator guidGenerator,
        ICurrentTenant currentTenant) : base(
            permissionGrantRepository,
            guidGenerator,
            currentTenant)
        {

            
        }
    }
}
