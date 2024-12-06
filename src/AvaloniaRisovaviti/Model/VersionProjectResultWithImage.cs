using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using AvaloniaRisovaviti.ProfileShows;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaRisovaviti.Model;
public class VersionProjectResultWithImage : ReactiveObject
{
	[Reactive]
	public VersionProjectResult VersionProjectResult { get; set; }

	[Reactive]
	public IImage Image { get; set; }

	IGetterImageProject _getterImage { get; set; }

	public VersionProjectResultWithImage(VersionProjectResult versionProject)
	{
		VersionProjectResult = versionProject;
		_getterImage = new GetterImageProject(Authentication.AuthenticationUser.User);
		Image = new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));
		LoadImage();
	}

	async void LoadImage()
	{
		try
		{
			ImageResult result = await _getterImage.GetImageResult(VersionProjectResult.Id);
			Image = ImageAvaloniaConverter.ConvertByteInImage(result.Image);
		}
		catch
		{
			Image = new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Accets/breakImage.png")));
		}
	}
}