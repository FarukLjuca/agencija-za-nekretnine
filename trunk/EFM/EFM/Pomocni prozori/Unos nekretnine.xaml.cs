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
        List<Nekretnina> nekretnine = null;

        public Unos_nekretnine(List<Nekretnina> nekretnine, List<Klijent> klijenti)
        {
            InitializeComponent();
            cbbTipNekretnine.ItemsSource =
                Enum.GetValues(typeof(Nekretnina.EnumTipNekretnine)).Cast<Nekretnina.EnumTipNekretnine>().ToList();
            foreach (Klijent k in klijenti)
            {
                cbbKlijenti.Items.Add(k.ToString());
            }
            this.nekretnine = nekretnine;
            cbbTipNekretnine.SelectedIndex = 0;
        }
        
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (validirajLokacije() == true)
            {
                List<Nekretnina.EnumTipNekretnine> l =
                    Enum.GetValues(typeof(Nekretnina.EnumTipNekretnine)).Cast<Nekretnina.EnumTipNekretnine>().ToList();
                Nekretnina.EnumTipNekretnine e1 = l[cbbTipNekretnine.SelectedIndex];
                if (txtCijena.Text == "") txtCijena.Text = "0";
                Nekretnina n = new Nekretnina(txtLokacija.Text, txtOpis.Text, e1,
                    Convert.ToDecimal(tbxCijena.Text), 0, cbxRezervisanost.IsChecked == true, cbbKlijenti.SelectedItem as Klijent);
                n.Slike = slike;

                nekretnine.Add(n);

                DAO.NekretninaDAO daon = new DAO.NekretninaDAO();
                daon.Create(n);

                foreach (BitmapImage i in slike)
                {
                    SlikeNekretnina sn = new SlikeNekretnina(n, i);

                    DAO.SlikeNekretninaDAO daosn = new DAO.SlikeNekretninaDAO();
                    daosn.Create(sn);
                }

                this.Close();
            }
            else pocrveni(borLokacija);
        }

        private bool validirajLokacije()
        {
            if (txtLokacija.Text == "") return false;
            return true;
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
                slika.UriSource = new Uri(put, UriKind.Absolute);
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

        private void pocrveni (Border b)
        {
            b.BorderBrush = Brushes.Red;
        }

        private void odcrveni(Border b)
        {
            b.BorderBrush = Brushes.White;
        }

        private void txtLokacija_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (validirajLokacije() == false) pocrveni(borLokacija);
            else odcrveni(borLokacija);
        }
    }
}
