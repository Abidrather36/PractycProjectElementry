using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practyc.Application.RRModel
{
    public class Department
    {
        public class DepartmentRequest
        {
            public string DepartmentName { get; set; } = string.Empty;
        }


        public class DepartmentResponse : DepartmentRequest
        {
            public Guid Id { get; set; }
        }

        public class DepartmentUpdateRequest : DepartmentRequest
        {
            public Guid Id { get; set; }
        }
    }
}
