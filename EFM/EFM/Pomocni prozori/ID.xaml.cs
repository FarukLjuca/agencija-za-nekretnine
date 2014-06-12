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
    /// Interaction logic for ID.xaml
    /// </summary>
    public partial class ID : Window
    {
        private List<int> broj;

        public ID(List<int> broj)
        {
            InitializeComponent();
            this.broj = broj;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            if (validiraj() == true)
            {
                broj.Add(Convert.ToInt32(tbxID.Text));
                this.Close();
            }
        }

        private bool validiraj()
        {
            bool dobar = true;
            foreach (char c in tbxID.Text)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    borID.BorderBrush = Brushes.Red;
                    tbxID.ToolTip = "Polje smije sadrzavari samo brojeve!";
                    dobar = false;
                    break;
                }
            }

            if (dobar == true) borID.BorderBrush = Brushes.White;
            return dobar;
        }

        private void tbxID_TextChanged(object sender, TextChangedEventArgs e)
        {
            validiraj();
        }
    }
}
