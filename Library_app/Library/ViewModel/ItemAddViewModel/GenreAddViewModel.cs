using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;
using System.ComponentModel;

namespace Library.ViewModel.ItemAddViewModel
{
    public class GenreAddViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private string myText;
        public string MyText

        {
            get { return this.myText; }
            set
            {
                this.myText = value;
                OnPropertyChanged("MyText");
            }
        }
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
