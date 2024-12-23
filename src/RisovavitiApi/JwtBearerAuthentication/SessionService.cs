using DomainModel.ResultsRequest;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class SessionService
	{
		public SessionService() { }

		public SessionAuthorizeObject SessionAuthorizeObject(UserResult user)
		{

			return new SessionAuthorizeObject();
		}

		public void DeleteSession(string refresh)
		{

		}

	}
}
