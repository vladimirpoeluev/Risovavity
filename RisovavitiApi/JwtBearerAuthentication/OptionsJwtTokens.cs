using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.IdentityModel.Protocols;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class OptionsJwtTokens
	{
		public static string ISSUER { get; } = "NighsVolk";
		public static string AUDIENCE { get; } = "User of Risovatiti";
		private static string KEY { get; } = "verysecretkey";

		public static SymmetricSecurityKey GetSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
	}
}
