namespace AvaloniaRisovaviti.ProfileShows
{
	using Avalonia.Media.Imaging;
	using Avalonia.Platform;
	using System.IO;

	/// <summary>
	/// Преобразование изображений Avalonia<see cref="ImageAvaloniaConverter" />
	/// </summary>
	internal static class ImageAvaloniaConverter
	{
		public static Bitmap BreakImage { get; set; } = new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Accets/breakImage.png")));

		/// <summary>
		/// Преобразование изображения в байты
		/// </summary>
		/// <param name="stream">Поток данных<see cref="Stream"/></param>
		/// <returns>The <see cref="byte[]"/></returns>
		public static byte[] ConvertImageInByte(Stream stream)
		{
			using (MemoryStream ms = new MemoryStream())
			{
				stream.CopyTo(ms);
				return ms.ToArray();
			}
		}

		/// <summary>
		/// Преобразование байт в изображение Avalonia
		/// </summary>
		/// <param name="bytes">The bytes<see cref="byte[]"/></param>
		/// <returns>The <see cref="Avalonia.Media.Imaging.Bitmap"/></returns>
		public static Bitmap ConvertByteInImage(byte[] bytes)
		{
			try
			{
				using (MemoryStream memory = new MemoryStream(bytes))
				{
					return new Bitmap(memory);
				}
			}
			catch
			{
				return BreakImage;
			}
		}
	}
}
