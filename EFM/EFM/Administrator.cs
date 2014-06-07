using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class Administrator : Zaposlenik
    {
		/*
		 string Ime, string Prezime, string AdresaStanovanja, 
		string BrojTelefona, DateTime DatumRodjenja, DateTime DatumUposlenja, string BrojLicneKarte,
		string UserName, System.Security.SecureString PassWord, decimal Plata, Image Slika)
            : base (Ime, Prezime, AdresaStanovanja, BrojTelefona, DatumRodjenja, BrojLicneKarte)
		 */
		/// <summary>
        /// Kreira novi objekat tipa zaposlenik koji ima funkciju administratora
        /// </summary>
		/// <param name="Ime">Ime administratora</param>
		/// <param name="Prezime">Prezime administratora</param>
		/// <param name="AdresaStanovanja">Adresa administratora</param>
		/// <param name="BrojTelefona">Broj telefona od administratora</param>
		/// <param name="DatumRodjenja">Datum rodjenja administratora</param>
		/// <param name="DatumUposlenja">Datum uposlenja administratora</param>
		/// <param name="JMBG">Maticni broj</param>
		/// <param name="BrojLicneKarte">Broj licne karte od administratora</param>
		/// <param name="UserName">Username administratora</param>
		/// <param name="Password">Password administratora</param>
		/// <param name="Plata">Plata od administratora</param>
		/// <param name="Slika">Slika administratora</param>
		public Administrator(string Ime, string Prezime, string AdresaStanovanja,
		string BrojTelefona, DateTime DatumRodjenja, DateTime DatumUposlenja, string BrojLicneKarte,
		string UserName, String PassWord, decimal Plata, Image Slika)
			: base (Ime, Prezime, AdresaStanovanja, BrojTelefona, DatumRodjenja, DatumUposlenja,
			BrojLicneKarte, UserName, PassWord, Plata, Slika)
		{ }
		//public Administrator(string Ime, string Prezime, string AdresaStanovanja, string BrojTelefona, DateTime DatumRodjenja, string BrojLicneKarte, decimal Plata)
		//	: base (Ime, Prezime, AdresaStanovanja, BrojTelefona, DatumRodjenja, BrojLicneKarte, Plata,  "", null, 0, null) 
			//TODO: 0 onaj ko je pravio admin-a obavezno da ovo popravi
		//{

		//}

        /// <summary>
        /// Konstrukor bez parametara, namjenjen za inicijaliziranje administratora
        /// </summary>
        public Administrator()
        {

        }

		public override string TIP
		{
			get { return "ADMIN"; }
		}
	}
}



