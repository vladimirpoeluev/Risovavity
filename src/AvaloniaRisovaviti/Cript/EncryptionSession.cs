

using AvaloniaRisovaviti.Cript.Interfaces;
using InteractiveApiRisovaviti.HttpIntegration;
using InteractiveApiRisovaviti.Interface;
using System.IO;
using System.Threading.Tasks;
using System;

namespace AvaloniaRisovaviti.Cript
{
    internal class EncryptionSession : IEncryptionSession
	{
		const string path = "/sesions/.cr";
		IEncrytionCreater _encrytionCreater;
		public EncryptionSession(IEncrytionCreater encrytionCreater)
		{
			_encrytionCreater = encrytionCreater;
		}

		public bool TryGetSession(out IAuthenticationUser session)
		{
			try
			{
				session = GetSessionAsync().Result;
				return true;
			}
			catch (Exception)
			{
				session = GetSessionAsync().Result;
				return false;
			}
		}

		public async Task<IAuthenticationUser> GetSessionAsync()
		{
			using StreamReader reader = new StreamReader(path);
			string token = await reader.ReadLineAsync() ?? throw new Exception("There have not token");
			return new AuthenticationUser(token);
		}

		public async Task SetSessionAsync(string sessionName)
		{
			using StreamWriter writer = new StreamWriter(path);
			await writer.WriteLineAsync(_encrytionCreater.Cryted(sessionName));
		}
	}
}
