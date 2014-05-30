using System;
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

namespace EFM.Pomocni_prozori
{
    /// <summary>
    /// Interaction logic for Kolona.xaml
    /// </summary>
    public partial class Kolona : UserControl
    {
        private StackPanel panela;

        public Kolona(StackPanel Panela)
        {
            InitializeComponent();
            panela = Panela;
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            panela.Children.Insert(panela.Children.IndexOf(this) + 1, new Kolona(panela));
        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            panela.Children.Remove(this);
        }

        public string dajString()
        {
            string rez = tbxNaziv.Text + " " + cbbTipPodatka.Text;
            //TODO Nastaviti
            return rez;
        }
    }
}
