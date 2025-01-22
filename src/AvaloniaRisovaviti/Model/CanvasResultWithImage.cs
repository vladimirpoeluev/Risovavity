using System.IO;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using System.Collections.Generic;
using System.Threading.Tasks;
using InteractiveApiRisovaviti.CanvasOperate;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Avalonia.Controls;
using System.Linq;
using InteractiveApiRisovaviti.Interface;
using Autofac;
using InteractiveApiRisovaviti.ControllerIntegration;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using DomainModel.ResultsRequest;
using System.Reactive;
using System;

namespace AvaloniaRisovaviti.Model
{
    public class CanvasResultWithImage : ReactiveObject, INotifyPropertyChanged
	{
        public CanvasResult CanvasResult { get; set; }
        IGetterImageProject _getterImage {  get; set; }
        IEditerCanvas _editer;
        ILikesOfCanvasService _likesService;

        [Reactive]
        public PermissionResult Permission { get; set; }
		[Reactive]
		public int CountLikes { get; set; }

        [Reactive]
        public bool? IsLike { get; set; }

		public ReactiveCommand<Unit, Task<CanvasResult>> DeleteCanvas { get; set; }
        public ReactiveCommand<Unit, Task<CanvasResult>> UpdateCanvas { get; set; }

        IDefinitionerOfPermission _definitioner = new DefinitionerOfPermission(Authentication.AuthenticationUser.User, App.Container.Resolve<FabricAutoControllerIntegraion>());
        
        IImage _image;

		public IImage ImageData { 
            get
            {
                return _image;
            }
        }

        public CanvasResultWithImage(CanvasResult result)
        {
            _editer = App.Container.Resolve<IEditerCanvas>();
			_likesService = App.Container.Resolve<ILikesOfCanvasService>();
			CanvasResult = result;
            _getterImage = new GetterImageProject(Authentication.AuthenticationUser.User);
            _image = new Bitmap("Accets\\8.gif");
            DeleteCanvas = ReactiveCommand.Create(Delete);
            UpdateCanvas = ReactiveCommand.Create(Update);
            SetImageTask();
            SetPermission();
            InfoLikesLoad();
            this.WhenAnyValue(vm => vm.IsLike).Subscribe(UpdateLikeChecked);
		}

        async void UpdateLikeChecked(bool? e)
        {
            if (!e.HasValue) return;
            if(e.Value)
                await _likesService.Like(CanvasResult.Id);
            if (!e.Value)
                await _likesService.UnLike(CanvasResult.Id);
			CountLikes = await _likesService.CouintLikes(CanvasResult.Id);
			OnPropertyChanged(nameof(CountLikes));
		}

        async void InfoLikesLoad()
        {
            IsLike = await _likesService.IsLike(CanvasResult.Id);
            CountLikes = await _likesService.CouintLikes(CanvasResult.Id);
        }

        async Task<CanvasResult> Update()
        {
            return CanvasResult;
        }

        async Task<CanvasResult> Delete()
        {
            await _editer.DeleteCanvasAsync(CanvasResult.Id);
            return CanvasResult;
        } 

        async void SetPermission()
        {
            try
            {
				Permission = await _definitioner.GetPermissionAsync(CanvasResult);
                OnPropertyChanged(nameof(Permission));
			}
            catch {
                Permission = new PermissionResult()
                {
                    AddVerstion = false,
                    Edit = false,
                    Read = false,
                };
            }
            
        }

        private async void SetImageTask()
        {
            try
            {
                ImageResult imageResult = await _getterImage.GetImageResult(CanvasResult.VersionId);
                _image = new Bitmap(new MemoryStream(imageResult.Image));
                OnPropertyChanged(nameof(ImageData));
            }
            catch{}
        }

        public static IEnumerable<CanvasResultWithImage> CanvasResultWithImageFromCanvasResult( IEnumerable<CanvasResult> objects, 
                                                                                                Action<Task<CanvasResult>> action = null, 
                                                                                                Action<Task<CanvasResult>> deleteAction = null)
        {
            return objects.Select(entity => 
            {
                var result = new CanvasResultWithImage(entity);
                if(action != null)
					result.UpdateCanvas.Subscribe(action);
                if(deleteAction != null)
                    result.DeleteCanvas.Subscribe(deleteAction);
				return result;

			});
        }

		public void SelectCanvas(object? window)
		{
			if (window != null)
			{
                UserControl userControl = (UserControl) window;
				userControl.Content = new CanvasInfoPage(CanvasResult);
			}
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
