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
    public partial class UnosEUgovora : Window
    {
        List<VanjskiSaradnik> z;
        List<EksterniUgovor> i;

        public DateTime Edatum
        {
            set { dtpDatumPotpisa.DisplayDate = value; }
        }

        public string Eopis
        {
            set { tbxOpisUgovora.Text = value; }
        }

        public Zaposlenik ESaradnik
        {
            set { cbbVanjskiSaradnik.SelectedItem = value; }
        }

        public UnosEUgovora(List<VanjskiSaradnik> z, List<EksterniUgovor> i)
        {
            InitializeComponent();
            this.z = z;
            this.i = i;
            foreach (VanjskiSaradnik zap in z)
            {
                cbbVanjskiSaradnik.Items.Add(sar.ToString());
            }
            
        }

        private void btnCancell_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOKk_Click(object sender, RoutedEventArgs e)
        {
            bool dobar = true;

            if (dtpDatumPotpisa.SelectedDate == null)
            {
                borDatumPotpisa.BorderBrush = Brushes.Red;
                dtpDatumPotpisa.ToolTip = "Polje ne smije ostati prazno!";
                dobar = false;
            }

            if (cbbVanjskiSaradnik.SelectedIndex == -1)
            {
                borVanjskiSaradnik.BorderBrush = Brushes.Red;
                cbbVanjskiSaradnik.ToolTip = "Polje ne smije ostati prazno!";
                dobar = false;
            }


            if (dobar == true)
            {
                EksterniUgovor EU = new EksterniUgovor();
                EU.VanjskiSaradnik = cbbVanjskiSaradnik.SelectedItem as VanjskiSaradnik;
                EU.DatumSklapanja = dtpDatumPotpisa.DisplayDate;
                EU.Opis = tbxOpisUgovora.Text;

                i.Add(EU);

                EksterniUgovorDAO dao = new EksterniUgovorDAO();
                dao.Create(EU);

                this.Close();
            }
        }
    }
}
