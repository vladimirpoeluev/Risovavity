using Avalonia.Media;
using DomainModel.Integration;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.Model
{
	public class AuthorResultImage : INotifyPropertyChanged
	{
		public IImage Icon { get; set; }
		public AuthorResult AuthorResult { get; set; }
		public AuthorResultImage(AuthorResult authorResult) 
		{
			this.AuthorResult = authorResult;
			Icon = new Avalonia.Media.Imaging.Bitmap("Accets/icoUser.png");
			IUserAvatarGetter getter = new AvatarGetter(Authentication.AuthenticationUser.User);
			try
			{
				TryGetterIcon(getter);
			}
			catch
			{
				SetDefaultIcon();
			}
			
		}

		async void TryGetterIcon(IUserAvatarGetter getter)
		{
			try
			{
				UserAvatarResult result = await getter.GetAvatarUserAsync(AuthorResult.UserId);
				byte[] bytes = result.AvatarResult;
				if (bytes != null)
					Icon = ProfileShows.ImageAvaloniaConverter.ConvertByteInImage(bytes);
			}
			catch
			{
				Icon = ProfileShows.ImageAvaloniaConverter.ConvertByteInImage([]);
			}
			
			OnPropertyChanged(nameof(Icon));
		}

		void SetDefaultIcon()
		{
			Icon = new Avalonia.Media.Imaging.Bitmap("Accets/icoUser.png");
		}

		public static IEnumerable<AuthorResultImage> ConvertAuthorResult(IEnumerable<AuthorResult> authorResult)
			=> authorResult.Select((author) => new AuthorResultImage(author));

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
