using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface ICreatable
    {
        public long? CreatedById { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
    }
}
