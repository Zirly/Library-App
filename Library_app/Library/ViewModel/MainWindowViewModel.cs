using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Library.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private ICommand _gotoBooksCommand;
        private ICommand _gotoAuthorsCommand;
        private object _currentView;
        private object _booksView;
        private object _authorsView;

        public MainWindowViewModel()
        {
            _booksView = new View.BooksListView();
            _authorsView = new View.AuthorsListView();

            CurrentView = _authorsView;
        }

        public object GotoBooksCommand
        {
            get
            {
                return _gotoBooksCommand ?? (_gotoBooksCommand = new RelayCommand(
                   x =>
                   {
                       GotoBooksView();
                   }));
            }
        }

        public ICommand GotoAuthorsCommand
        {
            get
            {
                return _gotoAuthorsCommand ?? (_gotoAuthorsCommand = new RelayCommand(
                   x =>
                   {
                       GotoAuthorsView();
                   }));
            }
        }

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged("CurrentView");
            }
        }

        private void GotoBooksView()
        {
            CurrentView = _booksView;
        }

        private void GotoAuthorsView()
        {
            CurrentView = _authorsView;
        }
    }
}
