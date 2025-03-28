
using AvaloniaRisovaviti.Model;
using AvaloniaRisovaviti.Services.Interface;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.Services
{
	internal class SettingsAppService : ISettingsAppService
	{
		string path = "settings.json";
		public async Task<SettingsApp> GetSettings()
		{
			using(StreamReader reader = new StreamReader(new FileStream(path, FileMode.OpenOrCreate)))
			{
				string json = await reader.ReadToEndAsync();
				var defaultValue = new SettingsApp()
				{
					Lang = "ru-RU",
					Theme = "Light"
				};
				if (json != null && json != string.Empty) 
				{
					return JsonConvert.DeserializeObject<SettingsApp>(json) ?? defaultValue;
				}
				return defaultValue;
			}
			throw new System.NotImplementedException();
		}

		public async Task SaveSettings(SettingsApp settings)
		{
			using StreamWriter writer = new StreamWriter(path);
			string json = JsonConvert.SerializeObject(settings, Formatting.Indented);
			await writer.WriteLineAsync(json);
		}
	}
}
