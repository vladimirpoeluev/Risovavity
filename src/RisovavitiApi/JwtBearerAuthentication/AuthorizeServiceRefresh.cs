using DomainModel.ResultsRequest;
using RisovavitiApi.JwtBearerAuthentication.Interface;
using RisovavitiApi.Model;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class AuthorizeServiceRefresh : IAutorizeServiceRefresh
	{

		public AuthorizeServiceRefresh()
		{ }

		public TokensRefreshAndAccess ExtendSession(string refresh)
		{
			throw new NotImplementedException();
		}

		public TokensRefreshAndAccess RegistSession(UserResult user)
		{
			throw new NotImplementedException();
		}
	}
}
