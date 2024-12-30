using DataIntegration.Interface;
using DomainModel.ResultsRequest;
using RisovavitiApi.JwtBearerAuthentication.Interface;

namespace RisovavitiApi.JwtBearerAuthentication
{
    public class SessionService : ISessionService
	{
		IDeleterSession _deleter;
		IRedisService _redisService;

		public SessionService(IDeleterSession deleterSession, IRedisService redis) 
		{
			_deleter = deleterSession;
			_redisService = redis;
		}

		public async Task<IEnumerable<SessionAuthorizeObject>> SessionAuthorizeObjectAsync(UserResult user)
		{
			IEnumerable<string> keys = await _redisService.GetKeys($"session:{user.Id}:*");
			List<SessionAuthorizeObject> result = new List<SessionAuthorizeObject>();
			foreach (string key in keys)
			{
				result.Add(await _redisService.GetObject<SessionAuthorizeObject>(key));
			}
			return result;
		}

		public async Task DeleteSessionAsync(string refresh)
		{
			await _deleter.DeleteSession(refresh);
		}

		public async Task DeleteAllSesstionByUserAsync(string userId)
		{
			IEnumerable<string> keys = await _redisService.GetKeys($"session:{userId}:*");
			foreach(var key in keys)
			{
				await _redisService.DeleteObject(key);
			}
		}
    }
}
