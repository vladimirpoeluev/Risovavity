using Autofac;
using Avalonia.Controls;
using AvaloniaRisovaviti.Model;
using DomainModel.Integration;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
    public class CanvasPageViewModel : ReactiveObject, INotifyPropertyChanged
    {
        IEnumerable<CanvasResultWithImage> _canvases;
        IGetterCanvas _getterCanvas;
        ISearcherCanvas _searcherCanvas;
        int countCart;
        const int stepLoad = 5;

        public event Action<Task<CanvasResult>> OnDeleteItem;
        public event Action<Task<CanvasResult>> OnClickUpdateItem;

        [Reactive]
        public string SearchString { get; set; } = string.Empty;

        public IEnumerable<CanvasResultWithImage> Canvases
        {
            get
            {
                return _canvases;
            }
        }

        public ReactiveCommand<string, Unit> SeacherCommand { get; set; }


        public CanvasResultWithImage SelectedCanvas { get; set; } = new CanvasResultWithImage(new CanvasResult());

        public CanvasPageViewModel()
        {
            SeacherCommand = ReactiveCommand.Create<string>(SearchByString);
            _getterCanvas = new GetterCanvasParseApi(Authentication.AuthenticationUser.User);
            _searcherCanvas = App.Container.Resolve<ISearcherCanvas>();
            _canvases = new List<CanvasResultWithImage>();
            countCart = 0;
            OnPropertyChanged(nameof(Canvases));
            this.WhenAnyValue(vm => vm.SearchString)
                .Where(value => value != string.Empty)
                .Throttle(TimeSpan.FromSeconds(0.6))
                .InvokeCommand(SeacherCommand);
            this.WhenAnyValue(vm => vm.SearchString)
                .Where(value => value == string.Empty)
                .Subscribe((e) =>
                {
                    countCart = 0;
                    _canvases = new List<CanvasResultWithImage>();
                    TryInitCart();
                });

			TryInitCart();
        }

        public async void SearchByString(string searchString)
        {
			IEnumerable<CanvasResult> result = await _searcherCanvas.Search(searchString);
			_canvases = CanvasResultWithImage.CanvasResultWithImageFromCanvasResult(result, ClickUpdateItem, DeleteItem);
			OnPropertyChanged(nameof(Canvases));
		}
        public async void Search()
        {
            IEnumerable<CanvasResult> result = await _searcherCanvas.Search(SearchString);
			_canvases = CanvasResultWithImage.CanvasResultWithImageFromCanvasResult(result, ClickUpdateItem, DeleteItem);
            OnPropertyChanged(nameof(Canvases));
        }

        void ClickUpdateItem(Task<CanvasResult> canvasResult)
        {
            OnClickUpdateItem(canvasResult);
        }

        async void DeleteItem(Task<CanvasResult> canvas)
        {
            var canvasresult = await canvas;
            _canvases = _canvases.Where((entity) => entity.CanvasResult != canvasresult);
            OnPropertyChanged(nameof(Canvases));
			OnDeleteItem(canvas);
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
            _canvases = _canvases.Concat(CanvasResultWithImage.CanvasResultWithImageFromCanvasResult(result, ClickUpdateItem, DeleteItem));
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