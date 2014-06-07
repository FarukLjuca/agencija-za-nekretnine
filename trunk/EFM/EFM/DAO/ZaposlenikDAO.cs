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
			DAL D = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();			
			C.CommandText = string.Format ("INSERT INTO UPOSLENICI (IME, PREZIME, " +
			"JMBG, BROJLK, DATUM_RODJENJA, DATUM_ZAPOSLENJA, PLATA, POZICIJA, SLIKA," +
			"TELBROJ, USERNAME, PASSWORD) VALUES (" +
			"{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {10}, {11}, @PASS)",
			E.Ime, E.Prezime, E.JMBG, E.BrojLicneKarte, E.DatumRodjenja,
			E.DatumUposlenja, E.Plata, E.TIP, DAL.ImgToBin (E.Slika), E.BrojTelefona, E.UserName);
			C.Parameters.Add ("PASS", System.Data.DbType.String);
			C.Parameters["PASS"].Value = E.PassWord.ToString();
			long x = C.ExecuteNonQuery ();
			return x;
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
