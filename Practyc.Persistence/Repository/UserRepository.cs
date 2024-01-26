using Practyc.Application.Abstraction.IRepository;
using Practyc.Domain.Entities;
using Practyc.Persistence.Data;

namespace Practyc.Persistence.Repository
{
    public class UserRepository :BaseRepository<User> ,IUserRepository
    {
     //   private readonly PractycDbContext context;

        public UserRepository(PractycDbContext context):base(context)
        {

        }
       /* public async Task<IEnumerable<UserResponse>> GetAlUsers()
        {
            return await QueryAsync<UserResponse>("Select * from Users ");
        }*/
    }

}