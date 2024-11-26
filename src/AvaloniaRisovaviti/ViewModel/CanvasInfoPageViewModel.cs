using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using InteractiveApiRisovaviti.Interface;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel
{
	public class CanvasInfoPageViewModel : INotifyPropertyChanged
	{
		public CanvasResult Canvas { get; set; }
		public VersionProjectResult VersionProject { get; set; }

		IGetterVersionProject _getterVersion;
		IGetterCanvas _getterCanvas;
		IGetterImageProject _getterImage;

		public CanvasInfoPageViewModel() 
		{
			Canvas = new CanvasResult();
			VersionProject = new VersionProjectResult();

			IAuthenticationUser user = Authentication.AuthenticationUser.User;
			_getterVersion = new GetterVersionProject(user);
			_getterCanvas = new GetterCanvasParseApi(user);
			_getterImage = new GetterImageProject(user);
		}

		public CanvasInfoPageViewModel(CanvasResult canvasResult) : this()
		{
			Canvas = canvasResult;
			LoadInfo();
		}

		void LoadInfo()
		{

		}

		async void LoadVersionProject()
		{

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