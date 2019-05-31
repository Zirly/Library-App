using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.ViewModel
{
    public class GenresListViewModel
    {
        public ObservableCollection<string> listaGenre = new ObservableCollection<string>();
        
        public GenresListViewModel()
        {
            listaGenre.Add("a");
            listaGenre.Add("b");
            listaGenre.Add("c");
        }
       
    }
}
