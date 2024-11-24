
using DomainModel.Integration;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface;

namespace InteractiveApiRisovaviti
{
    public class AuthorGetter : IAuthorGetter
	{
		IAuthorResultGetter _authorsIntegration;
		public AuthorGetter(IAuthenticationUser user)
		{
			_authorsIntegration = new Authors(user);
		}

		public async Task<AuthorResult> GetAuthorAsync(int id)
		{
			IEnumerable<AuthorResult> authors = await _authorsIntegration.GetAuthorsById(id);
			AuthorResult result = authors.First();
			return result;
		}

		public async Task<IEnumerable<AuthorResult>> GetAuthorsByNameAsync(string name)
		{
			IEnumerable<AuthorResult> authors = await _authorsIntegration.GetAuthorsByName(name);
			return authors;
		}

		public async Task<IEnumerable<AuthorResult>> GetAuthorsRange(int skip, int take)
		{
			_authorsIntegration.BuidSkip(skip);
			_authorsIntegration.BuidTake(take);
			IEnumerable<AuthorResult> authors = await _authorsIntegration.GetAuthors();
			return authors;
		}
	}
}
