using Autofac;
using AvaloniaRisovaviti.Model;
using AvaloniaRisovaviti.Services;
using DomainModel.Integration;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.Interface;
using MsBox.Avalonia;
using MsBox.Avalonia.Dto;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reactive.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	public class MyCanvasViewModel : BaseViewModel
	{
		IEnumerable<CanvasResultWithImage> _canvases;
		IGetterWorkByAuthorId _getterWorkByAuthorId;
		InteractiveApiRisovaviti.Profile _profile;
		IteraterItems _iterator;
		int countCart;
		const int stepLoad = 20;

		public event Action<Task<CanvasResult>> OnDeleteItem;
		public event Action<Task<CanvasResult>> OnClickUpdateItem;
		public event Action OnNavAddCanvas;

		[Reactive]
		public IEnumerable<CanvasResultWithImage> Canvases { get; set; }

		public ReactiveCommand<string, Task> SeacherCommand { get; set; }

		
		public CanvasResultWithImage SelectedCanvas { get; set; }

		public MyCanvasViewModel()
		{			
			_getterWorkByAuthorId = App.Container.Resolve<IGetterWorkByAuthorId>();
			_profile = new InteractiveApiRisovaviti.Profile(App.Container.Resolve<IAuthenticationUser>());
			_canvases = new List<CanvasResultWithImage>();
			_iterator = new IteraterItems(20, NavItems);
			Canvases = new List<CanvasResultWithImage>();
		}

		private async void NavItems((int skip, int take) range)
		{
			await TryActionAsync(async () =>
			{
				IEnumerable<CanvasResult> result = await _getterWorkByAuthorId.GetCanvasByAuthorId(_profile.ProfileUser.Id, range.skip, range.take);
				Canvases = Canvases.Concat(CanvasResultWithImage.CanvasResultWithImageFromCanvasResult(result, ClickUpdateItem, DeleteItem, ErrorView));
			});
			OnPropertyChanged(nameof(Canvases));
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
			_iterator.Next();
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