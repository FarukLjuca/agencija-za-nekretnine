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
using System.Data.OracleClient;
using System.Data.OleDb;

namespace EFM
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent ();
            WndLogin w = new WndLogin();
            w.ShowDialog();
		}

        private void mitUnosNekretnina_Click(object sender, RoutedEventArgs e)
        {
            Pomocni_prozori.Unos_nekretnine n = new Pomocni_prozori.Unos_nekretnine();
            n.ShowDialog();
        }

        private void TestPovezivanjaSaBP (object sender, RoutedEventArgs e)
        {
            //OracleConnection c = new OracleConnection();
            OleDbConnection c = new OleDbConnection();
            //c.ConnectionString = "host=80.65.65.66;database=ETFLAB.DB.LAB.ETF.UNSA.BA;uid=efmooad;pwd=hoa8DFWNeS533utR/Q+r3osHzyH5H835JQ==";
            c.ConnectionString = "provider=Oracle10g;data source=ETFLAB.DB.LAB.ETF.UNSA.BA;user id=efmooad;password=hoa8DFWNeS533utR/Q+r3osHzyH5H835JQ==";
            try { c.Open(); }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            MessageBox.Show("Connected to " + c.Database);
        }
	}
}
