using DomainModel.ResultsRequest;
using DomainModel.JwtModels;

namespace Logic.JwtBearerAuthentication.Interface
{
	public interface IAutorizeServiceRefresh 
	{
		Task<TokensRefreshAndAccess> ExtendSession(string refresh);
		Task<TokensRefreshAndAccess> RegistSession(UserResult user);
	}
}
