using Practyc.Application.Abstraction.IRepository;
using Practyc.Persistence.Data;

namespace Practyc.Persistence.Repository
{
    public  class DepartmentRepository:BaseRepository<Domain.Entities.Department>,IDepartmentRepository
    {
        public DepartmentRepository(PractycDbContext context):base(context)
        {
                
        }
    }
}
