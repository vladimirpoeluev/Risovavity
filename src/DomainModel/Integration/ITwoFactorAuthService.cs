

namespace DomainModel.Integration
{
	public interface ITwoFactorAuthService
	{
		Task SetAsync(bool value);
		Task<bool> GetAsync();
	}
}
