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

namespace EFM.Kontrole
{
    /// <summary>
    /// Interaction logic for kontrolaNekretnina.xaml
    /// </summary>
    public partial class kontrolaNekretnina : UserControl
    {
        public Nekretnina nekretnina { get; set; }

        public kontrolaNekretnina(Nekretnina n, BitmapImage slika1)
        {
            InitializeComponent();
            imgSlika.Source = slika1;
            txtOpis.Text = n.Opis;
            nekretnina = n;
        }

        public override string ToString()
        {
            return nekretnina.ToString1();
        }
    }
}
