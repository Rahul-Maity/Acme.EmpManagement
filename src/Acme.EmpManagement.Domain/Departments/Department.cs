using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.EmpManagement.Departments
{
    public class Department:AuditedAggregateRoot<Guid>
    {
        public string name { get; set; }=string.Empty;
    }
}
