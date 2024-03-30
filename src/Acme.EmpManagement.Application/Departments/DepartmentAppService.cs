using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.EmpManagement.Departments;

    public class DepartmentAppService:
        CrudAppService<
            Department,
            DepartmentDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateDepartmentDto
            >,
        IDepartmentAppService
    {

        public DepartmentAppService(IRepository<Department,Guid>repository):base(repository) { }
    }

