using Autofac;
using AvaloniaEdit.Utils;
using DynamicData.Binding;
using Newtonsoft.Json;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive.Linq;

namespace AvaloniaRisovaviti.ViewModel.Author
{
	public class AuthorsInfoViewModel : BaseViewModel
	{
		[Reactive]
		public object ViewModel { get; set; }

		public bool CanBack => CanBackCheck();

		private AuthorViewModel AuthorsViewModel { get; set; }

		public AuthorsInfoViewModel(AuthorViewModel vm)
		{
			AuthorsViewModel = vm;
			ViewModel = vm;
			this.WhenAnyValue(vm => vm.AuthorsViewModel.SelectedAuthor)
				.WhereNotNull()
				.Where(author => author?.AuthorResult?.UserId != 0)
				.Select(author => author.AuthorResult.UserId)
				.Subscribe(NavToAuthorInfo);
			this.WhenAnyValue(vm => vm.AuthorsViewModel.SelectedAuthor)
				.Subscribe((vm) => this.RaisePropertyChanged(nameof(CanBack)));
		}

		public void NavToAuthorInfo(int authorId)
		{
			var vm = App.Container.Resolve<AuthorInfoViewModel>();
			vm.AuthorId = authorId;
			ViewModel = vm;
			vm.Load();
		}

		public bool CanBackCheck()
		{
			return ViewModel is AuthorInfoViewModel && ViewModel != null;
			
		}
		public void Back()
		{
			ViewModel = AuthorsViewModel;
			
		}
	}
}