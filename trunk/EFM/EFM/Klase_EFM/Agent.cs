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
        private decimal povisica;

        public decimal Povisica
        {
            get { return povisica; }
            set { if (value < 0) throw new Exception("Povisica ne moze biti negativna!"); povisica = value; }
        }

        /// <summary>
        /// Kreira novi objekat tipa Agent
        /// </summary>
        /// <param name="Ime">Ime agenta</param>
        /// <param name="Prezime">Prezime agenta</param>
        /// <param name="DatumRodjenja">Datum rodjenja agenta</param>
        /// <param name="BrojLicneKarte">Broj licne karte agenta</param>
        /// <param name="Povisica">Povisica agenta (opcionalno)</param>
        /// <exception cref="EFM.Exc.ArgumentException">Izuzetak biva bacen kada je povisica agenta negativna</exception>
        public Agent(string Ime, string Prezime, DateTime DatumRodjenja, string BrojLicneKarte, double Plata, decimal Povisica = 0)
            : base(Ime, Prezime, DatumRodjenja, BrojLicneKarte, Plata)
        {
            this.Klijenti = new List<Klijent>();
            this.Povisica = Povisica;
        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjes iskljucivo za serijalizaciju/deserijalizaciju
        /// </summary>
        public Agent()
        {

        }
    }
}
