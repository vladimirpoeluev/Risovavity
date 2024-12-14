using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RisovavitiApi.Model;

namespace RisovavitiApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "refresh")]
    public class AutoController : Controller
    {
        [HttpGet("access/{tokenRefresh}")]
        public IActionResult Accert(string tokenRefresh)
        {
            return Ok(new TokensRefreshAndAccess("", ""));
        }
    }
}
