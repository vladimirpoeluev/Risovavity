
using AvaloniaRisovaviti.ViewModel.Canvas;

namespace AvaloniaRisovaviti.ViewModel.Fake
{
	internal class FakeFormAddVersionViewModel : FormAddVersionViewModel
	{
		public FakeFormAddVersionViewModel() 
		{
			base.ProjectResult = new DomainModel.ResultsRequest.Canvas.VersionProjectResult()
			{
				Name = "Test",
				Description = "Test",
			};
			base.NewProjectResult = new DomainModel.ResultsRequest.Canvas.VersionProjectResult() 
			{
				Name = "Test2",
				Description = "Test2",
			};
		}
	}
}
