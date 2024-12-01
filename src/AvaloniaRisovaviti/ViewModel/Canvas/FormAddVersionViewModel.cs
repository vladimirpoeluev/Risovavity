
using DomainModel.ResultsRequest.Canvas;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	internal class FormAddVersionViewModel : BaseViewModel
	{
		[Reactive]
		public VersionProjectResult ProjectResult { get; set; }

		[Reactive]
		public VersionProjectResult NewProjectResult { get; set; }
		
		public FormAddVersionViewModel() 
		{
			ProjectResult = new VersionProjectResult();
			NewProjectResult = new VersionProjectResult();
		}

		public FormAddVersionViewModel(VersionProjectResult parent) : this()
		{
			ProjectResult = parent;
		}
	}
}
