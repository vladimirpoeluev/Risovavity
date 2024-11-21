using AvaloniaRisovaviti.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
			InitCart();
		}

        void TryInitCart()
        {
            try
            {
                InitCart();
				
			}
            catch
            {
                MessageBoxManager.GetMessageBoxStandard(new MessageBoxStandardParams() 
                {
                    ContentMessage = "Что то пошло не так",
                    ContentTitle = "Error",
                    Icon = MsBox.Avalonia.Enums.Icon.Error,
                }).ShowAsync();

            }
        }

        async void InitCart()
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