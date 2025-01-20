using Autofac;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using AvaloniaRisovaviti.ProfileShows;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using InteractiveApiRisovaviti.Interface;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.Model;
public class VersionProjectResultWithImage : ReactiveObject
{
	[Reactive]
	public VersionProjectResult VersionProjectResult { get; set; }

	[Reactive]
	public IImage Image { get; set; }

	[Reactive]
	public PermissionResult Permission { get; set; }

	IGetterImageProject _getterImage { get; set; }
	IDefinitionerOfPermission _definitioner { get; set; }
	IAdderVersionProject _adderVersionProject { get; set; }

	public ReactiveCommand<Unit, Task<VersionProjectResult>> Delete { get; set; }
	public ReactiveCommand<Unit, VersionProjectResult> Update { get; set; }

	public VersionProjectResultWithImage(VersionProjectResult versionProject)
	{
		_definitioner = App.Container.Resolve<IDefinitionerOfPermission>();
		_adderVersionProject = App.Container.Resolve<IAdderVersionProject>();
		Delete = ReactiveCommand.Create(DeleteVersion);
		Update = ReactiveCommand.Create(UpdateVersion);
		VersionProjectResult = versionProject;
		_getterImage = new GetterImageProject(Authentication.AuthenticationUser.User);
		Image = new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));
		LoadImage();
		LoadPermission();
	}

	async void LoadPermission()
	{
		try
		{
			Permission = await _definitioner.GetPermissionAsync(VersionProjectResult);
		}
		catch
		{
			Permission = new PermissionResult()
			{
				AddVerstion = false,
				Edit = false,
				Read = false,
			};
		}
	}

	VersionProjectResult UpdateVersion()
	{
		return VersionProjectResult;
	}

	async Task<VersionProjectResult> DeleteVersion()
	{
		await _adderVersionProject.DeleteVertionProjectAsync(VersionProjectResult.Id);
		return VersionProjectResult;
	}

	async void LoadImage()
	{
		
		ImageResult result = await _getterImage.GetImageResult(VersionProjectResult.Id);
		Image = ImageAvaloniaConverter.ConvertByteInImage(result.Image);
		
	}
}