using DataIntegration.Model;
using DomainModel.Integration.TotpOperation;
using DomainModel.Model;
using Microsoft.EntityFrameworkCore;
using OtpNet;

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
			byte[] key = restoreAccess.SecretKeyByte;
			Totp totp = new Totp(key);
			
			return totp.VerifyTotp(code, out long time);
		}
	}
}
