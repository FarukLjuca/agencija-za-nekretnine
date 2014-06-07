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

namespace EFM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Zaposlenici _zaposlenici = new Zaposlenici();
        public MainWindow()
        {
            InitializeComponent();
            /*WndLogin w = new WndLogin();*/
            //w.ShowDialog(); itirita svaki put, Faruk
            popuniNekretnine();
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
                Kontrole.kontrolaNekretnina kn = new Kontrole.kontrolaNekretnina(n, n.Slike[0]);
                wpnlNekretnine.Children.Add(kn);
            }
        }

        private void refreshCheckN()
        {
            wpnlNekretnine.Children.RemoveRange(0, wpnlNekretnine.Children.Count);
            foreach (Nekretnina n in nekretnine)
            {
                Kontrole.checkNekretnina kn = new Kontrole.checkNekretnina(n, n.Slike[0]);
                wpnlNekretnine.Children.Add(kn);
            }
        }

        private void btnEditMode_Click(object sender, RoutedEventArgs e)
        {
            postaviPanelu();
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
        }

        private void tbxSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if 
        }

        #endregion

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            //TODO: Snimiti u bazu ILI kreirati Exit event pa u njemu snimati
            Application.Current.Shutdown(0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
    }
}
