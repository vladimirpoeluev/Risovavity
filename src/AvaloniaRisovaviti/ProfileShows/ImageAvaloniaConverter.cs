namespace AvaloniaRisovaviti.ProfileShows
{
	using Avalonia.Media.Imaging;
	using Avalonia.Platform;
	using System.IO;

	/// <summary>
	/// Defines the <see cref="ImageAvaloniaConverter" />
	/// </summary>
	internal static class ImageAvaloniaConverter
	{
		/// <summary>
		/// The ConvertImageInByte
		/// </summary>
		/// <param name="stream">The stream<see cref="Stream"/></param>
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
		/// The ConvertByteInImage
		/// </summary>
		/// <param name="bytes">The bytes<see cref="byte[]"/></param>
		/// <returns>The <see cref="Avalonia.Media.Imaging.Bitmap"/></returns>
		public static Avalonia.Media.Imaging.Bitmap ConvertByteInImage(byte[] bytes)
		{
			try
			{
				using (MemoryStream memory = new MemoryStream(bytes))
				{
					return new Avalonia.Media.Imaging.Bitmap(memory);
				}
			}
			catch
			{
				return new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Accets/breakImage.png")));
			}
		}
	}
}
