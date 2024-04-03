using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Authorization;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Users;

namespace Acme.EmpManagement.Departments;

[Authorize]
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



    private readonly ICurrentUser _currentUser;
    public DepartmentAppService(IRepository<Department,Guid>repository,
          ICurrentUser currentUser

        ) :base(repository) {
        _currentUser = currentUser;
    }

  
    public override async Task<PagedResultDto<DepartmentDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {

        if (_currentUser.IsInRole("HR"))
        {
            return await base.GetListAsync(input);

        }



        throw new AbpAuthorizationException("You are not authorized to get employees.");


    }


    public override async Task<DepartmentDto> CreateAsync(CreateUpdateDepartmentDto input)
    {
        if (!_currentUser.IsInRole("HR"))
        {

            throw new AbpAuthorizationException("You are not authorized to create departments.");
        }


        return await base.CreateAsync(input);
    }

    public override async Task<DepartmentDto> UpdateAsync(Guid id, CreateUpdateDepartmentDto input)
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

