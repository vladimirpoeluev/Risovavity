using Logic.JwtBearerAuthentication;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Logic.ToptOperation
{
	public class CreaterTokenForRestore : CreaterToken
	{
		public CreaterTokenForRestore() { }

		public List<Claim> Claims { get; set; } = new List<Claim>();

		protected override JwtSecurityToken CreateJwt()
		{
			return new JwtSecurityToken(
				issuer: OptionsJwtTokens.ISSUER,
				audience: OptionsJwtTokens.AUDIENCE,
				claims: Claims,
				expires: OptionsJwtTokens.Expires,
				signingCredentials: new SigningCredentials(OptionsJwtTokens.GetSecurityKeyRestore(), SecurityAlgorithms.HmacSha256)
				);
		}
	}
}
