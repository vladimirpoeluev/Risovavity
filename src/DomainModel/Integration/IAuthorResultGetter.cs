using DomainModel.ResultsRequest;

namespace DomainModel.Integration
{
	public interface IAuthorResultGetter
	{
		Task<IEnumerable<AuthorResult>> GetAuthors();
		Task<IEnumerable<AuthorResult>> GetAuthorsByName(string name);
		Task<IEnumerable<AuthorResult>> GetAuthorsById(int id);
		IAuthorResultGetter BuidTake(int count);
		IAuthorResultGetter BuidSkip(int count);
	}
}
