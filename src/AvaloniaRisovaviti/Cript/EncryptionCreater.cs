using AvaloniaRisovaviti.Cript.Interfaces;
using System;
using System.Security.Cryptography;

namespace AvaloniaRisovaviti.Cript
{
	internal class EncryptionCreater : IEncrytionCreater
	{
		public string Cryted(string value)
		{
			using Aes aes = Aes.Create();
			aes.Key = 
				[ 
					0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08,
					0x09, 0x10, 0x11, 0x12, 0x13, 0x14, 0x15, 0x16
				];
		}

		public string Decryted(string value)
		{
			throw new NotImplementedException();
		}
	}
}
