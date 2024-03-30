using Acme.EmpManagement.Departments;
using Acme.EmpManagement.Employees;
using AutoMapper;

namespace Acme.EmpManagement;

public class EmpManagementApplicationAutoMapperProfile : Profile
{
    public EmpManagementApplicationAutoMapperProfile()
    {
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */

        CreateMap<Department, DepartmentDto>();
        CreateMap<CreateUpdateDepartmentDto, Department>();

        CreateMap<Employee,EmployeeDto>();
        CreateMap<CreateUpdateEmployeeDto, Employee>();
    }
}
