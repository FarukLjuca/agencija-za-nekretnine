using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class KupacProdavac
        : Klijent
    {
        public Nekretnina Nekretnina { get; set; }

        /// <summary>
        /// Kreira novi objekat tipa Klijent koji obnasa funkciju prodavnja ili kupovine
        /// </summary>
        /// <param name="Ime">Ime klijenta</param>
        /// <param name="Prezime">Prezime klijenta</param>
        /// <param name="AdresaStanovanja">Adresa stanovanja klijenta</param>
        /// <param name="BrojTelefona">Broj telefona klijenta</param>
        /// <param name="DatumRodjenja">Datum rodjenja klijenta</param>
        /// <param name="BrojLicneKarte">Broj licne karte klijenta</param>
        /// <param name="Nekretnina">Stvarna nekretnina koj klijent zeli prodati ili imaginarna nekretnina (opis) koju klijent zeli kupiti</param>
        /// <param name="Agent">Agent koji je dodjeljen klijentu (opcionalno)</param>
        public KupacProdavac(string Ime, string Prezime, string AdresaStanovanja, string BrojTelefona, DateTime DatumRodjenja, string BrojLicneKarte, Nekretnina Nekretnina, Agent Agent = null)
            : base (Ime, Prezime, AdresaStanovanja, BrojTelefona, DatumRodjenja, BrojLicneKarte, Agent)
        {
            this.Nekretnina = Nekretnina;
        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjes iskljucivo za serijalizaciju/deserijalizaciju
        /// </summary>
        public KupacProdavac()
        {

        }
    }
}
