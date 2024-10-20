using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	public class Authors
	{
		IAuthorControllerIntegration _authorsController;

		public Authors(IAuthenticationUser user) 
		{
			_authorsController = new AuthorControllerIntegration(user);
		}

		public IEnumerable<AuthorResult> GetAuthors()
		{
			return _authorsController.GetAuthors();
		}
	}
}
