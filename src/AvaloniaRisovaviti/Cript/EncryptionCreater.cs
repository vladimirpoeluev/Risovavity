using AvaloniaRisovaviti.Cript.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace AvaloniaRisovaviti.Cript
{
	public class EncryptionCreater : IEncrytionCreater
	{
		public string Cryted(string value)
		{
			RSA rsa = RSA.Create();
			return Encoding.UTF8.GetString(rsa.Encrypt(Encoding.ASCII.GetBytes(value), RSAEncryptionPadding.Pkcs1));

		}

		public string Decryted(string value)
		{
			RSA rSA = RSA.Create();
			return Encoding.UTF8.GetString(rSA.Decrypt(Encoding.ASCII.GetBytes(value), RSAEncryptionPadding.Pkcs1));
		}
	}
}
