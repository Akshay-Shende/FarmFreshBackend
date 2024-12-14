using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Auditable : Entity,IAuditable
    {
        public long? CreatedById { get ; set ; }
        public DateTimeOffset? CreatedOn { get ; set ; }
        public long? DeletedById { get ; set ; }
        public DateTimeOffset? DeletedOn { get ; set ; }
        public long? UpdatedById { get; set ; }
        public DateTimeOffset? UpdatedOn { get ; set ; }
    }
}
