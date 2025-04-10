using Avalonia.Controls;
using InteractiveApiRisovaviti.Exceptions;
using ReactiveUI;
using System;
using System.Reactive;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel
{
	public class BaseViewModel : ReactiveObject, IActivatableView
	{
		public ReactiveCommand<Unit, Unit> LoadCommand { get; set; }
		public ReactiveCommand<UserControl, UserControl> Error { get; set; }
		public Action<UserControl> ErrorView { get; set; }
		public BaseViewModel() 
		{
			LoadCommand = ReactiveCommand.Create(Load);
			Error = ReactiveCommand.Create<UserControl, UserControl>(ErrorMetod);
		}

		public virtual void Load() {}

		public UserControl ErrorMetod(UserControl errorView) 
		{
			return errorView;
		} 

		public void TryAction(Action action)
		{
			try
			{
				action();
			}
			catch (AuthorizeException ex)
			{
				if (ErrorView != null)
					ErrorView(new ErrorAuthorizeView());
				Error.Execute(new ErrorAuthorizeView());
			}
			catch(RequstException ex)
			{
				if(ex.ErrorMessageRequest.NumberError == 404)
				{

					if (ErrorView != null)
						ErrorView(new Error404View());
					Error.Execute(new Error404View());
				}
				else if(ex.ErrorMessageRequest.NumberError == 500)
				{
					if (ErrorView != null)
						ErrorView(new Error500View());
					Error.Execute(new Error500View());
				}
				else
				{
					if (ErrorView != null)
						ErrorView(new Error500View());
					Error.Execute(new Error500View());
				}
			}
			catch(Exception)
			{
				if (ErrorView != null)
					ErrorView(new ErrorNotConnectView());
				Error.Execute(new ErrorNotConnectView());
			}
		}

		public async Task TryActionAsync(Func<Task> action)
		{
			try
			{
				await action();
			}
			catch (AuthorizeException ex)
			{
				if (ErrorView != null)
					ErrorView(new ErrorAuthorizeView());
				Error.Execute(new ErrorAuthorizeView());
			}
			catch (RequstException ex)
			{
				if (ex.ErrorMessageRequest.NumberError == 404)
				{

					if (ErrorView != null)
						ErrorView(new Error404View());
					Error.Execute(new Error404View());
				}
				else if (ex.ErrorMessageRequest.NumberError == 500)
				{
					if (ErrorView != null)
						ErrorView(new Error500View());
					Error.Execute(new Error500View());
				}
				else
				{
					if (ErrorView != null)
						ErrorView(new Error500View());
					Error.Execute(new Error500View());
				}
			}
			catch (Exception)
			{
				if (ErrorView != null)
					ErrorView(new ErrorNotConnectView());
				Error.Execute(new ErrorNotConnectView());
			}
		}
	}
}