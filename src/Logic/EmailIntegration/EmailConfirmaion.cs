﻿
using DataIntegration.Interface;
using DomainModel.Exceptions;
using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.EmailResult;
using Logic.EmailIntegration.Interface;
using Logic.Interface;

namespace Logic.EmailIntegration
{
    public class EmailConfirmaion : IEmailConfirmaion
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
			if (keys.Count() > 0)
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
			await DeleteOldRecordWait(registrationForm);
			string code = CodeGenerater.Generate();
			await _emailService.SendMessageAsync(registrationForm.Email, code);
			await _redis.AddObject($"emailWait:{registrationForm.Email}:{code}", registrationForm, TimeSpan.FromMinutes(10));

		}

		private async Task DeleteOldRecordWait(RegistrationForm registrationForm)
		{
			IEnumerable<string> keys = await _redis.GetKeys($"emailWait:{registrationForm.Email}:*");
			foreach (string key in keys)
			{
				await _redis.DeleteObject(key);
			}
		}
	}
}
