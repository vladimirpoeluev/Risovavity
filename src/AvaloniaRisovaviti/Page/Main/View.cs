using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaEdit.Utils;
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
				DataContext = _viewModel;
				InitError(_viewModel);
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
		private void InitError(BaseViewModel baseView)
		{
			baseView.Error.Subscribe(error =>
			{
				Content = error;
			});
			baseView.ErrorView = (error) =>
			{
				this.Content = error.Content;
			};
			
		}
	}
}
