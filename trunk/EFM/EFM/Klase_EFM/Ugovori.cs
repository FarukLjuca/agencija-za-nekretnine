using System;
using System.Collections.Generic;

namespace EFM
{
	/// <summary>
	/// Klasa koja sadrži listu ugovora tipa <see cref="EFM.IUgovor"/>
	/// </summary>
	public sealed class Ugovori
	{
		private List<IUgovor> Lista;

		/// <summary>
		/// Lista svih sklopljenih ugovora
		/// </summary>
		public List<IUgovor> ListaUgovora
		{
			get { return Lista; }
			set { Lista = value; }
		}
		/// <summary>
		/// Dodaje Ugovor u listu ugovora
		/// </summary>
		/// <param name="ugovor">Ugovor koji se dodaje</param>
		/// <exception cref="EFM.ArgumentException">Baca kada je ugovor već dodan</exception>
		/// <exception cref="EFM.NullObjectException">Baca kada je proslijeđeni parametar null</exception>
		public void DodajUgovor(IUgovor ugovor)
		{
			if (ugovor == null) throw new Exc.NullObjectException ("Parametar 'ugovor' je NULL!");
			IUgovor I = Lista.Find (e => ugovor.ID == e.ID);
			if (I != null)
				throw new Exc.ArgumentException ("Ugovor sa ID-om '{0}' je već dodan u listu ugovora!", ugovor.ID);
			Lista.Add (ugovor);
		}
		/// <summary>
		/// Briše Ugovor iz liste ugovora
		/// </summary>
		/// <param name="ugovor">Ugovor koji se briše</param>
		/// <exception cref="EFM.ArgumentException">Baca kada se ugovor ne nalazi u listi</exception>
		/// <exception cref="EFM.NullObjectException">Baca kada je proslijeđeni parametar null</exception>
		
		public void IzbrisiUgovor (IUgovor ugovor)
		{
			if (ugovor == null) throw new Exc.NullObjectException ("Parametar 'ugovor' je NULL!");
			IUgovor I = Lista.Find (e => ugovor.ID == e.ID);
			if (I == null)
				throw new Exc.ArgumentException ("Ugovor sa ID-om '{0}' se ne nalazi u listi ugovora!", ugovor.ID);
			Lista.Add (ugovor);
		}
		
	}
}
