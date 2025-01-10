
using DataIntegration.Interface.InterfaceOfModel;
using DomainModel.Integration;
using DomainModel.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Logic
{
	public class TwoFactorAuthService : ITwoFactorAuthService
	{
		private IDataBaseModel _dataBaseModel;
		private int UserId { get; set; }
		public TwoFactorAuthService(IDataBaseModel data, IHttpContextAccessor httpContext) 
		{
			_dataBaseModel = data;
			UserId = int.Parse(httpContext.HttpContext.User.Claims.First(e => e.Type == ClaimTypes.Sid).Value);
		}
		public async Task<bool> GetAsync()
		{
			return await _dataBaseModel.Users.Where(e => e.Id == UserId).Select(e => e.UseTwoFactorAuthentication).FirstAsync() ?? false;
		}

		public async Task SetAsync(bool value)
		{
			var user = new User();
			user.Id = UserId;
			user.UseTwoFactorAuthentication = value;
			_dataBaseModel.Users.Attach(user);
			_dataBaseModel.Entry(user).Property(e => e.UseTwoFactorAuthentication).IsModified = true;
			await _dataBaseModel.SaveChangesAsync();
		}
	}
}
