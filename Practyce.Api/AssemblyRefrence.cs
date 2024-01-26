 using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Practyc.Application.Abstraction.IService;
using Practyc.Application.Services;
using System.Text;

namespace Practyce.Api
{
    public  static class AssemblyRefrence
    {
        public static IServiceCollection AddApiService(this IServiceCollection service,IConfiguration configuration)
        {
            service.AddScoped<IUserService,UserService>();
            service.AddHttpContextAccessor();

            service.AddScoped<IStudentService, StudentService>();

            service.AddScoped<IEmployeeService, EmployeeService>();

            service.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = configuration["Jwt:Audience"],
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]))
                };
            });
            return service;

        }
    }
}
