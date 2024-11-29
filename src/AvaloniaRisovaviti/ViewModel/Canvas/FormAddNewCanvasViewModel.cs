using Avalonia.Media;
using Avalonia.Media.Imaging;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.IO;
using Avalonia.Platform;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
    internal class FormAddNewCanvasViewModel : INotifyPropertyChanged
    {
        public CanvasAddResult CanvasResult { get; set; }
        private IAdderCanvas _adderCanvas;
        private IImage _image = new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));
        public IImage ImageData
        {
            get
            {
                return _image;
            }
        }

        public FormAddNewCanvasViewModel()
        {
            CanvasResult = new CanvasAddResult()
            {
                VersionProject = new VersionProjectForCanvasResult()
            };
            _adderCanvas = new AdderCanvasParseApi(Authentication.AuthenticationUser.User);
            OnPropertyChanged(nameof(ImageData));
        }

        public void SetImage(byte[] bytes)
        {
            CanvasResult.VersionProject.Image = bytes;
            _image = new Bitmap(new MemoryStream(CanvasResult.VersionProject.Image));
            OnPropertyChanged(nameof(ImageData));
        }

        public async Task AddCanvas()
        {
            await _adderCanvas.AddCanvas(CanvasResult);
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