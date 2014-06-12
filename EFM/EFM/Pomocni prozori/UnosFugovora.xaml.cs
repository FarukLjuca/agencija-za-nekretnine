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
    /// Interaction logic for UnosFugovora.xaml
    /// </summary>
    public partial class UnosFugovora : Window
    {
        public partial class UnosFugovora : Window
        {
            List<Klijent> k;
            List<Klijent> p;
            List<Nekretnina> n;
            List<FinalniUgovor> f;

            public UnosFugovora(List<Klijent> k, List<Nekretnina> n, List<FinalniUgovor> f)
            {
                InitializeComponent();
                this.k = k;
                this.p = k;
                this.n = n;
                this.f = f;
                cbbKupac.ItemsSource = k;
                cbbProdavac.ItemsSource = k;
            }

            private void cbbProdavac_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                cbbNekretnina.IsEnabled = true;

                foreach (Nekretnina nek in n)
                {
                    if (nek.klijent == cbbProdavac.SelectedItem as Klijent)
                        cbbNekretnina.Items.Add(nek);
                }
            }

            private void btnCancel_Click(object sender, RoutedEventArgs e)
            {
                this.Close();
            }

            private void btnOK_Click(object sender, RoutedEventArgs e)
            {
                bool dobar = true;

                if (dtpDatum.SelectedDate == null)
                {
                    borDatum.BorderBrush = Brushes.Red;
                    dtpDatum.ToolTip = "Polje ne smije ostati prazno!";
                    dobar = false;
                }

                if (cbbKupac.SelectedIndex == -1)
                {
                    borKupac.BorderBrush = Brushes.Red;
                    cbbKupac.ToolTip = "Polje ne smije ostati prazno!";
                    dobar = false;
                }

                if (cbbProdavac.SelectedIndex == -1)
                {
                    borProdavac.BorderBrush = Brushes.Red;
                    cbbProdavac.ToolTip = "Polje ne smije ostati prazno!";
                    dobar = false;
                }

                if (cbbNekretnina.SelectedIndex == -1)
                {
                    borNekretnina.BorderBrush = Brushes.Red;
                    cbbNekretnina.ToolTip = "Polje ne smije ostati prazno!";
                    dobar = false;
                }

                if (dobar == true)
                {
                    FinalniUgovor FU = new FinalniUgovor();
                    FU.Kupac = cbbKupac.SelectedItem as Klijent;
                    FU.Prodavac = cbbProdavac.SelectedItem as Klijent;
                    FU.DatumSklapanja = dtpDatum.DisplayDate;
                    FU.Nekretnina = cbbNekretnina.SelectedItem as Nekretnina;
                    FU.Opis = tbxOpis.Text;
                    FU.prikazi = true;

                    f.Add(FU);

                    FinalniUgovorDAO dao = new FinalniUgovorDAO();
                    dao.Create(FU);

                    this.Close();
                }
            }
        }
    }
}
