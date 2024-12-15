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
		IGetterSessionByRefresh _getterSession;
		IDeleterSession _deleterSession;
		string _desctition = string.Empty;

		public AuthorizeServiceRefresh(	IAdderSessionByRefresh adderSession, 
										IInputerSystem inputer, 
										IGetterSessionByRefresh getterSesstion, 
										IDeleterSession deleterSession)
		{
			_adderSession = adderSession;
			_inputerSystem = inputer;
			_getterSession = getterSesstion;
			_deleterSession = deleterSession;
		}

		public async Task<TokensRefreshAndAccess> ExtendSession(string refresh)
		{
			SessionAuthorizeObject user = _getterSession.GetSession(refresh);
			if (user != null)
			{
				await _deleterSession.DeleteSession(refresh);
				string refreshToken = await _adderSession.AddSession(user);
				string accessToken = _inputerSystem.InputUser(new DomainModel.Model.User()
				{
					Id = user.UserId,
					Name = user.UserId.ToString(),
					Role = new DomainModel.Model.Role() { Name = "User" }
				});
				return new TokensRefreshAndAccess(accessToken, refreshToken);
			}
			throw new Exception("Not session");
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
