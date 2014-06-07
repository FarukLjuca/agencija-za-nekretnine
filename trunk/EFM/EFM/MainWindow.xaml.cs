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
            Pomocni_prozori.Unos_nekretnine n = new Pomocni_prozori.Unos_nekretnine(wpnlNekretnine);
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
