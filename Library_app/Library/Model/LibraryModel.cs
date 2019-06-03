using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Model
{
    /// <summary>
    /// Static class that keeps track of changes in object lists
    /// </summary>
    public static class LibraryModel
    {
        /// <summary>
        /// Check whether there are objects to be removed from the DB
        /// </summary>
        /// <returns>true, if some items are to be removed, otherwise false</returns>
        public static bool AreItemsRemoved()
        {
            if (Genres.AreRemovedItems || Authors.AreRemovedItems || Books.AreRemovedItems) return true;
            return false;
        }
        /// <summary>
        /// Check whether there are objects to be updated in the DB
        /// </summary>
        /// <returns>true, if some items are to be updated, otherwise false</returns>
        public static bool AreItemsUpdated()
        {
            if (Genres.IsUpdated || Authors.IsUpdated || Books.IsUpdated) return true;
            return false;
        }
        /// <summary>
        /// If the changes have been made, object lists' are set to not be updated/removed anymore
        /// </summary>
        public static void ChangesSaved()
        {
            Genres.AreRemovedItems = false;
            Authors.AreRemovedItems = false;
            Books.AreRemovedItems = false;
            Genres.IsUpdated = false;
            Authors.IsUpdated = false;
            Books.IsUpdated = false;
        }
    }
}
