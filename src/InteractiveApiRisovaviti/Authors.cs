using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.ControllerIntegration.AuthorsController;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	public class Authors
	{
		IAuthorControllerIntegration _authorsController;
		GetRangeControllerIntegration _authorsGetRange;

		public Authors(IAuthenticationUser user) 
		{
			_authorsController = new AuthorControllerIntegration(user);
			_authorsGetRange = new GetRangeControllerIntegration(user);
		}

		public IEnumerable<AuthorResult> GetAuthors(int skip, int take)
		{
			return _authorsGetRange.GetRange(skip, take);
		}

		public IEnumerable<AuthorResult> GetAuthors()
		{
			return _authorsController.GetAuthors();
		}
	}
}
