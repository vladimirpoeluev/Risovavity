using Avalonia.Media;
using Avalonia.Media.Imaging;
using DomainModel.Integration.CanvasOperation;
using DomainModel.ResultsRequest.Canvas;
using InteractiveApiRisovaviti.CanvasOperate;
using InteractiveApiRisovaviti.Interface;
using System.IO;
using Avalonia.Platform;
using System.Threading.Tasks;
using ReactiveUI.Fody.Helpers;
using System.Collections.Generic;
using AvaloniaRisovaviti.Model;
using System.Collections.ObjectModel;
using System.Linq;
using DynamicData.Binding;
using ReactiveUI;
using System;
using AvaloniaRisovaviti.ProfileShows;

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

        IGetterVersionProject _getterVersion;
        IGetterCanvas _getterCanvas;
        IGetterImageProject _getterImage;
        IGetterProjectByParentBuilder _getterDescendants;

        int _skip = 0;
        const int _take = 50;

        public CanvasInfoPageViewModel()
        {
            Image = new Bitmap(AssetLoader.Open(new Uri("avares://AvaloniaRisovaviti/Accets/placeholder.png")));
            IAuthenticationUser user = Authentication.AuthenticationUser.User;
            _getterVersion = new GetterVersionProject(user);
            _getterCanvas = new GetterCanvasParseApi(user);
            _getterImage = new GetterImageProject(user);
            _getterDescendants = new GetterProjectByParentBuilder(user);
            Descendants = new ObservableCollection<VersionProjectResultWithImage>();
        }

        public CanvasInfoPageViewModel(CanvasResult canvasResult) : this()
        {
            Canvas = canvasResult;
            LoadInfo();
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
        }

        async void LoadInfo()
        {
            await LoadCanvas();
            await LoadVersionProject();
            await LoadImage();
            await LoadDescendans();
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