using DomainModel.Records;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel
{
    internal class AuthorViewModel : INotifyPropertyChanged
    {
        public CartOfAuthor[] Users { get; set; }

        public AuthorViewModel()
        {
            Users = [
                new (new User(1, "����", "ioiorgo@dag.aiosd", "sdddl", "sdk", new Role(1, "������������"),  null)),
                new (new User(1, "����2", "ioiorgo@dag.aiosd", "sdddl", "sdk", new Role(1, "������������"),  null)),
                new (new User(1, "����3", "ioiorgo@dag.aiosd", "sdddl", "sdk", new Role(1, "������������"),  null)),
                new (new User(1, "����4", "ioiorgo@dag.aiosd", "sdddl", "sdk", new Role(1, "������������"),  null)),
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