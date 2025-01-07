using Microsoft.IdentityModel.Tokens;
using Logic.JwtBearerAuthentication.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Logic.JwtBearerAuthentication
{
	public class CreaterTokenForRefresh : CreaterToken
	{
		protected override JwtSecurityToken CreateJwt()
		{
			return new JwtSecurityToken(
				issuer: OptionsJwtTokens.ISSUER,
				audience: OptionsJwtTokens.AUDIENCE,
				claims: Claims,
				expires: OptionsJwtTokens.ExpiresRefresh,
				signingCredentials: new SigningCredentials(OptionsJwtTokens.GetSecurityKeyRefresh(), SecurityAlgorithms.HmacSha256)
				);
		}
	}
}
