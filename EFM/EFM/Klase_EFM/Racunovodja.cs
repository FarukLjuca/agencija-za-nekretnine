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
        /// <param name="Username">Username od racunovodje</param>
        /// <param name="Password">Password od racunovodje</param>
        
        public Racunovodja(string Ime, string Prezime, DateTime DatumRodjenja, string BrojLicneKarte, double Plata, string Username, string Password)
            : base(Ime, Prezime, DatumRodjenja, BrojLicneKarte, Plata, Username, Password)
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



