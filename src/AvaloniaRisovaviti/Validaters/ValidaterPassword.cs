

using Newtonsoft.Json.Serialization;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.Validaters
{
	public class ValidaterPassword : IValidaterPassword
	{
		public bool IsValid { get; private set; }

		public string Error { get; private set; } = string.Empty;

		private ValidaterPassword(){}

		public static ValidaterPassword CreateValidaterPassword(string password) 
		{
			var result = new ValidaterPassword();
			result.IsValid = true;
			result.IsValid &= IsNotNull(password);
			return result;
		}

		static bool IsNotNull(string password)
		{
			return password != null && password != string.Empty;
		}
	}
}
