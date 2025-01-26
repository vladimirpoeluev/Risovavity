using Avalonia.Media.Imaging;
using Avalonia.Platform;
using AvaloniaRisovaviti.Model;
using AvaloniaRisovaviti.ViewModel.Canvas;
using DomainModel.ResultsRequest.Canvas;

namespace AvaloniaRisovaviti.ViewModel.Fake
{
	internal class FakeCanvasInfoPageViewModel : CanvasInfoPageViewModel
	{
		public FakeCanvasInfoPageViewModel()
		{
			this.Canvas = new CanvasResult() 
			{
				Name = "Test name",
				Description = "Test description",
			};
			this.Image = new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));
			this.VersionProject = new VersionProjectResult()
			{
				Name = "Test name of project",
				Description = "Test description of project"
			};
			Descendants = 
				[
				new VersionProjectResultWithImage()
				{ 
					VersionProjectResult = new VersionProjectResult(){
						Id = 1,
						Description = "Test",
						Name = "Test",
						AuthorId = 1,
					}
				}
				];
		}
	}
}
