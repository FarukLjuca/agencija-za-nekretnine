using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = System.Data.SQLite;

namespace EFM
{
	public class EksterniUgovorDAO : DAO.IDaoCrud<EksterniUgovor>
	{
		public long Create(EksterniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("INSERT INTO EUGOVORI (DATUM, OPIS, ESARADNIK)" + 
				" VALUES ('{0}', '{1}', {2})", E.DatumSklapanja.ToShortDateString (),
			 E.Opis, E.VanjskiSaradnik.Id);
			long x = C.ExecuteNonQuery ();
			return x;

		}

		public EksterniUgovor Read(EksterniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("SELECT * FROM IUGOVORI WHERE ID = @ID");
			C.Parameters.Add ("@ID");
			C.Parameters["@ID"].Value = E.ID;
			DB.SQLiteDataReader R = C.ExecuteReader ();
			if (R.Read ())
			{
				EksterniUgovor F = new EksterniUgovor ();
				F.ID = E.ID;
				F.Opis = R.GetString (2);
				F.VanjskiSaradnik = (new DAO.VanjskiSaradnikDAO ()).Read (new VanjskiSaradnik { Id = R.GetInt32 (3) });
				F.DatumSklapanja = R.GetDateTime (1);
				return F;
			}
			else return null;
		}

		public EksterniUgovor Update(EksterniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("UPDATE IUGOVORI SET DATUM = '{0}', " +
						"OPIS = '{1}', ESARADNIK = {2}", E.DatumSklapanja.ToShortDateString (),
						 E.Opis, E.VanjskiSaradnik.Id);
			return E;
		}

		public void Delete(EksterniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("DELETE FROM EUGOVORI WHERE ID = @ID");
			C.Parameters.Add ("@ID");
			C.Parameters["@ID"].Value = E.ID;
			C.ExecuteNonQuery ();
		}
	}
}
