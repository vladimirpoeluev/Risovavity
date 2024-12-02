
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using DomainModel.ResultsRequest.Canvas;
using ReactiveUI.Fody.Helpers;
using InteractiveApiRisovaviti.CanvasOperate;
using DomainModel.Integration.CanvasOperation;
using System.Threading.Tasks;
using AvaloniaRisovaviti.ProfileShows;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	internal class FormAddVersionViewModel : BaseViewModel
	{
		[Reactive]
		public VersionProjectResult ProjectResult { get; set; }

		[Reactive] public IImage ImageOldProjectReasult { get; set; }

		[Reactive]
		public VersionProjectResult NewProjectResult { get; set; }

		[Reactive] public IImage NewImageProjectResult { get; set; }

		IGetterVersionProject _getterVersion;
		IGetterImageProject _getterImageProject;
		
		public FormAddVersionViewModel() 
		{
			ProjectResult = new VersionProjectResult();
			NewProjectResult = new VersionProjectResult();
			ImageOldProjectReasult = new Bitmap("Accets\\8.gif");
			NewImageProjectResult = new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));
			_getterVersion = new GetterVersionProject(Authentication.AuthenticationUser.User);
			_getterImageProject = new GetterImageProject(Authentication.AuthenticationUser.User);
		}

		public FormAddVersionViewModel(VersionProjectResult parent) : this()
		{
			ProjectResult = parent;
			LoadInfo();
		}



		async void LoadInfo()
		{
			await LoadOldVersionProject();
		}

		async Task LoadOldVersionProject()
		{
			ProjectResult = await _getterVersion.GetVersionProjectByIdAsync(ProjectResult.Id);
			ImageResult result = await _getterImageProject.GetImageResult(ProjectResult.Id);
			ImageOldProjectReasult = ImageAvaloniaConverter.ConvertByteInImage(result.Image);
		}
	}
}
