
using Avalonia.Media;
using Avalonia.Media.Imaging;
using DomainModel.ResultsRequest.Canvas;
using System.Collections.Generic;

namespace AvaloniaRisovaviti.Model
{
    public class CanvasResultWithImage
    {
        public CanvasResult CanvasResult { get; set; }
        public IImage ImageData { 
            get
            {
                return new Bitmap("Accets\\8.gif");
            }
        }

        public CanvasResultWithImage(CanvasResult result)
        {
            CanvasResult = result;
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
    }
}
