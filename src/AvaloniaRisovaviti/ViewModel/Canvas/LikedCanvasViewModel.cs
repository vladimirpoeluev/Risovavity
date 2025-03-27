
using AvaloniaRisovaviti.Model;
using DomainModel.Integration.CanvasOperation;
using InteractiveApiRisovaviti.Interface;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	internal class LikedCanvasViewModel : BaseViewModel
	{
		[Reactive]
		public IEnumerable<CanvasResultWithImage> Canvases { get; set; }

		int couint = 0;
		int next = 20;
		IGetterWorksByLikes _getterWorksByLikes;
		InteractiveApiRisovaviti.Profile _profile;
		public LikedCanvasViewModel(IGetterWorksByLikes getterWorks, 
									IAuthenticationUser user) 
		{
			_getterWorksByLikes = getterWorks;
			_profile = new InteractiveApiRisovaviti.Profile(user);
			Canvases = new List<CanvasResultWithImage>();
		}

		public async override void Load()
		{
			await LoadCanvases();
			base.Load();
		}

		public async Task LoadCanvases()
		{
			int idUser = _profile.ProfileUser.Id;
			IEnumerable<CanvasResultWithImage> canvases = 
				(await _getterWorksByLikes.GetCanvas(idUser, new DomainModel.RangeTakeAndSkip(couint, next)))
				.Select(e => new CanvasResultWithImage(e));
			Canvases = Canvases.Concat(canvases);
			couint += next;
		}
	}
}
