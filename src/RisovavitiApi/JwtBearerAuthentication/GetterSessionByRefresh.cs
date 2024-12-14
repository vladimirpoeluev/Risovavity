﻿using DataIntegration.Interface;
using RisovavitiApi.JwtBearerAuthentication.Interface;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class GetterSessionByRefresh : IGetterSessionByRefresh
	{
		public IRedisService _redis;

		public GetterSessionByRefresh(IRedisService redis)
		{
			_redis = redis;
		}

		public SessionAuthorizeObject GetSession(string refresh)
		{
			return GetSessionAsync(refresh).Result;
		}

		public async Task<SessionAuthorizeObject> GetSessionAsync(string refresh)
		{
			return await _redis.GetObject<SessionAuthorizeObject>(refresh);
		}
	}
}