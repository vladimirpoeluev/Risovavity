
using AvaloniaRisovaviti.Model;
using DomainModel.Integration.CanvasOperation;
using InteractiveApiRisovaviti.Interface;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	public class LikedVersionsProjectViewModel : BaseViewModel
	{
		[Reactive]
		public IEnumerable<VersionProjectResultWithImage> Versions { get; set; }

		InteractiveApiRisovaviti.Profile _profile;
		IGetterWorksByLikes _getterWorks;
		public LikedVersionsProjectViewModel(IAuthenticationUser user, IGetterWorksByLikes getterWorks)
		{
			_profile = new InteractiveApiRisovaviti.Profile(user);
			_getterWorks = getterWorks;
			Versions = new List<VersionProjectResultWithImage>();
		}

		
	}
}
