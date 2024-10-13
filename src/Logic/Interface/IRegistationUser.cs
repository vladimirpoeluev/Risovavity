using DomainModel.Model;
using DomainModel.ResultsRequest;

namespace Logic.Interface
{
	public interface IRegistationUser
	{
		void RegistrationUser(RegistrationForm user);
		void CheckEmail(string code);
	}
}
