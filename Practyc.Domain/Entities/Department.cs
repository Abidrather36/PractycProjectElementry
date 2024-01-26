namespace Practyc.Domain.Entities
{
    public class Department:BaseModel

    { 
        public string DepartmentName { get; set; } = null!;


        public ICollection<Student> Students { get; set; } = null!;


        public ICollection<Employee> Employees { get; set; } = null!;
    }
}
