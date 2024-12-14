using Core.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models.Roles
{
    public class Role : Auditable
    {
      public string RoleName { get; set; }
      public RoleCode RoleCode { get; set; }
    }
}
