﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Logic.JwtBearerAuthentication
{
	public class OptionsJwtTokens
	{
		public static string ISSUER { get; } = "MyAuthServer";
		public static string AUDIENCE { get; } = "MyAuthClient";
		private static string KEY { get; } = "mysupersecret_secretsecretsecretkey!123";
		private static string KEYRefresh { get; } = "mysupersecret_secretsecretsecretkey!321";
		private static string KEYRestore{ get; } = "mysupersecret_secretsecretsecretkey!312";
		public static DateTime Expires { get => DateTime.UtcNow.Add(TimeSpan.FromMinutes(10)); }
		public static DateTime ExpiresRefresh { get => DateTime.UtcNow.Add(ExpiresRefreshTimeSpan); }
		public static TimeSpan ExpiresRefreshTimeSpan { get; } = TimeSpan.FromDays(15);

		public static SymmetricSecurityKey GetSecurityKey() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
		public static SymmetricSecurityKey GetSecurityKeyRefresh() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEYRefresh));
		public static SymmetricSecurityKey GetSecurityKeyRestore() => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEYRestore));
	}
}
