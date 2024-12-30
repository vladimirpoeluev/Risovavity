using AvaloniaRisovaviti.ViewModel.Profile.SafetyModels;
using InteractiveApiRisovaviti.Models;
using System.Collections.Generic;

namespace AvaloniaRisovaviti.ViewModel.Fake
{
	internal class FakeSesstionListViewModel : SessionListViewModel
	{
		public FakeSesstionListViewModel() 
		{
			SessionList = new List<SessionViewModel>() 
			{
				new SessionViewModel(){UserId = 1, Descrition = "Inpontent info 1"},
				new SessionViewModel(){UserId = 1, Descrition = "Inpontent info 2"},
				new SessionViewModel(){UserId = 1, Descrition = "Inpontent info 3"},
				new SessionViewModel(){UserId = 1, Descrition = "Inpontent info 4"},
				new SessionViewModel(){UserId = 1, Descrition = "Inpontent info 5"},
			};

			CurrentSession = new SessionAuthorizeObject()
			{
				UserId = 1,
				Descrition = "Current session"
			};
		}
	}
}
