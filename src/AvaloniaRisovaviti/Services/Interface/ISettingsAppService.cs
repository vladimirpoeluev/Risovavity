using AvaloniaRisovaviti.Model;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.Services.Interface
{
	public interface ISettingsAppService
	{
		Task SaveSettings(SettingsApp settings);
		Task<SettingsApp> GetSettings();
	}
}
