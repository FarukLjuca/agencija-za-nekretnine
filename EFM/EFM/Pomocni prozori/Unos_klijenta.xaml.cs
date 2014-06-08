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

namespace EFM.Pomocni_prozori
{
    /// <summary>
    /// Interaction logic for Unos_klijenta.xaml
    /// </summary>
    public partial class Unos_klijenta : Window
    {
        BitmapImage slika = null;
        List<Klijent> klijenti = null;

        public Unos_klijenta(List<Klijent> k)
        {
            InitializeComponent();
            klijenti = k;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.DefaultExt = ".jpg";
            open.Filter = "Images(.jpg)|*.jpg";
            if (open.ShowDialog() == true)
            {
                string put = open.FileName;

                BitmapImage slika = new BitmapImage();
                slika.BeginInit();
                slika.UriSource = new Uri(put, UriKind.Absolute);
                slika.EndInit();

                imgSlika.Source = slika;

                this.slika = slika;
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            validirajAdresu();
            validirajBroj();
            validirajIme();
            validirajJmbg();
            validirajPrezime();
            if (validirajAdresu() & validirajBroj() & validirajIme() & validirajJmbg() & validirajPrezime())
            {
                Agent a = null;
                if (cbbAgent.SelectedIndex != -1) a = cbbAgent.SelectedItem as Agent;
                Klijent k = new Klijent(dtpDatumRodjenja.SelectedDate.Value, tbxIme.Text, tbxPrezime.Text, tbxJMBG.Text,
                    tbxBrLK.Text, slika, a);

                klijenti.Add(k);

                DAO.KlijentDAO kdao = new DAO.KlijentDAO();
                kdao.Create(k);

                this.Close();
            }
        }

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
            if (t.Text == "")
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
                if (!((c >= 'A' & c <= 'Z') | (c >= 'a' & c <= 'z') |
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

        private void tbxIme_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajIme();
        }

        private bool validirajIme ()
        {
            if (prazno(tbxIme, borIme) & samoSlova(tbxIme, borIme)) return true;
            return false;
        }

        private void tbxPrezime_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajPrezime();
        }

        private bool validirajPrezime ()
        {
            if (prazno(tbxPrezime, borPrezime) & samoSlova(tbxPrezime, borPrezime)) return true;
            return false;
        }

        private void tbxJMBG_TextChanged(object sender, TextChangedEventArgs e)
        {            
            validirajJmbg();
        }

        private bool validirajJmbg()
        {
            bool dobar = true;
            foreach (char c in tbxJMBG.Text)
            {
                if (!(c >= '0' & c <= '9'))
                {
                    pocrveni(borJMBG);
                    tbxJMBG.ToolTip = "Polje smije sadrzavati samo brojeve!";
                    dobar = false;
                    break;
                }
            }
            if (dobar == true) odcrveni(borJMBG);
            else pocrveni(borJMBG);

            return dobar & prazno(tbxJMBG, borJMBG);
        }

        private void tbxAdresa_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajAdresu();
        }

        private bool validirajAdresu()
        {
            if (prazno(tbxAdresa, borAdresa) & samoSlova(tbxAdresa, borAdresa)) return true;
            return false;
        }

        private void tbxTel_TextChanged(object sender, TextChangedEventArgs e)
        {
            validirajBroj();
        }

        private bool validirajBroj()
        {
            bool dobar = true;
            foreach (char c in tbxTel.Text)
            {
                if (!(c >= '0' & c <= '9') & c != ' ')
                {
                    pocrveni(borTel);
                    tbxTel.ToolTip = "Polje smije sadrzavati samo brojeve i praznine!";
                    dobar = false;
                    break;
                }
            }
            if (dobar == true) odcrveni(borTel);
            else pocrveni(borTel);

            return dobar;
        }
    }
}
