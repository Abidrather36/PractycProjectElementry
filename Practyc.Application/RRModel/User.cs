using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practyc.Application.RRModel
{
    public class UserRequest
    {
       /* [MinLength(5)]
        [MaxLength(15)]
        [Required(ErrorMessage = "Username is Must")]*/
        public string UserName { get; set; } = null!;


        [Required(ErrorMessage ="Email is Required")]
        [MinLength(8)]
        [MaxLength(32)]
        public string Email { get; set; } = null!;
        

        [MaxLength(15)]
        [MinLength(8)]
        [Required(ErrorMessage ="Password Is Required")]
        public string Password { get; set; } = null!;

    }

    public class UserResponse
    {
        public Guid Id { get; set; }

        public string? UserName { get; set; }

        public string? Email { get; set; }
    }

    public class UserUpdateRequest
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;
    }

    public class LoginUserRequest
    {
        public string UserName { get; set; } = null!;


        public string Password { get; set; }   =null!;
    }
    public class LoginUserResponse
    {
        public Guid Id { get; set; }


        public string? UserName { get; set;} = null!;   
    }

    public class ChangeUserPassword
    {
        public string OldPassword { get; set; } = null!;

        public string Newpassword { get; set; } = null!;

        public string ConfirmPassword { get; set; } = null!;

    }
}
