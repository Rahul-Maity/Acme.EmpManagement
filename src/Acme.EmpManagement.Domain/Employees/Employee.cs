using Acme.EmpManagement.Departments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace Acme.EmpManagement.Employees
{
    public class Employee:AuditedAggregateRoot<Guid>
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public int age { get; set; }

        [ForeignKey("Department")]
        public Guid DepartmentId { get; set; }

        public Department Department { get; set; }

    }
}
