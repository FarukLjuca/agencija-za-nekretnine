using System;

namespace EFM
{
	/// <summary>
	/// Klasa Osoba iz koje će biti naslijeđivane klase Zaposlenik, Notar itd
	/// </summary>
	public abstract class Osoba
	{
		/// <summary>
		/// Inicijalizira osobu sa praznim stringovima kao 
		/// atributima i postavlja DatumRodjenja na dan kreiranja objekta
		/// </summary>
		public Osoba()
		{
			DatumRodjenja = DateTime.Now.Date;
		}
		/// <summary>
		/// Kreira osobu sa navedenim atributima
		/// </summary>
		/// <param name="Ime">Ime osobe</param>
		/// <param name="Prezime">Prezime osobe</param>
		/// <param name="AdresaStanovanja">Adresa stanovanja</param>
		/// <param name="BrojTelefona">Broj Telefona (format: xxx-yyy-zzz)(ne validira se u V1)</param>
		/// <param name="DatumRodjenja">DatumRodjenja (ne validira se u V1)</param>
		/// <param name="BrojLicneKarte">Broj lične karte (ne validira se u V1)</param>
		public Osoba(String Ime, String Prezime, DateTime DatumRodjenja, String BrojLicneKarte)
		{
			this.Ime = Ime;
			this.Prezime = Prezime;
			this.DatumRodjenja = DatumRodjenja;
			this.BrojLicneKarte = BrojLicneKarte;
		}
		/// <summary>
		/// Ime osobe
		/// </summary>
		public String Ime { get; set; }
		/// <summary>
		/// Prezime osobe
		/// </summary>
		public String Prezime  { get; set; }
		/// <summary>
		/// Datum rođenja - Sati se odbacuju
		/// </summary>
        public DateTime DatumRodjenja { get; set; }
		/// <summary>
		/// Broj lične karte (nema validacije)(v1)
		/// </summary>
		public String BrojLicneKarte  { get; set; }
		/// <summary>
		/// Broj telefona u formatu xxx-yyy-eee (nema validacije)(v1)
	}
}
