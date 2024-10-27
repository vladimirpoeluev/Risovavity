using DomainModel.Integration;
using DataIntegration.Model;
using DomainModel.Model;
using Microsoft.EntityFrameworkCore;
using DomainModel.Filter;

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
			db.Users.Add(user);
			db.SaveChanges();
			return true;
		}

		public User Get(int id)
		{
			var user = db.Users
					.Include(u => u.Role)
					.Where(u => u.Id == id)
					.First();
			return user;
		}

		public User[] Get()
		{
			return db.Users.ToArray();
		}

		public User[] Get(string login)
		{
			var result = db.Users.Where(user => user.Login == login);
			result = result.Select(x => x)
						.Include(u => u.Role);
			return result.ToArray();
		}

		public User Get(UserNameFilter userNameFilter)
		{
			var result = db.Users.Include(user => user.Role).Where(user => user.Name == userNameFilter.Name).First();
			return result;
		}

		public User Get(UserOfLoginFilter userOfLoginFilter)
		{
			return db.Users.Where((user) => user.Login == userOfLoginFilter.Login).First();
		}

		public bool Remove(User user)
		{
			throw new NotImplementedException();
		}

		public bool Update(User user, User newUser)
		{ 
			var updatedUser = db.Users.First((item) => item.Id == user.Id);

			updatedUser.Icon = newUser.Icon;
			updatedUser.Email = newUser.Email;
			updatedUser.Password = newUser.Password;
			updatedUser.Login = newUser.Login;
			updatedUser.IdRole = updatedUser.IdRole;
			updatedUser.Name = newUser.Name;
			updatedUser.Role = newUser.Role;
			db.Entry(updatedUser).State = EntityState.Modified;
			db.SaveChanges();
			return true;
		}
	}
}
