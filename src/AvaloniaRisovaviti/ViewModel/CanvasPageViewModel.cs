using AvaloniaRisovaviti.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel
{
    public class CanvasPageViewModel: INotifyPropertyChanged
    {
        IEnumerable<CanvasResultWithImage> _canvases;
        IGetterCanvas _getterCanvas;
        int countCart;
        const int stepLoad = 5;

        public IEnumerable<CanvasResultWithImage> Canvases
        {
            get
            {
                return _canvases;
            }
        }

        public CanvasResultWithImage SelectedCanvas { get; set; } = new CanvasResultWithImage(new CanvasResult());

        public CanvasPageViewModel()
        {
			_getterCanvas = new GetterCanvasParseApi(Authentication.AuthenticationUser.User);
            _canvases = new List<CanvasResultWithImage>();
            countCart = 0;
			InitCart();
		}

        public void TryInitCart()
        {
            try
            {
                InitCart();
				
			}
            catch
            {
                MessageBoxManager.GetMessageBoxStandard(new MessageBoxStandardParams() 
                {
                    ContentMessage = "��� �� ����� �� ���",
                    ContentTitle = "Error",
                    Icon = MsBox.Avalonia.Enums.Icon.Error,
                }).ShowAsync();

            }
        }

        async void InitCart()
        {
		    IEnumerable<CanvasResult> result = await _getterCanvas.GetAsync(countCart, stepLoad);
            _canvases = _canvases.Concat(CanvasResultWithImage.CanvasResultWithImageFromCanvasResult(result));
			OnPropertyChanged(nameof(Canvases));
            countCart += stepLoad;
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