
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using DomainModel.ResultsRequest.Canvas;
using ReactiveUI.Fody.Helpers;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	internal class FormAddVersionViewModel : BaseViewModel
	{
		[Reactive]
		public VersionProjectResult ProjectResult { get; set; }

		[Reactive] public Task<IImage> ImageOldProjectReasult { get; set; }

		[Reactive]
		public VersionProjectResult NewProjectResult { get; set; }

		[Reactive] public Task<IImage> NewImageProjectResult { get; set; }
		
		public FormAddVersionViewModel() 
		{
			ProjectResult = new VersionProjectResult();
			NewProjectResult = new VersionProjectResult();
			ImageOldProjectReasult = Task.FromResult((IImage)new Bitmap("\\Accets\\8.gif"));
			NewImageProjectResult = Task.FromResult((IImage)new Bitmap(AssetLoader.Open(new System.Uri("avares:"))));
		}

		public FormAddVersionViewModel(VersionProjectResult parent) : this()
		{
			ProjectResult = parent;
		}
	}
}
