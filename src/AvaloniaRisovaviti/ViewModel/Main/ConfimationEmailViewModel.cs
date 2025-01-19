using Autofac;
using InteractiveApiRisovaviti.Interface;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Main
{
	public class ConfimationEmailViewModel : ReactiveObject
	{
		public string Email { get; set; } = string.Empty;

		public string Code { get; set; }

		public ReactiveCommand<Unit, Task<EntrancePageViewModel>> NavEntrance { get; set; }

		IConfirmationViaEmail _viaEmail;

		public ConfimationEmailViewModel(IConfirmationViaEmail viaEmail) 
		{
			_viaEmail = viaEmail;
			NavEntrance = ReactiveCommand.Create(Confimation);
			Code = string.Empty;
		}

		public async Task<EntrancePageViewModel> Confimation()
		{
			try
			{
				await _viaEmail.EmailConfimationAsync(new DomainModel.ResultsRequest.EmailResult.EmailConfirmaionResult()
				{
					Code = Code,
					Email = Email,
				});
			}
			catch
			{

			}
			
			return App.Container.Resolve<EntrancePageViewModel>();
		}
	}
}
