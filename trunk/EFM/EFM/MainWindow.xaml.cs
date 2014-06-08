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
using EFM.DAO;
using System.Reflection;

namespace EFM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private Zaposlenici _zaposlenici = new Zaposlenici();
		public enum Privilegija : uint { Direktor, Admin, Agent, Racunovodja, Cistacica }
		Privilegija privilegija;
        public MainWindow()
        {
            InitializeComponent();
			foreach (TabItem t in tbcGlavniTab.Items)
			{
				t.Visibility = System.Windows.Visibility.Hidden;
			}
			tbcGlavniTab.Items.Clear();
			WndLogin w = new WndLogin ();
			if (w.ShowDialog () != true) { Application.Current.Shutdown (); return; }
			privilegija = w.Privilegija;
			#region Privilegije
			AdminTabs = new TabItem[] { tabDobrodosli, tabNekretnine, tabVSaradnici, tabUgovori };
			DirektorTabs = new TabItem[] { tabDobrodosli, tabNekretnine, tabZaposleni, tabKlijenti, tabVSaradnici, tabUgovori };
			AgentTabs = new TabItem[] { tabDobrodosli, tabNekretnine, tabKlijenti };
			RacunovodjaTabs = new TabItem[] { tabDobrodosli, tabZaposleni };
			CistacicaTabs = new TabItem[] { tabDobrodosli };
			var Nesto = DirektorTabs;
			switch (privilegija)
			{
				case Privilegija.Direktor:
					break;
				case Privilegija.Admin:
					Nesto = AdminTabs;
					break;
				case Privilegija.Agent:
					Nesto = AgentTabs;
					break;
				case Privilegija.Racunovodja:
					Nesto = RacunovodjaTabs;
					break;
				case Privilegija.Cistacica:
					Nesto = CistacicaTabs;
					break;
			}
			foreach (TabItem t in Nesto)
			{
				t.Visibility = System.Windows.Visibility.Visible;
				tbcGlavniTab.Items.Add (t);
			}
			if (tabNekretnine.Visibility == System.Windows.Visibility.Hidden)
				spLabels.Children.Remove (tbl2);
			if (tabKlijenti.Visibility == System.Windows.Visibility.Hidden)
				spLabels.Children.Remove (tbl3);
			if (tabZaposleni.Visibility == System.Windows.Visibility.Hidden)
				spLabels.Children.Remove (tbl4);
			if (tabUgovori.Visibility == System.Windows.Visibility.Hidden)
				spLabels.Children.Remove (tbl5);
			if (tabVSaradnici.Visibility == System.Windows.Visibility.Hidden)
				spLabels.Children.Remove (tbl6);
			#endregion
			tbIme.Text = w.User.Ime + ", dobrodošli";
			var C = new System.Globalization.CultureInfo ("bs-Latn-BA");
			String Dan = C.DateTimeFormat.GetDayName (DateTime.Today.DayOfWeek);
			StringBuilder sb = new StringBuilder (Dan);
			sb[0] = char.ToUpper (sb[0]);
			tbDate.Text = sb.ToString() + ", " + DateTime.Today.ToShortDateString ();
            popuniNekretnine();
            popuniKlijente();
            ZaposlenikDAO zDao = new ZaposlenikDAO();
            _zaposlenici = zDao.List();
            zaposleniciGrid.ItemsSource = _zaposlenici.ListaZaposlenika;
			
        }

        private void mitUnosNekretnina_Click(object sender, RoutedEventArgs e)
        {
            Pomocni_prozori.Unos_nekretnine n = new Pomocni_prozori.Unos_nekretnine(nekretnine);
            n.ShowDialog();
        }

        private void TestPovezivanjaSaBP(object sender, RoutedEventArgs e)
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

        bool editMode = false;
        List<Nekretnina> nekretnine = new List<Nekretnina>();

        private void refreshN()
        {

            wpnlNekretnine.Children.RemoveRange(0, wpnlNekretnine.Children.Count);
            foreach (Nekretnina n in nekretnine)
            {
                if (n.prikazi == true)
                {
                    if (n.Slike.Count == 0)
                    {
                        Assembly assembly = Assembly.GetCallingAssembly();

                        BitmapImage img = new BitmapImage();
                        img.BeginInit();
                        img.UriSource = new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component/Resursi/nekretnina.jpg",
                            UriKind.Absolute);
                        img.EndInit();

                        n.Slike.Add(img);
                    }

                    Kontrole.kontrolaNekretnina kn = new Kontrole.kontrolaNekretnina(n, n.Slike[0]);
                    wpnlNekretnine.Children.Add(kn);
                }
            }
        }

        private void refreshCheckN()
        {
            wpnlNekretnine.Children.RemoveRange(0, wpnlNekretnine.Children.Count);
            foreach (Nekretnina n in nekretnine)
            {
                if (n.prikazi == true)
                {
                    if (n.Slike.Count == 0)
                    {
                        Assembly assembly = Assembly.GetCallingAssembly();

                        BitmapImage img = new BitmapImage();
                        img.BeginInit();
                        img.UriSource = new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component/Resursi/nekretnina.jpg",
                            UriKind.Absolute);
                        img.EndInit();

                        n.Slike.Add(img);
                    }

                    Kontrole.checkNekretnina kn = new Kontrole.checkNekretnina(n, n.Slike[0]);
                    wpnlNekretnine.Children.Add(kn);
                }
            }
        }

        private void btnEditMode_Click(object sender, RoutedEventArgs e)
        {
            if (editMode == false) postaviPanelu();
            refreshCheckN();
            editMode = true;
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
            btnObrisi.Click += new RoutedEventHandler(obrisiNekretnine_Click);
            spnlButtoni.Children.Add(btnObrisi);
        }

        private void dodajNekretninu_Click(object seneder, RoutedEventArgs e)
        {
            Pomocni_prozori.Unos_nekretnine nek = new Pomocni_prozori.Unos_nekretnine(nekretnine);
            nek.ShowDialog();
            if (editMode == true) refreshCheckN();
            else refreshN();
            tbxSearch_TextChanged(tbxSearch, null);
        }

        private void obrisiNekretnine_Click(object seneder, RoutedEventArgs e)
        {
            foreach (Kontrole.checkNekretnina cn in wpnlNekretnine.Children)
            {
                if (cn.IsChecked == true)
                {
                    nekretnine.Remove(cn.nekretnina);
                }
            }
            if (editMode == true) refreshCheckN();
            else refreshN();
        }

        private void popuniNekretnine()
        {
            /*
            DAO.NekretninaDAO ndao = new DAO.NekretninaDAO();
            List<Nekretnina> nekretnine = ndao.getAll();
            foreach (Nekretnina nek in nekretnine)
            {
                DAO.SlikeNekretninaDAO sln = new DAO.SlikeNekretninaDAO();
                Kontrole.kontrolaNekretnina kn = new Kontrole.kontrolaNekretnina(nek, sln.getAll()[0].Slika);
                wpnlNekretnine.Children.Add(kn);
            }
            */
            cbbpretrazivanjePo.SelectedIndex = 0;
        }

        private void tbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cbbpretrazivanjePo.SelectedIndex == 0)
            {
                foreach (Nekretnina n in nekretnine)
                {
                    if (!n.Opis.Contains(tbxSearch.Text))
                        n.prikazi = false;
                    else
                        n.prikazi = true;
                }
            }
            else if (cbbpretrazivanjePo.SelectedIndex == 1)
            {
                foreach (Nekretnina n in nekretnine)
                {
                    if (!n.Lokacija.Contains(tbxSearch.Text))
                        n.prikazi = false;
                    else
                        n.prikazi = true;
                }
            }
            else
            {
                foreach (Nekretnina n in nekretnine)
                {
                    if (!n.TipNekretnine.ToString().Contains(tbxSearch.Text))
                        n.prikazi = false;
                    else
                        n.prikazi = true;
                }
            }
            if (editMode == true) refreshCheckN();
            else refreshN();
        }

        #endregion

        #region Klijenti

        List<Klijent> klijeti = new List<Klijent>();
        bool editModeK = false;

        private void popuniKlijente()
        {
            
            DAO.KlijentDAO kd = new KlijentDAO();
            klijeti = kd.getAll();
            
            refreshK();
            cbbpretrazivanjePoKlijenti.SelectedIndex = 0;
        }

        private void btnEditModeK_Click(object sender, RoutedEventArgs e)
        {
            if (editModeK == false) postaviPaneluK();
            refreshCheckK();
            editModeK = true;
        }

        private void postaviPaneluK()
        {
            btnEditModeKlijenti.Margin = new Thickness(15, 20, 15, 5);

            Button btnDodajKlijenti = new Button();
            btnDodajKlijenti.Margin = new Thickness(15, 5, 15, 5);
            btnDodajKlijenti.Content = "Dodaj novu";
            btnDodajKlijenti.Click += new RoutedEventHandler(dodajKlijenta_Click);
            spnlButtoniKlijenti.Children.Add(btnDodajKlijenti);

            Button btnObrisiKlijenti = new Button();
            btnObrisiKlijenti.Margin = new Thickness(15, 5, 15, 5);
            btnObrisiKlijenti.Content = "Obrisi";
            btnObrisiKlijenti.Click += new RoutedEventHandler(obrisiKlijente_Click);
            spnlButtoniKlijenti.Children.Add(btnObrisiKlijenti);
        }

        private void dodajKlijenta_Click(object seneder, RoutedEventArgs e)
        {
            Pomocni_prozori.Unos_klijenta k = new Pomocni_prozori.Unos_klijenta(klijeti, _zaposlenici);
            k.ShowDialog();
            if (editModeK == true) refreshCheckK();
            else refreshK();
            tbxSearchK_TextChanged(tbxSearch, null);
        }

        private void obrisiKlijente_Click(object seneder, RoutedEventArgs e)
        {
            foreach (Kontrole.checkKlijent ck in wpnlKlijenti.Children)
            {
                if (ck.IsChecked == true)
                {
                    klijeti.Remove(ck.klijent);
                }
            }
            if (editModeK == true) refreshCheckK();
            else refreshK();
        }

        private void refreshK()
        {
            wpnlKlijenti.Children.RemoveRange(0, wpnlKlijenti.Children.Count);
            foreach (Klijent k in klijeti)
            {
                if (k.prikazi == true)
                {
                    if (k.slika == null)
                    {
                        Assembly assembly = Assembly.GetCallingAssembly();

                        BitmapImage img = new BitmapImage();
                        img.BeginInit();
                        img.UriSource = new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component/Resursi/klijent.jpg",
                            UriKind.Absolute);
                        img.EndInit();

                        k.slika = img;
                    }

                    Kontrole.kontrolaKlijent kk = new Kontrole.kontrolaKlijent(k);
                    wpnlKlijenti.Children.Add(kk);
                }
            }
        }

        private void refreshCheckK()
        {
            wpnlKlijenti.Children.RemoveRange(0, wpnlKlijenti.Children.Count);
            foreach (Klijent k in klijeti)
            {
                if (k.prikazi == true)
                {
                    if (k.slika == null)
                    {
                        Assembly assembly = Assembly.GetCallingAssembly();

                        BitmapImage img = new BitmapImage();
                        img.BeginInit();
                        img.UriSource = new Uri(@"pack://application:,,,/" + assembly.GetName().Name + ";component/Resursi/klijent.jpg",
                            UriKind.Absolute);
                        img.EndInit();

                        k.slika = img;
                    }

                    Kontrole.checkKlijent kk = new Kontrole.checkKlijent(k);
                    wpnlKlijenti.Children.Add(kk);
                }
            }
        }

        private void tbxSearchK_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (cbbpretrazivanjePoKlijenti.SelectedIndex == 0)
            {
                foreach (Klijent k in klijeti)
                {
                    if (!k.Ime.Contains(tbxSearchKlijenti.Text))
                        k.prikazi = false;
                    else
                        k.prikazi = true;
                }
            }
            else if (cbbpretrazivanjePoKlijenti.SelectedIndex == 1)
            {
                foreach (Klijent k in klijeti)
                {
                    if (!k.Prezime.Contains(tbxSearchKlijenti.Text))
                        k.prikazi = false;
                    else
                        k.prikazi = true;
                }
            }
            else
            {
                foreach (Klijent k in klijeti)
                {
                    if (!k.JMBG.ToString().Contains(tbxSearchKlijenti.Text))
                        k.prikazi = false;
                    else
                        k.prikazi = true;
                }
            }
            if (editModeK == true) refreshCheckK();
            else refreshK();
        }

        #endregion

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Snimiti u bazu ILI kreirati Exit event pa u njemu snimati
            Application.Current.Shutdown(0);
        }

        private void Unos_Zaposlenika(object sender, RoutedEventArgs e)
        {
            ZaposlenikFactory zaposlenikFactory = new ZaposlenikFactory();
            if (txtNoviZaposlenikPozicija.SelectedValue != null)
            {
                var pozicija = (ComboBoxItem)txtNoviZaposlenikPozicija.SelectedValue;
                Zaposlenik zaposlenik = zaposlenikFactory.GetZaposlenik(pozicija.Content.ToString());
                zaposlenik.Ime = txtNoviZaposlenikIme.Text;
                zaposlenik.Prezime = txtNoviZaposlenikPrezime.Text;

                //TODO Handle exception
                zaposlenik.Plata = double.Parse(txtNoviZaposlenikPlata.Text);
                zaposlenik.DatumRodjenja = txtNoviZaposlenikDatROdj.DisplayDate;
                zaposlenik.DatumZaposlenja = txtNoviZaposlenikDatZap.DisplayDate;
                zaposlenik.Jmbg = txtNoviZaposlenikJmbg.Text;
                zaposlenik.BrojLicneKarte = txtNoviZaposlenikBrojLk.Text;

                ZaposlenikDAO zaposlenikDao = new ZaposlenikDAO();
                zaposlenikDao.Create(zaposlenik);
                //_zaposlenici.ListaZaposlenika.Add(zaposlenik);
                //zaposleniciGrid.
            }
        }

        private void Unos_Vanjskog_Saradnika(object sender, RoutedEventArgs e)
        {
            VanjskiSaradnikUloga vanjskiSaradnikUloga = new VanjskiSaradnikUloga();
            if (txtNoviVSaradnikPozicija.SelectedValue != null)
            {
                var pozicija = (ComboBoxItem)txtNoviVSaradnikPozicija.SelectedValue;
                VanjskiSaradnik vanjskisaradnik = vanjskiSaradnikUloga.GetSaradnik(pozicija.Content.ToString());
                vanjskisaradnik.Naziv = txtNoviVSaradnikNaziv.Text;
                vanjskisaradnik.Plata = double.Parse(txtNoviVSaradnikPlata.Text);

                VanjskiSaradnikDAO vanjskiSaradnikDAO = new VanjskiSaradnikDAO();
                vanjskiSaradnikDAO.Create(vanjskisaradnik);    
            }
        }



		private TabItem[] AdminTabs;
		private TabItem[] AgentTabs;
		private TabItem[] DirektorTabs;
		private TabItem[] RacunovodjaTabs;
		private TabItem[] CistacicaTabs;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            System.Environment.Exit(0);
        }

		private void Hyperlink_Click_1(object sender, RoutedEventArgs e)
		{
			System.Windows.Forms.MessageBox.Show ("Nekako trbe odvesti do forme mijenjanja passworda. Ako je ovo napravljeno dobro (kako sam ja zamislio, onda će to lagano biti.. ali et'");
		}

		private void Hyperlink_Click_2(object sender, RoutedEventArgs e)
		{
			tbcGlavniTab.SelectedItem = tabNekretnine;
		}

		private void Hyperlink_Click_3(object sender, RoutedEventArgs e)
		{
			tbcGlavniTab.SelectedItem = tabKlijenti;
		}

		private void Hyperlink_Click_4(object sender, RoutedEventArgs e)
		{
			tbcGlavniTab.SelectedItem = tabZaposleni;
		}

		private void Hyperlink_Click_5(object sender, RoutedEventArgs e)
		{
			tbcGlavniTab.SelectedItem = tabUgovori;
		}

		private void Hyperlink_Click_6(object sender, RoutedEventArgs e)
		{
			tbcGlavniTab.SelectedItem = tabVSaradnici;
		}
    }
}
