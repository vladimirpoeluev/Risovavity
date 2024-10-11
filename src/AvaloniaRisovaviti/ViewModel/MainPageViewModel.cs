using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AvaloniaRisovaviti.ViewModel
{
	public class MainPageViewModel : INotifyPropertyChanged
	{
		public UserResult UserResult { get; set; }

		public MainPageViewModel() 
		{
			Profile profile = new Profile(Authentication.AuthenticationUser.User);
			InitUser(profile);
		}

		private void InitUser(Profile profile)
		{
			UserResult = profile.ProfileUser;
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

