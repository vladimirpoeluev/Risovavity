using Avalonia.Media;
using Avalonia.Media.Imaging;
using System.IO;

namespace AvaloniaRisovaviti.Services
{
	internal static class ImageSaver
	{
		public static ImageFormat GetImageFormat(byte[] bytes)
		{
			var pngSignature = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };
			if(bytes.Length >= pngSignature.Length)
			{
				bool isPng = true;
				for(int i = 0; i < pngSignature.Length; i++)
				{
					if(bytes[i] != pngSignature[i])
					{
						isPng = false;
						break;
					}
					if(isPng) return ImageFormat.Png;
				}
				
			}
			if (bytes.Length >= 2 && bytes[0] == 0xFF && bytes[1] == 0xD8)
			{
				return ImageFormat.Jpeg;
			}
			return ImageFormat.UnKnow;
		}

		public static ImageFormat GetImageFormat(IImage image)
		{
			using var memoryStream = new MemoryStream();
			if(image is Bitmap bitmap)
			{
				bitmap.Save(memoryStream);
			}

			return GetImageFormat(memoryStream.ToArray());
		}
	}

	enum ImageFormat
	{
		Jpeg,
		Png,
		UnKnow
	}
}
