using System.Reactive.Linq;
using System.Collections.Generic;
using System.Reactive.Disposables;
using System.Threading.Tasks;
using AvaloniaRisovaviti.Model;
using DomainModel.Integration;
using InteractiveApiRisovaviti.Interface;
using ReactiveUI;
using System;
using DomainModel.ResultsRequest.Canvas;
using System.Linq;
using System.Windows.Input;
using System.Reactive;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	public class MyVersionViewModel : BaseViewModel
	{
		private IGetterWorkByAuthorId _getter;
		private InteractiveApiRisovaviti.Profile _profile;
		[Reactive]
		public IEnumerable<VersionProjectResultWithImage> VersionsProject { get; set; }
		public ReactiveCommand<Unit, Unit> Init { get; set; }

		public MyVersionViewModel(IGetterWorkByAuthorId getter, IAuthenticationUser user) 
		{
			_getter = getter;
			_profile = new InteractiveApiRisovaviti.Profile(user);
			VersionsProject = new List<VersionProjectResultWithImage>();
			Init = ReactiveCommand.CreateFromTask(InitVersionsProject);
		}
		
		private async Task InitVersionsProject()
		{
			IEnumerable<VersionProjectResult> versions = await _getter.GetVersionProjectResultsByAuthorId(_profile.ProfileUser.Id, 0, 20);
			VersionsProject = versions.Select(v => new VersionProjectResultWithImage(v));
		}

	}
}