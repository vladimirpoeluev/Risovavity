using System.Net;
using System.Net.Http.Headers;

namespace InteractiveApiRisovaviti.HttpIntegration
{
	internal class OptionsApiRequest
	{
		public static Uri BaseAddress { get; } = new Uri("https://localhost:32771/");
	}
}
