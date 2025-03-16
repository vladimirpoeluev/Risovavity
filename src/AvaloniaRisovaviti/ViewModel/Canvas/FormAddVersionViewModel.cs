
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using DomainModel.ResultsRequest.Canvas;
using ReactiveUI.Fody.Helpers;
using InteractiveApiRisovaviti.CanvasOperate;
using DomainModel.Integration.CanvasOperation;
using System.Threading.Tasks;
using AvaloniaRisovaviti.ProfileShows;
using System.IO;
using MsBox.Avalonia;
using System;
using AvaloniaRisovaviti.Services.Interface;
using Autofac;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	internal class FormAddVersionViewModel : BaseViewModel
	{
		[Reactive]
		public VersionProjectResult ProjectResult { get; set; }

		[Reactive] public IImage ImageOldProjectReasult { get; set; }

		[Reactive]
		public VersionProjectResult NewProjectResult { get; set; }

		[Reactive] public IImage NewImageProjectResult { get; set; }

		[Reactive] public string Error { get; set; } = string.Empty;

		private ImageResult OldImage {  get; set; }
		private string Path { get; set; }

		IGetterVersionProject _getterVersion;
		IGetterImageProject _getterImageProject;
		IAdderVersionProject _adderVersion;
		IAdderNewProject _addProject;
		IGetterDraftProject _getterDraftProject;
		
		public FormAddVersionViewModel() 
		{
			ProjectResult = new VersionProjectResult();
			NewProjectResult = new VersionProjectResult();
			ImageOldProjectReasult = new Bitmap("Accets\\8.gif");
			NewImageProjectResult = new Bitmap(AssetLoader.Open(new System.Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));
			_getterVersion = new GetterVersionProject(Authentication.AuthenticationUser.User);
			_getterImageProject = new GetterImageProject(Authentication.AuthenticationUser.User);
			_adderVersion = new AdderVesionProject(Authentication.AuthenticationUser.User);
			_addProject = App.Container.Resolve<IAdderNewProject>();
			_getterDraftProject = App.Container.Resolve<IGetterDraftProject>();
		}

		public FormAddVersionViewModel(VersionProjectResult parent) : this()
		{
			ProjectResult = parent;
			LoadInfo();
		}

		async void LoadInfo()
		{
			await LoadOldVersionProject();
		}

		async Task LoadOldVersionProject()
		{
			ProjectResult = await _getterVersion.GetVersionProjectByIdAsync(ProjectResult.Id);
			ImageResult result = await _getterImageProject.GetImageResult(ProjectResult.Id);
			OldImage = result;
			ImageOldProjectReasult = ImageAvaloniaConverter.ConvertByteInImage(result.Image);
		}

		public void SetImage(string path)
		{
			NewImageProjectResult = new Bitmap(path);
			Path = path;
		}

		public async Task AddVersion()
		{
			try
			{
				byte[] image = ImageAvaloniaConverter.ConvertImageInByte(new StreamReader(Path).BaseStream);
				await _adderVersion.AddVertionProjectAsync(new VersionProjectForAddResult()
				{
					Image = image,
					ParentVertionProjectId = ProjectResult.Id,
					Name = NewProjectResult.Name,
					Descriptoin = NewProjectResult.Description,
				});
			}
			catch (Exception ex)
			{
				MessageBoxManager.GetMessageBoxStandard("LF", $"{ex.Message}");
			}
			
		}

		public async Task OpenEditerForEdit()
		{
			Guid identity = await _addProject.AddProject(new Model.DraftModel()
			{
				DraftInfo = new Model.DraftInfo()
				{
					Description = NewProjectResult.Description,
					Name = NewProjectResult.Name,
				},
				Guid = Guid.NewGuid(),
				Images = OldImage.Image
			});
			_getterDraftProject.OpenForEdit(identity);
		}
	}
}
