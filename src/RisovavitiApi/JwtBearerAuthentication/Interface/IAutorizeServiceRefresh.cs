using DomainModel.ResultsRequest;
using RisovavitiApi.Model;

namespace RisovavitiApi.JwtBearerAuthentication.Interface
{
	public interface IAutorizeServiceRefresh 
	{
		Task<TokensRefreshAndAccess> ExtendSession(string refresh);
		Task<TokensRefreshAndAccess> RegistSession(UserResult user);
	}
}
