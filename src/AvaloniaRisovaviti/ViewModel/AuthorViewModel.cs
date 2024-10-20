using DomainModel.Model;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AvaloniaRisovaviti.ViewModel
{
    internal class AuthorViewModel : INotifyPropertyChanged
    {
        public CartOfAuthor[] Users { get; set; }
        public IEnumerable<AuthorResult> AuthorResults { get; set; }

        public AuthorViewModel()
        {
            Authors authors = new Authors(Authentication.AuthenticationUser.User);
            AuthorResults = authors.GetAuthors();
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