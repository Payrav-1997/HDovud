using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HDovud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected Guid GetCurrentUserId() =>
        HttpContext.User.Identity is not ClaimsIdentity identity ? Guid.Empty : Guid.Parse(identity.FindFirst("id")?.Value ?? string.Empty);

    }
}
