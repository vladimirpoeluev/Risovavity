using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Interface.Topt;

namespace InteractiveApiRisovaviti.TotpOperate
{
	public class EditPasswordForRecovery : IEditPasswordForRecovery
	{
		private FabricAutoControllerIntegraion fabric;
		private IAuthenticationUser _user;
		public EditPasswordForRecovery(	IAuthenticationUser user, 
										FabricAutoControllerIntegraion controllerIntegraion) 
		{
			fabric = controllerIntegraion;
			_user = user;
		}
		public async Task EditPassword(EditNewPasswordResul passwordForm)
		{
			await fabric.CreatePostPatser(_user, passwordForm).ExecuteRequestAsync("api/restore-access/edit-password");
		}
	}
}
