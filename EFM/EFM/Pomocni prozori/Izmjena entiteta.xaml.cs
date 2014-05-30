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
using System.Data.SQLite;

namespace EFM.Pomocni_prozori
{
    /// <summary>
    /// Interaction logic for Izmjena_entiteta.xaml
    /// </summary>
    public partial class Izmjena_entiteta : Window
    {
        public Izmjena_entiteta()
        {
            InitializeComponent();

            stpGlavnaPanela.Children.Add(new Zaglavlje());
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void cbbEntitet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
