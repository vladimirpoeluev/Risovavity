using DomainModel.Records;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel
{
    public class CartOfAuthorViewModel : INotifyPropertyChanged
    {
        public User UserOfCart { get; set; }

        public CartOfAuthorViewModel(User user)
        {
            UserOfCart = user;
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
