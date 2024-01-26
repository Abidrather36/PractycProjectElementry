using Practyc.Application.Abstraction.IRepository;
using Practyc.Application.Abstraction.IService;
using Practyc.Application.ApiResponse;
using Practyc.Application.RRModel;
using Practyc.Application.Utils;
using Practyc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practyc.Application.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUserRepository urepository;
        private readonly IEmployeeRepository erepository;

        public EmployeeService(IUserRepository Urepository,IEmployeeRepository Erepository)
        {
            urepository = Urepository;
            erepository = Erepository;
        }
        public Task<ApiResponse<EmployeeResponse>> Add(EmployeeRequest model)
        {
            User user = new()
            {
                Id = Guid.NewGuid(),
                Salt = AppEncryption.CreateSalt(),
                Username="JohnK",
                Password=model.Password,
                Email=model.Email,
                
            };
            user.Employee = new Employee
            {
                Id=user.Id,
                Name="John F Keneedy",
                Salary="127237",
                IsActive=true,
                EmpCode=123,
                DepartmentId=Guid.Empty
            };
            return default;
        }
    }
}
