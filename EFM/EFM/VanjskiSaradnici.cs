using System;
using System.Collections.Generic;

namespace EFM
{
	/// <summary>
	/// Klasa koja sadrži listu Vanjskih Saradnika tipa <see cref="EFM.IVanjskiSaradnik"/>
	/// </summary>
	public sealed class VanjskiSaradnici
	{
		private List<IVanjskiSaradnik> Lista;

		/// <summary>
		/// Lista svih VanjskiSaradnika
		/// </summary>
		public List<IVanjskiSaradnik> ListaVanjskiSaradnika
		{
			get { return Lista; }
			set { Lista = value; }
		}
		/// <summary>
		/// Dodaje Vanjskog Saradnika u listu VanjskiSaradnici
		/// </summary>
		/// <param name="VanjskiSaradnik">Vanjski Saradnik koji se dodaje</param>
		/// <exception cref="EFM.ArgumentException">Baca kada je Vanjski Saradnik već dodan</exception>
		/// <exception cref="EFM.NullObjectException">Baca kada je proslijeđeni parametar null</exception>
		public void DodajVanjskogSaradnika(IVanjskiSaradnik VanjskiSaradnik)
		{
			if (VanjskiSaradnik == null) throw new Exc.NullObjectException ("Parametar 'VanjskiSaradnik' je NULL!");
			IVanjskiSaradnik I = Lista.Find (e => VanjskiSaradnik.Naziv == e.Naziv);
			if (I != null)
				throw new Exc.ArgumentException ("Vanjski Saradnik sa Nazivom '{0}' je već dodan u listu VanjskiSaradnici!", VanjskiSaradnik.Naziv);
			Lista.Add (VanjskiSaradnik);
		}
		/// <summary>
		/// Briše Vanjskog Saradnika iz liste VanjskiSaradnici
		/// </summary>
		/// <param name="VanjskiSaradnik">Vanjski Saradnik koji se briše</param>
		/// <exception cref="EFM.ArgumentException">Baca kada se Vanjski Saradnik ne nalazi u listi</exception>
		/// <exception cref="EFM.NullObjectException">Baca kada je proslijeđeni parametar null</exception>

		public void IzbrisiVanjskogSaradnika(IVanjskiSaradnik VanjskiSaradnik)
		{
			if (VanjskiSaradnik == null) throw new Exc.NullObjectException ("Parametar 'VanjskiSaradnik' je NULL!");
			IVanjskiSaradnik I = Lista.Find (e => VanjskiSaradnik.Naziv == e.Naziv);
			if (I == null)
				throw new Exc.ArgumentException ("VanjskiSaradnik sa Nazivom '{0}' se ne nalazi u listi VanjskiSaradnici!", VanjskiSaradnik.Naziv);
			Lista.Add (VanjskiSaradnik);
		}

	}
}
