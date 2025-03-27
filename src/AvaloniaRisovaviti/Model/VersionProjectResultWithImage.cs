using Autofac;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using AvaloniaEdit.Utils;
using AvaloniaRisovaviti.ProfileShows;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;
using DynamicData.Binding;
using InteractiveApiRisovaviti.CanvasOperate;
using InteractiveApiRisovaviti.Interface;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using System.Reactive.Linq;
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

	[Reactive]
	public int CountLike { get; set; }
	[Reactive]
	public bool? IsLiked { get; set; }

	IGetterImageProject _getterImage { get; set; }
	IDefinitionerOfPermission _definitioner { get; set; }
	IAdderVersionProject _adderVersionProject { get; set; }
	ILikesOfVersitonService _likesService;

	public ReactiveCommand<Unit, Task<VersionProjectResult>> Delete { get; set; }
	public ReactiveCommand<Unit, VersionProjectResult> Update { get; set; }
	public VersionProjectResultWithImage()
	{
		Image = new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));
	}

	public VersionProjectResultWithImage(VersionProjectResult versionProject) : this()
	{
		_definitioner = App.Container.Resolve<IDefinitionerOfPermission>();
		_adderVersionProject = App.Container.Resolve<IAdderVersionProject>();
		_likesService = App.Container.Resolve<ILikesOfVersitonService>();
		Delete = ReactiveCommand.Create(DeleteVersion);
		Update = ReactiveCommand.Create(UpdateVersion);
		VersionProjectResult = versionProject;
		_getterImage = new GetterImageProject(Authentication.AuthenticationUser.User);
		this.WhenValueChanged(vm => vm.IsLiked)
			.Where(isLiked => isLiked != null)
			.Subscribe(async (isLiked) =>
			{
				if (isLiked ?? false) await _likesService.Like(VersionProjectResult.Id);
				else await _likesService.UnLike(VersionProjectResult.Id);
			});
		LoadInfo();
		
	}
	async void LoadInfo()
	{
		await Task.WhenAll(LoadLikes(), LoadImage(), LoadPermission());
	}
	async Task LoadLikes()
	{
		CountLike = await _likesService.CouintLikes(VersionProjectResult.Id);
		IsLiked = await _likesService.IsLike(VersionProjectResult.Id);
	}

	async Task LoadPermission()
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

	async Task LoadImage()
	{
		ImageResult result = await _getterImage.GetImageResult(VersionProjectResult.Id);
		Image = ImageAvaloniaConverter.ConvertByteInImage(result.Image);
	}
}