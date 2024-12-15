using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static long? RoleId(this ClaimsPrincipal principal)
        {
            if (principal == null)
            {

            }
            var roleIdClaim = principal.Claims?.FirstOrDefault(c => c.Type == "RoleId");
            return Convert.ToInt64(roleIdClaim.Value);
        }
    }
}
