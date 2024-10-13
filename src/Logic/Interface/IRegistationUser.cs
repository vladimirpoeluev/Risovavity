using DomainModel.Model;

namespace Logic.Interface
{
	public interface IRegistationUser
	{
		void RegistrationUser(User user);
		void CheckEmail(string code);
	}
}
