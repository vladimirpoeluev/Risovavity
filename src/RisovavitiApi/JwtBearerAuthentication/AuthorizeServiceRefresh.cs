using Azure.Core;
using DomainModel.ResultsRequest;
using Logic.Interface;
using RisovavitiApi.JwtBearerAuthentication.Interface;
using RisovavitiApi.Model;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class AuthorizeServiceRefresh : IAutorizeServiceRefresh
	{
		IAdderSessionByRefresh _adderSession;
		IInputerSystem _inputerSystem;
		IGetterSessionByRefresh _getterSession;
		IDeleterSession _deleterSession;
		IAdderSession _adder;
		string _desctition = string.Empty;

		public AuthorizeServiceRefresh(	IAdderSessionByRefresh adderSession, 
										IInputerSystem inputer, 
										IGetterSessionByRefresh getterSesstion, 
										IDeleterSession deleterSession, 
										IAdderSession adder)
		{
			_adderSession = adderSession;
			_inputerSystem = inputer;
			_getterSession = getterSesstion;
			_deleterSession = deleterSession;
			_adder = adder;
		}

		public async Task<TokensRefreshAndAccess> ExtendSession(string refresh)
		{
			SessionAuthorizeObject user = _getterSession.GetSession(refresh);
			if (user != null)
			{
				await _deleterSession.DeleteSession(refresh);
				
				(string accessToken, string refreshToken) = await _adder.GenerateSession();
				return new TokensRefreshAndAccess(accessToken, refreshToken);
			}
			throw new Exception("Not session");
		}

		public async Task<TokensRefreshAndAccess> RegistSession(UserResult user)
		{
			(string access, string refresh) = _adder.GenerateSession(user);
			return new TokensRefreshAndAccess(access, refresh);
		}
	}
}
