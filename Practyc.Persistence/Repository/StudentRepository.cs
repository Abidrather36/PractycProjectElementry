using Practyc.Application.Abstraction.IRepository;
using Practyc.Domain.Entities;
using Practyc.Persistence.Data;
using System.Linq.Expressions;

namespace Practyc.Persistence.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly PractycDbContext context;

        public StudentRepository(PractycDbContext context)
        {
            this.context = context;
        }
        public async Task<int> Delete(Guid id)
        {
            Student std= new Student() { Id= id };
            await Task.Run(()=> context.Set<Student>().Remove(std));
            return await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> FindBy(Expression<Func<Student, bool>> expression)
        {
            return await Task.Run(() => context.Set<Student>().Where(expression));
        }

        public async Task<IEnumerable<Student>> GetAll()
        {
            return await Task.Run(() => context.Set<Student>());
        }

        public async Task<Student> GetById(Guid id)
        {
          return await context.Set<Student>().FindAsync(id);
        }

        public async Task<int> Insert(Student model)
        {
           await context.Set<Student>().AddAsync(model);
           return await context.SaveChangesAsync();
        }

        public async Task<int> Update(Student model)
        {

          await Task.Run(()=> context.Set<Student>().Update(model));
         return await  context.SaveChangesAsync();
        }
    }
}
