using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class Administrator : Zaposlenik
    {
        /// <summary>
        /// Kreira novi objekat tipa zaposlenik koji ima funkciju administratora
        /// </summary>
        /// <param name="Ime">Ime administratora</param>
        /// <param name="Prezime">Prezime administratora</param>
        /// <param name="DatumRodjenja">Datum rodjenja administratora</param>
        /// <param name="BrojLicneKarte">Broj licne karte od administratora</param>
        /// <param name="Username">Username od administratora</param>
        /// <param name="Password">Password od administratora</param>

        public Administrator(string Ime, string Prezime, DateTime DatumRodjenja, string BrojLicneKarte, double Plata, string Username, string Password, string Pozicija)
            : base(Ime, Prezime, DatumRodjenja, BrojLicneKarte, Plata, Username, Password, Pozicija)
        {
         
        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjen za inicijaliziranje administratora
        /// </summary>
        public Administrator()
        {

        }
    }
}



