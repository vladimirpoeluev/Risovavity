
using InteractiveApiRisovaviti.Interface;
using InteractiveApiRisovaviti.Models;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Linq;

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
			LoadInfo();
		}

		public async void LoadInfo()
		{
			IEnumerable<SessionAuthorizeObject> result = new List<SessionAuthorizeObject>();
			try
			{
				result = await _sessionServierService.GetSessionAsync();
			}
			catch
			{
				//TODO Сделать с лучшае ошибки 
			}
			SessionList = result.Select(entity => new SessionViewModel(_sessionServierService, entity));
		}

		public async void DeleteSession(string refresh)
		{
			try
			{
				await _sessionServierService.DeleteSessionAsync(refresh);
			}
			catch
			{
				//TODO: Сделать в случае ошибки
			}
		}

		public async void DeleteAllSession()
		{
			try
			{
				await _sessionServierService.DeleteAllSessionAsync();
			}
			catch
			{
				//TODO: Сделать в случае ошибки
			}
			
		} 

		
	}
}
