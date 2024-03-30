using Acme.EmpManagement.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace Acme.EmpManagement
{
    public class EmployeeDataSeederContributor : IDataSeedContributor, ITransientDependency
    {

        private readonly IRepository<Employee,Guid> _employeeRepository;

        public EmployeeDataSeederContributor(IRepository<Employee, Guid> employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }


        public async Task SeedAsync(DataSeedContext context)
        {
            if (await _employeeRepository.GetCountAsync() > 0)
            {
                return;
            }

            await _employeeRepository.InsertAsync(
                new Employee
                {
                    FullName = "Rahul Maity",
                    Position = "Developer",
                    age = 20,
                    DepartmentId =new Guid("3a119b23-fb08-471d-5480-e8e1df2256d0")
                    
                },
                autoSave: true
            );

        }
    }
}
