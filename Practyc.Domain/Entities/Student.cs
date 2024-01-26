using Practyc.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Practyc.Domain.Entities
{
    public  class Student:BaseModel
    {
       
        public string Name { get; set; } = null!;


        public int RollNo { get; set; }


        public bool IsActive { get; set; }

        public Guid DepartmentId { get; set; }


        [ForeignKey(nameof(DepartmentId))]

        public Department Department { get; set; } = null!;


        [ForeignKey(nameof(Id))]

        public User? User { get; set; }
    }
}

     
