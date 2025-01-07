using DataIntegration.Interface;
using Logic.JwtBearerAuthentication.Interface;

namespace Logic.JwtBearerAuthentication
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
			IEnumerable<string> keys = await _redis.GetKeys($"session:*:{refresh}");
			return await _redis.GetObject<SessionAuthorizeObject>(keys.First());
		}
	}
}
