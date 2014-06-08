using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
	public class Nekretnine
	{
		public List<Nekretnina> ListaNekretnina { get; set; }

		/// <summary>
		/// Kreira novi objekat tipa Nekretnine, sto pretstavlja listu pojedinacnih Nekretnina
		/// </summary>
		public Nekretnine()
		{
			this.ListaNekretnina = new List<Nekretnina> ();
		}
	}
}
