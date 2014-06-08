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

namespace EFM.Kontrole
{
    /// <summary>
    /// Interaction logic for kontrolaKlijent.xaml
    /// </summary>
    public partial class kontrolaKlijent : UserControl
    {
        public kontrolaKlijent(Klijent k)
        {
            InitializeComponent();
            imgSlika.Source = k.slika;
            txtNaziv.Text = k.ToString();
        }
    }
}
