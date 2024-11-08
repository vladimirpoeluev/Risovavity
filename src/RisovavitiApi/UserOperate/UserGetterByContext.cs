using DomainModel.Integration;
using DomainModel.ResultsRequest;
using Logic.Integration;
using System.Security.Claims;

namespace RisovavitiApi.UserOperate
{
	public static class UserGetterByContext
	{
		private static IRuleIntegrationUser _integrationUser;
		static UserGetterByContext()
		{
			_integrationUser = new IntegrationUsersEf();
		}

		public static UserResult GetUserIntegration(HttpContext httpContext)
		{
			int id = int.Parse(httpContext.User.Claims
							.Where((claim) => claim.Type == ClaimTypes.Sid)
							.First().Value);
			return UserResult.CreateResultFromUser(_integrationUser.Get(id));
		}
	}
}
