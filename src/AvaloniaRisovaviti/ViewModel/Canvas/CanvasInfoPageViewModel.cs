using Avalonia.Media;
using Avalonia.Media.Imaging;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using InteractiveApiRisovaviti.Interface;
using Avalonia.Platform;
using System.Threading.Tasks;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using AvaloniaRisovaviti.Model;
using System.Collections.ObjectModel;
using System.Linq;
using ReactiveUI;
using System;
using AvaloniaRisovaviti.ProfileShows;
using System.Reactive;
using DomainModel.ResultsRequest;
using Autofac;
using System.Reactive.Linq;
using Avalonia.Controls;
using AvaloniaRisovaviti.Page.Main;
using AvaloniaRisovaviti.Services;

namespace AvaloniaRisovaviti.ViewModel.Canvas
{
    public class CanvasInfoPageViewModel : BaseViewModel
    {
        [Reactive]
        public CanvasResult Canvas { get; set; } = new CanvasResult();
        [Reactive]
        public VersionProjectResult VersionProject { get; set; } = new VersionProjectResult();
        [Reactive]
        public IImage Image { get; set; }
        [Reactive]
        public IEnumerable<VersionProjectResultWithImage> Descendants { get; set; }
		[Reactive]
		public PermissionResult Permission { get; set; }
        [Reactive]
        public PermissionResult PermissionCanvas { get; set; }
        [Reactive]
        public int CountLike { get; set; }
        [Reactive]
        public bool? IsLikes { get; set; }
        [Reactive]
        public bool IsMainVersion { get; set; } = true;

        [Reactive]
        public bool IsEdit { get; set; } = false;

		IDefinitionerOfPermission _definitioner { get; set; }
		IAdderVersionProject _adderVersionProject { get; set; }
        View _view;

		public ReactiveCommand<Unit, Task<VersionProjectResult>> Delete { get; set; }
		public ReactiveCommand<Unit, VersionProjectResult> Update { get; set; }
        public ReactiveCommand<Unit, Task> SelectMainVersion { get; set; }

		IGetterVersionProject _getterVersion;
        IGetterCanvas _getterCanvas;
        IGetterImageProject _getterImage;
        IGetterProjectByParentBuilder _getterDescendants;
        IEditMainVerstionInCanvas _editMainVersion;
        ILikesOfVersitonService _likesService;
        IEditVersionProject _editVersionProject;


		int _skip = 0;
        const int _take = 50;

        public CanvasInfoPageViewModel()
        {
            Image = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));
			SettingsNode();
			IAuthenticationUser user = Authentication.AuthenticationUser.User;
			Delete = ReactiveCommand.Create(DeleteVersion);
			Update = ReactiveCommand.Create(UpdateVersion);
            SelectMainVersion = ReactiveCommand.Create(SelectVersion);
			_definitioner = App.Container.Resolve<IDefinitionerOfPermission>();
			_adderVersionProject = App.Container.Resolve<IAdderVersionProject>();
            _likesService = App.Container.Resolve<ILikesOfVersitonService>();
			_editVersionProject = App.Container.Resolve<IEditVersionProject>();
			_getterVersion = new GetterVersionProject(user);
            _getterCanvas = new GetterCanvasParseApi(user);
            _getterImage = new GetterImageProject(user);
            _getterDescendants = new GetterProjectByParentBuilder(user);
            _editMainVersion = App.Container.Resolve<IEditMainVerstionInCanvas>();
            Descendants = new ObservableCollection<VersionProjectResultWithImage>();
        }

		public CanvasInfoPageViewModel(CanvasResult canvasResult, View view) : this()
		{
            _view = view;
			Canvas = canvasResult;
			LoadInfo();
		}

        void SettingsNode()
        {
            this.WhenAnyValue(vm => vm.VersionProject)
                .Select((version) => Canvas.VersionId != version.Id)
                .ToProperty(this, (vm) => vm.IsMainVersion);

            this.WhenAnyValue(vm => vm.IsLikes)
                .Subscribe(async (value) =>
                {

                    await TryActionAsync(async () =>
                    {
						if (value == null)
							return;
						if (value.Value)
						{
							await _likesService.Like(VersionProject.Id);
						}
						else
						{
							await _likesService.UnLike(VersionProject.Id);
						}
						await LoadLikes();
					});
                    
				});
        }

        async Task SelectVersion()
        {
            await TryActionAsync(async () =>
            {
				await _editMainVersion.SelectMainVerstion(new MainVersionInCanvasResutl()
				{
					VersitonId = VersionProject.Id,
					CanvasId = Canvas.Id,
				});
			});
            
            Canvas.VersionId = VersionProject.Id;
        }

        
		async Task LoadPermission()
		{
			try
			{
				Permission = await _definitioner.GetPermissionAsync(VersionProject);
                PermissionCanvas = await _definitioner.GetPermissionAsync(Canvas);
			}
			catch
			{
				Permission = new PermissionResult()
				{
					AddVerstion = false,
					Edit = false,
					Read = false,
				};
			}
		}

		VersionProjectResult UpdateVersion()
		{
			return VersionProject;
		}

		async Task<VersionProjectResult> DeleteVersion()
		{
            await TryActionAsync(async () =>
            {
				await _adderVersionProject.DeleteVertionProjectAsync(VersionProject.Id);
				await SetVersion(new VersionProjectResult()
				{
					Id = VersionProject.ParentVertionProject
				});
			});
			
			return VersionProject;
		}

		public async void BackVersion()
        {
            if (VersionProject.ParentVertionProject != -1)
            await SetVersion(new VersionProjectResult()
            {
                Id = VersionProject.ParentVertionProject
            });
        }

        public async Task SetVersion(VersionProjectResult value)
        {
            await TryActionAsync(async () =>
            {
                if (value == null)
                    return;
                _skip = 0;
                VersionProject = value;
                await LoadVersionProject(value.Id);
                await LoadImage();
                await LoadDescendans();
                await Task.WhenAll([LoadPermission(), LoadLikes()]);
            });
        }

        async void LoadInfo()
        {
            await TryActionAsync(async () =>
            {
                await LoadCanvas();
                await LoadVersionProject();
                await Task.WhenAll(LoadPermission(), LoadImage(), LoadDescendans(), LoadLikes());
            });
		}

        async Task LoadLikes()
        {
            await TryActionAsync(async () => { 
                IsLikes = await _likesService.IsLike(VersionProject.Id);
                CountLike = await _likesService.CouintLikes(VersionProject.Id);
            });
        }

        async Task LoadCanvas()
        {
            await TryActionAsync(async () =>
            {
				Canvas = await _getterCanvas.GetAsync(Canvas.Id);
			});
            
        }

        async Task LoadVersionProject()
        {
            await TryActionAsync(async () =>
            {
                await LoadVersionProject(Canvas.VersionId);
            });
        }

        async Task LoadVersionProject(int idVerionsProject)
        {
            await TryActionAsync(async () =>
            {
                VersionProject = await _getterVersion.GetVersionProjectByIdAsync(idVerionsProject);
            });
        }

        async Task LoadImage()
        {
            await TryActionAsync(async () =>
            {
                ImageResult result = await _getterImage.GetImageResult(VersionProject.Id);
                Image = ImageAvaloniaConverter.ConvertByteInImage(result.Image);
            });
        }

        public async Task LoadDescendans()
        {
            await TryActionAsync(async () =>
            {
                IEnumerable<VersionProjectResult> result = await _getterDescendants.SetSkip(_skip)
                .SetTake(_take).Build().GetVersionsByParent(VersionProject);
                IEnumerable<VersionProjectResultWithImage> parentsWithImage = result.Select(x => new VersionProjectResultWithImage(x));
                _skip += _take;
                Descendants = new ObservableCollection<VersionProjectResultWithImage>(parentsWithImage);
            });
        }

        public async void EditVersion()
        {
            if (IsEdit)
            {
                await _editVersionProject.Edit(
                    new VerstionProjectEditResutl() 
                    {
                        NameEdit = VersionProject.Name,
                        DescriptionEdit = VersionProject.Description,
                        VerstionId = VersionProject.Id,
                    });
               await SetVersion(VersionProject);
            }
            IsEdit = !IsEdit;
        }

        public async void Save()
        {
            var toplevel = TopLevel.GetTopLevel(_view);
            var files = await toplevel.StorageProvider.SaveFilePickerAsync(new Avalonia.Platform.Storage.FilePickerSaveOptions()
            {
                Title = "����� ���������� �������"
            });
            if (files is not null)
            {
				((Bitmap)Image).Save(files.Path.LocalPath + "." + (ImageSaver.GetImageFormat(Image).ToString().ToLower()));
            }

        }

    }
}