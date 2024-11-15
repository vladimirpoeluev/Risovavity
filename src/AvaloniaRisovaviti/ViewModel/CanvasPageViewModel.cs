using AvaloniaRisovaviti.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel
{
    public class CanvasPageViewModel: INotifyPropertyChanged
    {
        IEnumerable<CanvasResultWithImage> _canvases;
        IGetterCanvas _getterCanvas;
        public IEnumerable<CanvasResultWithImage> Canvases
        {
            get
            {
                return _canvases;
            }
        }

        public CanvasPageViewModel()
        {
			_getterCanvas = new GetterCanvasParseApi(Authentication.AuthenticationUser.User);
            _canvases = new List<CanvasResultWithImage>();
			Task initCartTask = InitCart();
		}

        async Task InitCart()
        {
		    IEnumerable<CanvasResult> result = await _getterCanvas.GetAsync(0, 3);
			_canvases = CanvasResultWithImage.CanvasResultWithImageFromCanvasResult(result);
			OnPropertyChanged(nameof(Canvases));
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