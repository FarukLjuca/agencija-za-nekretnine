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
            set { if (value < 0) /*Baci izuzetak, ali je Enil ne da da se baca :P*/; povisica = value; }
        }
        
        /// <summary>
        /// Kreira novi objekat tipa Agent sa parametrima
        /// </summary>
        /// <param name="Klijenti">Lista klijenata (opcionalno)</param>
        /// <param name="Povisica">Povisica (opcionalno)</param>
        public Agent(string Ime, string prezime, List<Klijent> Klijenti = null, decimal Povisica = 0)
            : base (
        {
            if (Klijenti == null)
                this.Klijenti = new List<Klijent>();
            else
                this.Klijenti = Klijenti;
            this.Povisica = Povisica;
        }
    }
}
