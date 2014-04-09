using System;


namespace EFM
{
	/// <summary>
	/// Osiguranje agencije. Vanjski saradnik koji se brine o sigurnosti zgrade agencije, 
	/// dokumenata u agenciji i zaposlenima.
	/// </summary>
	public class Osiguranje : IVanjskiSaradnik
	{
		/// <summary>
		/// Naziv Osiguranja
		/// </summary>
		public String Naziv { get; set; } //TODO: pod hitno mijenjati
	}
}
