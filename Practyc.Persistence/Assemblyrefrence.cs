using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Practyc.Application.Abstraction.IRepository;
using Practyc.Persistence.Data;
using Practyc.Persistence.Repository;

namespace Practyc.Persistence
{
    public static  class Assemblyrefrence
    {
        public static IServiceCollection AddPersistenceService(this IServiceCollection service ,IConfiguration configuration)
        {
            service.AddScoped<IUserRepository, UserRepository>();
            service.AddScoped<IStudentRepository, StudentRepository>();
            service.AddScoped<IEmployeeRepository, EmployeeRepository>();
            service.AddScoped<IDepartmentRepository, DepartmentRepository>();

            service.AddDbContextPool<PractycDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(PractycDbContext))));
            return service;

        }

    }
}
