using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practyc.Application.RRModel
{
    public class EmployeeRequest
    {
        public string Name { get; set; } = null!;


        public string Salary { get; set; } = null!;


        public string Email { get; set; } = null!;


        public string Password { get; set; } = null!;
    }

    public class EmployeeResponse
    {
        public Guid Id { get; set; }

        public string Email { get; set; } = null!;

    }
}
