using DomainModel.ResultsRequest;

namespace DomainModel.Integration
{
	public interface IAuthorResultGetter
	{
		Task<IEnumerable<AuthorResult>> GetAuthors();
		Task<IEnumerable<AuthorResult>> GetAuthorsByName(string Name);
	}
}
