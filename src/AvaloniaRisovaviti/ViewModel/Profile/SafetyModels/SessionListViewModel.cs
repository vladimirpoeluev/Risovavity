
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Models;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaRisovaviti.ViewModel.Profile.SafetyModels
{
	internal class SessionListViewModel : BaseViewModel
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
			LoadInfo();
		}

		public async void LoadInfo()
		{
			IEnumerable<SessionAuthorizeObject> result = await _sessionServierService.GetSessionAsync();
			SessionList = result.Select(entity => new SessionViewModel(_sessionServierService, entity));
		}

		public async void DeleteSession(string refresh)
		{
			await _sessionServierService.DeleteSessionAsync(refresh);
		}

		public async void DeleteAllSession()
		{
			await _sessionServierService.DeleteAllSessionAsync();
		} 

		
	}
}
