using DomainModel.Integration;
using DomainModel.ResultsRequest;

namespace Logic.AuthorsIntegration
{
	internal class AuthorGetter : IAuthorResultGetter
	{
		public Task<IEnumerable<AuthorResult>> GetAuthors()
		{
			throw new NotImplementedException();
		}

		public Task<IEnumerable<AuthorResult>> GetAuthorsByName(string Name)
		{
			throw new NotImplementedException();
		}
	}
}
