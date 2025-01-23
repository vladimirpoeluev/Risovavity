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
        public bool IsMainVersion { get; set; } = true;

		IDefinitionerOfPermission _definitioner { get; set; }
		IAdderVersionProject _adderVersionProject { get; set; }

		public ReactiveCommand<Unit, Task<VersionProjectResult>> Delete { get; set; }
		public ReactiveCommand<Unit, VersionProjectResult> Update { get; set; }
        public ReactiveCommand<Unit, Task> SelectMainVersion { get; set; }

		IGetterVersionProject _getterVersion;
        IGetterCanvas _getterCanvas;
        IGetterImageProject _getterImage;
        IGetterProjectByParentBuilder _getterDescendants;
        IEditMainVerstionInCanvas _editMainVersion;

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
			_getterVersion = new GetterVersionProject(user);
            _getterCanvas = new GetterCanvasParseApi(user);
            _getterImage = new GetterImageProject(user);
            _getterDescendants = new GetterProjectByParentBuilder(user);
            _editMainVersion = App.Container.Resolve<IEditMainVerstionInCanvas>();
            Descendants = new ObservableCollection<VersionProjectResultWithImage>();
            
        }

		public CanvasInfoPageViewModel(CanvasResult canvasResult) : this()
		{
			Canvas = canvasResult;
			LoadInfo();
		}

        void SettingsNode()
        {
            this.WhenAnyValue(vm => vm.Canvas)
                .Select((canvas) => canvas.VersionId != VersionProject.Id)
                .ToProperty(this, (vm) => vm.IsMainVersion);
        }

		private bool H(CanvasInfoPageViewModel model)
		{
            return model.IsMainVersion;
		}

        async Task SelectVersion()
        {
            await _editMainVersion.SelectMainVerstion(new MainVersionInCanvasResutl()
            {
                VersitonId = VersionProject.Id,
                CanvasId = Canvas.Id,
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
			await _adderVersionProject.DeleteVertionProjectAsync(VersionProject.Id);
            SetVersion(new VersionProjectResult()
            {
                Id = VersionProject.ParentVertionProject
            });
			return VersionProject;
		}

		

        public async void SetVersion(VersionProjectResult value)
        {
            if (value == null)
                return;
            _skip = 0;
            VersionProject = value;
            await LoadVersionProject(value.Id);
            await LoadImage();
            await LoadDescendans();
            LoadPermission();
        }

        async void LoadInfo()
        {
            await LoadCanvas();
            await LoadVersionProject();
			LoadPermission();
            LoadImage();
            LoadDescendans();
		}

        async Task LoadCanvas()
        {
            Canvas = await _getterCanvas.GetAsync(Canvas.Id);
        }

        async Task LoadVersionProject()
        {
            await LoadVersionProject(Canvas.VersionId);
        }

        async Task LoadVersionProject(int idVerionsProject)
        {
            VersionProject = await _getterVersion.GetVersionProjectByIdAsync(idVerionsProject);
        }

        async Task LoadImage()
        {
            ImageResult result = await _getterImage.GetImageResult(VersionProject.Id);
            Image = ImageAvaloniaConverter.ConvertByteInImage(result.Image);
        }

        public async Task LoadDescendans()
        {
            IEnumerable<VersionProjectResult> result = await _getterDescendants.SetSkip(_skip)
                .SetTake(_take).Build().GetVersionsByParent(VersionProject);
            IEnumerable<VersionProjectResultWithImage> parentsWithImage = result.Select(x => new VersionProjectResultWithImage(x));
            _skip += _take;
            Descendants = new ObservableCollection<VersionProjectResultWithImage>(parentsWithImage);
        }

    }
}