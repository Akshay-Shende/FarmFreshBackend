using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUpdatable
    {
        public long? UpdatedById { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
