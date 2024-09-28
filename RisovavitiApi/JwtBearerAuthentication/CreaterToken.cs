using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class CreaterToken : ICreaterToken
	{
		public List<Claim> Claims { get; set; }

		public CreaterToken() 
		{
			Claims = new List<Claim>();
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
				claims: Claims,
				expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
				signingCredentials: new SigningCredentials(OptionsJwtTokens.GetSecurityKey(), SecurityAlgorithms.HmacSha256)
				);
		}

		public static CreaterToken TokenGeneratorBasedOnClaim(List<Claim> claims)
		{
			var creater = new CreaterToken();
			creater.Claims = claims;
			return creater;
		}
	}
}
