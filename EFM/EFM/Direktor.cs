using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class Direktor : Osoba
    {
        /// <summary>
        /// Kreira novi objekat tipa Direktor
        /// </summary>
        /// <param name="Ime">Ime direktora</param>
        /// <param name="Prezime">Prezime direktora</param>
        /// <param name="AdresaStanovanja">Adresa direktora</param>
        /// <param name="BrojTelefona">Broj telefona od direktora</param>
        /// <param name="DatumRodjenja">Datum rodjenja direktora</param>
        /// <param name="BrojLicneKarte">Broj licne karte od direktora</param>
        public Direktor(string Ime, string Prezime, string AdresaStanovanja, string BrojTelefona, DateTime DatumRodjenja, string BrojLicneKarte)
            : base(Ime, Prezime, AdresaStanovanja, BrojTelefona, DatumRodjenja, BrojLicneKarte)
        {

        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjen za inicijaliziranje direktora
        /// </summary>
        public Direktor()
        {

        }
    }
}



