using DomainModel.Filter;
using DomainModel.Integration;
using DomainModel.Model;
using Logic.Interface;

namespace Logic
{
	public class RegistrationUser : IRegistationUser
	{
		public IRuleIntegrationUser User { get; set; }
		public RegistrationUser(IRuleIntegrationUser user) 
		{
			User = user;
		}

		public void CheckEmail(string code)
		{
			throw new NotImplementedException();
		}

		void IRegistationUser.RegistrationUser(User user)
		{
			if(!CheckForLogin(user))
				User.Add(user);
			else
				throw new Exception("Пользователь с таким логином существует");
		}

		bool CheckForLogin(User user)
		{
			try
			{
				return TryFindUser(user);
			}
			catch (Exception)
			{
				return false;
			}
			
		}

		bool TryFindUser(User user) 
		{
			User.Get(new UserOfLoginFilter(user.Login));
			return true;
		}
	}
}
