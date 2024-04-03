//using Acme.EmpManagement.Departments;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Volo.Abp.Data;
//using Volo.Abp.DependencyInjection;
//using Volo.Abp.Domain.Repositories;

//namespace Acme.EmpManagement
//{
//    public class DepartmentDataSeederContributor : IDataSeedContributor, ITransientDependency
//    {
//        private readonly IRepository<Department, Guid> _departmentRepository;
//        public DepartmentDataSeederContributor(IRepository<Department, Guid> departmentRepository)
//        {
//            _departmentRepository = departmentRepository;

//        }

//        public async Task SeedAsync(DataSeedContext context)
//        {
//            if (await _departmentRepository.GetCountAsync() > 0)
//            {
//                return;
//            }

//            await _departmentRepository.InsertAsync(
//                new Department
//                {
//                    name = "Management",

//                },
//                autoSave: true
//            );


//        }
//    }
//}
