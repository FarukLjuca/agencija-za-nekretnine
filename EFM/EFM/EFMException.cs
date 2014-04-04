using System;

namespace EFM.Exc
{
	#region Exc.Exception
	/// <summary>
	/// Standardna klasa za sve EFM izuzetke
	/// </summary>
	public class Exception : System.Exception
	{
		/// <summary>
		/// Baca prazan izuzetak
		/// </summary>
		public Exception() : base () { }
		/// <summary>
		/// Baca izuzetak sa tekstom zadanim kao parametar
		/// </summary>
		/// <param name="Tekst">Tekst koji će biti prenesen kao poruka izuzetka</param>
		public Exception(String Tekst) : base (Tekst) { }
		/// <summary>
		/// Baca izuzetak sa formatiranim tekstom. Npr: 
		/// Throw New Exception ("Korisnik sa imenom {0} i br. indexa {1} ne postoji!", K.Ime, K.Indeks);
		/// </summary>
		/// <param name="TekstFormat">Format teksta koji će se koristiti da se kreira izuzetak (npr. "Ime = {0}, Prezime = {1}")</param>
		/// <param name="Argumenti">Beskonačan niz objekata. NOTE: paziti da se broj navedenih objekata slaže sa brojem nabrojanih u TekstFormat parametru.</param>
		public Exception(String TekstFormat, params object[] Argumenti)
		{
			String S = "";
			try
			{
				S = String.Format (TekstFormat, Argumenti);
			}
			catch
			{
				throw new Exception ("Neispravni podaci u 'TextFormat' argumentu! Poziv" +
					" funkcije Pri kreiranju novog EFM.Exception objekta");
			}
			throw new Exception (S);
		}
	}
	#endregion
	#region Exc.ArgumentException
		/// <summary>
		/// Klasa za bacanje izuzetaka u slučaju pogrešnih parametara u funkcijama
		/// </summary>
		public class ArgumentException : EFM.Exc.Exception
		{
		/// <summary>
		/// Baca prazan izuzetak
		/// </summary>
		public ArgumentException() : base () { }
		/// <summary>
		/// Baca izuzetak sa tekstom zadanim kao parametar
		/// </summary>
		/// <param name="Tekst">Tekst koji će biti prenesen kao poruka izuzetka</param>
		public ArgumentException(String Tekst) : base (Tekst) { }
		/// <summary>
		/// Baca izuzetak sa formatiranim tekstom. Npr: 
		/// Throw New ArgumentException ("Korisnik sa imenom {0} i br. indexa {1} ne postoji!", K.Ime, K.Indeks);
		/// </summary>
		/// <param name="TekstFormat">Format teksta koji će se koristiti da se kreira izuzetak (npr. "Ime = {0}, Prezime = {1}")</param>
		/// <param name="Argumenti">Beskonačan niz objekata. NOTE: paziti da se broj navedenih objekata slaže sa brojem nabrojanih u TekstFormat parametru.</param>
		public ArgumentException(String TekstFormat, params object[] Argumenti)
		{
			String S = "";
			try
			{
				S = String.Format (TekstFormat, Argumenti);
			}
			catch
			{
				throw new Exception ("Neispravni podaci u 'TextFormat' argumentu! Poziv" +
					" funkcije Pri kreiranju novog EFM.Exception objekta");
			}
			throw new Exception (S);
		}
		}
	#endregion
	#region Exc.NullObjectException
		/// <summary>
		/// Baca se u slučaju pristupa NULL objektu
		/// </summary>
		public class NullObjectException : EFM.Exc.Exception
		{
		/// <summary>
		/// Baca prazan izuzetak
		/// </summary>
		public NullObjectException() : base () { }
		/// <summary>
		/// Baca izuzetak sa tekstom zadanim kao parametar
		/// </summary>
		/// <param name="Tekst">Tekst koji će biti prenesen kao poruka izuzetka</param>
		public NullObjectException(String Tekst) : base (Tekst) { }
		/// <summary>
		/// Baca izuzetak sa formatiranim tekstom. Npr: 
		/// Throw New NullObjectException ("Korisnik sa imenom {0} i br. indexa {1} ne postoji!", K.Ime, K.Indeks);
		/// </summary>
		/// <param name="TekstFormat">Format teksta koji će se koristiti da se kreira izuzetak (npr. "Ime = {0}, Prezime = {1}")</param>
		/// <param name="Argumenti">Beskonačan niz objekata. NOTE: paziti da se broj navedenih objekata slaže sa brojem nabrojanih u TekstFormat parametru.</param>
		public NullObjectException(String TekstFormat, params object[] Argumenti)
		{
			String S = "";
			try
			{
				S = String.Format (TekstFormat, Argumenti);
			}
			catch
			{
				throw new Exception ("Neispravni podaci u 'TextFormat' argumentu! Poziv" +
					" funkcije Pri kreiranju novog EFM.Exception objekta");
			}
			throw new Exception (S);
		}
		}
		#endregion
	#region Exc.LazyDeveloperException :D
		/// <summary>
		/// LazyDeveloperException aka NotImplementedException - 
		/// Baca se kada je neko bio toliko vrijedan da je uspio napisati 
		/// throw new LazyDeveloperException(); 
		/// </summary>
		public class LazyDeveloperException : EFM.Exc.Exception
		{
		/// <summary>
		/// Baca prazan izuzetak
		/// </summary>
		public LazyDeveloperException() : base () { }
		/// <summary>
		/// Baca izuzetak sa tekstom zadanim kao parametar
		/// </summary>
		/// <param name="Tekst">Tekst koji će biti prenesen kao poruka izuzetka</param>
		public LazyDeveloperException(String Tekst) : base (Tekst) { }
		}
		#endregion
	#region Exc.NetConnectionException
		/// <summary>
		/// Baca se kada postoje problemi sa internet konekcijom
		/// </summary>
		public class NetConnectionException : EFM.Exc.Exception
		{
		/// <summary>
		/// Baca prazan izuzetak
		/// </summary>
		public NetConnectionException() : base () { }
		/// <summary>
		/// Baca izuzetak sa tekstom zadanim kao parametar
		/// </summary>
		/// <param name="Tekst">Tekst koji će biti prenesen kao poruka izuzetka</param>
		public NetConnectionException(String Tekst) : base (Tekst) { }
		/// <summary>
		/// Baca izuzetak sa formatiranim tekstom. Npr: 
		/// Throw New NetConnectionException ("Korisnik sa imenom {0} i br. indexa {1} ne postoji!", K.Ime, K.Indeks);
		/// </summary>
		/// <param name="TekstFormat">Format teksta koji će se koristiti da se kreira izuzetak (npr. "Ime = {0}, Prezime = {1}")</param>
		/// <param name="Argumenti">Beskonačan niz objekata. NOTE: paziti da se broj navedenih objekata slaže sa brojem nabrojanih u TekstFormat parametru.</param>
		public NetConnectionException(String TekstFormat, params object[] Argumenti)
		{
			String S = "";
			try
			{
				S = String.Format (TekstFormat, Argumenti);
			}
			catch
			{
				throw new Exception ("Neispravni podaci u 'TextFormat' argumentu! Poziv" +
					" funkcije Pri kreiranju novog EFM.Exception objekta");
			}
			throw new Exception (S);
		}
		}
		#endregion
	#region Exc.IOException
		/// <summary>
		/// Baca se kod problema sa Izlazom i Ulazom kod podataka
		/// </summary>
		public class IOException : EFM.Exc.Exception
		{
		/// <summary>
		/// Baca prazan izuzetak
		/// </summary>
		public IOException() : base () { }
		/// <summary>
		/// Baca izuzetak sa tekstom zadanim kao parametar
		/// </summary>
		/// <param name="Tekst">Tekst koji će biti prenesen kao poruka izuzetka</param>
		public IOException(String Tekst) : base (Tekst) { }
		/// <summary>
		/// Baca izuzetak sa formatiranim tekstom. Npr: 
		/// Throw New IOException ("Korisnik sa imenom {0} i br. indexa {1} ne postoji!", K.Ime, K.Indeks);
		/// </summary>
		/// <param name="TekstFormat">Format teksta koji će se koristiti da se kreira izuzetak (npr. "Ime = {0}, Prezime = {1}")</param>
		/// <param name="Argumenti">Beskonačan niz objekata. NOTE: paziti da se broj navedenih objekata slaže sa brojem nabrojanih u TekstFormat parametru.</param>
		public IOException(String TekstFormat, params object[] Argumenti)
		{
			String S = "";
			try
			{
				S = String.Format (TekstFormat, Argumenti);
			}
			catch
			{
				throw new Exception ("Neispravni podaci u 'TextFormat' argumentu! Poziv" +
					" funkcije Pri kreiranju novog EFM.Exception objekta");
			}
			throw new Exception (S);
		}
		}
		#endregion
}
