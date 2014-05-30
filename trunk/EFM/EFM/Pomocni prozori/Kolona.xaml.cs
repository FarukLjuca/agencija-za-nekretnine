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

namespace EFM.Pomocni_prozori
{
    /// <summary>
    /// Interaction logic for Kolona.xaml
    /// </summary>
    public partial class Kolona : UserControl
    {
        private StackPanel panela;

        public Kolona(StackPanel Panela)
        {
            InitializeComponent();
            panela = Panela;
            cbbTipPodatka.Items.Add("null");
            cbbTipPodatka.Items.Add("integer");
            cbbTipPodatka.Items.Add("real");
            cbbTipPodatka.Items.Add("text");
            cbbTipPodatka.Items.Add("blob");

            SQLiteConnection con = new SQLiteConnection(@"Data Source=c:\sqlite\efmooad.db;Version=3;");
            con.Open();
            string komanda = "SELECT * FROM sqlite_master WHERE type = 'table';";
            SQLiteCommand com = new SQLiteCommand(komanda, con);
            SQLiteDataReader citac = com.ExecuteReader();

            while (citac.Read())
            {
                for (int a = 0; a < citac.FieldCount; a++)
                {
                    if (a == 2) cbbStraniKljucTabela.Items.Add(citac[a].ToString());
                }
            }
            con.Close();

            SQLiteConnection con1 = new SQLiteConnection(@"Data Source=c:\sqlite\efmooad.db;Version=3;");
            con1.Open();
            string komanda1 = "SELECT * FROM emplyees;";
            SQLiteCommand com1 = new SQLiteCommand(komanda1, con1);
            SQLiteDataReader citac1 = com1.ExecuteReader();
            string tekst1 = "";
            while (citac1.Read())
            {
                for (int a = 0; a < citac1.FieldCount; a++)
                {

                    // This will give you the name of the current row's column
                    string columnName = citac1.GetName(a);

                    // This will give you the value of the current row's column
                    string columnValue = citac1[a].ToString();
                    tekst1 += a.ToString() + " | " + columnName + " | " + columnValue + "\n";
                }
            }
            MessageBox.Show(tekst1);
            con1.Close();
        }

        private void Dodaj(object sender, RoutedEventArgs e)
        {
            panela.Children.Insert(panela.Children.IndexOf(this) + 1, new Kolona(panela));
        }

        private void Obrisi(object sender, RoutedEventArgs e)
        {
            panela.Children.Remove(this);
        }

        public string dajString()
        {
            string rez = tbxNaziv.Text + " " + cbbTipPodatka.Text;
            if (true == tbxVelicinaPodatka.IsEnabled) rez += "(" + tbxVelicinaPodatka.Text + ")";
            if (false == cbxDopustiNull.IsChecked) rez += " not null";
            if (true == cbxUnikatan.IsChecked) rez += " unique";
            if (true == cbxPrimarniKljuc.IsChecked) rez += " primary key";
            if (true == cbxStraniKljuc.IsChecked) rez += " references " + cbbStraniKljucTabela.Text + "(" + 
                cbbStraniKljucKolona.Text + ")";
            if (tbxCheck.Text != "") rez += " check (" + tbxCheck.Text + ")";
            //if (tbxKomentar.Text != "") rez += " comment " + tbxKomentar.Text; Nema komentara u SQLite, ovo sam ostavio ako se prebacimo na neku drugu :D
            return rez;
        }

        private void cbbTipPodatka_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Ako se prebacimo na sql, onda se recimo moze pisati varchar(100), za sqlite je samo text, tako da ovoga nema
        }

        private void cbxStraniKljuc_Checked(object sender, RoutedEventArgs e)
        {
            if (true == (sender as CheckBox).IsChecked)
                cbbStraniKljucTabela.IsEnabled = cbbStraniKljucKolona.IsEnabled = true;
        }
    }
}
