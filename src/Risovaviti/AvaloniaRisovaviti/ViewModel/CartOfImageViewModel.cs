using DomainModel.Records;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel
{
    internal class CartOfImageViewModel: INotifyPropertyChanged
    {
        public InteractiveCanvas InteractiveCanvas { get; set; }

        public CartOfImageViewModel(InteractiveCanvas canvas) 
        {
            InteractiveCanvas = canvas;
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