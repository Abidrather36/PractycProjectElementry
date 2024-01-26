using Practyc.Application.RRModel;
using Practyc.Domain.Entities;
using System.Linq.Expressions;

namespace Practyc.Application.Abstraction.IRepository
{
    public interface IUserRepository:IBaseRepository<User>
    {
        /*Task<IEnumerable<UserResponse>> GetAlUsers();*/


    }
}
