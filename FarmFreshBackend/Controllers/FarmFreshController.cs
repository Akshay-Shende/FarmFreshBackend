using Core.Extensions;
using Core.Models.ClaimsPrincipal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Controller = FarmFreshBackend.Controllers.Controller;

namespace FarmFreshBackend.Controllers
{
    public class FarmFreshController : Controller
    {
        public virtual FarmFreshClaimsPrincipal FarmFreshClaimsPrincipal { get; set; }

        public virtual long? CurrentRoleId => FarmFreshClaimsPrincipal != null ? FarmFreshClaimsPrincipal.RoleId: User.RoleId();
    }
}
