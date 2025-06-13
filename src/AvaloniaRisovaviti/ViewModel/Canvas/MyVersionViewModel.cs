using AvaloniaEdit.Utils;
using AvaloniaRisovaviti.Model;
using DomainModel.Integration;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.Interface;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	public class MyVersionViewModel : BaseViewModel
	{
		private IGetterWorkByAuthorId _getter;
		private InteractiveApiRisovaviti.Profile _profile;
		private int count = 0;
		private int next = 20;
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
			count = 0;
			await UpdateItem();
			count += next;
		}

		private void DeleteItem(Task<VersionProjectResult> itemForDeleted)
		{
			VersionsProject = VersionsProject.Where(item => item.VersionProjectResult.Id != itemForDeleted.Id);
		}

		public async Task Next()
		{
			await UpdateItem();
			count += next;
		}

		private async Task UpdateItem()
		{
			await TryActionAsync(async () =>
			{
				IEnumerable<VersionProjectResult> versions = await _getter.GetVersionProjectResultsByAuthorId(_profile.ProfileUser.Id, count, next);
				VersionsProject = versions.Select(v => 
				{
					var item = new VersionProjectResultWithImage(v);
					item.Delete.Subscribe(DeleteItem);
					return item;
				});
			});
		}
	}
}