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
using System.Windows.Shapes;

namespace EFM.Pomocni_prozori
{
    /// <summary>
    /// Interaction logic for Unos_nekretnine.xaml
    /// </summary>
    public partial class Unos_nekretnine : Window
    {
        private List<BitmapImage> slike = new List<BitmapImage>();
        private int trenutnaSlika;

        public Unos_nekretnine()
        {
            InitializeComponent();
            cbbTipNekretnine.ItemsSource =
                Enum.GetValues(typeof(Nekretnina.EnumTipNekretnine)).Cast<Nekretnina.EnumTipNekretnine>().ToList();
        }
        
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            List<Nekretnina.EnumTipNekretnine> l = 
                Enum.GetValues(typeof(Nekretnina.EnumTipNekretnine)).Cast<Nekretnina.EnumTipNekretnine>().ToList();
            Nekretnina.EnumTipNekretnine e1 = l[cbbTipNekretnine.SelectedIndex];
            Nekretnina n = new Nekretnina(txtLokacija.Text, txtOpis.Text, e1,
                cbxDaLiJeOciscena.IsChecked == true, cbxRezervisanost.IsChecked == true);
            //TODO Ovo treba negdje spasiti, to se trebamo dogovoriti kako cemo rjesavati :D
        }

        private void btnNovaSlika_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.DefaultExt = ".jpg";
            open.Filter = "Images(.jpg)|*.jpg";
            if (open.ShowDialog() == true)
            {
                string put = open.FileName;

                BitmapImage slika = new BitmapImage();
                slika.BeginInit();
                slika.UriSource = new Uri(put);
                slika.EndInit();

                imgNekretnine.Source = slika;

                slike.Add(slika);
                trenutnaSlika = slike.Count-1;
            }
        }

        private void btnListajDesno_Click(object sender, RoutedEventArgs e)
        {
            trenutnaSlika++;
            if (trenutnaSlika == slike.Count) trenutnaSlika = 0;

            imgNekretnine.Source = slike[trenutnaSlika];
        }

        private void btnListajLijevo_Click(object sender, RoutedEventArgs e)
        {
            trenutnaSlika--;
            if (trenutnaSlika == -1) trenutnaSlika = slike.Count-1;

            imgNekretnine.Source = slike[trenutnaSlika];
        }
    }
}
