using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class Notar : Osoba, IVanjskiSaradnik
    {
        /// <summary>
        /// Kreira novi objekat tipa Notar
        /// </summary>
        /// <param name="Ime">Ime notara</param>
        /// <param name="Prezime">Prezime notara</param>
        /// <param name="AdresaStanovanja">Adresa notara</param>
        /// <param name="BrojTelefona">Broj telefona od notara</param>
        /// <param name="DatumRodjenja">Datum rodjenja notara</param>
        /// <param name="BrojLicneKarte">Broj licne karte od notara</param>
        public Notar(string Ime, string Prezime, string AdresaStanovanja, string BrojTelefona, DateTime DatumRodjenja, string BrojLicneKarte)
            : base(Ime, Prezime, AdresaStanovanja, BrojTelefona, DatumRodjenja, BrojLicneKarte)
        {

        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjen za inicijaliziranje notara
        /// </summary>
        public Notar()
        {

        }
    }
}

