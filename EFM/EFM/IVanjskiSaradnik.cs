using System;

namespace EFM
{
	/// <summary>
	/// Interfejs za povezivanje vanskih saradnika. 
	/// Podržava metodu Naziv preko koje se identifikuje Vanjski Saradnik
	/// </summary>
	public interface IVanjskiSaradnik
	{
		/// <summary>
		/// Naziv vanjskog saradnika (osiguranja, marketnške agencije) ili pak Ime i Prezime notara
		/// </summary>
		public String Naziv { get; set; }
	}
}
