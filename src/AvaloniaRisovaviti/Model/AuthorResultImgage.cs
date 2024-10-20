using Avalonia.Media;
using DomainModel.ResultsRequest;
using Newtonsoft.Json.Linq;
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
		}

		public static IEnumerable<AuthorResultImgage> ConvertAuthorResult(IEnumerable<AuthorResult> authorResult)
			=> authorResult.Select((author) => new AuthorResultImgage(author));
	}
}
