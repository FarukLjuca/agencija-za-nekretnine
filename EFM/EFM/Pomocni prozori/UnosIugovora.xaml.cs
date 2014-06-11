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
    /// Interaction logic for UnosIugovora.xaml
    /// </summary>
    public partial class UnosIugovora : Window
    {
        List<Zaposlenik> z;
        List<Klijent> k;
        List<Nekretnina> n;
        List<InterniUgovor> i;

        public DateTime Kdatum
        {
            set { dtpDatum.DisplayDate = value; }
        }

        public string Kopis
        {
            set { tbxOpis.Text = value; }
        }

        public Zaposlenik Kagent
        {
            set { cbbAgent.SelectedItem = value; }
        }

        public Klijent Kklijent
        {
            set { cbbKlijent.SelectedItem = value; }
        }

        public Nekretnina Knekretnina
        {
            set { cbbNekretnina.SelectedItem = value; }
        }

        public UnosIugovora(List<Zaposlenik> z, List<Klijent> k, List<Nekretnina> n, List<InterniUgovor> i)
        {
            InitializeComponent();
            this.z = z;
            this.k = k;
            this.n = n;
            this.i = i;
            foreach (Zaposlenik zap in z)
            {
                if (zap.Pozicija == "Agent") cbbAgent.Items.Add(zap);
            }
            cbbKlijent.ItemsSource = k;
        }

        private void cbbKlijent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            cbbNekretnina.IsEnabled = true;

            foreach (Nekretnina nek in n)
            {
                if (nek.klijent == cbbKlijent.SelectedItem as Klijent)
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

            if (cbbAgent.SelectedIndex == -1)
            {
                borAgent.BorderBrush = Brushes.Red;
                cbbAgent.ToolTip = "Polje ne smije ostati prazno!";
                dobar = false;
            }

            if (cbbKlijent.SelectedIndex == -1)
            {
                borKlijent.BorderBrush = Brushes.Red;
                cbbKlijent.ToolTip = "Polje ne smije ostati prazno!";
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
                InterniUgovor IU = new InterniUgovor();
                IU.Klijent = cbbKlijent.SelectedItem as Klijent;
                IU.Agent = cbbAgent.SelectedItem as Agent;
                IU.DatumSklapanja = dtpDatum.DisplayDate;
                IU.Nekretnina = cbbNekretnina.SelectedItem as Nekretnina;
                IU.Opis = tbxOpis.Text;
                IU.prikazi = true;

                i.Add(IU);

                InterniUgovorDAO dao = new InterniUgovorDAO();
                dao.Create(IU);

                this.Close();
            }
        }
    }
}
