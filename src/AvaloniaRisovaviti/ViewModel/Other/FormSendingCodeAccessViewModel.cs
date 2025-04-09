using AvaloniaEdit.Utils;
using DomainModel.ResultsRequest.TotpModels;
using DynamicData.Binding;
using ReactiveUI.Fody.Helpers;
using System.Reactive.Linq;

namespace AvaloniaRisovaviti.ViewModel.Other
{
	public class FormSendingCodeAccessViewModel : BaseViewModel
	{
		[Reactive]
		public CodeToptConfirmationResult CodeResult { get; set; } = new CodeToptConfirmationResult() 
		{
			Login = string.Empty,
			TotpCode = string.Empty,
		};

		[Reactive]
		public string TotpCode { get; set; }

		[Reactive]
		public string Login { get; set; }	
		public FormSendingCodeAccessViewModel()
		{
			this.WhenValueChanged(vm => vm.TotpCode)
				.Subscribe(e => CodeResult.TotpCode = e ?? string.Empty);
			this.WhenValueChanged(vm => vm.Login)
				.Subscribe(e => CodeResult.Login = e ?? string.Empty);
		}

	}
}
