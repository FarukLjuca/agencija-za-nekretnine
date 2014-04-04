using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    class Agent
        : Osoba
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
        /// <param name="AdresaStanovanja">Adresa stanovanja agenta</param>
        /// <param name="BrojTelefona">Broj telefona agenta</param>
        /// <param name="DatumRodjenja">Datum rodjenja agenta</param>
        /// <param name="BrojLicneKarte">Broj licne karte agenta</param>
        /// <param name="Klijenti">Lista klijenata agenta (opcionalno)</param>
        /// <param name="Povisica">Povisica agenta (opcionalno)</param>
        public Agent(string Ime, string Prezime, string AdresaStanovanja, string BrojTelefona, DateTime DatumRodjenja, string BrojLicneKarte, List<Klijent> Klijenti = null, decimal Povisica = 0)
            : base (Ime, Prezime, AdresaStanovanja, BrojTelefona, DatumRodjenja, BrojLicneKarte)
        {
            if (Klijenti == null)
                this.Klijenti = new List<Klijent>();
            else
                this.Klijenti = Klijenti;
            this.Povisica = Povisica;
        }
    }
}
