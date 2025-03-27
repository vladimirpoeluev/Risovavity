
using AvaloniaRisovaviti.Model;
using AvaloniaRisovaviti.Services;
using AvaloniaRisovaviti.Services.Interface;
using DomainModel.Integration.CanvasOperation;
using InteractiveApiRisovaviti.Interface;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	public class LikedVersionsProjectViewModel : BaseViewModel
	{
		[Reactive]
		public IEnumerable<VersionProjectResultWithImage> Versions { get; set; }

		InteractiveApiRisovaviti.Profile _profile;
		IGetterWorksByLikes _getterWorks;
		IIteraterItems _iteraterItems;
		public LikedVersionsProjectViewModel(IAuthenticationUser user, IGetterWorksByLikes getterWorks)
		{
			_profile = new InteractiveApiRisovaviti.Profile(user);
			_getterWorks = getterWorks;
			Versions = new List<VersionProjectResultWithImage>();
			_iteraterItems = new IteraterItems(20, LoadVersions);
		}

		

		public override void Load()
		{
			base.Load();
			_iteraterItems.Next();
		}

		public async void LoadVersions((int skip, int take) range)
		{
			var versions = (await _getterWorks.GetVersionProject(_profile.ProfileUser.Id,
								new DomainModel.RangeTakeAndSkip(range.skip, range.take)))
								.Select(e => new VersionProjectResultWithImage(e));

			Versions = Versions.Concat(versions);
		}

	}
}
