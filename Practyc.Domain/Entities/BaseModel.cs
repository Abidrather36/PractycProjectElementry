using Practyc.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practyc.Domain.Entities
{
    public class BaseModel : IBaseModel
    {
        public Guid Id { get ; set ; }
        public DateTimeOffset CreatedOn { get; set ; }
        public DateTimeOffset UpdatedOn { get; set; }
        public Guid UpdatedBy { get; set; }
        public Guid CreatedBy { get; set; }

    }
}
