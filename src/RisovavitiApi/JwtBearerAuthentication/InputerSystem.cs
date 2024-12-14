using DomainModel.Model;
using System.Security.Claims;
using Logic.Interface;
using RisovavitiApi.JwtBearerAuthentication.Interface;

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
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role.Name ?? "User"),
				new Claim(ClaimTypes.Sid, user.Id.ToString())
			};
			this.СreaterToken.Claims = claims;
			return СreaterToken.GenerateToken();
		}
	}
}
