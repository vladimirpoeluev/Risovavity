using Avalonia.Media;
using InteractiveApiRisovaviti;
using System;

namespace AvaloniaRisovaviti.ProfileShows
{
	internal class ProfileSetterImage
	{
		Profile _profile;
		public ProfileSetterImage(Profile profile)
		{
			_profile = profile;
		}

		public IImage UpdateImage()
		{
			try
			{
				var bytes = _profile.ProfileAvatar.AvatarResult;
				return ImageAvaloniaConverter.ConvertByteInImage(bytes);
			}
			catch (Exception)
			{
				return new Avalonia.Media.Imaging.Bitmap("Accets/icoUser.png");
			}
		}
	}
}
