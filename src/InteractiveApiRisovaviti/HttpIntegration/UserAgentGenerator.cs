using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	public class UserAgentGenerator
	{
		public static string GetUserAgent(string appName, string appVersion)
		{
			string osDescription = GetOSDescription();
			return $"{appName}/{appVersion} ({osDescription})";
		}

		private static string GetOSDescription()
		{
			string osName = Environment.OSVersion.ToString(); // Получаем полное описание ОС
			string version = Environment.OSVersion.Version.ToString(); // Получаем версию ОС

			// Можно использовать различную логику для определения конкретной ОС
			if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
			{
				return $"Windows {version}";
			}
			else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Linux))
			{
				return "Linux";
			}
			else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
			{
				return "macOS";
			}
			else
			{
				return "Unknown OS"; // На случай, если ОС не определена
			}
		}
	}
}
