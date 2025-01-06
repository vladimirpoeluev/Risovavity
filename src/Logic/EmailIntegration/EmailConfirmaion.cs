
using DataIntegration.Interface;
using DomainModel.Exceptions;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.EmailResult;
using Logic.EmailIntegration.Interface;
using Logic.Interface;

namespace Logic.EmailIntegration
{
	public class EmailConfirmaion
	{
		IRedisService _redis;
		IRegistationUser _registation;
		IEmailService _emailService;
		public EmailConfirmaion(IRedisService redis, IRegistationUser registation, IEmailService email)
		{
			_redis = redis;
			_emailService = email;
			_registation = registation;
		}

		public async Task Valid(EmailConfirmaionResult confirmaion)
		{
			IEnumerable<string> keys = await _redis.GetKeys($"emailWait:{confirmaion.Email}:{confirmaion.Code}");
			if(keys.Count() > 0)
			{
				_registation.RegistrationUser(await _redis.GetObject<RegistrationForm>(keys.First()));
				await _redis.DeleteObject(keys.First());
			}
			else
			{
				throw new VerificateEmailException();
			}
		}

		public async Task AddToPendingConfirmation(RegistrationForm registrationForm)
		{
			string code = CodeGenerate();
			await _redis.AddObject($"emailWait:{registrationForm.Email}:{code}", registrationForm);

			await _emailService.SendMessageAsync(registrationForm.Email, code);
		}

		private string CodeGenerate()
		{
			Random random = new();
			string result = string.Empty;
			for(int i = 0; i < 5; i++)
			{
				result += random.Next(9).ToString();
			}
			return result;
		}
	}
}
