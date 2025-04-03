using DomainModel.ResultsRequest.TotpModels;

namespace DomainModel.Integration.TotpOperation
{
	public interface ITotpGetter
	{
		Task<TotpKeysResult> CreateKeyAsync(int userId);
	}
}
