using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Acme.EmpManagement.Departments
{
    public interface IDepartmentAppService:
        ICrudAppService<
            DepartmentDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDepartmentDto
            >
    {
        
    }
}
