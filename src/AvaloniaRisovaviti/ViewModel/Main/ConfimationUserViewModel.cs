
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.EmailResult;
using InteractiveApiRisovaviti.Interface;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Main
{
	public class ConfimationUserViewModel
	{
		IConfirmationViaEmail _confirmationViaEmail;
		public UserConfirmationResult Code { get; set; }
		public ConfimationUserViewModel(IConfirmationViaEmail confirmation)
		{
			_confirmationViaEmail = confirmation;
			Code = new UserConfirmationResult();
		}

		public async Task<IAuthenticationUser> UserConfirmaiton()
		{
			return await _confirmationViaEmail.UserConfimationAsync(Code);
		}
	}
}
