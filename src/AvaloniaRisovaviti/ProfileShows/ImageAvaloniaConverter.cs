using System.Drawing;
using System.IO;

namespace AvaloniaRisovaviti.ProfileShows
{
	internal static class ImageAvaloniaConverter
	{
		public static byte[] ConvertImageInByte(Stream stream)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				stream.CopyTo(ms);
				return ms.ToArray();
			}
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
