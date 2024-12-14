using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Auditable : Entity
    {
        public long     CreatedById { get; set; }
        public long     UpdatedById { get; set;}
        public long     DeletedById { get; set; }
        public DateTime CreatedOn   { get; set; }
        public DateTime UpdatedOn   { get; set;}
        public DateTime DeletedOn   { get; set;}

    }
}
