using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class UnajmljivacIznajmljivac
        : Klijent
    {
        public NekretninaZaUI Nekretnina { get; set; }

        /// <summary>
        /// Kreira novi objekat tipa Klijent koji obnasa funkciju unajmljivanja ili iznajmljivanja
        /// </summary>
        /// <param name="Ime">Ime klijenta</param>
        /// <param name="Prezime">Prezime klijenta</param>
        /// <param name="AdresaStanovanja">Adresa stanovanja klijenta</param>
        /// <param name="BrojTelefona">Broj telefona klijenta</param>
        /// <param name="DatumRodjenja">Datum rodjenja klijenta</param>
        /// <param name="BrojLicneKarte">Broj licne karte klijenta</param>
        /// <param name="Nekretnina">Stvarna nekretnina koj klijent zeli iznajmiti ili imaginarna nekretnina (opis) koju klijent zeli unajmiti</param>
        /// <param name="Agent">Agent koji je dodjeljen klijentu (opcionalno)</param>
        public UnajmljivacIznajmljivac(string Ime, string Prezime, string AdresaStanovanja, string BrojTelefona, DateTime DatumRodjenja, string BrojLicneKarte, NekretninaZaUI Nekretnina, Agent Agent = null)
            : base (Ime, Prezime, AdresaStanovanja, BrojTelefona, DatumRodjenja, BrojLicneKarte, Agent)
        {
            this.Nekretnina = Nekretnina;
        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjes iskljucivo za serijalizaciju/deserijalizaciju
        /// </summary>
        public UnajmljivacIznajmljivac()
        {

        }
    }
}
