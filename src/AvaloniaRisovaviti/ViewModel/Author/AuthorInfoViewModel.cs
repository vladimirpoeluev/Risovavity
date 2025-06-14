using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using AvaloniaRisovaviti.ProfileShows;
using AvaloniaRisovaviti.Services;
using AvaloniaRisovaviti.ViewModel.Other;
using DomainModel.Integration;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using DomainModel.ResultsRequest.Canvas;
using DomainModel.Integration.CanvasOperation;

namespace AvaloniaRisovaviti.ViewModel.Author
{
	public class AuthorInfoViewModel : BaseViewModel
	{
		private int? _authorId;

		private IAuthorGetter _authorGetter;
		private IGetterWorkByAuthorId _getterWorkByAuthorId;
		private IUserAvatarGetter _userAvatarGetter;
		private IGetterImageProject _getterImageProject;

		private IteraterItems iteraterCanvas;
		private IteraterItems iteraterVersionProject;

		[Reactive]
		public IImage ImageAuthor { get; set; } = new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Assets/Icons/user-avatar.png")));
		[Reactive]
		public string AuthorName { get; set; } = string.Empty;
		[Reactive]
		public int CountLike { get; set; } = 0;

		public int? AuthorId
		{
			get
			{
				return _authorId;
			}
			set
			{
				_authorId = value;
			}
		}

		[Reactive]
		public IEnumerable<CanvasViewModel> Canvases { get; set; } = new List<CanvasViewModel>();
		[Reactive]
		public IEnumerable<VersionProjectViewModel> VersionProjects { get; set; } = new List<VersionProjectViewModel>();

		public AuthorInfoViewModel(IAuthorGetter getterGetter,
									IGetterWorkByAuthorId getterWork,
									IUserAvatarGetter userAvatar,
									IGetterImageProject getterImage)
		{
			_authorGetter = getterGetter;
			_userAvatarGetter = userAvatar;
			_getterWorkByAuthorId = getterWork;
			_getterImageProject = getterImage;
			iteraterCanvas = new IteraterItems(20, CanvasIterate);
			iteraterVersionProject = new IteraterItems(20, VersionProjectIterate);
		}

		private async void CanvasIterate((int skip, int take) range)
		{
			IEnumerable<CanvasResult> items = await _getterWorkByAuthorId.GetCanvasByAuthorId(AuthorId ?? -1, range.skip, range.take);
			Canvases = items.Select(item => new CanvasViewModel()
			{
				Description = item.Description,
				Name = item.Name,
				Id = item.Id,
				MainVersionProject = new VersionProjectViewModel()
				{
					Id = item.VersionId,
				}
			});
			await LoadImage();
		}

		private async void VersionProjectIterate((int skip, int take) range)
		{
			IEnumerable<VersionProjectResult> items = await _getterWorkByAuthorId.GetVersionProjectResultsByAuthorId(AuthorId ?? -1, range.skip, range.take);
			VersionProjects = items.Select(item => new VersionProjectViewModel()
			{
				Description = item.Description,
				Name = item.Name,
				Id = item.Id,
			});
			await LoadImage();
		}

		public override async void Load()
		{
			if (AuthorId != null)
			{
				iteraterCanvas.Next();
				iteraterVersionProject.Next();
				await LoadAuthorInfoAsync();
				
			}
			base.Load();
		}

		async Task LoadAuthorInfoAsync()
		{
			await TryActionAsync(async () =>
			{
				AuthorResult authorrestul = await _authorGetter.GetAuthorAsync(AuthorId ?? -1);
				AuthorName = authorrestul.Name;
				UserAvatarResult imageResult = await _userAvatarGetter.GetAvatarUserAsync(AuthorId ?? -1);
				ImageAuthor = ImageAvaloniaConverter.ConvertByteInImage(imageResult.AvatarResult);
			});

		}
		async Task LoadImage()
		{
			await Task.WhenAll(LoadImageForCanvas(), LoadImageForVersionProject());
		}

		async Task LoadImageForCanvas()
		{
			await TryActionAsync(async () =>
			{
				Canvases = Canvases.Select((item) =>
				{
					LoadImage(item);
					return item;
				});
			});
		}
		async Task LoadImageForVersionProject()
		{
			await TryActionAsync(async () =>
			{
				VersionProjects = VersionProjects.Select((item) =>
				{
					LoadImage(item);
					return item;
				});
			});
		}

		async void LoadImage(CanvasViewModel canvas)
		{
			if (canvas.Image != null)
				return;
			ImageResult image = await _getterImageProject.GetImageResult(canvas.MainVersionProject.Id);
			canvas.Image = ImageAvaloniaConverter.ConvertByteInImage(image.Image);
		}

		async void LoadImage(VersionProjectViewModel versionProject)
		{
			if(versionProject.Image != null)
				return;
			ImageResult image = await _getterImageProject.GetImageResult(versionProject.Id);
			versionProject.Image = ImageAvaloniaConverter.ConvertByteInImage(image.Image);
		}
	}
}
