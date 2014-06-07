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
        /// <param name="AdresaStanovanja">Adresa administratora</param>
        /// <param name="BrojTelefona">Broj telefona od administratora</param>
        /// <param name="DatumRodjenja">Datum rodjenja administratora</param>
        /// <param name="BrojLicneKarte">Broj licne karte od administratora</param>
		//public Cistacica(string Ime, string Prezime, string AdresaStanovanja, string BrojTelefona, DateTime DatumRodjenja, string BrojLicneKarte, decimal Plata)
		//	: base (Ime, Prezime, AdresaStanovanja, BrojTelefona, DatumRodjenja, BrojLicneKarte, Plata, "", null, 0, null) //TODO: 1 ispraviti obavezno
		//{

		//}
		
		//TODO: 0 obavezno ispraviti

        /// <summary>
        /// Konstrukor bez parametara, namjenjen za inicijaliziranje cistacice
        /// </summary>
        public Cistacica()
        {

        }

		public override string TIP
		{
			get { return "CISTACICA"; }
		}
	}
}




