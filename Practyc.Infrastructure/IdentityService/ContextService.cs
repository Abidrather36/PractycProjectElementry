using Microsoft.AspNetCore.Http;
using Practyc.Application.IIdentity;
using Practyc.Infrastructure.JWT;

namespace Practyc.Infrastructure.IdentityService
{
    public class ContextService : IContextService
    {
        private readonly IHttpContextAccessor contextAccessor;

        public ContextService(IHttpContextAccessor contextAccessor)
        {
          this.contextAccessor = contextAccessor;   
        }
        public string Email()
        {
            var Email = contextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == AppClaimsType.Email)?.Value;

            if (Email == null) return string.Empty;
            return Email;  
            
        }

       

        public string UserName()
        {
           var UserName= contextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == AppClaimsType.UserName)?.Value;
            if(UserName == null) return string.Empty;
            else return UserName;
        }

        public Guid UserId()
        {
            var UserId = contextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == AppClaimsType.UserId)?.Value;
            if (UserId == null) return Guid.Empty;
            else
            {
                Guid Id = Guid.Parse(UserId);
                return Id;
            }
        }
    }
}
