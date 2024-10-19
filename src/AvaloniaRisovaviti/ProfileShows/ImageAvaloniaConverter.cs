using System.Drawing;
using System.IO;

namespace AvaloniaRisovaviti.ProfileShows
{
	internal static class ImageAvaloniaConverter
	{
		public static byte[] ConvertImageInByte(Stream stream)
		{
			var converter = new ImageConverter();
			return (byte[])converter.ConvertTo(new Bitmap(stream), typeof(byte[]));
		}

		public static Avalonia.Media.Imaging.Bitmap ConvertByteInImage(byte[] bytes)
		{
			using (MemoryStream memory = new MemoryStream(bytes))
			{
				return new Avalonia.Media.Imaging.Bitmap(memory);
			}
		}
	}
}
