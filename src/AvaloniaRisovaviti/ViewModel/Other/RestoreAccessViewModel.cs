using DomainModel.ResultsRequest;
using DomainModel.ResultsRequest.TotpModels;
using DynamicData.Binding;
using InteractiveApiRisovaviti.Interface.Topt;
using MsBox.Avalonia;
using ReactiveUI.Fody.Helpers;
using System;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Other
{
	public class RestoreAccessViewModel : BaseViewModel
	{
		[Reactive]
		public object View { get; set; }

		
		[Reactive]
		public FormSendingCodeAccessViewModel CodeToptConfirmation { get; set; } = new FormSendingCodeAccessViewModel();

		private IAccessRecovery recovery;
		public Action Back { get; set; } = () => { MessageBoxManager.GetMessageBoxStandard("Сбой!!!", "Переход на страницу входа сломан"); };

		public RestoreAccessViewModel(IAccessRecovery recovery)
		{
			this.recovery = recovery;
			View = CodeToptConfirmation;
			this.WhenValueChanged(vm => vm.CodeToptConfirmation.TotpCode)
				.Where(code => code.Length == 6)
				.Subscribe(async sender => await SendCodeRecovery());
		}

		public async Task SendCodeRecovery()
		{
			await TryActionAsync(SendCodeRecoveryWithError);
		}
		private async Task SendCodeRecoveryWithError()
		{
			IEditPasswordForRecovery editerPassword = await recovery.Recovery(new CodeToptConfirmationResult()
			{
				TotpCode = CodeToptConfirmation.TotpCode,
				Login = CodeToptConfirmation.Login,
			});
			View = new FormNewPasswordViewModel(editerPassword, Back);
		}

		public void BackInEntrance()
		{
			Back();
		}
		
	}
}
