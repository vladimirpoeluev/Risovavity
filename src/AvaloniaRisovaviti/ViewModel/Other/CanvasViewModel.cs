using Avalonia.Media;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaRisovaviti.ViewModel.Other
{
	public class CanvasViewModel : BaseViewModel
	{
		public int Id { get; set; }
		[Reactive]
		public string Name { get; set; }

		[Reactive]
		public string Description { get; set; }

		[Reactive]
		public IImage Image { get; set; }

		[Reactive]
		public int CountLike { get; set; }

		[Reactive]
		public VersionProjectViewModel MainVersionProject { get; set; }
	}
}
