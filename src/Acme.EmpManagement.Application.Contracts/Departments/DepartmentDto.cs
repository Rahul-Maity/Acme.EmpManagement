using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.EmpManagement.Departments
{
    public class DepartmentDto:AuditedEntityDto<Guid>
    {
        public string name { get; set; }
    }
}
