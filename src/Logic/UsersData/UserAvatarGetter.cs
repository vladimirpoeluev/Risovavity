using DataIntegration.Model;
using DomainModel.Integration;
using DomainModel.ResultsRequest;
using Microsoft.EntityFrameworkCore;

namespace Logic.UsersData
{
	public class UserAvatarGetter : IUserAvatarGetter
	{
		DatabaseContext _db { get; set; }

		public UserAvatarGetter(DatabaseContext db) 
		{
			_db = db;
		}

		Task<UserAvatarResult> IUserAvatarGetter.GetAvatarUserAsync(int id)
			=> _db.Users.Where((user) => user.Id == id).Select(u 
				=> new UserAvatarResult() 
				{ 
					UserName = u.Name, 
					AvatarResult = u.Icon 
				}).FirstAsync();
	}
}
