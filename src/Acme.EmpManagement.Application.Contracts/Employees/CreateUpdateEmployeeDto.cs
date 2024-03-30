using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.EmpManagement.Employees
{
    public class CreateUpdateEmployeeDto
    {
        [Required]
        [StringLength(128)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [StringLength(128)]
        public string Position { get; set; } = string.Empty;

        [Required]
        public int Age { get; set; }

        [Required]
        public Guid DepartmentId { get; set; }
    }
}
