using Practyc.Domain.Enums;

namespace Practyc.Domain.Entities
{
    public class User:BaseModel
    {
        public string Username { get; set; } = null!;


        public string Email { get; set; } = null!;


        public string Password { get; set; } = null!;


        public UserRole UserRole { get; set; }

        public string? Salt { get; set; }

        public string? Address { get; set; }


        public Student Student { get; set; }


        public Employee Employee { get; set; }
    }
}
