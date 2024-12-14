using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDeletable
    {
        public long? DeletedById { get; set; }
        public DateTimeOffset? DeletedOn { get; set; }
    }
}
