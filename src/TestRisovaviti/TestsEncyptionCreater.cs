

using AvaloniaRisovaviti.Cript;

namespace TestRisovaviti
{
	public class TestsEncyptionCreater
	{
		[Fact]
		public void TestsEncryptiToDeencrypti()
		{
			string token = "UEGRGSURHIS";
			EncryptionCreater enc = new EncryptionCreater();

			string encryptiToken = enc.Cryted(token);
			string dencryptiToken = enc.Decryted(token);
			Assert.Equal(token, dencryptiToken);
		}
	}
}
