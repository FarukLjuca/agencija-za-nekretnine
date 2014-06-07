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
using System.Data.OleDb;

namespace EFM
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Privilegija privilegija;
		public MainWindow()
		{
			InitializeComponent ();
            WndLogin w = new WndLogin();
			if (w.ShowDialog () != true) Application.Current.Shutdown ();
			privilegija = w.Privilegija;
			tbIme.Text = w.User.Ime + ", dobrodošli";
			tbDate.Text = DateTime.Today.DayOfWeek.ToString () + ", " + DateTime.Today.ToShortDateString ();


            popuniNekretnine();
		}
		public enum Privilegija : uint { Direktor, Admin, Agent, Racunovodja, Cistacica }
        private void mitUnosNekretnina_Click(object sender, RoutedEventArgs e)
        {
            Pomocni_prozori.Unos_nekretnine n = new Pomocni_prozori.Unos_nekretnine(wpnlNekretnine);
            n.ShowDialog();
        }

        private void TestPovezivanjaSaBP (object sender, RoutedEventArgs e)
        {
            //Provider=OraOLEDB.Oracle.1MSDAORA.1
            /*OleDbConnection cn = new OleDbConnection(
  "Provider=MSDAORA.1;Data Source=TEST;User ID=efmooad;" +
  "Password=efmooad;Default Collection =SAMPLEDB");
            cn.Open();
            OleDbCommand k = new OleDbCommand();
            
            
            sqliteconnection con = new sqliteconnection
                (@"data source=c:\sqlite\efmooad.db;version=3;");
            con.open();
            sqlitecommand com = new sqlitecommand("create table proba(rjec text);", con);
            com.executenonquery();
            com.commandtext = "insert into proba values ('uspjelo je :d');";
            com.executenonquery();
            con.close();
            */


        }

        private void UnosEntiteta(object sender, RoutedEventArgs e)
        {
            Pomocni_prozori.Unos_entiteta en = new Pomocni_prozori.Unos_entiteta();
            en.ShowDialog();
        }

        #region Nekretnine

        private void btnEditMode_Click(object sender, RoutedEventArgs e)
        {
            postaviPanelu();
        }

        private void postaviPanelu()
        {
            btnEditMode.Margin = new Thickness(15, 20, 15, 5);

            Button btnDodaj = new Button();
            btnDodaj.Margin = new Thickness(15, 5, 15, 5);
            btnDodaj.Content = "Dodaj novu";
            btnDodaj.Click += new RoutedEventHandler(dodajNekretninu_Click);
            spnlButtoni.Children.Add(btnDodaj);

            Button btnObrisi = new Button();
            btnObrisi.Margin = new Thickness(15, 5, 15, 5);
            btnObrisi.Content = "Obrisi";
            spnlButtoni.Children.Add(btnObrisi);
        }

        private void dodajNekretninu_Click(object seneder, RoutedEventArgs e)
        {
            Pomocni_prozori.Unos_nekretnine nek = new Pomocni_prozori.Unos_nekretnine(wpnlNekretnine);
            nek.ShowDialog();
        }

        private void popuniNekretnine()
        {
            //try
            //{
                DAO.NekretninaDAO ndao = new DAO.NekretninaDAO();
                List<Nekretnina> nekretnine = ndao.getAll();
                foreach (Nekretnina nek in nekretnine)
                {
                    DAO.SlikeNekretninaDAO sln = new DAO.SlikeNekretninaDAO();
                    Kontrole.kontrolaNekretnina kn = new Kontrole.kontrolaNekretnina(nek, sln.getAll()[0].Slika);
                    wpnlNekretnine.Children.Add(kn);
                }
            /*}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }*/
        }

        #endregion

		private void BtnExit_Click(object sender, RoutedEventArgs e)
		{
			//TODO: Snimiti u bazu ILI kreirati Exit event pa u njemu snimati
			Application.Current.Shutdown (0);
		}
		public static System.Drawing.Bitmap BitmapSourceToBitmap2(BitmapSource srs)
		{
			int width = srs.PixelWidth;
			int height = srs.PixelHeight;
			int stride = width * ((srs.Format.BitsPerPixel + 7) / 8);
			IntPtr ptr = IntPtr.Zero;
			try
			{
				ptr = System.Runtime.InteropServices.Marshal.AllocHGlobal (height * stride);
				srs.CopyPixels (new Int32Rect (0, 0, width, height), ptr, height * stride, stride);
				using (var btm = new System.Drawing.Bitmap (width, height, stride, System.Drawing.Imaging.PixelFormat.Format1bppIndexed, ptr))
				{
					return new System.Drawing.Bitmap (btm);
				}
			}
			finally
			{
				if (ptr != IntPtr.Zero)
					System.Runtime.InteropServices.Marshal.FreeHGlobal (ptr);
			}
		}
		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			Zaposlenik z = new Administrator
			{
				Ime = "Meho",
				Prezime = "Mehić",
				AdresaStanovanja = "KK",
				BrojLicneKarte = "BL3K_KBSJrt43",
				BrojTelefona = "0534300434030",
				JMBG = "JMBG129466546",
				DatumRodjenja = DateTime.Today,
				DatumUposlenja = DateTime.Today,
				PassWord = "Password",
				Plata = 1231,
				Slika = null,
				UserName = "mmehic3"
			};
			DAO.ZaposlenikDAO d = new DAO.ZaposlenikDAO ();
			System.Windows.Forms.MessageBox.Show (d.Create (z).ToString());
			d.Read (z);
		}
    }
}
