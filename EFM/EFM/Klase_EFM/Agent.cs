using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class Agent
        : Zaposlenik
    {
        public List<Klijent> Klijenti { get; set; }
        

        /// <summary>
        /// Kreira novi objekat tipa Agent
        /// </summary>
        /// <param name="Ime">Ime agenta</param>
        /// <param name="Prezime">Prezime agenta</param>
        /// <param name="DatumRodjenja">Datum rodjenja agenta</param>
        /// <param name="BrojLicneKarte">Broj licne karte agenta</param>
        /// <param name="Username">Username od agenta</param>
        /// <param name="Password">Password od agenta</param>
        
        public Agent(string Ime, string Prezime, DateTime DatumRodjenja, string BrojLicneKarte, double Plata, string Username, string Password, string Pozicija)
            : base(Ime, Prezime, DatumRodjenja, BrojLicneKarte, Plata, Username, Password, Pozicija)
        {
            this.Klijenti = new List<Klijent>();
        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjes iskljucivo za serijalizaciju/deserijalizaciju
        /// </summary>
        public Agent()
        {

        }
    }
}
