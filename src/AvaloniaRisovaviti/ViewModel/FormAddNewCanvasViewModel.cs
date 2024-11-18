using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel
{
    internal class FormAddNewCanvasViewModel: INotifyPropertyChanged
    {
        public CanvasAddResult CanvasResult { get; set; }
        private IAdderCanvas _adderCanvas;

        public FormAddNewCanvasViewModel()
        {
            CanvasResult = new CanvasAddResult();
            _adderCanvas = new AdderCanvasParseApi(Authentication.AuthenticationUser.User);
        }

        public void SetImage(byte[] bytes)
        {
            CanvasResult.VersionProject.Image = bytes;
            OnPropertyChanged(nameof(CanvasResult));
        }

        public void AddCanvas()
        {
            _adderCanvas.AddCanvas(CanvasResult);
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