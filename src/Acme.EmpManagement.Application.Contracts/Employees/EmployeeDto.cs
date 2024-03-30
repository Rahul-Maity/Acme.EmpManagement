using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace Acme.EmpManagement.Employees
{
    public class EmployeeDto:AuditedEntityDto<Guid>
    {
        public string FullName { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public int Age { get; set; }
        public Guid DepartmentId { get; set; }
    }
}
