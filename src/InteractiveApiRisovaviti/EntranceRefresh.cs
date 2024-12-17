
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
			IPostAutoControllerIntegraion postrequst = _integration.CreatePostPatser<AuthenticationForm>(
				AuthenticationUser.NotAuthenticationUser, 
				new AuthenticationForm()
			{
				Login = login,
				Password = password
			});
			postrequst.ExecuteRequestAsync<>()

			throw new NotImplementedException();
		}

		IAuthenticationUser IEntrance.IputSystem(string login, string password)
		{
			throw new NotImplementedException();
		}
	}
}
