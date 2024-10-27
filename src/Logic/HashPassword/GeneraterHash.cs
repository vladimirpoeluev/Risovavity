using Logic.Interface;

namespace Logic.HashPassword
{
	public class GeneraterHash : IGeneraterHash
	{
		public string Generate(string password)
		{
			return BCrypt.Net.BCrypt.EnhancedHashPassword(password);
		}

		public bool Verify(string password, string hash)
		{
			return BCrypt.Net.BCrypt.EnhancedVerify(password, hash);
		}
	}
}
