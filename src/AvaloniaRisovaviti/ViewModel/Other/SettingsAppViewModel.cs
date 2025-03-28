using Avalonia;
using Avalonia.Styling;
using AvaloniaEdit.Utils;
using AvaloniaRisovaviti.Assets;
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

		public SettingsAppViewModel()
		{
			this.WhenValueChanged(vm => vm.SelectedTheme)
				.Where(theme => theme != null || theme != string.Empty)
				.Subscribe((theme) => {
					Application.Current.RequestedThemeVariant = SelectedTheme == "Light"? ThemeVariant.Light : ThemeVariant.Dark ;
				} );
			this.WhenValueChanged(vm => vm.SelectedLanguage)
				.WhereNotNull()
				.Subscribe((language) => {
					Resource.Culture = new System.Globalization.CultureInfo(language);
				});
		}
	}

}
