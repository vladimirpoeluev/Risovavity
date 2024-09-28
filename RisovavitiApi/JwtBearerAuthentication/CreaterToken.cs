using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class CreaterToken : ICreaterToken
	{
		private List<Claim> claims;

		private CreaterToken()
		{
			claims = new List<Claim>();
		}

		public string GenerateToken()
		{
			var jwt = CreateJwt();
			return new JwtSecurityTokenHandler().WriteToken(jwt);
		}

		private JwtSecurityToken CreateJwt()
		{
			return new JwtSecurityToken(
				issuer: OptionsJwtTokens.ISSUER,
				audience: OptionsJwtTokens.AUDIENCE,
				claims: claims,
				expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
				signingCredentials: new SigningCredentials(OptionsJwtTokens.GetSecurityKey(), SecurityAlgorithms.HmacSha256)
				);
		}

		public static CreaterToken TokenGeneratorBasedOnClaim(List<Claim> claims)
		{
			var creater = new CreaterToken();
			creater.claims = claims;
			return creater;
		}
	}
}
