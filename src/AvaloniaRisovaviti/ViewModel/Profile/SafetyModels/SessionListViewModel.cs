
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Models;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Profile.SafetyModels
{
	public class SessionListViewModel : BaseViewModel
	{
		[Reactive]
		public IEnumerable<SessionViewModel> SessionList { get; set; }

		[Reactive]
		public SessionAuthorizeObject CurrentSession { get; set; }

		private ISessionService _sessionServierService;

		public SessionListViewModel(){}
		public SessionListViewModel(ISessionService sessionService)   
		{
			_sessionServierService = sessionService;
			SessionList = new List<SessionViewModel>();
			CurrentSession = new SessionAuthorizeObject();
			
		}

		public override async void Load()
		{
			base.Load();
			await LoadInfo();
		}

		public async Task LoadInfo()
		{
			IEnumerable<SessionAuthorizeObject> result = new List<SessionAuthorizeObject>();
			await TryActionAsync(async () =>
			{
				result = await _sessionServierService.GetSessionAsync();
			});
			SessionList = result.Select(entity => new SessionViewModel(_sessionServierService, entity));
		}

		public async void DeleteSession(string refresh)
		{
			await TryActionAsync(async () =>
			{
				await _sessionServierService.DeleteSessionAsync(refresh);
			});
		}

		public async void DeleteAllSession()
		{
			await TryActionAsync(_sessionServierService.DeleteAllSessionAsync);
		} 

		
	}
}
