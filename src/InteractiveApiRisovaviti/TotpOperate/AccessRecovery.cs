using DomainModel.ResultsRequest.TotpModels;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Interface.Topt;

namespace InteractiveApiRisovaviti.TotpOperate
{
	public class AccessRecovery : IAccessRecovery
	{
		IAuthenticationUser _user;
		FabricAutoControllerIntegraion fabricAuto;
		public AccessRecovery(	IAuthenticationUser user,
								FabricAutoControllerIntegraion fabric) 
		{
			fabricAuto = fabric;
			_user = user;
		}

		public async Task<IEditPasswordForRecovery> Recovery(CodeToptConfirmationResult codeTopt)
		{
			string token = await fabricAuto.CreatePostPatser(_user, codeTopt).GetResultAsync<string>("api/restore-access/restore");
			var authorForEditPassword = new AuthenticationUser(token);
			return new EditPasswordForRecovery(authorForEditPassword, fabricAuto);
		}
	}
}
