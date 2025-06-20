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
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
    public class CanvasPageViewModel : BaseViewModel, INotifyPropertyChanged
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

        public ReactiveCommand<string, Task> SeacherCommand { get; set; }


        public CanvasResultWithImage SelectedCanvas { get; set; } = new CanvasResultWithImage(new CanvasResult());

        public CanvasPageViewModel()
        {
            OnDeleteItem = new Action<Task<CanvasResult>>((s) => { });
            SeacherCommand = ReactiveCommand.Create<string, Task>(SearchByString);
            _getterCanvas = new GetterCanvasParseApi(Authentication.AuthenticationUser.User);
            _searcherCanvas = App.Container.Resolve<ISearcherCanvas>();
            _canvases = new List<CanvasResultWithImage>();
            countCart = 0;
            OnPropertyChanged(nameof(Canvases));
            this.WhenAnyValue(vm => vm.SearchString)
                .Throttle(TimeSpan.FromSeconds(0.25))
                .InvokeCommand(SeacherCommand);

			this.WhenAnyValue(vm => vm.SearchString)
                .Where(value => value == string.Empty)
                .Subscribe((e) =>
                {
                    countCart = 0;
                    _canvases = new List<CanvasResultWithImage>();
                    Task.WaitAll(TryInitCart());
                });

			Task.WaitAll(TryInitCart());
        }

        public async Task SearchByString(string searchString)
        {
            await TryActionAsync(async () => {
				if (searchString.Trim() == string.Empty)
				{
					await TryInitCart();
				}
				IEnumerable<CanvasResult> result = await _searcherCanvas.Search(searchString);
				_canvases = CanvasResultWithImage.CanvasResultWithImageFromCanvasResult(result, ClickUpdateItem, DeleteItem);
				OnPropertyChanged(nameof(Canvases));
			});
		}
        public async Task Search()
        {
            await TryActionAsync(async () =>
            {
                if (SearchString.Trim() == string.Empty)
                {
                    await TryInitCart();
                }
                IEnumerable<CanvasResult> result = await _searcherCanvas.Search(SearchString);
                _canvases = CanvasResultWithImage.CanvasResultWithImageFromCanvasResult(result, ClickUpdateItem, DeleteItem);
                OnPropertyChanged(nameof(Canvases));
            });
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
            if(canvas is not null)
			    OnDeleteItem(canvas);
		}

        public async Task TryInitCart()
        {
            try
            {
                await InitCart();
            }
            catch
            {
                await MessageBoxManager.GetMessageBoxStandard(new MessageBoxStandardParams()
                {
                    ContentMessage = "��� �� ����� �� ���",
                    ContentTitle = "Error",
                    Icon = MsBox.Avalonia.Enums.Icon.Error,
                }).ShowAsync();
            }
        }

		AsyncLock asyncLock = new AsyncLock();
		async Task InitCart()
        {
            asyncLock.Wait(async () =>
            {
				await TryActionAsync(async () =>
				{
					IEnumerable<CanvasResult> result = await _getterCanvas.GetAsync(countCart, stepLoad);
					_canvases = _canvases.Concat(CanvasResultWithImage.CanvasResultWithImageFromCanvasResult(result, ClickUpdateItem, DeleteItem));
					countCart += stepLoad;
				});
			});
			
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