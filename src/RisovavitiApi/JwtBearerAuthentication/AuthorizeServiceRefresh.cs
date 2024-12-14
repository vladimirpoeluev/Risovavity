using DataIntegration.RedisDataBase;
using DomainModel.ResultsRequest;
using Logic.Interface;
using RisovavitiApi.JwtBearerAuthentication.Interface;
using RisovavitiApi.Model;
using System.Diagnostics;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class AuthorizeServiceRefresh : IAutorizeServiceRefresh
	{
		IAdderSessionByRefresh _adderSession;
		IInputerSystem _inputerSystem;
		string _desctition = string.Empty;
		public AuthorizeServiceRefresh(IAdderSessionByRefresh adderSession, IInputerSystem inputer)
		{
			_adderSession = adderSession;
			_inputerSystem = inputer;
		}

		public Task<TokensRefreshAndAccess> ExtendSession(string refresh)
		{
			throw new NotImplementedException();
		}

		public async Task<TokensRefreshAndAccess> RegistSession(UserResult user)
		{
			string refresh = await _adderSession.AddSession(new SessionAuthorizeObject()
			{
				UserId = user.Id,
				Descrition =_desctition
			});

			string access = _inputerSystem.InputUser(new DomainModel.Model.User()
			{
				Id = user.Id,
				Name = user.Name,
				Role = new DomainModel.Model.Role()
				{
					Name = "User"
				},
			});
			return new TokensRefreshAndAccess(access, refresh);
		}
	}
}
