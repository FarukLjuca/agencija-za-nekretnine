using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = System.Data.SQLite;
using System.Drawing;
namespace EFM.DAO
{
	public class ZaposlenikDAO : IDaoCrud<Zaposlenik>
	{

		//create table uposlenici (id integer primary key, ime text not null,
		//	prezime text not null, jmbg text unique not null, brojlk text unique,
		//  datum_rodjenja date not null, datum_zaposlenja date not null,
		//  plata real, pozicija text, username TEXT unique key not null, password TEXT not null,
		//	slika blob);
		public long Create(Zaposlenik E)
		{
			return 0;
		}
		public Zaposlenik Read(Zaposlenik z)
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
