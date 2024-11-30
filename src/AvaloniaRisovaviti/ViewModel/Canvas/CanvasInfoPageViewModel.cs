using Avalonia.Media;
using Avalonia.Media.Imaging;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using InteractiveApiRisovaviti.Interface;
using System.IO;
using Avalonia.Platform;
using System.Threading.Tasks;
using ReactiveUI.Fody.Helpers;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
    public class CanvasInfoPageViewModel : BaseViewModel
    {
        [Reactive]
        public CanvasResult Canvas { get; set; } = new CanvasResult();
		[Reactive]
        public VersionProjectResult VersionProject { get; set; } = new VersionProjectResult();
		[Reactive]
        public IImage Image { get; set; }

        IGetterVersionProject _getterVersion;
        IGetterCanvas _getterCanvas;
        IGetterImageProject _getterImage;

        public CanvasInfoPageViewModel()
        {
            Image = new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));
            IAuthenticationUser user = Authentication.AuthenticationUser.User;
            _getterVersion = new GetterVersionProject(user);
            _getterCanvas = new GetterCanvasParseApi(user);
            _getterImage = new GetterImageProject(user);
        }

        public CanvasInfoPageViewModel(CanvasResult canvasResult) : this()
        {
            Canvas = canvasResult;
            LoadInfo();
        }

        async void LoadInfo()
        {
            await LoadCanvas();
            await LoadVersionProject();
            await LoadImage();
        }

        async Task LoadCanvas()
        {
            Canvas = await _getterCanvas.GetAsync(Canvas.Id);
        }

        async Task LoadVersionProject()
        {
            VersionProject = await _getterVersion.GetVersionProjectByIdAsync(Canvas.VersionId);
        }

        async Task LoadImage()
        {
            ImageResult result = await _getterImage.GetImageResult(VersionProject.Id);
            Image = new Bitmap(new MemoryStream(result.Image));
        }

    }
}