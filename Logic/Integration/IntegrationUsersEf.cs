using DomainModel.Integration;
using DataIntegration.Model;
using DomainModel.Model;
using Microsoft.EntityFrameworkCore;

namespace Logic.Integration
{
	public class IntegrationUsersEf : IRuleIntegrationUser
	{
		DatabaseContext db;
		public IntegrationUsersEf() 
		{
			db = new DatabaseContext();
		}
		public bool Add(User user)
		{
			throw new NotImplementedException();
		}

		public User Get(int id)
		{
			return db.Users
					.Include(u => u.Role)
					.First(u => u.Id == id);

		}

		public User[] Get()
		{
			return db.Users.ToArray();
		}

		public User[] Get(string login, string password)
		{
			var result = db.Users.Where(user => user.Login == login && user.Password == password);
			result = result.Select(x => x)
						.Include(u => u.Role);
			return result.ToArray();
		}

		public User Get(UserNameFilter userNameFilter)
		{
			var result = db.Users.Include(user => user.Role).Where(user => user.Name == userNameFilter.Name).First();
			return result;
		}

		public bool Remove(User user)
		{
			throw new NotImplementedException();
		}

		public bool Update(User user, User newUser)
		{
			var updatedUser = db.Users.First((item) => item.Id == user.Id);
			updatedUser = newUser;
			db.Update(updatedUser);
			return true;
		}
	}
}
