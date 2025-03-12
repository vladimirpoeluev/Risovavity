using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	public class MyWorkViewModel : ReactiveObject
	{
		public object ViewModel { get; set; }
		
		[Reactive]
		public object View { get; set; } = new MyCanvasesView();
	}
}