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
			//Sada je dovoljno samo kao user i pass prazno -.-
			if (TxtUserID.Text == "" && TxtPassword.Text == "")
			{ this.DialogResult = true; Privilegija = MainWindow.Privilegija.Direktor; User = new Zaposlenik { Ime = "Neko" }; this.Close (); return; }
			//DAO.ZaposlenikDAO d = new DAO.ZaposlenikDAO ();
			//Zaposlenik z = new Zaposlenik ();
			//z.UserName = TxtUserID.Text;
			//z = d.Read (z);
			//if (z == null)
			//{
			//	tbInfo.Visibility = System.Windows.Visibility.Visible;
			//	TxtUserID.SelectAll ();
			//	return;
			//}
			//if (z.PassWord != TxtPassword.Text)
			//{ tbInfo.Visibility = System.Windows.Visibility.Visible; TxtPassword.SelectAll (); return; }
			//if (z.TIP == "Administrator") Privilegija = MainWindow.Privilegija.Admin;
			//else if (z.TIP == "Agent") Privilegija = MainWindow.Privilegija.Agent;
			//else if (z.TIP == "Direktor") Privilegija = MainWindow.Privilegija.Direktor;
			//else if (z.TIP == "Racunovodja") Privilegija = MainWindow.Privilegija.Racunovodja;
			//else if (z.TIP == "Cistacica") Privilegija = MainWindow.Privilegija.Cistacica;
			//User = z;
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

