﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Acme.EmpManagement.Employees;

    public class EmployeeAppService:
        CrudAppService<
            Employee,
            EmployeeDto,
            Guid,
            PagedAndSortedResultRequestDto,
            CreateUpdateEmployeeDto
            >,
        IEmployeeAppService
    {
    public EmployeeAppService(IRepository<Employee,Guid>repository):base(repository) { }
    
}
