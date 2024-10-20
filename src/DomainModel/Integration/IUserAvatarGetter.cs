
using DomainModel.ResultsRequest;

namespace DomainModel.Integration
{
	public interface IUserAvatarGetter
	{
		Task<UserAvatarResult> GetAvatarUserAsync(int id);
	}
}
