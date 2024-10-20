
using DomainModel.ResultsRequest;

namespace InteractiveApiRisovaviti.Interface
{
	internal interface IAuthorControllerIntegration
	{
		IEnumerable<AuthorResult> GetAuthors();
	}
}
