using Practyc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practyc.Application.Abstraction.IJWT
{
    public interface IJwtProvider
    { 
        public string GenerateToken(User user);
        
    }
}
