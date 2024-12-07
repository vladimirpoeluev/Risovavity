using AvaloniaRisovaviti.Cript.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace AvaloniaRisovaviti.Cript
{
	public class EncryptionCreater : IEncrytionCreater
	{
		private byte[] _iv;
		public string Cryted(string value)
		{
			RSA rsa = RSA.Create();
			rsa.KeySize = 32;
			Aes aes = Aes.Create();
			byte[] key =
			{
				0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
				0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
			};
			aes.Key = key;
			byte[] iv = aes.IV;
			_iv = iv;
			byte[] stringEn = aes.EncryptCbc(Encoding.UTF8.GetBytes(value), iv);
			return Encoding.ASCII.GetString(stringEn);
		}

		public string Decryted(string value)
		{
			RSA rSA = RSA.Create();
			rSA.KeySize = 32;
			return Encoding.UTF8.GetString(rSA.Decrypt(Encoding.UTF8.GetBytes(value), RSAEncryptionPadding.Pkcs1));
		}
	}
}
