using DomainModel.ResultsRequest;

namespace DomainModel.Integration
{
	public interface IUserAvatarInteractive
	{
		Task<UserAvatarResult> GetUserAvatarByIdAsync(int id);
	}
}
