using Practyc.Application.Abstraction.IRepository;
using Practyc.Domain.Entities;
using Practyc.Persistence.Data;

namespace Practyc.Persistence.Repository
{
    public class EmployeeRepository:BaseRepository<Employee>,IEmployeeRepository
    {
        public EmployeeRepository(PractycDbContext context ):base(context)
        {
            
        }
    }
}
