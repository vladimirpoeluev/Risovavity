using DataIntegration.Interface;
using RisovavitiApi.JwtBearerAuthentication.Interface;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class DeleterSession : IDeleterSession
	{
		IRedisService _redis;
		public DeleterSession(IRedisService redis) 
		{
			_redis = redis;
		}

		async Task IDeleterSession.DeleteSession(string refresh)
		{
			await _redis.DeleteObject(refresh);
		}
	}
}
