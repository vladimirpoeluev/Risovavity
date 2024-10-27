using Avalonia.Media;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaRisovaviti.Model
{
	internal class AuthorResultImage
	{
		public IImage Icon { get; set; }
		public AuthorResult AuthorResult { get; set; }
		public AuthorResultImage(AuthorResult authorResult) 
		{
			this.AuthorResult = authorResult;
			AvatarGetter getter = new AvatarGetter(Authentication.AuthenticationUser.User);
			try
			{
				TryGetterIcon(getter);
			}
			catch
			{
				SetDefaultIcon();
			}
			
		}

		void TryGetterIcon(AvatarGetter getter)
		{
			var bytes = getter.GetUserAvatar(AuthorResult.UserId).AvatarResult;
			Icon = ProfileShows.ImageAvaloniaConverter.ConvertByteInImage(bytes);
		}

		void SetDefaultIcon()
		{
			Icon = new Avalonia.Media.Imaging.Bitmap("Accets/icoUser.png");
		}

		public static IEnumerable<AuthorResultImage> ConvertAuthorResult(IEnumerable<AuthorResult> authorResult)
			=> authorResult.Select((author) => new AuthorResultImage(author));
	}
}
