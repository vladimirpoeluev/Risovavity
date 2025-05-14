
using Avalonia.Media.Imaging;
using Avalonia.Media;
using Avalonia.Platform;
using AvaloniaRisovaviti.ViewModel.Canvas;
using System.Threading.Tasks;

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
			base.NewProjectResult = new () 
			{
				Name = "Test2",
				Description = "Test2",
			};

			ImageOldProjectReasult = new Bitmap("AvaloniaRisovaviti\\Accets\\8.gif");
			NewImageProjectResult = new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));
		}
	}
}
