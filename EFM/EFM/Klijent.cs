using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class Klijent
        : Osoba
    {
        public Agent Agent { get; set; }

        /// <summary>
        /// Kreira novi objekar tipa Klijent
        /// </summary>
        /// <param name="Ime">Ime klijenta</param>
        /// <param name="Prezime">Prezime klijenta</param>
        /// <param name="AdresaStanovanja">Adresa stanovanja klijenta</param>
        /// <param name="BrojTelefona">Broj telefona klijenta</param>
        /// <param name="DatumRodjenja">Datum rodjenja klijenta</param>
        /// <param name="BrojLicneKarte">Broj licne karte klijenta</param>
        /// <param name="Agent">Agent koji je lijentu dodjeljen (opcionalno)</param>
        public Klijent(string Ime, string Prezime, string AdresaStanovanja, string BrojTelefona, DateTime DatumRodjenja, string BrojLicneKarte, Agent Agent = null)
            : base (Ime, Prezime, AdresaStanovanja, BrojTelefona, DatumRodjenja, BrojLicneKarte)
        {
            this.Agent = Agent;
        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjes iskljucivo za serijalizaciju/deserijalizaciju
        /// </summary>
        public Klijent()
        {

        }
    }
}
