using System.Collections.Generic;
using System.Linq;

namespace AvaloniaRisovaviti.Validaters
{
	public class ValidaterPassword : IValidaterPassword
	{
		public bool IsValid { get; private set; }

		public IEnumerable<string> Error { get; private set; } = new List<string>();

		private ValidaterPassword(){}

		public static ValidaterPassword CreateValidaterPassword(string password) 
		{
			var result = new ValidaterPassword();
			result.IsValid = true;
			result.IsValid &= result.IsNotNull(password);
			return result;
		}

		bool IsNotNull(string password)
		{
			if(password != null && password.Trim() != string.Empty)
				return true;
			else
			{
				Error = Error.Append("Пароль не заполнен");
				return false;
			}
		}
	}
}
