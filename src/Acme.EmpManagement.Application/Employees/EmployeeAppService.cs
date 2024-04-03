using Acme.EmpManagement.Departments;
using Acme.EmpManagement.Permissions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Acme.EmpManagement.Employees;


[Authorize]
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
    private readonly IRepository<Department, Guid> _departmentRepository;
    private readonly ICurrentUser _currentUser;
    public EmployeeAppService(

        IRepository<Employee,Guid>repository,
           ICurrentUser currentUser,
            IRepository<Department, Guid> departmentRepository
        ) :base(repository) {

        _departmentRepository = departmentRepository;

        _currentUser = currentUser;

    }

    public async Task<List<EmployeeDto>> GetEmployeesByDepartmentNameAsync(string departmentName)
    {
        if (!_currentUser.IsInRole("HR"))
        {
           
            throw new AbpAuthorizationException("You are not authorized to get employees by department name.");
        }

        var department = await _departmentRepository.FirstOrDefaultAsync(d => d.name == departmentName);
        if (department == null)
        {
            throw new EntityNotFoundException(typeof(Department), departmentName);
        }
        IQueryable<Employee> employeelist = await Repository.GetQueryableAsync();

        var employees=employeelist.Where(e => e.DepartmentId == department.Id)
                ;
        var list = employees.ToList();
        return list.Select(item => new EmployeeDto
        {
            Id = item.Id,
            FullName = item.FullName,
            DepartmentId = item.DepartmentId,
             Position=item.Position,
             Age = item.age
        }).ToList();


    }

        public async Task<EmployeeDto> GetEmployeeByNameAsync(string name)
    {
        if (!_currentUser.IsInRole("HR"))
        {
           
            throw new AbpAuthorizationException("You are not authorized to get employees by name.");
        }
        var employee = await Repository.FirstOrDefaultAsync(e => e.FullName == name);
        if (employee == null)
        {
            throw new EntityNotFoundException(typeof(Employee), name);
        }
        return ObjectMapper.Map<Employee, EmployeeDto>(employee);

    }

        
    public override async Task<PagedResultDto<EmployeeDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {

        if (_currentUser.IsInRole("HR"))
        {
            return await base.GetListAsync(input);

        }



        throw new AbpAuthorizationException("You are not authorized to get employees.");


    }

    public override async Task<EmployeeDto> CreateAsync(CreateUpdateEmployeeDto input)
    {
        if (!_currentUser.IsInRole("HR"))
        {
           
            throw new AbpAuthorizationException("You are not authorized to create departments.");
        }

        
        return await base.CreateAsync(input);
    }

    public override async Task<EmployeeDto> UpdateAsync(Guid id, CreateUpdateEmployeeDto input)
    {
       
        if (!_currentUser.IsInRole("HR"))
        {
            
            throw new AbpAuthorizationException("You are not authorized to update employees.");
        }

       
        return await base.UpdateAsync(id, input);
    }

    public override async Task DeleteAsync(Guid id)
    {
       
        if (!_currentUser.IsInRole("HR"))
        {
           
            throw new AbpAuthorizationException("You are not authorized to delete employees.");
        }


        await base.DeleteAsync(id);
    }


}

