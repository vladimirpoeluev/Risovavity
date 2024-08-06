using DomainModel.Integration;
using DomainModel.Model;
using Logic.Integration;

namespace Logic
{
	public class SetterUser
	{
		private IRuleIntegrationUser IntegrationUsers{ get; set; }
		private User User { get; set; }

		public SetterUser(IRuleIntegrationUser integrationUsers, User user)
		{
			IntegrationUsers = integrationUsers;
			User = user;
		}

		public bool SetUserData(User newUser)
		{
			return IntegrationUsers.Update(User, newUser);
		}

		public bool SetUserImage(byte[] image)
		{
			var newUser = User;
			newUser.Icon = image;
			return IntegrationUsers.Update(User, newUser);
		}
	}
}
