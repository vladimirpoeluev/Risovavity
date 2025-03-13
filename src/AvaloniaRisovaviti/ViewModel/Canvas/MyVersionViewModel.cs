using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AvaloniaRisovaviti.Model;
using DomainModel.Integration;
using InteractiveApiRisovaviti.Interface;
using ReactiveUI;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	public class MyVersionViewModel : ReactiveObject
	{
		private IGetterWorkByAuthorId _getter;
		private InteractiveApiRisovaviti.Profile _profile;
		public IEnumerable<VersionProjectResultWithImage> VersionsProject { get; set; }

		public MyVersionViewModel(IGetterWorkByAuthorId getter, IAuthenticationUser user) 
		{
			_getter = getter;
			_profile = new InteractiveApiRisovaviti.Profile(user);
			VersionsProject = new List<VersionProjectResultWithImage>();
			Task.WaitAll(InitVersionsProject());
		}
		
		private async Task InitVersionsProject()
		{

		}

	}
}