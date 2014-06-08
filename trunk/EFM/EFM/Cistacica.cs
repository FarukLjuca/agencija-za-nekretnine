using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class Cistacica : Zaposlenik
    {
        /// <summary>
        /// Kreira novi objekat tipa Administrator
        /// </summary>
        /// <param name="Ime">Ime administratora</param>
        /// <param name="Prezime">Prezime administratora</param>
        /// <param name="DatumRodjenja">Datum rodjenja administratora</param>
        /// <param name="BrojLicneKarte">Broj licne karte od administratora</param>
        public Cistacica(string Ime, string Prezime, DateTime DatumRodjenja, string BrojLicneKarte, double Plata)
            : base(Ime, Prezime, DatumRodjenja, BrojLicneKarte, Plata)
        {

        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjen za inicijaliziranje cistacice
        /// </summary>
        public Cistacica()
        {

        }
    }
}




