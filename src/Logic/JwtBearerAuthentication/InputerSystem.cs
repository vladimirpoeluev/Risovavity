using DomainModel.Model;
using System.Security.Claims;
using Logic.Interface;
using Logic.JwtBearerAuthentication.Interface;

namespace RisovavitiApi.JwtBearerAuthentication
{
    public class InputerSystem : IInputerSystem, IInputerSystemWithRefresh
	{
		ICreaterToken СreaterToken { get; set; }

		public string RefreshToken { get; set; }

		public InputerSystem(ICreaterToken createrToken) 
		{
			this.СreaterToken = createrToken;
			this.RefreshToken = string.Empty;
		}

		public string InputUser(User user)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.Name),
				new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name ?? "User"),
				new Claim(ClaimTypes.Sid, user.Id.ToString()),
				new Claim(ClaimTypes.Authentication, RefreshToken),
			};
			this.СreaterToken.Claims = claims;
			return СreaterToken.GenerateToken();
		}
	}
}
