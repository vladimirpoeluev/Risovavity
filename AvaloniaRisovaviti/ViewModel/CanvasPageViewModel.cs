using DomainModel.Records;
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
                new CartOfImage(new InteractiveCanvas(1, "Изображение", "dsfj", null, new Status(1, "Public"), new User(1, "Name", "email.mail@gmail.com", "Login", "password", new Role(1, "User"), null))),
                new CartOfImage(new InteractiveCanvas(1, "Изображение", "dsfj", null, new Status(1, "Public"), new User(1, "Name", "email.mail@gmail.com", "Login", "password", new Role(1, "User"), null))),
                new CartOfImage(new InteractiveCanvas(1, "Изображение", "dsfj", null, new Status(1, "Public"), new User(1, "Name", "email.mail@gmail.com", "Login", "password", new Role(1, "User"), null))),
                new CartOfImage(new InteractiveCanvas(1, "Изображение", "dsfj", null, new Status(1, "Public"), new User(1, "Name", "email.mail@gmail.com", "Login", "password", new Role(1, "User"), null))),
                new CartOfImage(new InteractiveCanvas(1, "Изображение", "dsfj", null, new Status(1, "Public"), new User(1, "Name", "email.mail@gmail.com", "Login", "password", new Role(1, "User"), null))),
                new CartOfImage(new InteractiveCanvas(1, "Изображение", "dsfj", null, new Status(1, "Public"), new User(1, "Name", "email.mail@gmail.com", "Login", "password", new Role(1, "User"), null))),
                new CartOfImage(new InteractiveCanvas(1, "Изображение", "dsfj", null, new Status(1, "Public"), new User(1, "Name", "email.mail@gmail.com", "Login", "password", new Role(1, "User"), null))),
                new CartOfImage(new InteractiveCanvas(1, "Изображение", "dsfj", null, new Status(1, "Public"), new User(1, "Name", "email.mail@gmail.com", "Login", "password", new Role(1, "User"), null))),
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