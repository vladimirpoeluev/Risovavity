using DataIntegration.Interface;
using Logic.JwtBearerAuthentication.Interface;
using StackExchange.Redis;
using System.Security.Claims;

namespace Logic.JwtBearerAuthentication
{
	public class AdderSessionByRefresh : IAdderSessionByRefresh
	{
		IRedisService _redis;
		ICreaterToken _createrToken;
		ISessionService _getterSessionByRefresh;
		public Guid Refresh { get; set; }

		public AdderSessionByRefresh(IRedisService redis, ICreaterToken createrToken, ISessionService getterSession)
		{
			_redis = redis;
			_createrToken = createrToken;
			_getterSessionByRefresh = getterSession;
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
			await DeleteThisDivase(obj);	
			await _redis.AddObject($"session:{obj.UserId}:{key}", obj, OptionsJwtTokens.ExpiresRefreshTimeSpan);
			return _createrToken.GenerateToken();
		}

		async Task DeleteThisDivase(SessionAuthorizeObject obj)
		{
			IEnumerable<SessionAuthorizeObject> sessions = await _getterSessionByRefresh.SessionAuthorizeObjectAsync(new DomainModel.ResultsRequest.UserResult()
			{
				Id = obj.UserId,
			});

            foreach (var item in sessions)
            {
                if(item.Descrition == obj.Descrition)
				{
					await _getterSessionByRefresh.DeleteSessionAsync(item.Refresh);
				}
            }
        }
	}
}
