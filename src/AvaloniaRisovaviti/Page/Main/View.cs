using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.ViewModel;

namespace AvaloniaRisovaviti.Page.Main
{
	public partial class View : UserControl
	{
		private BaseViewModel _viewModel;

		public BaseViewModel ViewModel
		{
			get
			{
				return _viewModel;
			}
			set
			{
				_viewModel = value;
				DataContext = value;
			}
		}
		public View()
		{
			Loaded += Load;
		}

		private void Load(object obj, RoutedEventArgs args)
		{
			if (ViewModel != null)
			{
				ViewModel.Load();
			}
		}
	}
}
