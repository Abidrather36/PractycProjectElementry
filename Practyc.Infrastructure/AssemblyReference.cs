using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Practyc.Application.Abstraction.IJWT;
using Practyc.Application.IIdentity;
using Practyc.Infrastructure.IdentityService;
using Practyc.Infrastructure.JWT;

namespace Practyc.Infrastructure
{
    public static class AssemblyReference
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddSingleton<IJwtProvider>(new JwtProvider(configuration));
            services.AddSingleton<IContextService,ContextService>();

            return services; 

        }
    }
}
