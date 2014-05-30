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

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                SQLiteConnection con = new SQLiteConnection(@"Data Source=c:\sqlite\efmooad.db;Version=3;");
                con.Open();
                string komanda = "create table " + tbxNazivEntiteta.Text + "(";
                foreach (object k in stpGlavnaPanela.Children)
                {
                    if (k is Kolona)
                    {
                        komanda += (k as Kolona).dajString();
                        if (stpGlavnaPanela.Children.IndexOf(k as UIElement) != stpGlavnaPanela.Children.Count - 1)
                            komanda += ", ";
                    }
                }
                komanda += ");";
                SQLiteCommand com = new SQLiteCommand(komanda, con);
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
