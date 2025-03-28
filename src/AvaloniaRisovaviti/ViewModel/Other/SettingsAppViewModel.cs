using Avalonia;
using Avalonia.Styling;
using AvaloniaEdit.Utils;
using AvaloniaRisovaviti.Assets;
using AvaloniaRisovaviti.Model;
using AvaloniaRisovaviti.Services.Interface;
using DynamicData.Binding;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using System.Reactive.Linq;

namespace AvaloniaRisovaviti.ViewModel.Other
{
	public class SettingsAppViewModel : BaseViewModel
	{
		[Reactive]
		public string SelectedTheme { get; set; }
		[Reactive]
		public string SelectedLanguage { get; set; }
		public IEnumerable<string> Themes { get; set; } = new List<string>() { "Light", "Dark" };
		public IEnumerable<string> Language { get; set; } = new List<string>() { "ru-RU", "en-EN" };

		public SettingsAppViewModel(ISettingsAppService settingsServise)
		{
			this.WhenValueChanged(vm => vm.SelectedTheme)
				.Where(theme => theme != null && theme != string.Empty)
				.Subscribe(async (theme) => {
					Application.Current.RequestedThemeVariant = SelectedTheme == "Light"? ThemeVariant.Light : ThemeVariant.Dark;
					SettingsApp settings = await settingsServise.GetSettings();
					settings.Theme = theme ?? "Light";
					await settingsServise.SaveSettings(settings);
				} );
			this.WhenValueChanged(vm => vm.SelectedLanguage)
				.WhereNotNull()
				.Subscribe(async (language) => {
					Resource.Culture = new System.Globalization.CultureInfo(language);
					SettingsApp settings = await settingsServise.GetSettings();
					settings.Lang = language ?? "Light";
					await settingsServise.SaveSettings(settings);
				});
		}
	}

}
