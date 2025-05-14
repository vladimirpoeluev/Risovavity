using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using AvaloniaRisovaviti.ProfileShows;
using AvaloniaRisovaviti.ViewModel.Other;
using DomainModel.Integration;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.Interface;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Author
{
	public class AuthorInfoViewModel : BaseViewModel
	{
		private int? _authorId;

		private IAuthorGetter _authorGetter;
		private IGetterWorkByAuthorId _getterWorkByAuthorId;
		private IUserAvatarGetter _userAvatarGetter;

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
		
		public AuthorInfoViewModel(	IAuthorGetter getterGetter,
									IGetterWorkByAuthorId getterWork,
									IUserAvatarGetter userAvatar) 
		{
			_authorGetter = getterGetter;
			_userAvatarGetter = userAvatar;
			_getterWorkByAuthorId = getterWork;
		}

		public override async void Load()
		{
			if(AuthorId != null)
			{
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
	}
}
