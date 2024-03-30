using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.EmpManagement.Departments
{
    public class CreateUpdateDepartmentDto
    {
        [Required]
        [StringLength(128)]
        public string name { get; set; } 
    }
}
