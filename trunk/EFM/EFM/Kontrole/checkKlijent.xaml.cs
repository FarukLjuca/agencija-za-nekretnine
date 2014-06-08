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
    /// Interaction logic for checkKlijent.xaml
    /// </summary>
    public partial class checkKlijent : UserControl
    {
        public Klijent klijent { get; set; }

        public checkKlijent(Klijent k)
        {
            InitializeComponent();
            imgSlika.Source = k.slika;
            txtNaziv.Text = k.ToString();
            klijent = k;
        }

        public bool IsChecked
        {
            get { return cbxEdit.IsChecked == true; }
        }

        public override string ToString()
        {
            return klijent.ToString1();
        }
    }
}
