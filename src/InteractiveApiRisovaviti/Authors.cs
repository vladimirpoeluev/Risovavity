using DomainModel.Integration;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.ControllerIntegration;
using InteractiveApiRisovaviti.ControllerIntegration.AuthorsController;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
	public class Authors : IAuthorResultGetter
	{
		IAuthorControllerIntegration _authorsController;
		GetRangeControllerIntegration _authorsGetRange;
		IGetAutoControllerIntegraion _controllerIntegration;

		int _skip = 0;
		int _take = 0;

		public Authors(IAuthenticationUser user) 
		{
			_authorsController = new AuthorControllerIntegration(user);
			_authorsGetRange = new GetRangeControllerIntegration(user);
			_controllerIntegration = new GetAutoControllerIntegraion(user);
		}

		public IAuthorResultGetter BuidSkip(int count)
		{
			_skip = count;
			return this;
		}

		public IAuthorResultGetter BuidTake(int count)
		{
			_take = count;
			return this;
		}

		public IEnumerable<AuthorResult> GetAuthors(int skip, int take)
		{
			return _authorsGetRange.GetRange(skip, take);
		}

		public IEnumerable<AuthorResult> GetAuthors()
		{
			return _authorsController.GetAuthors();
		}

		public async Task<IEnumerable<AuthorResult>> GetAuthorsById(int id)
		{
			return await _controllerIntegration.GetResultAsync<IEnumerable<AuthorResult>>($"api/Authors/getById?id={id}");
		}

		public async Task<IEnumerable<AuthorResult>> GetAuthorsByName(string name)
		{
			return await _controllerIntegration.GetResultAsync<IEnumerable<AuthorResult>>($"api/Authors/getbyname?name={name}");
		}

		async Task<IEnumerable<AuthorResult>> IAuthorResultGetter.GetAuthors()
		{
			return await _controllerIntegration.GetResultAsync<IEnumerable<AuthorResult>>($"api/Authors/getRange?skip={_skip}&take={_take}");
		}
	}
}
