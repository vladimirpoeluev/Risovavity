
using DataIntegration.Model;
using DomainModel.Integration.TotpOperation;
using DomainModel.Model;
using DomainModel.ResultsRequest.TotpModels;
using Microsoft.EntityFrameworkCore;
using OtpNet;

namespace Logic.ToptOperation
{
	public class TotpGetter : ITotpGetter
	{
		DatabaseContext context;
		public TotpGetter(DatabaseContext context)
		{
			this.context = context;
		}
		
		public async Task<TotpKeysResult> CreateKeyAsync(int userId)
		{
			await context.TotpRestoreAccesses.Where(entityt => entityt.UserId == userId).ExecuteDeleteAsync();
			
			TotpRestoreAccess restoreAccess = await AddTotprestoreAccess(userId);


			return new TotpKeysResult() 
			{
				TotpKeysForQR = new OtpUri(OtpType.Totp, restoreAccess.SecretKey, "Risovavity").ToString(),
				TotpKeys = restoreAccess.SecretKey.ToString()
			};
		}

		private async Task<TotpRestoreAccess> AddTotprestoreAccess(int userId)
		{
			byte[] key = KeyGeneration.GenerateRandomKey(20);
			await context.AddAsync(new TotpRestoreAccess() 
			{
				SecretKey = Base32Encoding.ToString(key),
				SecretKeyByte = key,
				UserId = userId
			});
			await context.SaveChangesAsync();
			return context.TotpRestoreAccesses.FirstOrDefault((o) => o.UserId == userId);
		}
	}
}
