using Avalonia.Controls;
using InteractiveApiRisovaviti.Exceptions;
using ReactiveUI;
using System;
using System.Reactive;

namespace AvaloniaRisovaviti.ViewModel
{
	public class BaseViewModel : ReactiveObject, IActivatableView
	{
		public ReactiveCommand<Unit, Unit> LoadCommand { get; set; }
		public ReactiveCommand<UserControl, UserControl> Error { get; set; }
		public BaseViewModel() 
		{
			LoadCommand = ReactiveCommand.Create(Load);
			Error = ReactiveCommand.Create<UserControl, UserControl>(ErrorMetod);
		}

		public virtual void Load() {}

		public UserControl ErrorMetod(UserControl errorView) => errorView;

		public void TryAction(Action action)
		{
			try
			{
				action();
			}
			catch (AuthorizeException ex)
			{
				Error.Execute(new ErrorAuthorizeView());
			}
			catch(RequstException ex)
			{
				if(ex.ErrorMessageRequest.NumberError == 404)
				{
					Error.Execute(new Error404View());
				}
				else if(ex.ErrorMessageRequest.NumberError == 500)
				{
					Error.Execute(new Error500View());
				}
				else
				{
					Error.Execute(new Error500View());
				}
			}
			catch(Exception ex)
			{
				Error.Execute(new ErrorNotConnectView());
			}
		}
	}
}