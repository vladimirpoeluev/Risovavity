using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace RisovavitiApi.JwtBearerAuthentication
{
	public class OptionsJwtTokens
	{
		public static string ISSUER { get; } = "MyAuthServer";
		public static string AUDIENCE { get; } = "MyAuthClient";
		private static string KEY { get; } = "mysupersecret_secretsecretsecretkey!123";
		public static DateTime Expires { get; } = DateTime.UtcNow.Add(TimeSpan.FromDays(1));

		public static SymmetricSecurityKey GetSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
	}
}
