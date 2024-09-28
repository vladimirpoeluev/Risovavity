using System.Security.Claims;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public interface ICreaterToken
	{
		string GenerateToken();
		List<Claim> Claims { get; set;  }
	}
}
