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
        /// <param name="AdresaStanovanja">Adresa administratora</param>
        /// <param name="BrojTelefona">Broj telefona od administratora</param>
        /// <param name="DatumRodjenja">Datum rodjenja administratora</param>
        /// <param name="BrojLicneKarte">Broj licne karte od administratora</param>
        public Administrator(string Ime, string Prezime, string AdresaStanovanja, string BrojTelefona, DateTime DatumRodjenja, string BrojLicneKarte, decimal Plata)
            : base (Ime, Prezime, AdresaStanovanja, BrojTelefona, DatumRodjenja, BrojLicneKarte, Plata)
        {

        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjes iskljucivo za serijalizaciju/deserijalizaciju
        /// </summary>
        public Administrator()
        {

        }
    }
}



