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

namespace AvaloniaRisovaviti.Model
{
    public class CanvasResultWithImage : INotifyPropertyChanged
	{
        public CanvasResult CanvasResult { get; set; }
        IGetterImageProject _getterImage {  get; set; }
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

        private async void SetImageTask()
        {
            try
            {
                ImageResult imageResult = await _getterImage.GetImageResult(CanvasResult.VersionId);
                _image = new Bitmap(new MemoryStream(imageResult.Image));
                OnPropertyChanged(nameof(ImageData));
            }
            catch
            {

            }
        }

        public static IEnumerable<CanvasResultWithImage> CanvasResultWithImageFromCanvasResult(IEnumerable<CanvasResult> objects)
        {
            var result = new List<CanvasResultWithImage>();
            foreach (var obj in objects) 
            {
                result.Add(new CanvasResultWithImage(obj));
            }
            return result;
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
