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
    /// Interaction logic for Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        public string pass { get; set; }
        public int id { get; set; }
        private bool kliknuo = false;

        public Password(string pass, int id)
        {
            InitializeComponent();
            this.pass = pass;
            this.id = id;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            kliknuo = true;

            if (validirajNovi() && validirajStari())
            {
                DAO.ZaposlenikDAO dao = new DAO.ZaposlenikDAO();
                dao.Pass(tbxNovi2.Text, id);
                this.Close();
            }
        }

        private bool validirajStari()
        {
            if (tbxStari.Text != pass && kliknuo == true)
            {
                borStari.BorderBrush = Brushes.Red;
                tbxStari.ToolTip = "Niste ispravno unijeli stari password!";
                return false;
            }
            else
            {
                borStari.BorderBrush = Brushes.White;
                tbxStari.ToolTip = "OK";
                return true;
            }
        }

        private bool validirajNovi()
        {
            if (tbxNovi2.Text != tbxNovi1.Text && kliknuo == true)
            {
                borNovi2.BorderBrush = Brushes.Red;
                borNovi2.ToolTip = "Niste ispravno ponovili novi password!";
                return false;
            }
            else
            {
                borNovi2.BorderBrush = Brushes.White;
                borNovi2.ToolTip = "OK";
                return true;
            }
        }

        private void tbxStari_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajStari();
        }

        private void tbxNovi2_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajNovi();
        }
    }
}
