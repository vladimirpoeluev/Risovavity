using DataIntegration.Model;
using DomainModel.Integration.TotpOperation;
using DomainModel.Model;
using Microsoft.EntityFrameworkCore;
using OtpNet;
using System.Text;

namespace Logic.ToptOperation
{
	public class VerificaterTotp : IVerifycaterTotp
	{
		DatabaseContext context;
		public VerificaterTotp(DatabaseContext context) 
		{
			this.context = context;
		}

		public async Task<bool> VerifycaterTotpAsync(int id, string code)
		{
			TotpRestoreAccess? restoreAccess = await context.TotpRestoreAccesses.FirstOrDefaultAsync(o => o.UserId == id);
			if (restoreAccess == null)
			{
				return false;
			}
			Totp totp = new Totp(Encoding.ASCII.GetBytes(restoreAccess.SecretKey));
			
			return totp.VerifyTotp(DateTime.Now, code, out long time);
		}
	}
}
