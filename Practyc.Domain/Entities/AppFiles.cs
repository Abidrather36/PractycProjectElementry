using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practyc.Domain.Entities
{
    public class AppFiles
    {
        public Guid Id { get; set; }

        public string FilePath { get; set; } = null!;

        public Guid EntityId { get; set; }
    }
}
