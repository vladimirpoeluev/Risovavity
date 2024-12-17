
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Models;

namespace InteractiveApiRisovaviti
{
	public class EntranceRefresh : IEntrance
	{
		FabricAutoControllerIntegraion _integration;
		public EntranceRefresh(FabricAutoControllerIntegraion integration)
		{
			_integration = integration;
		}

		public async Task<IAuthenticationUser> InputSystemAsync(string login, string password)
		{
			IPostAutoControllerIntegraion postrequst = 
				_integration.CreatePostPatser(
				AuthenticationUser.NotAuthenticationUser, 
				new AuthenticationForm()
			{
				Login = login,
				Password = password
			});
			TokensRefreshAndAccess result = 
				await postrequst.GetResultAsync<TokensRefreshAndAccess>("api/Auto/regist");

			return new AuthenticationUserByRefresh(result, _integration);
		}

		IAuthenticationUser IEntrance.IputSystem(string login, string password)
		{
			return InputSystemAsync(login, password).Result;
		}
	}
}
