using Avalonia.Media;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti;
using System.Collections.Generic;
using System.Linq;

namespace AvaloniaRisovaviti.Model
{
	internal class AuthorResultImgage
	{
		IImage Icon { get; set; }
		AuthorResult AuthorResult { get; set; }
		public AuthorResultImgage(AuthorResult authorResult) 
		{
			this.AuthorResult = authorResult;
			AvatarGetter getter = new AvatarGetter(Authentication.AuthenticationUser.User);
			var bytes = getter.GetUserAvatar(AuthorResult.UserId).AvatarResult;
			Icon = ProfileShows.ImageAvaloniaConverter.ConvertByteInImage(bytes);
		}

		public static IEnumerable<AuthorResultImgage> ConvertAuthorResult(IEnumerable<AuthorResult> authorResult)
			=> authorResult.Select((author) => new AuthorResultImgage(author));
	}
}
