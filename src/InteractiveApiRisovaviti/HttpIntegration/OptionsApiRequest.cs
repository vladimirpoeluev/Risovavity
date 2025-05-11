using System.Configuration;
namespace InteractiveApiRisovaviti.HttpIntegration
{
	internal class OptionsApiRequest
	{
		public static Uri BaseAddress { get; }
		static OptionsApiRequest() 
		{
			var address = ConfigurationManager.AppSettings["Address"];
			if (address != null)
			{
				BaseAddress = new Uri(address);
			}
			else
			{
				BaseAddress = new Uri("https://localhost:7281");
			}
				
		}
	}
}
