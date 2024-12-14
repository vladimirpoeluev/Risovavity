using DomainModel.ResultsRequest;
using RisovavitiApi.Model;

namespace RisovavitiApi.JwtBearerAuthentication.Interface
{
	public interface IAutorizeServiceRefresh 
	{
		TokensRefreshAndAccess ExtendSession(string refresh);
		TokensRefreshAndAccess RegistSession(UserResult user);
	}
}
