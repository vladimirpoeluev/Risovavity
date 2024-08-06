using DomainModel.Model;

namespace Logic.Interface
{
	public interface IGetUser
	{
		IEnumerable<User> Get();
		User Get(int id);
	}
}
