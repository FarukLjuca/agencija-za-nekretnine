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
    /// Interaction logic for Unos_entiteta.xaml
    /// </summary>
    public partial class Unos_entiteta : Window
    {
        public Unos_entiteta()
        {
            InitializeComponent();

            stpGlavnaPanela.Children.Add(new Zaglavlje());
            stpGlavnaPanela.Children.Add(new Kolona(stpGlavnaPanela));
            stpGlavnaPanela.Children.Add(new Kolona(stpGlavnaPanela));
        }
    }
}
