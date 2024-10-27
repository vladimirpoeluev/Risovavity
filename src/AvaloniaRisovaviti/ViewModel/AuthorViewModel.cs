using AvaloniaRisovaviti.Model;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel
{
    internal class AuthorViewModel : INotifyPropertyChanged
    {
        public IEnumerable<AuthorResult> AuthorResults { get; set; } = new List<AuthorResult>();
        public IEnumerable<AuthorResultImage> Authors { get; set; } = new List<AuthorResultImage>();
        public int _countShowedUser = 0;

        public AuthorViewModel()
        {
            ContinueListAuthors();
        }

        public void ContinueListAuthors()
        {
            var listNewAuthors = GetAuthors();
            var listNewAuthorForShow = AuthorResultImage.ConvertAuthorResult(listNewAuthors);
            foreach (var authors in listNewAuthorForShow)
            {
                Authors = Authors.Append(authors);
            }
            OnPropertyChanged(nameof(Authors));
        }

        private IEnumerable<AuthorResult> GetAuthors()
        {
			Authors authorsGetter = new Authors(Authentication.AuthenticationUser.User); 
            var authors = authorsGetter.GetAuthors(_countShowedUser, _countShowedUser + 50);
            _countShowedUser += 50;
            return authors;
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