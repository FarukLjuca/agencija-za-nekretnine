﻿using System;
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
using System.Diagnostics;

namespace EFM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
		private Zaposlenici _zaposlenici = new Zaposlenici();
        private VanjskiSaradnici _saradnici = new VanjskiSaradnici();
		public enum Privilegija : uint { Direktor, Admin, Agent, Racunovodja, Cistacica }
		Privilegija privilegija;
        Zaposlenik user = null;
        public MainWindow()
        {
            InitializeComponent();
			Test ();
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
            user = w.User;
			var C = new System.Globalization.CultureInfo ("bs-Latn-BA");
			String Dan = C.DateTimeFormat.GetDayName (DateTime.Today.DayOfWeek);
			StringBuilder sb = new StringBuilder (Dan);
			sb[0] = char.ToUpper (sb[0]);
			tbDate.Text = sb.ToString() + ", " + DateTime.Today.ToShortDateString ();
            popuniNekretnine();
            popuniKlijente();
            popuniIugovore();
            popuniFugovore();
            ZaposlenikDAO zDao = new ZaposlenikDAO();
            _zaposlenici = zDao.List();
            zaposleniciGrid.ItemsSource = _zaposlenici.ListaZaposlenika;

            VanjskiSaradnikDAO sDao = new VanjskiSaradnikDAO();
            _saradnici = sDao.List();
            saradniciGrid.ItemsSource = _saradnici.ListaVanjskihSaradnika;
			
        }

        private void mitUnosNekretnina_Click(object sender, RoutedEventArgs e)
        {
            Pomocni_prozori.Unos_nekretnine n = new Pomocni_prozori.Unos_nekretnine(nekretnine, klijeti);
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
                    dodajContextMenu(kn);
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
                    dodajContextMenu(kn);
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
            Pomocni_prozori.Unos_nekretnine nek = new Pomocni_prozori.Unos_nekretnine(nekretnine, klijeti);
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
                    DAO.NekretninaDAO dao = new NekretninaDAO();
                    dao.Delete(cn.nekretnina);
                }
            }
            if (editMode == true) refreshCheckN();
            else refreshN();
        }

        private void popuniNekretnine()
        {
            
            DAO.NekretninaDAO ndao = new DAO.NekretninaDAO();
            nekretnine = ndao.getAll(klijeti);
            foreach (Nekretnina nek in nekretnine)
            {
                DAO.SlikeNekretninaDAO slndao = new DAO.SlikeNekretninaDAO();
                List<SlikeNekretnina> sln = new List<SlikeNekretnina>();
                sln = slndao.getAll(klijeti, nekretnine);
                foreach (SlikeNekretnina SN in sln)
                {
                    if (SN.Nekretnina == nek) nek.Slike.Add(SN.Slika);
                }
            }
            if (editMode == true) refreshN();
            else refreshCheckN();
            
            
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

        private void dodajContextMenu(Control c)
        {
            ContextMenu cm = new ContextMenu();

            MenuItem miDetalji = new MenuItem();
            miDetalji.Header = "Prikaži detalje";
            miDetalji.Click += new RoutedEventHandler(detalji);
            cm.Items.Add(miDetalji);

            MenuItem miObrisi = new MenuItem();
            miObrisi.Header = "Obrisi";
            miObrisi.Click += new RoutedEventHandler(obrisi);
            cm.Items.Add(miObrisi);

            MenuItem miIzmjeni = new MenuItem();
            miIzmjeni.Header = "Izmjeni";
            miIzmjeni.Click += new RoutedEventHandler(izmjeni);
            cm.Items.Add(miIzmjeni);

            c.ContextMenu = cm;
        }

        private void detalji(object sender, RoutedEventArgs e)
        {
            string tekst = "";

            var item = sender as MenuItem;
            var menu = item.Parent as ContextMenu;

            if (menu.PlacementTarget is Kontrole.checkKlijent)
                tekst = (menu.PlacementTarget as Kontrole.checkKlijent).ToString();
            else if (menu.PlacementTarget is Kontrole.checkNekretnina)
                tekst = (menu.PlacementTarget as Kontrole.checkNekretnina).ToString();
            else if (menu.PlacementTarget is Kontrole.kontrolaKlijent)
                tekst = (menu.PlacementTarget as Kontrole.kontrolaKlijent).ToString();
            else if (menu.PlacementTarget is Kontrole.kontrolaNekretnina)
                tekst = (menu.PlacementTarget as Kontrole.kontrolaNekretnina).ToString();

            MessageBox.Show(tekst);
        }

        private void obrisi(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            var menu = item.Parent as ContextMenu;

            if (menu.PlacementTarget is Kontrole.checkKlijent)
            {
                klijeti.Remove((menu.PlacementTarget as Kontrole.checkKlijent).klijent);
                refreshCheckK();
            }
            else if (menu.PlacementTarget is Kontrole.checkNekretnina)
            {
                nekretnine.Remove((menu.PlacementTarget as Kontrole.checkNekretnina).nekretnina);
                refreshCheckN();
            }
            else if (menu.PlacementTarget is Kontrole.kontrolaKlijent)
            {
                klijeti.Remove((menu.PlacementTarget as Kontrole.kontrolaKlijent).klijent);
                refreshK();
            }
            else if (menu.PlacementTarget is Kontrole.kontrolaNekretnina)
            {
                nekretnine.Remove((menu.PlacementTarget as Kontrole.kontrolaNekretnina).nekretnina);
                refreshN();
            }
        }

        private void izmjeni(object sender, RoutedEventArgs e)
        {
            var item = sender as MenuItem;
            var menu = item.Parent as ContextMenu;

            Pomocni_prozori.Unos_klijenta uk = new Pomocni_prozori.Unos_klijenta(klijeti, _zaposlenici.ListaZaposlenika);
            Pomocni_prozori.Unos_nekretnine un = new Pomocni_prozori.Unos_nekretnine(nekretnine, klijeti);

            Klijent k = null;
            Nekretnina n = null;

            if (menu.PlacementTarget is Kontrole.checkKlijent)
            {
                k = (menu.PlacementTarget as Kontrole.checkKlijent).klijent;
                uk.popuni(k);
            }
            else if (menu.PlacementTarget is Kontrole.kontrolaKlijent)
            {
                k = (menu.PlacementTarget as Kontrole.kontrolaKlijent).klijent;
                uk.popuni(k);
            }
            else if (menu.PlacementTarget is Kontrole.kontrolaNekretnina)
            {
                n = (menu.PlacementTarget as Kontrole.kontrolaNekretnina).nekretnina;
                un.popuni(n);
            }
            else if (menu.PlacementTarget is Kontrole.checkNekretnina)
            {
                n = (menu.PlacementTarget as Kontrole.checkNekretnina).nekretnina;
                un.popuni(n);
            }

            if (k != null)
            {
                if (uk.ShowDialog() == true)
                {
                    KlijentDAO dao = new KlijentDAO();
                    dao.Delete((menu.PlacementTarget as Kontrole.kontrolaKlijent).klijent);

                    if (menu.PlacementTarget is Kontrole.checkKlijent)
                    {
                        refreshCheckK();
                    }
                    else if (menu.PlacementTarget is Kontrole.kontrolaKlijent)
                    {
                        refreshK();
                    }
                }
            }
            else if (n != null)
            {
                if (un.ShowDialog() == true)
                {
                    NekretninaDAO dao = new NekretninaDAO();
                    dao.Delete((menu.PlacementTarget as Kontrole.kontrolaNekretnina).nekretnina);

                    if (menu.PlacementTarget is Kontrole.checkNekretnina)
                    {
                        refreshCheckN();
                    }
                    else if (menu.PlacementTarget is Kontrole.kontrolaNekretnina)
                    {
                        refreshN();
                    }

                }
            }
        }

        #endregion

        #region Klijenti

        List<Klijent> klijeti = new List<Klijent>();
        bool editModeK = false;

        private void popuniKlijente()
        {
            
            DAO.KlijentDAO kd = new KlijentDAO();
            klijeti = kd.getAll(_zaposlenici.ListaZaposlenika);
            
            
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
            Pomocni_prozori.Unos_klijenta k = new Pomocni_prozori.Unos_klijenta(klijeti, _zaposlenici.ListaZaposlenika);
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
                    KlijentDAO dao = new KlijentDAO();
                    dao.Delete(ck.klijent);
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
                    dodajContextMenu(kk);
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
                    dodajContextMenu(kk);
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

        #region Interni ugovori

        private List<InterniUgovor> Iugovori = new List<InterniUgovor>();
        private bool editModeI = false;

        private void btnEditModeI_Click(object sender, RoutedEventArgs e)
        {
            if (editModeI == false)
            {
                btnEditModeI.Margin = new Thickness(15, 20, 15, 5);

                Button btnDodajI = new Button();
                btnDodajI.Margin = new Thickness(15, 5, 15, 5);
                btnDodajI.Content = "Dodaj novi";
                btnDodajI.Click += new RoutedEventHandler(dodajI_Click);
                spnlButtoniI.Children.Add(btnDodajI);

                Button btnObrisiI = new Button();
                btnObrisiI.Margin = new Thickness(15, 5, 15, 5);
                btnObrisiI.Content = "Obrisi";
                btnObrisiI.Click += new RoutedEventHandler(obrisiI_Click);
                spnlButtoniI.Children.Add(btnObrisiI);

                Button btnIzmjeni = new Button();
                btnIzmjeni.Margin = new Thickness(15, 5, 15, 5);
                btnIzmjeni.Content = "Izmjeni";
                btnIzmjeni.Click += new RoutedEventHandler(btnIzmjeni_Click);
                spnlButtoniI.Children.Add(btnIzmjeni);
            }

            editModeI = true;
        }

        private void btnIzmjeni_Click(object sender, RoutedEventArgs e)
        {
            List<int> broj = new List<int>();
            Pomocni_prozori.ID id = new Pomocni_prozori.ID(broj);

            if (id.ShowDialog() == true)
            {
                bool imaGa = false;
                InterniUgovor iu = null;
                foreach (InterniUgovor i in Iugovori)
                {
                    if (i.ID == broj[0]) { imaGa = true; iu = i; break; }
                }

                if (imaGa == true)
                {
                    Pomocni_prozori.UnosIugovora IU = new Pomocni_prozori.UnosIugovora(_zaposlenici.ListaZaposlenika, klijeti,
                nekretnine, Iugovori);
                    if (IU.ShowDialog() == true)
                    {
                        InterniUgovorDAO dao = new InterniUgovorDAO();
                        dao.Delete(iu);
                        refreshIBaza();
                        refreshI();
                    }
                }
                else MessageBox.Show("ID koji ste unijeli ne postoji!");

                refreshIBaza();
                refreshI();
            }
        }

        private void obrisiI_Click(object sender, RoutedEventArgs e)
        {
            List<int> broj = new List<int>();
            Pomocni_prozori.ID id = new Pomocni_prozori.ID(broj);

            if (id.ShowDialog() == true)
            {
                bool imaGa = false;
                InterniUgovor iu = null;
                foreach (InterniUgovor i in Iugovori)
	            {
		            if (i.ID == broj[0]) { imaGa = true; iu = i; break; }
	            }

                if (imaGa == true)
                {
                    InterniUgovorDAO dao = new InterniUgovorDAO();
                    dao.Delete(iu);
                }
                else MessageBox.Show("ID koji ste unijeli ne postoji!");

                refreshIBaza();
                refreshI();
            }
        }

        private void dodajI_Click(object sender, RoutedEventArgs e)
        {
            Pomocni_prozori.UnosIugovora IU = new Pomocni_prozori.UnosIugovora(_zaposlenici.ListaZaposlenika, klijeti,
                nekretnine, Iugovori);
            IU.ShowDialog();

            refreshI();
            tbxSearchI_TextChanged(null, null);
        }

        private void tbxSearchI_TextChanged(object sender, RoutedEventArgs e)
        {
            if (cbbpretrazivanjePoI.SelectedIndex == 0)
            {
                foreach (InterniUgovor i in Iugovori)
                {
                    if (i.Agent.Ime.Contains(tbxSearchI.Text))
                        i.prikazi = true;
                    else i.prikazi = false;
                }
            }
            else if (cbbpretrazivanjePoI.SelectedIndex == 1)
            {
                foreach (InterniUgovor i in Iugovori)
                {
                    if (i.Agent.Prezime.Contains(tbxSearchI.Text))
                        i.prikazi = true;
                    else i.prikazi = false;
                }
            }
            else if (cbbpretrazivanjePoI.SelectedIndex == 2)
            {
                foreach (InterniUgovor i in Iugovori)
                {
                    if (i.Klijent.Ime.Contains(tbxSearchI.Text))
                        i.prikazi = true;
                    else i.prikazi = false;
                }
            }
            else if (cbbpretrazivanjePoI.SelectedIndex == 3)
            {
                foreach (InterniUgovor i in Iugovori)
                {
                    if (i.Klijent.Prezime.Contains(tbxSearchI.Text))
                        i.prikazi = true;
                    else i.prikazi = false;
                }
            }

            refreshI();
        }

        private void refreshIBaza()
        {
            InterniUgovorDAO dao = new InterniUgovorDAO();
            Iugovori = dao.getAll();
            dtgInterni.ItemsSource = Iugovori;
        }

        List<Klase_EFM.DTGIugovori> SearchIUgovori = new List<Klase_EFM.DTGIugovori>();

        private void refreshI()
        {
            SearchIUgovori = new List<Klase_EFM.DTGIugovori>();
            foreach (InterniUgovor i in Iugovori)
            {
                if (i.prikazi == true) SearchIUgovori.Add( new Klase_EFM.DTGIugovori(i));
            }
            dtgInterni.ItemsSource = SearchIUgovori;
        }

        private void popuniIugovore()
        {
			
			refreshIBaza();
			refreshI();
			
//TODO Enil
            cbbpretrazivanjePoI.SelectedIndex = 1;
        }

        #endregion

        #region Finalni ugovori

        private List<FinalniUgovor> Fugovori = new List<FinalniUgovor>();
        private bool editModeF = false;

        private void btnEditModeF_Click(object sender, RoutedEventArgs e)
        {
            if (editModeF == false)
            {
                btnEditModeF.Margin = new Thickness(15, 20, 15, 5);

                Button btnDodajF = new Button();
                btnDodajF.Margin = new Thickness(15, 5, 15, 5);
                btnDodajF.Content = "Dodaj novi";
                btnDodajF.Click += new RoutedEventHandler(dodajF_Click);
                spnlButtoniF.Children.Add(btnDodajF);

                Button spspnlButtoniF = new Button();
                spspnlButtoniF.Margin = new Thickness(15, 5, 15, 5);
                spspnlButtoniF.Content = "Obrisi";
                spspnlButtoniF.Click += new RoutedEventHandler(obrisiF_Click);
                spnlButtoniF.Children.Add(spspnlButtoniF);

                Button btnIzmjeniF = new Button();
                btnIzmjeniF.Margin = new Thickness(15, 5, 15, 5);
                btnIzmjeniF.Content = "Izmjeni";
                btnIzmjeniF.Click += new RoutedEventHandler(btnIzmjeniF_Click);
                spnlButtoniF.Children.Add(btnIzmjeniF);
            }

            editModeF = true;
        }

        private void btnIzmjeniF_Click(object sender, RoutedEventArgs e)
        {
            List<int> broj = new List<int>();
            Pomocni_prozori.ID id = new Pomocni_prozori.ID(broj);

            if (id.ShowDialog() == true)
            {
                bool imaGa = false;
                FinalniUgovor fu = null;
                foreach (FinalniUgovor i in Fugovori)
                {
                    if (i.ID == broj[0]) { imaGa = true; fu = i; break; }
                }

                if (imaGa == true)
                {
                    Pomocni_prozori.UnosFugovora FU = new Pomocni_prozori.UnosFugovora(klijeti, nekretnine, Fugovori);
                    FU.popuni(fu);
                    if (FU.ShowDialog() == true)
                    {
                        FinalniUgovorDAO dao = new FinalniUgovorDAO();
                        dao.Delete(fu);
                        refreshFBaza();
                        refreshF();
                    }
                }
                else MessageBox.Show("ID koji ste unijeli ne postoji!");

                refreshFBaza();
                refreshF();
            }
        }

        private void obrisiF_Click(object sender, RoutedEventArgs e)
        {
            List<int> broj = new List<int>();
            Pomocni_prozori.ID id = new Pomocni_prozori.ID(broj);

            if (id.ShowDialog() == true)
            {
                bool imaGa = false;
                FinalniUgovor fu = null;
                foreach (FinalniUgovor i in Fugovori)
                {
                    if (i.ID == broj[0]) { imaGa = true; fu = i; break; }
                }

                if (imaGa == true)
                {
                    FinalniUgovorDAO dao = new FinalniUgovorDAO();
                    dao.Delete(fu);
                }
                else MessageBox.Show("ID koji ste unijeli ne postoji!");

                refreshFBaza();
                refreshF();
            }
        }

        private void dodajF_Click(object sender, RoutedEventArgs e)
        {
            Pomocni_prozori.UnosFugovora FU = new Pomocni_prozori.UnosFugovora(klijeti, nekretnine, Fugovori);
            FU.ShowDialog();

            refreshF();
            tbxSearchF_TextChanged(null, null);
        }

        private void tbxSearchF_TextChanged(object sender, RoutedEventArgs e)
        {
            if (cbbpretrazivanjePoF.SelectedIndex == 0)
            {
                foreach (FinalniUgovor i in Fugovori)
                {
                    if (i.Prodavac.Ime.Contains(tbxSearchF.Text))
                        i.prikazi = true;
                    else i.prikazi = false;
                }
            }
            else if (cbbpretrazivanjePoF.SelectedIndex == 1)
            {
                foreach (FinalniUgovor i in Fugovori)
                {
                    if (i.Kupac.Ime.Contains(tbxSearchF.Text))
                        i.prikazi = true;
                    else i.prikazi = false;
                }
            }
            else if (cbbpretrazivanjePoF.SelectedIndex == 2)
            {
                foreach (FinalniUgovor i in Fugovori)
                {
                    if (i.Nekretnina.Opis.Contains(tbxSearchI.Text))
                        i.prikazi = true;
                    else i.prikazi = false;
                }
            }

            refreshF();
        }

        private void refreshFBaza()
        {
            FinalniUgovorDAO dao = new FinalniUgovorDAO();
            Fugovori = dao.getAll();
            dtgF.ItemsSource = Fugovori;
        }

        List<Klase_EFM.DTGFugovori> SearchFUgovori = new List<Klase_EFM.DTGFugovori>();

        private void refreshF()
        {
            SearchFUgovori = new List<Klase_EFM.DTGFugovori>();
            foreach (FinalniUgovor i in Fugovori)
            {
                if (i.prikazi == true) SearchFUgovori.Add(new Klase_EFM.DTGFugovori(i));
            }
            dtgF.ItemsSource = SearchFUgovori;
        }

        private void popuniFugovore()
        {
			
			refreshFBaza();
			refreshF();
			
//TODO Enil
            cbbpretrazivanjePoF.SelectedIndex = 1;
        }

        #endregion

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Snimiti u bazu ILI kreirati Exit event pa u njemu snimati
            Application.Current.Shutdown(0);
        }



        private void Unos_Zaposlenika(object sender, RoutedEventArgs e)
        {
            validirajIme();
            validirajPrezime();
            validirajUsername();
            validirajPassword();
            validirajJMBG();
            validirajZapPlatu();

            if (validirajIme() && validirajPrezime() && validirajUsername() && validirajPassword() && validirajJMBG() && validirajZapPlatu())
            {

                ZaposlenikFactory zaposlenikFactory = new ZaposlenikFactory();
                if (txtNoviZaposlenikPozicija.SelectedValue != null)
                {
                    var pozicija = (ComboBoxItem)txtNoviZaposlenikPozicija.SelectedValue;
                    Zaposlenik zaposlenik = zaposlenikFactory.GetZaposlenik(pozicija.Content.ToString());
                    zaposlenik.Ime = txtNoviZaposlenikIme.Text;
                    zaposlenik.Prezime = txtNoviZaposlenikPrezime.Text;

                    zaposlenik.Plata = double.Parse(txtNoviZaposlenikPlata.Text);
                    zaposlenik.DatumRodjenja = txtNoviZaposlenikDatROdj.DisplayDate;
                    zaposlenik.DatumZaposlenja = txtNoviZaposlenikDatZap.DisplayDate;
                    zaposlenik.Jmbg = txtNoviZaposlenikJmbg.Text;
                    zaposlenik.BrojLicneKarte = txtNoviZaposlenikBrojLk.Text;
                    zaposlenik.Username = txtNoviZaposlenikUsername.Text;
                    zaposlenik.Password = txtNoviZaposlenikPassword.Text;

                    ZaposlenikDAO zaposlenikDao = new ZaposlenikDAO();
                    zaposlenikDao.Create(zaposlenik);
                    _zaposlenici.ListaZaposlenika.Add(zaposlenik);
                    
                    ZaposlenikDAO zDao = new ZaposlenikDAO();
                    _zaposlenici = zDao.List();
                    zaposleniciGrid.ItemsSource = _zaposlenici.ListaZaposlenika;
                }
            }
        }

        #region ValidiranjeUnosaZaposlenika

        private void pocrveni(Border b)
        {
            b.BorderBrush = Brushes.Red;
        }

        private void odcrveni(Border b)
        {
            b.BorderBrush = Brushes.White;
        }

        private bool prazno(TextBox t, Border b)
        {
            if (t.Text.Length < 1)
            {
                pocrveni(b);
                t.ToolTip = "Polje ne smije biti prazno!";
                return false;
            }
            else
            {
                odcrveni(b);
                return true;
            }
        }

        private bool samoSlova(TextBox t, Border b)
        {

            bool dobar = true;
            foreach (char c in t.Text)
            {
                if (!((c >= 'A' && c <= 'Z') | (c >= 'a' && c <= 'z') |
                    (new List<char>() { 'Č', 'č', 'Ć', 'ć', 'Ž', 'ž', 'Đ', 'đ', 'Š', 'š' }).Exists(element => element == c)))
                {
                    pocrveni(b);
                    t.ToolTip = "Polje smije sadrzavati samo slova!";
                    dobar = false;
                    t.Text.Remove(t.Text.IndexOf(c), t.Text.IndexOf(c) + 1);
                    break;
                }
            }
            if (dobar == true) odcrveni(b);
            else pocrveni(b);
            return dobar;
        }

        private void IDIme_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajIme();
        }

        private bool validirajIme()
        {
            if (prazno(txtNoviZaposlenikIme, borImeID) && samoSlova(txtNoviZaposlenikIme, borImeID)) return true;
            return false;
        }

        private void IDPrezime_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajPrezime();
        }

        private bool validirajPrezime()
        {
            if (prazno(txtNoviZaposlenikPrezime, borPrezimeID) && samoSlova(txtNoviZaposlenikPrezime, borPrezimeID)) return true;
            return false;
        }

        private void IDUsername_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajUsername();
        }

        private bool validirajUsername()
        {
            if ((prazno(txtNoviZaposlenikUsername, borUsernameID))) return true;
            return false;
        }


        private void IDPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajPassword();
        }

        private bool validirajPassword()
        {
            if ((prazno(txtNoviZaposlenikPassword, borPasswordID))) return true;
            return false;
        }


        private void JMBG_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajJMBG();
        }

        private bool validirajJMBG()
        {
            bool dobar = true;
            foreach (char c in txtNoviZaposlenikJmbg.Text)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    pocrveni(borJmbg);
                    txtNoviZaposlenikJmbg.ToolTip = "Polje smije sadrzavati samo brojeve!";
                    dobar = false;
                    break;
                }
                else if ((txtNoviZaposlenikJmbg.Text.Length) != 13)
                {
                    pocrveni(borJmbg);
                    txtNoviZaposlenikJmbg.ToolTip = "Polje mora imati 13 brojeva";
                    dobar = false;
                    break;
                }
            }
            if (dobar == true) odcrveni(borJmbg);
            else pocrveni(borJmbg);

            return dobar && prazno(txtNoviZaposlenikJmbg, borJmbg);
        }

        private void ZapPlata_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajZapPlatu();
        }

        private bool validirajZapPlatu()
        {
            bool dobar = true;
            foreach (char c in txtNoviZaposlenikPlata.Text)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    pocrveni(borZapPlata);
                    txtNoviZaposlenikPlata.ToolTip = "Polje smije sadrzavati samo brojeve!";
                    dobar = false;
                    break;
                }
            }
            if (dobar == true) odcrveni(borZapPlata);
            else pocrveni(borZapPlata);

            return dobar && prazno(txtNoviZaposlenikPlata, borZapPlata);
        }


        #endregion



        private void Obrisi_Zaposlenika(object sender, RoutedEventArgs e)
        {
            {
                validirajIDZap();
                if (validirajIDZap())
                {
                    ZaposlenikFactory obrisiZaposlenika = new ZaposlenikFactory();
                    if (txtObrisiZaposlenikaPozicija.SelectedValue != null)
                    {
                        var pozicija = (ComboBoxItem)txtObrisiZaposlenikaPozicija.SelectedValue;
                        Zaposlenik obrisizaposlenik = obrisiZaposlenika.GetZaposlenik(pozicija.Content.ToString());
                        obrisizaposlenik.Id = long.Parse(txtObrisiZaposlenikaId.Text);
                        ZaposlenikDAO obrisiZaposlenikDao = new ZaposlenikDAO();
                        obrisiZaposlenikDao.Delete(obrisizaposlenik);

                        ZaposlenikDAO zDao = new ZaposlenikDAO();
                        _zaposlenici = zDao.List();
                        zaposleniciGrid.ItemsSource = _zaposlenici.ListaZaposlenika;
                    }
                }
            }
        }

        #region ValidiranjeBrisanjaZaposlenika

        private void IDZap_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajIDZap();
        }

        private bool validirajIDZap()
        {
            bool dobar = true;
            foreach (char c in txtObrisiZaposlenikaId.Text)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    pocrveni(borZapID);
                    txtObrisiZaposlenikaId.ToolTip = "Polje smije sadrzavati samo brojeve!";
                    dobar = false;
                    break;
                }
            }
            if (dobar == true) odcrveni(borZapID);
            else pocrveni(borZapID);

            return dobar && prazno(txtObrisiZaposlenikaId, borZapID);
        }

        #endregion


        private void Unos_Vanjskog_Saradnika(object sender, RoutedEventArgs e)
        {
            
            validirajNaziv();
            validirajPlatu();
            
            if (validirajNaziv() && validirajPlatu())
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

                    VanjskiSaradnikDAO sDao = new VanjskiSaradnikDAO();
                    _saradnici = sDao.List();
                    saradniciGrid.ItemsSource = _saradnici.ListaVanjskihSaradnika;
                }
           }
        }

        #region ValidiranjeUnosaSaradnika


        private void Naziv_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajNaziv();
        }

        private bool validirajNaziv ()
        {
            if (prazno(txtNoviVSaradnikNaziv, borNaziv) && samoSlova(txtNoviVSaradnikNaziv, borNaziv)) return true;
            return false;
        }

        private void Plata_TextChanged(object sender, TextChangedEventArgs e)
        {            
            validirajPlatu();
        }

        private bool validirajPlatu()
        {
            bool dobar = true;
            foreach (char c in txtNoviVSaradnikPlata.Text)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    pocrveni(borPlata);
                    txtNoviVSaradnikPlata.ToolTip = "Polje smije sadrzavati samo brojeve!";
                    dobar = false;
                    break;
                }
            }
            if (dobar == true) odcrveni(borPlata);
            else pocrveni(borPlata);

            return dobar && prazno(txtNoviVSaradnikPlata, borPlata);
        }

        #endregion

        private void Obrisi_Vanjskog_Saradnika(object sender, RoutedEventArgs e)
        {
            validirajID();

            if (validirajID())
            {

                VanjskiSaradnikUloga obrisiSaradnika = new VanjskiSaradnikUloga();
                if (txtObrisiVSaradnikaPozicija.SelectedValue != null)
                {
                    var pozicija = (ComboBoxItem)txtObrisiVSaradnikaPozicija.SelectedValue;
                    VanjskiSaradnik obrisisaradnik = obrisiSaradnika.GetSaradnik(pozicija.Content.ToString());
                    obrisisaradnik.Id = long.Parse(txtObrisiVSaradnikaId.Text);
                    VanjskiSaradnikDAO obrisiSaradnikDAO = new VanjskiSaradnikDAO();
                    obrisiSaradnikDAO.Delete(obrisisaradnik);

                    VanjskiSaradnikDAO sDao = new VanjskiSaradnikDAO();
                    _saradnici = sDao.List();
                    saradniciGrid.ItemsSource = _saradnici.ListaVanjskihSaradnika;
                }
            }
        }

        #region ValidiranjeBrisanjaSaradnika

        private void ID_TextChanged(object sender, TextChangedEventArgs e)
        {            
            validirajID();
        }

        private bool validirajID()
        {
            bool dobar = true;
            foreach (char c in txtObrisiVSaradnikaId.Text)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    pocrveni(borID);
                    txtObrisiVSaradnikaId.ToolTip = "Polje smije sadrzavati samo brojeve!";
                    dobar = false;
                    break;
                }
            }
            if (dobar == true) odcrveni(borID);
            else pocrveni(borID);

            return dobar && prazno( txtObrisiVSaradnikaId, borID);
        }

        #endregion


        #region Eksterni ugovori

        private List<EksterniUgovor> Eugovori = new List<EksterniUgovor>();

        private void btnEditEks_Click(object sender, RoutedEventArgs e)
        {
            btnEditModeKlijenti.Margin = new Thickness(15, 20, 15, 5);

            Button btnDodajE = new Button();
            btnDodajE.Margin = new Thickness(15, 5, 15, 5);
            btnDodajE.Content = "Dodaj novi";
            btnDodajE.Click += new RoutedEventHandler(dodajE_Click);
            spnlEks.Children.Add(btnDodajE);

            Button btnObrisiE = new Button();
            btnObrisiE.Margin = new Thickness(15, 5, 15, 5);
            btnObrisiE.Content = "Obrisi";
            btnObrisiE.Click += new RoutedEventHandler(obrisiE_Click);
            spnlEks.Children.Add(btnObrisiE);
        }


        private void obrisiE_Click(object sender, RoutedEventArgs e)
        {
            List<int> broj = new List<int>();
            Pomocni_prozori.ID id = new Pomocni_prozori.ID(broj);

            if (id.ShowDialog() == true)
            {
                bool imaGa = false;
                EksterniUgovor iu = null;
                foreach (EksterniUgovor i in Eugovori)
                {
                    if (i.ID == broj[0]) { imaGa = true; iu = i; break; }
                }

                if (imaGa == true)
                {
                    EksterniUgovorDAO dao = new EksterniUgovorDAO();
                    dao.Delete(iu);
                }
                else MessageBox.Show("ID koji ste unijeli ne postoji!");

                refreshEBaza();
            }
        }

        private void dodajE_Click(object sender, RoutedEventArgs e)
        {
            
            Pomocni_prozori.UnosEUgovora EU = new Pomocni_prozori.UnosEUgovora(_saradnici.ListaVanjskihSaradnika, Eugovori);
            EU.ShowDialog();

            refreshE();
            tbxTraziEks_TextChanged(null, null);
            
        }



        private void tbxTraziEks_TextChanged(object sender, RoutedEventArgs e)
        {
            if (cbbpretraziPo.SelectedIndex == 0)
            {
                foreach (EksterniUgovor i in Eugovori)
                {
                    if (i.VanjskiSaradnik.Naziv.Contains(tbxTraziEks.Text))
                        i.prikazi = true;
                    else i.prikazi = false;
                }
            }

            refreshE();
        }

        private void refreshEBaza()
        {
            /*
            EksterniUgovorDAO dao = new EksterniUgovorDAO();
            Eugovori = dao.getAll();
            dtgEksterni.ItemsSource = Eugovori;
            */
        }

        private void refreshE()
        {
            foreach (EksterniUgovor i in Eugovori)
            {
                if (i.prikazi == true) dtgEksterni.Items.Add(i);
            }
        }
        
        #endregion


        void Test()
		{
			return;
			InterniUgovor E = new InterniUgovor ();
			E.Opis = "Ovo je jedan interni ugovor!!";
			E.DatumSklapanja = DateTime.Today;
			E.ID = 2;
			InterniUgovorDAO d = new InterniUgovorDAO ();
			d.Delete (E);
			return;
			E.ID = 2;

			System.Windows.Forms.MessageBox.Show ("Izbrisao!");
			InterniUgovor S = d.Read (E);
			System.Windows.Forms.MessageBox.Show (S.Opis);
			System.Windows.Forms.MessageBox.Show (S.DatumSklapanja.ToString());

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
			if (user.Id == -7)
			{
				System.Windows.MessageBox.Show ("Ovo je testni profil i kao takav nema password-a.",
					"Profil za testiranje", MessageBoxButton.OK, MessageBoxImage.Information);
				return;
			}
            Pomocni_prozori.Password p = new Pomocni_prozori.Password(user.Password, (int)user.Id);
            p.ShowDialog();
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

		private void Button_Click_1(object sender, RoutedEventArgs e)
		{
			FrmCam f = new FrmCam ();
			f.ShowDialog ();
		}

        private void About_Click(object sender, RoutedEventArgs e)
        {
            AboutP ab = new AboutP();
            ab.Show();

        }

		private void mitAbout_Click_1(object sender, RoutedEventArgs e)
		{
			About_Click (null, null);
		}

		private void MenuItem_Click_1(object sender, RoutedEventArgs e)
		{
			Hyperlink_Click_1 (null, null);
		}

		private void mitRestart_Click_1(object sender, RoutedEventArgs e)
		{
			Process.Start (Application.ResourceAssembly.Location);
			Application.Current.Shutdown ();
		}

		private void mitExit_Click_1(object sender, RoutedEventArgs e)
		{
			Application.Current.Shutdown ();
		}
    }
}
