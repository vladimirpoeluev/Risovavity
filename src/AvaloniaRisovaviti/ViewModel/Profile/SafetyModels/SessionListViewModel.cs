
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Models;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;

namespace AvaloniaRisovaviti.ViewModel.Profile.SafetyModels
{
	internal class SessionListViewModel : BaseViewModel
	{
		[Reactive]
		public IEnumerable<SessionAuthorizeObject> SessionList { get; set; }

		[Reactive]
		public SessionAuthorizeObject CurrentSession { get; set; }

		private ISessionService _sessionServierService;

		public SessionListViewModel(ISessionService sessionService) 
		{
			_sessionServierService = sessionService;
			SessionList = new List<SessionAuthorizeObject>();
			CurrentSession = new SessionAuthorizeObject();
			LoadInfo();
		}

		public async void LoadInfo()
		{
			SessionList = await _sessionServierService.GetSessionAsync();
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
