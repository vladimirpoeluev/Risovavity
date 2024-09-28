using DomainModel.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel
{
    public class CanvasPageViewModel: INotifyPropertyChanged
    {
        public CartOfImage[] Canvases { get; set; }

        public CanvasPageViewModel() 
        {
            Canvases = [
                new CartOfImage(new InteractiveCanvas()),
                new CartOfImage(new InteractiveCanvas()),
                new CartOfImage(new InteractiveCanvas()),
                new CartOfImage(new InteractiveCanvas()),
                new CartOfImage(new InteractiveCanvas()),
                new CartOfImage(new InteractiveCanvas()),
                new CartOfImage(new InteractiveCanvas()),
                new CartOfImage(new InteractiveCanvas()),
                ];
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