using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Models;

namespace AvaloniaRisovaviti.ViewModel.Profile.SafetyModels
{
	public class SessionViewModel : SessionAuthorizeObject
	{
		ISessionService _sesstion;
		SessionListViewModel _list;
		public SessionViewModel(ISessionService sesstion, 
								SessionAuthorizeObject viewModel,
								SessionListViewModel list)
		{
			_sesstion = sesstion;
			base.Descrition = viewModel.Descrition;
			base.Refresh = viewModel.Refresh;
			base.UserId = viewModel.UserId;
			_list = list;
		}
		public SessionViewModel() { }

		public async void DeleteSession()
		{
			await _list.TryActionAsync(async () =>
			{
				await _sesstion.DeleteSessionAsync(Refresh);
			});
		}
	}
}
