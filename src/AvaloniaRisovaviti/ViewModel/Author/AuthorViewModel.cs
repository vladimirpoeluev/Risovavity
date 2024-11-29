using AvaloniaRisovaviti.Model;
using DomainModel.ResultsRequest;
using InteractiveApiRisovaviti;
using InteractiveApiRisovaviti.Interface;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace AvaloniaRisovaviti.ViewModel.Author
{
    internal class AuthorViewModel : INotifyPropertyChanged
    {
        public IEnumerable<AuthorResult> AuthorResults { get; set; } = new List<AuthorResult>();
        public IEnumerable<AuthorResultImage> Authors { get; set; } = new List<AuthorResultImage>();
        private int _countShowedUser = 0;
        private const int stepAdd = 50;
        public bool IsCart { get; private set; } = true;
        IAuthorGetter _authorsGetter;

        public AuthorViewModel()
        {
            _authorsGetter = new AuthorGetter(Authentication.AuthenticationUser.User);
            ContinueListAuthors();
        }

        public async void ContinueListAuthors()
        {
            var listNewAuthors = await GetAuthors();
            if (listNewAuthors.Count() == 0)
            {
                IsCart = false;
                OnPropertyChanged(nameof(IsCart));
                return;
            }

            var listNewAuthorForShow = AuthorResultImage.ConvertAuthorResult(listNewAuthors);
            Authors = Authors.Concat(listNewAuthorForShow);
            OnPropertyChanged(nameof(Authors));
            IsCart = true;
        }

        private async Task<IEnumerable<AuthorResult>> GetAuthors()
        {
            IEnumerable<AuthorResult> authors = await _authorsGetter.GetAuthorsRange(_countShowedUser, stepAdd);
            _countShowedUser += stepAdd;
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