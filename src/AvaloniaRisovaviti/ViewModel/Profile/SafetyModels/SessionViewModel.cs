using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Models;

namespace AvaloniaRisovaviti.ViewModel.Profile.SafetyModels
{
	public class SessionViewModel : SessionAuthorizeObject
	{
		ISessionService _sesstion;
		public SessionViewModel(ISessionService sesstion, SessionAuthorizeObject viewModel)
		{
			_sesstion = sesstion;
			base.Descrition = viewModel.Descrition;
			base.Refresh = viewModel.Refresh;
			base.UserId = viewModel.UserId;
		}
		public SessionViewModel() { }

		public async void DeleteSession()
		{
			await _sesstion.DeleteSessionAsync(Refresh);
		}
	}
}
