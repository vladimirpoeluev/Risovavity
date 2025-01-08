
using DomainModel.ResultsRequest.EmailResult;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Models;
using System.Security.AccessControl;

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

		public async Task<TokensRefreshAndAccess> UserConfimationAsync(UserConfirmationResult confirmation)
		{
			return await _operateHttp.CreatePostPatser(_user, confirmation).GetResultAsync<TokensRefreshAndAccess>("api/Email/userconfimation");
		}

		public async Task EmailConfimationAsync(EmailConfirmaionResult confirmaion)
		{
			await _operateHttp.CreatePostPatser(_user, confirmaion).ExecuteRequestAsync("api/Email/confirmation");
		}
	}
}
