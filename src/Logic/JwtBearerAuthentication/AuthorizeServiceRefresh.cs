using DataIntegration.Interface.InterfaceOfModel;
using DomainModel.Model;
using DomainModel.ResultsRequest;
using Logic.Interface;
using Microsoft.EntityFrameworkCore;
using Logic.JwtBearerAuthentication.Interface;
using DomainModel.JwtModels;

namespace Logic.JwtBearerAuthentication
{
	public class AuthorizeServiceRefresh : IAutorizeServiceRefresh
	{
		IAdderSessionByRefresh _adderSession;
		IInputerSystem _inputerSystem;
		IGetterSessionByRefresh _getterSession;
		IDeleterSession _deleterSession;
		IAdderSession _adder;
		IUserDataBase _userData;
		string _desctition = string.Empty;

		public AuthorizeServiceRefresh(	IAdderSessionByRefresh adderSession, 
										IInputerSystem inputer, 
										IGetterSessionByRefresh getterSesstion, 
										IDeleterSession deleterSession, 
										IAdderSession adder,
										IUserDataBase getterUser)
		{
			_adderSession = adderSession;
			_inputerSystem = inputer;
			_getterSession = getterSesstion;
			_deleterSession = deleterSession;
			_adder = adder;
			_userData = getterUser;
		}

		public async Task<TokensRefreshAndAccess> ExtendSession(string refresh)
		{
			SessionAuthorizeObject user = _getterSession.GetSession(refresh);
			if (user != null)
			{
				await _deleterSession.DeleteSession(refresh);
				User userresult = await _userData.Users.Where(entity => entity.Id == user.UserId).FirstAsync();
				(string accessToken, string refreshToken) = _adder.GenerateSession(UserResult.CreateResultFromUser(userresult));
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
