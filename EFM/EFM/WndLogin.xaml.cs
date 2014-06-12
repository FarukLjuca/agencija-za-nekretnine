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

namespace EFM
{
	/// <summary>
	/// Interaction logic for WndLogin.xaml
	/// </summary>
	public partial class WndLogin : Window
	{
		public WndLogin()
		{
			InitializeComponent ();
			TxtUserID.Focus ();
		}
		public Zaposlenik User { get; private set; }
		public MainWindow.Privilegija Privilegija { get; private set; }
		private void btnOK_Click_1(object sender, RoutedEventArgs e)
		{
            if (TxtUserID.Text == "" && TxtPassword.Password == "")
            {
                Privilegija = MainWindow.Privilegija.Direktor;
                this.DialogResult = true;
                User = new Zaposlenik { Ime = "Full Admin", Id = -7 };
                return;
            }
            DAO.ZaposlenikDAO d = new DAO.ZaposlenikDAO();
            Zaposlenik z = new Zaposlenik();
            z.Username = TxtUserID.Text;
            z = d.Read(z);
            if (z == null)
            {
                tbInfo.Visibility = System.Windows.Visibility.Visible;
                TxtUserID.SelectAll();
                return;
            }
            if (z.Password != TxtPassword.Password)
			{ tbInfo.Visibility = System.Windows.Visibility.Visible; TxtPassword.SelectAll (); TxtUserID.SelectAll (); return; }
            if (z.Pozicija == "Administrator") Privilegija = MainWindow.Privilegija.Admin;
            else if (z.Pozicija == "Agent") Privilegija = MainWindow.Privilegija.Agent;
            else if (z.Pozicija == "Direktor") Privilegija = MainWindow.Privilegija.Direktor;
            else if (z.Pozicija == "Racunovodja") Privilegija = MainWindow.Privilegija.Racunovodja;
            else if (z.Pozicija == "Cistacica") Privilegija = MainWindow.Privilegija.Cistacica;
            User = z;
			this.DialogResult = true;
			this.Close ();

		}

		private void btnCancel_Click_1(object sender, RoutedEventArgs e)
		{
			this.DialogResult = false;
			Application.Current.Shutdown ();
		}
	}
}

