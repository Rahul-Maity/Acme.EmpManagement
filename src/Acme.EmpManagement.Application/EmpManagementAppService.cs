using System;
using System.Collections.Generic;
using System.Text;
using Acme.EmpManagement.Localization;
using Volo.Abp.Application.Services;

namespace Acme.EmpManagement;

/* Inherit your application services from this class.
 */
public abstract class EmpManagementAppService : ApplicationService
{
    protected EmpManagementAppService()
    {
        LocalizationResource = typeof(EmpManagementResource);
    }
}
