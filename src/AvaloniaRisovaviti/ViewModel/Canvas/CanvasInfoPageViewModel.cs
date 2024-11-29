using Avalonia.Media;
using Avalonia.Media.Imaging;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using InteractiveApiRisovaviti.Interface;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using Avalonia.Platform;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
    public class CanvasInfoPageViewModel : INotifyPropertyChanged
    {
        public CanvasResult Canvas { get; set; }
        public VersionProjectResult VersionProject { get; set; }
        public IImage Image { get; set; }

        IGetterVersionProject _getterVersion;
        IGetterCanvas _getterCanvas;
        IGetterImageProject _getterImage;

        public CanvasInfoPageViewModel()
        {
            Canvas = new CanvasResult();
            VersionProject = new VersionProjectResult();
            Image = new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));

            IAuthenticationUser user = Authentication.AuthenticationUser.User;
            _getterVersion = new GetterVersionProject(user);
            _getterCanvas = new GetterCanvasParseApi(user);
            _getterImage = new GetterImageProject(user);
        }

        public CanvasInfoPageViewModel(CanvasResult canvasResult) : this()
        {
            Canvas = canvasResult;
            OnPropertyChanged(nameof(Canvas));
            LoadInfo();
        }

        async void LoadInfo()
        {
            await LoadCanvas();
            await LoadVersionProject();
            LoadImage();
        }

        async Task LoadCanvas()
        {
            Canvas = await _getterCanvas.GetAsync(Canvas.Id);
        }

        async Task LoadVersionProject()
        {
            VersionProject = await _getterVersion.GetVersionProjectByIdAsync(Canvas.VersionId);
            OnPropertyChanged(nameof(VersionProject));
        }

        async void LoadImage()
        {
            ImageResult result = await _getterImage.GetImageResult(VersionProject.Id);
            Image = new Bitmap(new MemoryStream(result.Image));
            OnPropertyChanged(nameof(Image));
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            if (name != null)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}