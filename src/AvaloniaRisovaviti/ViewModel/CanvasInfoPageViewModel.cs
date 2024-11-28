using Avalonia.Media;
using Avalonia.Media.Imaging;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using InteractiveApiRisovaviti.Interface;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using Avalonia.Platform;

namespace AvaloniaRisovaviti.ViewModel
{
	public class CanvasInfoPageViewModel : INotifyPropertyChanged
	{
		public CanvasResult Canvas { get; set; }
		public VersionProjectResult VersionProject { get; set; }
		public IImage Image { get; set; }

		IGetterVersionProject _getterVersion;
		IGetterCanvas _getterCanvas;
		IGetterImageProject _getterImage;

		public CanvasInfoPageViewModel() 
		{
			Canvas = new CanvasResult();
			VersionProject = new VersionProjectResult();
			Image = new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));

			IAuthenticationUser user = Authentication.AuthenticationUser.User;
			_getterVersion = new GetterVersionProject(user);
			_getterCanvas = new GetterCanvasParseApi(user);
			_getterImage = new GetterImageProject(user);
		}

		public CanvasInfoPageViewModel(CanvasResult canvasResult) : this()
		{
			Canvas = canvasResult;
			LoadInfo();
		}

		void LoadInfo()
		{
			LoadCanvas();
			LoadVersionProject();
		}

		async void LoadCanvas()
		{
			Canvas = await _getterCanvas.GetAsync(Canvas.Id);
			OnPropertyChanged(nameof(Canvas));
		}

		async void LoadVersionProject()
		{
			VersionProject = await _getterVersion.GetVersionProjectByIdAsync(Canvas.VersionId);
			OnPropertyChanged(nameof(VersionProject));
		}

		async void LoadImage()
		{
			ImageResult result = await _getterImage.GetImageResult(VersionProject.Id);
			Image = new Bitmap(new MemoryStream(result.Image));
		}

		#region INotifyPropertyChanged Implementation
		public event PropertyChangedEventHandler? PropertyChanged;

		public void OnPropertyChanged([CallerMemberName] string? name = null)
		{
			if (name != null)
			{
				PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
			}
		}
		#endregion
	}
}