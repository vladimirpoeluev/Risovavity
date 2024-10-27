namespace TestRisovaviti
{
	using Logic.HashPassword;
	public class TestPasswordHeshed
	{
		[Fact]
		public void Test1()
		{
			string password = "password";
			GeneraterHash generater = new GeneraterHash();
			Assert.True(generater.Verify(password, generater.Generate(password)));
		}
	}
}