using DomainModel.ResultsRequest;

namespace InteractiveApiRisovaviti.Interface
{
    public interface IAuthorGetter
    {
        Task<AuthorResult> GetAuthorAsync(int id);
        Task<IEnumerable<AuthorResult>> GetAuthorsByNameAsync(string name);
        Task<IEnumerable<AuthorResult>> GetAuthorsRange(int skip, int take);
    }
}