using DataIntegration.Model;
using DomainModel.Integration;
using DomainModel.ResultsRequest;
using Microsoft.EntityFrameworkCore;

namespace Logic.AuthorsIntegration
{
	public class AuthorGetter : IAuthorResultGetter
	{
		private DatabaseContext _db;

		public AuthorGetter(DatabaseContext db)
		{
			_db = db;
		}

		public async Task<IEnumerable<AuthorResult>> GetAuthors() 
			=> await _db.Users.Select((user) 
				=> new AuthorResult() 
				{ 
					Name = user.Name, 
					UserId = user.Id 
				})
			.ToListAsync();			
	

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
