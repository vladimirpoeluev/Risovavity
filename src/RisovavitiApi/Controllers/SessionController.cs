using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RisovavitiApi.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class SessionController : Controller
	{
		[HttpGet("get")]
		public IActionResult GetSessions()
		{
			return Ok(HttpContext.Request.Headers["User-Agent"].ToString());
		}

		[HttpPost("delete")]
		public IActionResult DeleteSession([FromBody]Guid refresh)
		{
			return NotFound();
		}

		[HttpPost("delete/all-except-current")]
		public IActionResult DeleteSesstionAll()
		{
			return NotFound();
		}
	}
}
