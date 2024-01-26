using Practyc.Domain.Enums;

namespace Practyc.Application.RRModel
{
    public  class StudentRequest
    {
        public string Name { get; set; } = null!;


        /*public UserRole UserRole { get; set; }*/

        public string Email { get; set; } = null!;

        public int Rollno { get; set; }


        public int RegNo { get; set; }


        public int ContactNo { get; set; }

        public Guid DepartmentId { get; set; }
    }
    public  class StudentResponse:StudentRequest
    {
        public Guid  Id { get; set; }
 
    }
    public class StudentUpdateRequest
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }= null!;   

    }
}
