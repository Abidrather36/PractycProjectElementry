using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practyc.Application.IIdentity
{
    public interface IContextService
    {
        public Guid UserId();

        public string UserName();

        public string Email();
    }
}
