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
		}

		private void btnOK_Click_1(object sender, RoutedEventArgs e)
		{
			DAO.ZaposlenikDAO d = new DAO.ZaposlenikDAO ();
			Direktor dd = new Direktor ();
			dd.UserName = TxtUserID.Text;
			dd = d.Read (dd);
		}

		private void btnCancel_Click_1(object sender, RoutedEventArgs e)
		{

		}
	}
}
