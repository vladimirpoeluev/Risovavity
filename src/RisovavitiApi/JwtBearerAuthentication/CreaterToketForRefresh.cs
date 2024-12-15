using Microsoft.IdentityModel.Tokens;
using RisovavitiApi.JwtBearerAuthentication.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class CreaterToketForRefresh : CreaterToken
	{
		protected override JwtSecurityToken CreateJwt()
		{
			return new JwtSecurityToken(
				issuer: OptionsJwtTokens.ISSUER,
				audience: OptionsJwtTokens.AUDIENCE,
				claims: Claims,
				expires: OptionsJwtTokens.Expires,
				signingCredentials: new SigningCredentials(OptionsJwtTokens.GetSecurityKeyRefresh(), SecurityAlgorithms.HmacSha256)
				);
		}
	}
}
