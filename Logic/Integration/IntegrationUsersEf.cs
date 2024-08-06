using DomainModel.Integration;
using DataIntegration.Model;
using DomainModel.Model;


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
			return db.Users.First(u => u.Id == id);

		}

		public User[] Get()
		{
			return db.Users.ToArray();
		}

		public User[] Get(string login, string password)
		{
			return db.Users.Where(user => user.Login == login && user.Password == password).ToArray();
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
