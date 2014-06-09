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
        /// Kreira novi objekat tipa Cistacica
        /// </summary>
        /// <param name="Ime">Ime cistacice</param>
        /// <param name="Prezime">Prezime cistacice</param>
        /// <param name="DatumRodjenja">Datum rodjenja cistacice</param>
        /// <param name="BrojLicneKarte">Broj licne karte od cistacice</param>
        /// <param name="Username">Username od cistacice</param>
        /// <param name="Password">Password od cistacice</param>

        public Cistacica(string Ime, string Prezime, DateTime DatumRodjenja, string BrojLicneKarte, double Plata, string Username, string Password, string Pozicija)
            : base(Ime, Prezime, DatumRodjenja, BrojLicneKarte, Plata, Username, Password, Pozicija)
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




