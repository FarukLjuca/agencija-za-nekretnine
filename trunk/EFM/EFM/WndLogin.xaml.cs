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
			string s = TxtUserID.Text;
			if (!string.IsNullOrWhiteSpace(s))
				s = s.ToLower ();
			if (s == "admin") Privilegija = MainWindow.Privilegija.Admin;
			else if (s == "direktor" || string.IsNullOrWhiteSpace (s)) {Privilegija = MainWindow.Privilegija.Direktor; s = "Direktor";}
			else if (s == "cistacica") Privilegija = MainWindow.Privilegija.Cistacica;
			else if (s == "agent") Privilegija = MainWindow.Privilegija.Agent;
			else if (s.StartsWith ("racun")) Privilegija = MainWindow.Privilegija.Racunovodja;
			else { tbInfo.Visibility = System.Windows.Visibility.Visible; return; }
			{ this.DialogResult = true; User = new Zaposlenik { Ime = s.ToUpper() }; this.Close (); return; }
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

