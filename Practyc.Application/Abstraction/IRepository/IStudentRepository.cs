using Practyc.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practyc.Application.Abstraction.IRepository
{
    public  interface IStudentRepository
    {
        Task<int> Insert(Student model);


        Task<int> Update(Student model);


        Task<int> Delete(Guid id);


        Task<IEnumerable<Student>> GetAll();


        Task<Student> GetById(Guid id);


        Task<IEnumerable<Student>> FindBy(Expression<Func<Student, bool>> expression);

    }
}
