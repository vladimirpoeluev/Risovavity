using Microsoft.AspNetCore.Mvc;
using RisovavitiApi.Model;

namespace RisovavitiApi.Controllers
{
    [ApiController]
    [Route("api/[contiroller]")]
    public class AutoController : Controller
    {
        [HttpGet("access/{tokenRefresh}")]
        public IActionResult Accert(string tokenRefresh)
        {
            return Ok(new TokensRefreshAndAccess("", ""));
        }
    }
}
