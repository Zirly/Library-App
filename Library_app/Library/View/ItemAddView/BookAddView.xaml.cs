﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Library.Model;

namespace Library.View.ItemAddView
{
    /// <summary>
    /// Interaction logic for BookAddView.xaml
    /// </summary>
    public partial class BookAddView : UserControl
    {
        public BookAddView()
        {
            InitializeComponent();
            cbGenres.ItemsSource = Genres.GenresList;
            
        }


    }
}
