using DataIntegration.Interface;
using DomainModel.ResultsRequest;
using RisovavitiApi.JwtBearerAuthentication.Interface;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class AdderSessionByRefresh : IAdderSessionByRefresh
	{
		IRedisService _redis;

		public AdderSessionByRefresh(IRedisService redis)
		{
			_redis = redis;
		}

		public async Task<string> AddSession(SessionAuthorizeObject obj)
		{
			Guid key = Guid.NewGuid();
			await _redis.AddObject(key.ToString(), obj, OptionsJwtTokens.ExpiresRefreshTimeSpan);
			return key.ToString();
		}
	}
}
