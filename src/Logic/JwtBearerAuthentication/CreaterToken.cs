﻿using Microsoft.IdentityModel.Tokens;
using Logic.JwtBearerAuthentication.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Logic.JwtBearerAuthentication
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

		protected virtual JwtSecurityToken CreateJwt()
		{
			return new JwtSecurityToken(
				issuer: OptionsJwtTokens.ISSUER,
				audience: OptionsJwtTokens.AUDIENCE,
				claims: Claims,
				expires: OptionsJwtTokens.Expires,
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
