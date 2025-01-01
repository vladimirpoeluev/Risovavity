using DataIntegration.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace RisovavitiApi.Middleware
{
	public class AuthorizeAccessToken
	{
		private readonly RequestDelegate _next;
		private IGetterKeys _keys;

		public AuthorizeAccessToken(RequestDelegate next, IGetterKeys keys)
		{
			_next = next;
			_keys = keys;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			
			var resutl = await context.AuthenticateAsync("Bearer");
			if (resutl.Succeeded)
			{
				string idRefresh = context.User.Claims.FirstOrDefault((claim) => claim.Type == ClaimTypes.Authentication)?.Value;
				if(idRefresh == null)
				{
					_next(context);
					return;
				}
				IEnumerable<string> keys = await _keys.GetKeys($"session:*:{idRefresh}");
				if (keys.Count() == 0)
				{
					context.Response.StatusCode = StatusCodes.Status401Unauthorized;
					await context.Response.WriteAsync("Unauthorized");
					return;
				}
			}
			
			await _next(context);
		}
	}
}
