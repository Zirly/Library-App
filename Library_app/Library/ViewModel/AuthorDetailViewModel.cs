﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.ViewModel
{
    /// <summary>
    /// Interaction logic for AuthorDetailView.xaml
    /// </summary>
    public class AuthorDetailViewModel
    {
       public Author MyAuthor { get; set; }

        public AuthorDetailViewModel() { }
        public AuthorDetailViewModel(Author author)
        {
            MyAuthor = author;
            
        }
    }
}
