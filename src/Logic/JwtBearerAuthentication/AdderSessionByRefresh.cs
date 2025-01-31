﻿using DataIntegration.Interface;
using Logic.JwtBearerAuthentication.Interface;
using System.Security.Claims;

namespace Logic.JwtBearerAuthentication
{
	public class AdderSessionByRefresh : IAdderSessionByRefresh
	{
		IRedisService _redis;
		ICreaterToken _createrToken;
		public Guid Refresh { get; set; }

		public AdderSessionByRefresh(IRedisService redis, ICreaterToken createrToken)
		{
			_redis = redis;
			_createrToken = createrToken;
		}

		public async Task<string> AddSession(SessionAuthorizeObject obj)
		{
			Guid key = Guid.NewGuid();
			Refresh = key;
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.AuthenticationInstant, key.ToString())
			};
			_createrToken.Claims = claims;
			obj.Refresh = Refresh.ToString();
			await _redis.AddObject($"session:{obj.UserId}:{key}", obj, OptionsJwtTokens.ExpiresRefreshTimeSpan);
			return _createrToken.GenerateToken();
		}
	}
}
