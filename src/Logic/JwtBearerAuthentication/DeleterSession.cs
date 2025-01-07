using DataIntegration.Interface;
using Logic.JwtBearerAuthentication.Interface;

namespace Logic.JwtBearerAuthentication
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
			IEnumerable<string> keys = await _redis.GetKeys($"session:*:{refresh}");
			await _redis.DeleteObject(keys.First());
		}
	}
}
