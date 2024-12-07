

using AvaloniaRisovaviti.Cript;

namespace TestRisovaviti
{
	public class TestsEncyptionCreater
	{
		[Fact]
		public void TestsEncryptiToDeencrypti()
		{
			string token = "UEGRGSURHISHERPLAIRO3898394H3URHAIFHO4HFUH39Q48HW3UO4H7W5UGW895GHWU945H8WGU9I";
			EncryptionCreater enc = new EncryptionCreater();

			string encryptiToken = enc.Cryted(token);
			string dencryptiToken = enc.Decryted(token);
			Assert.Equal(token, dencryptiToken);
		}
	}
}
