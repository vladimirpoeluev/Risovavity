using DomainModel.Integration;
using DomainModel.ResultsRequest;
using System.Security.Claims;

namespace RisovavitiApi.UserOperate
{
	public static class UserGetterByContext
	{
		

		public static UserResult GetUserIntegration(HttpContext httpContext, IRuleIntegrationUser integrationUser)
		{
			int id = int.Parse(httpContext.User.Claims
							.Where((claim) => claim.Type == ClaimTypes.Sid)
							.First().Value);
			return UserResult.CreateResultFromUser(integrationUser.Get(id));
		}
	}
}
