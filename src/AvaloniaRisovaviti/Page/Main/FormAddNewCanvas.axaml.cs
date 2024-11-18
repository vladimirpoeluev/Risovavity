using Avalonia.Controls;
using Avalonia.Controls.Platform;
using Avalonia.Interactivity;
using AvaloniaRisovaviti.ViewModel;

namespace AvaloniaRisovaviti;

public partial class FormAddNewCanvas : UserControl
{
    FormAddNewCanvasViewModel viewModel;
    public FormAddNewCanvas()
    {
		InitializeComponent();
        viewModel = new FormAddNewCanvasViewModel();
    }

    public async void AddNewImage_Click(object obj, RoutedEventArgs e)
    {
        TopLevel topLevel = TopLevel.GetTopLevel(this);
        var files = await topLevel.StorageProvider.OpenFilePickerAsync(new Avalonia.Platform.Storage.FilePickerOpenOptions()
        {
            Title = "Open Text File",
            AllowMultiple = false
        });

        if(files.Count >= 1)
        {
            await using var stream = await files[0].OpenReadAsync();
        }

    }
}