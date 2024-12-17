namespace AvaloniaRisovaviti.Cript
{
	using AvaloniaRisovaviti.Cript.Interfaces;
	using InteractiveApiRisovaviti.HttpIntegration;
	using InteractiveApiRisovaviti.Interface;
	using System;
	using System.IO;
	using System.Net.Http;
	using System.Security.Cryptography;
	using System.Text;
	using System.Threading.Tasks;

	/// <summary>
	/// Defines the <see cref="EncryptionSession" />
	/// </summary>
	internal class EncryptionSession : IEncryptionSession
	{
		/// <summary>
		/// Defines the path
		/// </summary>
		internal const string path = "x.txt";

		/// <summary>
		/// Defines the _encrytionCreater
		/// </summary>
		internal IEncrytionCreater _encrytionCreater;

		/// <summary>
		/// Initializes a new instance of the <see cref="EncryptionSession"/> class.
		/// </summary>
		/// <param name="encrytionCreater">The encrytionCreater<see cref="IEncrytionCreater"/></param>
		public EncryptionSession(IEncrytionCreater encrytionCreater)
		{
			_encrytionCreater = encrytionCreater;
		}

		/// <summary>
		/// The TryGetSession
		/// </summary>
		/// <param name="session">The session<see cref="IAuthenticationUser"/></param>
		/// <returns>The <see cref="bool"/></returns>
		public bool TryGetSession(out IAuthenticationUser session)
		{
			try
			{
				session = GetSessionAsync().Result;
				return true;
			}
			catch (Exception)
			{
				session = null;
				return false;
			}
		}

		/// <summary>
		/// The GetSessionAsync
		/// </summary>
		/// <returns>The <see cref="Task{IAuthenticationUser}"/></returns>
		public async Task<IAuthenticationUser> GetSessionAsync()
		{
			using (FileStream fileStream = new(path, FileMode.Open))
			{
				using (Aes aes = Aes.Create())
				{
					byte[] iv = new byte[aes.IV.Length];
					int numBytesToRead = aes.IV.Length;
					int numBytesRead = 0;
					while (numBytesToRead > 0)
					{
						int n = fileStream.Read(iv, numBytesRead, numBytesToRead);
						if (n == 0) break;

						numBytesRead += n;
						numBytesToRead -= n;
					}

					byte[] key =
					{
				0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
				0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
			};

					using (CryptoStream cryptoStream = new(
					   fileStream,
					   aes.CreateDecryptor(key, iv),
					   CryptoStreamMode.Read))
					{
						using (StreamReader decryptReader = new(cryptoStream))
						{
							string decryptedMessage = decryptReader.ReadToEnd().Trim();
							if (decryptedMessage == string.Empty)
								throw new Exception();
							return new AuthenticationUser(decryptedMessage);
						}
					}
				}
			}
		}

		/// <summary>
		/// The SetSessionAsync
		/// </summary>
		/// <param name="sessionName">The sessionName<see cref="string"/></param>
		/// <returns>The <see cref="Task"/></returns>
		public async Task SetSessionAsync(IAuthenticationUser sessionName)
		{
			using (FileStream fileStream = new(path, FileMode.Create))
			{
				using (Aes aes = Aes.Create())
				{
					byte[] key =
					{
						0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
						0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
					};
					aes.Key = key;

					byte[] iv = aes.IV;
					fileStream.Write(iv, 0, iv.Length);

					using (CryptoStream cryptoStream = new(
						fileStream,
						aes.CreateEncryptor(),
						CryptoStreamMode.Write))
					{
						using (StreamWriter encryptWriter = new(cryptoStream))
						{
							await encryptWriter.WriteLineAsync(GetToken(sessionName));
						}
					}
				}
			}
		}

		private string GetToken(IAuthenticationUser user)
		{
			if(user is IAuthenticationUserForSave)
			{
				var userForSave = (IAuthenticationUserForSave)user;
				Stream stream = userForSave.Stream;
				byte[] bytes = new byte[stream.Length];
				stream.Read(bytes, 0, (int)stream.Length);
				return Encoding.ASCII.GetString(bytes);
			}
			var client = new HttpClient();
			user.SettingUpDataProvisioning(client);
			return client.DefaultRequestHeaders.Authorization?.Parameter ?? string.Empty;
		}


	}
}
