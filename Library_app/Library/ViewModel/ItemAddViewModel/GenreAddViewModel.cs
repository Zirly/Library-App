using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using System.ComponentModel;

namespace Library.ViewModel.ItemAddViewModel
{
    /// <summary>
    /// Interaction logic for GenreAddView.xaml
    /// </summary>
    public class GenreAddViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private Genre myGenre = new Genre();
        public Genre MyGenre
        {
            get { return this.myGenre; }
            set
            {
                this.myGenre = value;
                OnPropertyChanged("MyGenre");
            }
        }
        /// <summary>
        /// Raises an event, when property is changed
        /// </summary>
        /// <param name="name">changed property</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
