using DataIntegration.Interface;
using RisovavitiApi.JwtBearerAuthentication.Interface;
using System.Security.Claims;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class AdderSessionByRefresh : IAdderSessionByRefresh
	{
		IRedisService _redis;
		ICreaterToken _createrToken;

		public AdderSessionByRefresh(IRedisService redis, ICreaterToken createrToken)
		{
			_redis = redis;
			_createrToken = createrToken;
		}

		public async Task<string> AddSession(SessionAuthorizeObject obj)
		{
			Guid key = Guid.NewGuid();
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.AuthenticationInstant, key.ToString())
			};
			_createrToken.Claims = claims;
			await _redis.AddObject(key.ToString(), obj, OptionsJwtTokens.ExpiresRefreshTimeSpan);
			return _createrToken.GenerateToken();
		}
	}
}
