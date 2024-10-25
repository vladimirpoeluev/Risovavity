using DataIntegration.Model;
using DomainModel.Integration;
using DomainModel.ResultsRequest;
using Microsoft.EntityFrameworkCore;

namespace Logic.AuthorsIntegration
{
	public class AuthorGetter : IAuthorResultGetter
	{
		private DatabaseContext _db;
		int _take = 50;
		int _skip = 0;

		public AuthorGetter(DatabaseContext db)
		{
			_db = db;
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

		public async Task<IEnumerable<AuthorResult>> GetAuthors() 
			=> await _db.Users
			.Skip(_skip)
			.Take(_take)
			.Select((user) 
				=> new AuthorResult() 
				{ 
					Name = user.Name, 
					UserId = user.Id
				})
			.ToListAsync();

		public async Task<IEnumerable<AuthorResult>> GetAuthorsById(int id)
			=> await _db.Users.Where(user 
				=> user.Id == id).Select(user
				=> new AuthorResult()
				   {
					Name = user.Name,
					UserId = user.Id
				}).ToListAsync();

		public async Task<IEnumerable<AuthorResult>> GetAuthorsByName(string name)
			=> await _db.Users
			.Where((user) 
				=> user.Name == name)
			.Select((user) 
				=> new AuthorResult() 
				{ 
					UserId = user.Id, 
					Name = user.Name
				}).ToListAsync();

	}
}
