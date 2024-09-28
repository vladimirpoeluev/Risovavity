using DomainModel.Model;
using System.Security.Claims;
using Logic.Interface;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class InputerSystem : IInputerSystem
	{
		ICreaterToken СreaterToken { get; set; }
		public InputerSystem(ICreaterToken createrToken) 
		{
			this.СreaterToken = createrToken;
		}

		public string InputUser(User user)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Name),
				new Claim(ClaimTypes.Role, user.Role.Name),
			};
			this.СreaterToken.Claims = claims;
			return СreaterToken.GenerateToken();
		}
	}
}
