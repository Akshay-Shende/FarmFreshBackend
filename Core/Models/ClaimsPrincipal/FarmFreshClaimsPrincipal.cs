using Core.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.ClaimsPrincipal
{
    public class FarmFreshClaimsPrincipal
    {
        public virtual bool IsStaff { get; set; }
        public virtual long? UserId { get; set; }
        public virtual long? RoleId { get; set; }
        public virtual RoleType? RoleType { get; set; }
        public virtual bool? IsSuperAdmin { get; set; }

    }
}
