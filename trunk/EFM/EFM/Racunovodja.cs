using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class Racunovodja : Zaposlenik
    {
        /// <summary>
        /// Kreira novi objekat tipa zaposlenik koji ima funkciju racunovodje
        /// </summary>
        /// <param name="Ime">Ime racunovodje</param>
        /// <param name="Prezime">Prezime racunovodje</param>
        /// <param name="AdresaStanovanja">Adresa racunovodje</param>
        /// <param name="BrojTelefona">Broj telefona od racunovodje</param>
        /// <param name="DatumRodjenja">Datum rodjenja racunovodje</param>
        /// <param name="BrojLicneKarte">Broj licne karte od racunovodje</param>
		//public Racunovodja(string Ime, string Prezime, string AdresaStanovanja, string BrojTelefona, DateTime DatumRodjenja, string BrojLicneKarte, decimal Plata)
		//	: base (Ime, Prezime, AdresaStanovanja, BrojTelefona, DatumRodjenja, BrojLicneKarte, Plata, "", null, 0, null) //TODO: 1 obavezno ispraviti
		//{

		//}

        /// <summary>
        /// Konstrukor bez parametara, namjenjen za inicijaliziranje racunovodje
        /// </summary>
        public Racunovodja()
        {

        }

		public override string TIP
		{
			get { return "RACUNOVODJA"; }
		}
	}
}



