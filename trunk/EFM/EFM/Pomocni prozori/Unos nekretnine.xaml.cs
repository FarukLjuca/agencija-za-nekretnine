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
                cbbKlijenti.Items.Add(k);
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
            if (validirajLokacije() == true && validirajCijenu() == true)
            {
                List<Nekretnina.EnumTipNekretnine> l =
                    Enum.GetValues(typeof(Nekretnina.EnumTipNekretnine)).Cast<Nekretnina.EnumTipNekretnine>().ToList();
                Nekretnina.EnumTipNekretnine e1 = l[cbbTipNekretnine.SelectedIndex];
                if (tbxCijena.Text == "") tbxCijena.Text = "0.0";
                decimal dec = Convert.ToDecimal(tbxCijena.Text);
                Nekretnina n = new Nekretnina(txtLokacija.Text, txtOpis.Text, e1,
                    dec, 0, cbxRezervisanost.IsChecked == true, null);
                n.Slike = slike;
                n.klijent = cbbKlijenti.SelectedItem as Klijent;

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
            if (txtLokacija.Text == "") { borLokacija.BorderBrush = Brushes.Red; return false; }
            else
            {
                borLokacija.BorderBrush = Brushes.White;
                return true;
            }
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
            if (validirajLokacije() == false) { pocrveni(borLokacija); tbxLokacija.ToolTip = "Polje ne smije biti prazno!"; }
            else odcrveni(borLokacija);
        }

        private bool validirajCijenu()
        {
            bool dobar = true;
            foreach (char c in tbxCijena.Text)
            {
                if (!(c >= '0' && c <= '9') && c != '.')
                {
                    tbxCijena.ToolTip = "Polje smije sadrzavari samo brojeve!";
                    borCijena.BorderBrush = Brushes.Red;
                    dobar = false;
                    break;
                }
            }

            if (dobar == true) borCijena.BorderBrush = Brushes.White;

            return dobar;
        }

        private void tbxCijena_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajCijenu();
        }

        public void popuni(Nekretnina n)
        {
            txtLokacija.Text = n.Lokacija;
            txtOpis.Text = n.Opis;
            cbbTipNekretnine.SelectedItem = n.TipNekretnine;
            tbxCijena.Text = n.Cijena.ToString();
            cbbKlijenti.SelectedItem = n.klijent;
            cbxRezervisanost.IsChecked = n.DaLiJeRezervisana;
            slike = n.Slike;
            if (slike.Count > 0)
                imgNekretnine.Source = slike[0];
        }
    }
}
