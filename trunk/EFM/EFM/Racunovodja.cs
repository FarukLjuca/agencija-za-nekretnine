using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class Racunovodja : Zaposlenik
    {
        /// <summary>
        /// Kreira novi objekat tipa zaposlenik koji ima funkciju racunovodje
        /// </summary>
        /// <param name="Ime">Ime racunovodje</param>
        /// <param name="Prezime">Prezime racunovodje</param>
        /// <param name="DatumRodjenja">Datum rodjenja racunovodje</param>
        /// <param name="BrojLicneKarte">Broj licne karte od racunovodje</param>
        public Racunovodja(string Ime, string Prezime, string AdresaStanovanja, string BrojTelefona, DateTime DatumRodjenja, string BrojLicneKarte, double Plata)
            : base(Ime, Prezime, DatumRodjenja, BrojLicneKarte, Plata)
        {

        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjen za inicijaliziranje racunovodje
        /// </summary>
        public Racunovodja()
        {

        }
    }
}



