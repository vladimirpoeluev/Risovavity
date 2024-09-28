using DomainModel.Model;
using System.Security.Claims;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class InputerSystem : IInputerSystem
	{
		ICreaterToken СreaterToken { get; set; }
		public InputerSystem(User user) 
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Name),
				new Claim(ClaimTypes.Role, user.Role.Name),
			};

			this.СreaterToken = CreaterToken.TokenGeneratorBasedOnClaim(claims);
		}

		public string InputUser()
		{
			return СreaterToken.GenerateToken();
		}
	}
}
