using DomainModel.ResultsRequest;

namespace DomainModel.Integration
{
	public interface IAuthorResultGetter
	{
		Task<IEnumerable<AuthorResult>> GetAuthors();
		Task<IEnumerable<AuthorResult>> GetAuthorsByName(string name);
		Task<IEnumerable<AuthorResult>> GetAuthorsById(int id);
		void BuidTake(int count);
		void BuidSkip(int count);
	}
}
