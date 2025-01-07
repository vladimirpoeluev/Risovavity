using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.EmailIntegration
{
	internal class CodeGenerater
	{
		public static string Generate()
		{
			return Generate(5);
		}

		public static string Generate(int count)
		{
			Random random = new();
			string result = string.Empty;
			for (int i = 0; i < count; i++)
			{
				result += random.Next(9).ToString();
			}
			return result;
		}
	}
}
