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
using System.Data.SQLite;

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
            SQLiteConnection con = new SQLiteConnection
                (@"Data Source=c:\sqlite\efmooad.db;Version=3;");
            con.Open();
            SQLiteCommand com = new SQLiteCommand("create table proba(rjec text);", con);
            com.ExecuteNonQuery();
            com.CommandText = "insert into proba values ('Uspjelo je :D');";
            com.ExecuteNonQuery();
            con.Close();
        }
	}
}
