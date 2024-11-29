using Avalonia.Controls;
using AvaloniaRisovaviti.Model;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
    public class CanvasPageViewModel : INotifyPropertyChanged
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
            OnPropertyChanged(nameof(Canvases));
            TryInitCart();
        }

        public async void TryInitCart()
        {
            try
            {
                await InitCart();
            }
            catch
            {
                await MessageBoxManager.GetMessageBoxStandard(new MessageBoxStandardParams()
                {
                    ContentMessage = "Что то пошло не так",
                    ContentTitle = "Error",
                    Icon = MsBox.Avalonia.Enums.Icon.Error,
                }).ShowAsync();
            }
        }



        async Task InitCart()
        {
            IEnumerable<CanvasResult> result = await _getterCanvas.GetAsync(countCart, stepLoad);
            _canvases = _canvases.Concat(CanvasResultWithImage.CanvasResultWithImageFromCanvasResult(result));
            countCart += stepLoad;
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