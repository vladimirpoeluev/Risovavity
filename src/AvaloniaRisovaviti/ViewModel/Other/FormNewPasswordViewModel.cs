using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti.Interface.Topt;
using ReactiveUI.Fody.Helpers;
using System;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Other
{
	public class FormNewPasswordViewModel
	{
		[Reactive]
		public EditNewPasswordResul EditNewPasswordResult { get; set; } = new EditNewPasswordResul();
		[Reactive]
		public string Password { get; set; } = string.Empty;
		private IEditPasswordForRecovery editPassword;
		private Action next;
		public FormNewPasswordViewModel(IEditPasswordForRecovery editPassword, Action next)
		{
			this.editPassword = editPassword;
			this.next = next;
		}

		public async Task EditPassword()
		{
			await editPassword.EditPassword(EditNewPasswordResult);
			next();
		}
	}
}
