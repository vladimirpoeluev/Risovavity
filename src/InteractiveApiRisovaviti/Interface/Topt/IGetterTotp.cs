using DomainModel.ResultsRequest.TotpModels;

namespace InteractiveApiRisovaviti.Interface.Topt
{
	public interface IGetterTotp
	{
		Task<TotpKeysResult> GetKey();
	}
}
