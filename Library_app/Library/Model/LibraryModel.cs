using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    public static class LibraryModel
    {
        
        public static bool AreChangesMade()
        {
            if (Genres.IsChanged || Authors.IsChanged) return true;
            return false;
        }
    }
}
