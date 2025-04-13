using System;
using System.Collections.Generic;
using AvaloniaRisovaviti.Model;
using DomainModel.Integration;
using DomainModel.ResultsRequest.Canvas;
using System.Threading.Tasks;
using ReactiveUI;
using Autofac;
using MsBox.Avalonia.Dto;
using MsBox.Avalonia;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using InteractiveApiRisovaviti.Interface;
using AvaloniaEdit.CodeCompletion;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	public class MyCanvasViewModel : BaseViewModel
	{
		IEnumerable<CanvasResultWithImage> _canvases;
		IGetterWorkByAuthorId _getterWorkByAuthorId;
		InteractiveApiRisovaviti.Profile _profile;
		int countCart;
		const int stepLoad = 20;

		public event Action<Task<CanvasResult>> OnDeleteItem;
		public event Action<Task<CanvasResult>> OnClickUpdateItem;
		public event Action OnNavAddCanvas;


		public IEnumerable<CanvasResultWithImage> Canvases
		{
			get
			{
				return _canvases;
			}
			set
			{
				_canvases = value;
				OnPropertyChanged(nameof(Canvases));
			}
		}

		public ReactiveCommand<string, Task> SeacherCommand { get; set; }

		
		public CanvasResultWithImage SelectedCanvas { get; set; }

		public MyCanvasViewModel()
		{			
			_getterWorkByAuthorId = App.Container.Resolve<IGetterWorkByAuthorId>();
			_profile = new InteractiveApiRisovaviti.Profile(App.Container.Resolve<IAuthenticationUser>());
			_canvases = new List<CanvasResultWithImage>();
			countCart = 0;
			
		}

		public override async void Load()
		{
			await TryInitCart();
			OnPropertyChanged(nameof(Canvases));
			base.Load();
		}

		public void AddCanvas()
		{
			OnNavAddCanvas();
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

		public async Task TryInitCart()
		{
			try
			{
				await TryActionAsync(InitCart);
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
			await TryActionAsync(async () =>
			{
				IEnumerable<CanvasResult> result = await _getterWorkByAuthorId.GetCanvasByAuthorId(_profile.ProfileUser.Id, countCart, stepLoad);
				Canvases = _canvases.Concat(CanvasResultWithImage.CanvasResultWithImageFromCanvasResult(result, ClickUpdateItem, DeleteItem).Select((entity) =>
				{
					entity.ErrorView = this.ErrorView;
					return entity;
				}));
				countCart = 0;
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