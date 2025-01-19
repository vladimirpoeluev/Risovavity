﻿using System.IO;
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

namespace AvaloniaRisovaviti.Model
{
    public class CanvasResultWithImage : ReactiveObject, INotifyPropertyChanged
	{
        public CanvasResult CanvasResult { get; set; }
        IGetterImageProject _getterImage {  get; set; }

        [Reactive]
        public PermissionResult Permission { get; set; }

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
            CanvasResult = result;
            _getterImage = new GetterImageProject(Authentication.AuthenticationUser.User);
            _image = new Bitmap("Accets\\8.gif");
            SetImageTask();
		}

        async void SetPermission()
        {
            Permission = await _definitioner.GetPermissionAsync(CanvasResult);
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

        public static IEnumerable<CanvasResultWithImage> CanvasResultWithImageFromCanvasResult(IEnumerable<CanvasResult> objects)
        {
            return objects.Select(entity => new CanvasResultWithImage(entity));
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
