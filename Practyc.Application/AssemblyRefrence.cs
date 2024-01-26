using Microsoft.Extensions.DependencyInjection;
using Practyc.Application.Abstraction.IService;
using Practyc.Application.IIdentity;
using Practyc.Application.Services;

namespace Practyc.Application
{
    public static class AssemblyRefrence
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection service)
        {
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IStudentService, StudentService>();
            service.AddScoped<IDepartmentService, DepartmentService>();
            service.AddScoped<IEmployeeService, EmployeeService>();

            return service;

        }
    }
}
