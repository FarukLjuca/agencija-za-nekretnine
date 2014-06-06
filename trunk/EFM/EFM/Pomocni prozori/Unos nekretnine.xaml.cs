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
        WrapPanel lista = null;

        public Unos_nekretnine(WrapPanel l)
        {
            InitializeComponent();
            cbbTipNekretnine.ItemsSource =
                Enum.GetValues(typeof(Nekretnina.EnumTipNekretnine)).Cast<Nekretnina.EnumTipNekretnine>().ToList();
            lista = l;
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
                slike,  cbxDaLiJeOciscena.IsChecked == true, cbxRezervisanost.IsChecked == true);

            EFM.Kontrole.kontrolaNekretnina kon = new Kontrole.kontrolaNekretnina(n);
            lista.Children.Add(kon);

            //TODO Spasi u bazuž

            this.Close();
        }

        private void btnNovaSlika_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.DefaultExt = ".jpg";
            open.Filter = "Images(.jpg)|*.jpg";
            if (open.ShowDialog() == true)
            {
                string put = open.FileName;

                Image slika = new Image();
                slika.Source = new ImageSourceConverter().ConvertFromString(put) as ImageSource;

                imgNekretnine.Source = slika.Source;

                slike.Add(slika);
                trenutnaSlika = slike.Count-1;
            }
        }

        private void btnListajDesno_Click(object sender, RoutedEventArgs e)
        {
            trenutnaSlika++;
            if (trenutnaSlika == slike.Count) trenutnaSlika = 0;

            imgNekretnine.Source = slike[trenutnaSlika].Source;
        }

        private void btnListajLijevo_Click(object sender, RoutedEventArgs e)
        {
            trenutnaSlika--;
            if (trenutnaSlika == -1) trenutnaSlika = slike.Count-1;

            imgNekretnine.Source = slike[trenutnaSlika].Source;
        }
    }
}
