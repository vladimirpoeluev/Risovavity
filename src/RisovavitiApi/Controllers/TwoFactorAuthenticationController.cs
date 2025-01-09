using DomainModel.Integration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace RisovavitiApi.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/settings-auth")]
	public class TwoFactorAuthenticationController : Controller
	{
		ITwoFactorAuthService _twoFactorAuth;
		public TwoFactorAuthenticationController(ITwoFactorAuthService authService) 
		{
			_twoFactorAuth = authService;
		}

		[HttpGet("get-auth")]
		public async Task<IActionResult> GetAuto()
		{
			return Ok(await _twoFactorAuth.GetAsync());
		}

		[HttpPost("set-auth/{useTwoAuto}")]
		public async Task<IActionResult> SetAuto(bool useTwoAuto)
		{
			await _twoFactorAuth.SetAsync(useTwoAuto);
			return Ok();
		}
	}
}
