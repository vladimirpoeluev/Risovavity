
using DomainModel.ResultsRequest.EmailResult;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Models;

namespace InteractiveApiRisovaviti
{
	public class ConfirmationViaEmail
	{
		FabricAutoControllerIntegraion _operateHttp;
		IAuthenticationUser _user;
		public ConfirmationViaEmail(FabricAutoControllerIntegraion operateHttp, IAuthenticationUser user)
		{
			_operateHttp = operateHttp;
			_user = user;
		}

		public async Task<IAuthenticationUser> UserConfimationAsync(UserConfirmationResult confirmation)
		{
			var tokent = await _operateHttp.CreatePostPatser(_user, confirmation).GetResultAsync<TokensRefreshAndAccess>("api/Email/userconfimation");
			return new AuthenticationUserByRefresh(tokent, _operateHttp);
		}

		public async Task EmailConfimationAsync(EmailConfirmaionResult confirmaion)
		{
			await _operateHttp.CreatePostPatser(_user, confirmaion).ExecuteRequestAsync("api/Email/confirmation");
		}
	}
}
