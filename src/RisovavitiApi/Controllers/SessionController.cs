﻿using DomainModel.ResultsRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RisovavitiApi.JwtBearerAuthentication.Interface;
using RisovavitiApi.UserOperate;
using System.Security.Claims;

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
		public async Task<IActionResult> GetSessions()
		{
			return Ok(await _sessionService.SessionAuthorizeObjectAsync(GetUser()));
		}

		[HttpPost("delete")]
		public async Task<IActionResult> DeleteSession()
		{
			await _sessionService.DeleteSessionAsync(GetRefresh());
			return Ok();
		}

		[HttpPost("delete-by-refresh")]
		public async Task<IActionResult> DeleteSession([FromBody] string refresh)
		{
			await _sessionService.DeleteSessionAsync(refresh);
			return Ok();
		}

		[HttpPost("delete/all-except-current")]
		public async Task<IActionResult> DeleteSesstionAll()
		{
			await _sessionService.DeleteAllSesstionByUserAsync(GetUser().Id.ToString());
			return Ok();
		}

		private string GetRefresh()
		{
			return HttpContext.User.Claims
				.Where((item) => item.Type == ClaimTypes.Authentication).First().Value;
		}

		private UserResult GetUser()
		{
			return UserGetterByContext.GetUserIntegration(HttpContext);
		}
	}
}
