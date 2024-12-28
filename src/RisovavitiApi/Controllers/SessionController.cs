using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RisovavitiApi.JwtBearerAuthentication.Interface;

namespace RisovavitiApi.Controllers
{
	[Authorize]
	[ApiController]
	[Route("api/[controller]")]
	public class SessionController : Controller
	{
		private ISessionService _sessionService;

		public SessionController(ISessionService sessionService)
		{
			_sessionService = sessionService;
		}
		[HttpGet("get")]
		public IActionResult GetSessions()
		{
			return Ok(HttpContext.Request.Headers["User-Agent"].ToString());
		}

		[HttpPost("delete")]
		public IActionResult DeleteSession()
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
