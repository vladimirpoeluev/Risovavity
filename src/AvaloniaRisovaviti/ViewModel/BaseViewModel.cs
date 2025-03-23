using ReactiveUI;
using System.Reactive;

namespace AvaloniaRisovaviti.ViewModel
{
	public class BaseViewModel : ReactiveObject, IActivatableView
	{
		public ReactiveCommand<Unit, Unit> LoadCommand { get; set; }
		public BaseViewModel() 
		{
			LoadCommand = ReactiveCommand.Create(Load);
		}

		public virtual void Load() 
		{
			
		}
	}
}