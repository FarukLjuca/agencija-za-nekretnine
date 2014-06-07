using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = System.Data.SQLite;
namespace EFM.DAO
{
	public class ZaposlenikDAO : IDaoCrud<Zaposlenik>
	{
		protected Object Conn = null;
		public long Create(Zaposlenik Entity)
		{
			/*
			 * Ovjde implementiramo INSERT SQL komande
			 * ------------------------------------------------------------------
			 * Eh, problem je što smo odlučili (za sada) da koristimo fakultetsku bazu
			 * Emir nam je napravio acc.. i imali smo problema sa konektovanjem na nju.
			 * Cilj je, između ostaloga, da imamo modularnu aplikaciju čak i u smislu
			 * konektora. Sada ćemo u početku napraviti da se konektujemo na DB2 na ETFLAB
			 * i pokušaćemo da to bude toliko modularno da kasnije pređemo na MySQL
			 * a da ne mijenjamo ništa osim deklaracije konekcije (sada je to običan Conn object)
			 * 
			 * To ćemo uraditi kada se uspijemo nakačiti na ETFLAB. Bilo je nekih problema pa
			 * je Emir objašnjavao na raznjem predavanju kako se postavke extractuju :)
			 */
			return 0;
		}

		public Zaposlenik Read(int id)
		{
			return null;
			throw new Exc.LazyDeveloperException ();
		}

		public Zaposlenik Update(Zaposlenik Entity)
		{
			return null;
			throw new Exc.LazyDeveloperException ();
		}

		public void Delete(Zaposlenik Entity)
		{
				throw new Exc.LazyDeveloperException ();
		}
	}
}
