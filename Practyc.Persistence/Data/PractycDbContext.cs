using Microsoft.EntityFrameworkCore;
using Practyc.Domain.Entities;

namespace Practyc.Persistence.Data
{
    public class PractycDbContext:DbContext
    {
        public PractycDbContext(DbContextOptions<PractycDbContext> options) :base(options)
        {
                
        }
        public DbSet <User> Users { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Employee> Employees { get; set; }
    }
}
