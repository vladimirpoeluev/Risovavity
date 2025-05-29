
using Autofac;
using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using AvaloniaRisovaviti.Model;
using AvaloniaRisovaviti.ProfileShows;
using AvaloniaRisovaviti.Services;
using AvaloniaRisovaviti.Services.Interface;
using AvaloniaRisovaviti.ViewModel.FormAdd;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using DynamicData.Binding;
using InteractiveApiRisovaviti.CanvasOperate;
using MsBox.Avalonia;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
	internal class FormAddVersionViewModel : BaseViewModel
	{
		[Reactive]
		public VersionProjectResult ProjectResult { get; set; }

		[Reactive] public IImage ImageOldProjectReasult { get; set; }

		[Reactive]
		public VersionProjectViewModel NewProjectResult { get; set; }

		[Reactive] public IImage NewImageProjectResult { get; set; }

		[Reactive] public string Error { get; set; } = string.Empty;

		private ImageResult OldImage {  get; set; }
		private string Path { get; set; }
		[Reactive]
		private Guid GuidNewProject { get; set; }
		[Reactive]
		public IEnumerable<string> ImageNames { get; set; }
		[Reactive]
		public string SelectedName { get; set; } = "image";

		IGetterVersionProject _getterVersion;
		IGetterImageProject _getterImageProject;
		IAdderVersionProject _adderVersion;
		IAdderNewProject _addProject;
		IGetterDraftProject _getterDraftProject;
		
		public FormAddVersionViewModel() 
		{
			ProjectResult = new VersionProjectResult();
			NewProjectResult = new();
			ImageOldProjectReasult = new Bitmap("Accets\\8.gif");
			NewImageProjectResult = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));
			_getterVersion = new GetterVersionProject(Authentication.AuthenticationUser.User);
			_getterImageProject = new GetterImageProject(Authentication.AuthenticationUser.User);
			_adderVersion = new AdderVesionProject(Authentication.AuthenticationUser.User);
			_addProject = App.Container.Resolve<IAdderNewProject>();
			_getterDraftProject = App.Container.Resolve<IGetterDraftProject>();
			this.WhenValueChanged((vm) => vm.SelectedName)
				.Subscribe((str) => 
				{
					if (GuidNewProject != Guid.Empty)
					{
						if (SelectedName == string.Empty || SelectedName == null)
							SelectedName = "image";
						NewImageProjectResult =
							new Bitmap(Environment.CurrentDirectory + @$"\{AdderNewProject.Path}\{GuidNewProject}\{SelectedName}");
						Path = Environment.CurrentDirectory + @$"\{AdderNewProject.Path}\{GuidNewProject}\{SelectedName}";
					}
				});
		}
		
		void ClearForm()
		{
			Path = null;
			NewImageProjectResult = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));
			NewProjectResult = new VersionProjectViewModel();
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
			await TryActionAsync(async () =>
			{
				ProjectResult = await _getterVersion.GetVersionProjectByIdAsync(ProjectResult.Id);
				ImageResult result = await _getterImageProject.GetImageResult(ProjectResult.Id);
				OldImage = result;
				ImageOldProjectReasult = ImageAvaloniaConverter.ConvertByteInImage(result.Image);
			});
			
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
				await TryActionAsync(async () => 
				{
					await _adderVersion.AddVertionProjectAsync(new VersionProjectForAddResult()
					{
						Image = image,
						ParentVertionProjectId = ProjectResult.Id,
						Name = NewProjectResult.Name,
						Descriptoin = NewProjectResult.Description,
					});
					await MessageBoxManager.GetMessageBoxStandard("Уведомление", $"Проект \"{NewProjectResult.Name}\" был успешно добавлен")
						.ShowWindowAsync();
					ClearForm();
				});
			}
			catch (Exception ex)
			{
				MessageBoxManager.GetMessageBoxStandard("Ошибка: ", $"{ex.Message}");
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
			GuidNewProject = identity;
			_getterDraftProject.OpenForEdit(identity);
			
		}
		public bool CanNextEdit()
		{
			return GuidNewProject != Guid.Empty; 
		}
		public async void NextEdit()
		{
			try
			{
				if (GuidNewProject != Guid.Empty)
				{
					_getterDraftProject.OpenForEdit(GuidNewProject, SelectedName);
				}
			}
			catch (Exception)
			{

			}
		}

		public async Task UpdateNewProject()
		{
			try
			{
				if (GuidNewProject != Guid.Empty)
				{
					DraftModel model = await _getterDraftProject.GetDraftModel(GuidNewProject);
					Path = Environment.CurrentDirectory + @$"\{AdderNewProject.Path}\{model.Guid}\{SelectedName}";
					NewImageProjectResult = ImageAvaloniaConverter.ConvertByteInImage(model.Images);
					ImageNames = await _getterDraftProject.GetImagesByProject(model.Guid);
				}
			}
			catch(Exception ex)
			{

			}
			
			
		}
	}
}
