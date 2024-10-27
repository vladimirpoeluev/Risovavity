using DomainModel.Filter;
using DomainModel.Integration;
using DomainModel.Model;
using DomainModel.ResultsRequest;
using Logic.HashPassword;
using Logic.Interface;

namespace Logic
{
	public class RegistrationUser : IRegistationUser
	{
		public IRuleIntegrationUser User { get; set; }
		private IGeneraterHash _generaterHash;
		public RegistrationUser(IRuleIntegrationUser user) 
		{
			User = user;
			_generaterHash = new GeneraterHash();
		}

		public void CheckEmail(string code)
		{
			throw new NotImplementedException();
		}

		void IRegistationUser.RegistrationUser(RegistrationForm user)
		{
			if (!CheckForLogin(user.GetUser()))
			{
				user.Password = _generaterHash.Generate(user.Password);
				User.Add(user.GetUser());
			}
				
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
