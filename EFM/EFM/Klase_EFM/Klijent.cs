using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EFM
{
    public class Klijent
        : Osoba
    {
        public Agent Agent { get; set; }
        public bool prikazi { get; set; }
        public BitmapImage slika { get; set; }
        public string JMBG { get; set; }
        public int ID { get; set; }
        public string Adresa { get; set; }
        public string brojTelefona { get; set; }

        /// <summary>
        /// Kreira novi objekar tipa Klijent
        /// </summary>
        /// <param name="Ime">Ime klijenta</param>
        /// <param name="Prezime">Prezime klijenta</param>
        /// <param name="DatumRodjenja">Datum rodjenja klijenta</param>
        /// <param name="BrojLicneKarte">Broj licne karte klijenta</param>
        /// <param name="Agent">Agent koji je lijentu dodjeljen (opcionalno)</param>
        public Klijent(DateTime DatumRodjenja, string Ime, string Prezime, string jmbg, string BrojLicneKarte, BitmapImage slika, Agent Agent = null)
            : base (Ime, Prezime, DatumRodjenja, BrojLicneKarte)
        {
            this.Agent = Agent;
            this.slika = slika;
            JMBG = jmbg;
            prikazi = true;
        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjes iskljucivo za serijalizaciju/deserijalizaciju
        /// </summary>
        public Klijent()
        {

        }

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }

        public string ToString1()
        {
            return "Detaljni podaci o klijentu\n" +
                "\nIme: " + Ime +
                "\nPrezime: " + Prezime +
                "\nDatum rođenja: " + String.Format("{0}", DatumRodjenja.ToShortDateString()) +
                "\nJMBG: " + JMBG +
                "\nBroj licne karte: " + BrojLicneKarte;
        }
    }
}
