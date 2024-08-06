using DomainModel.Integration;
using DomainModel.Model;
using Logic.Interface;

namespace Logic
{
	public class GetUsers : IGetUser
	{
		private readonly IRuleIntegrationUser _integrationUser;

		public GetUsers(IRuleIntegrationUser integrationUser) 
		{
			_integrationUser = integrationUser;
		}

		IEnumerable<User> IGetUser.Get()
		{
			return _integrationUser.Get();
		}

		User IGetUser.Get(int id)
		{
			return _integrationUser.Get(id);
		}
	}
}
