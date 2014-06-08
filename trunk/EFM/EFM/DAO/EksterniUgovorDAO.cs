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
				" VALUES (@DATE, '{0}', {1})",  E.Opis, DAL.REP (E.VanjskiSaradnik).Id);
			C.Parameters.Add ("@DATE",   System.Data.DbType.String).Value = DT(E.DatumSklapanja);
			long x = C.ExecuteNonQuery ();
			return x;

		}
		private string DT(DateTime datetime)
		{
			string dateTimeFormat = "{0}-{1}-{2} {3}:{4}:{5}.{6}";
			return string.Format (dateTimeFormat, datetime.Year, datetime.Month, datetime.Day, datetime.Hour, datetime.Minute, datetime.Second, datetime.Millisecond);
		}
		public EksterniUgovor Read(EksterniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("SELECT * FROM EUGOVORI WHERE ID = @ID");
			C.Parameters.Add ("@ID", System.Data.DbType.Int32);
			C.Parameters["@ID"].Value = E.ID;
			DB.SQLiteDataReader R = C.ExecuteReader ();
			if (R.Read ())
			{
				EksterniUgovor F = new EksterniUgovor ();
				F.ID = E.ID;
				F.Opis = R.GetString (2);
				F.VanjskiSaradnik = (new DAO.VanjskiSaradnikDAO ()).Read (new VanjskiSaradnik { Id = R.GetInt32 (3) });
				//F.DatumSklapanja = (DateTime) R[1];
				F.DatumSklapanja = DateTime.Parse (R.GetString (1));
				return F;
			}
			else return null;
		}

		public EksterniUgovor Update(EksterniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("UPDATE EUGOVORI SET DATUM = @DATE, " +
						"OPIS = '{0}', ESARADNIK = {1}", E.Opis, DAL.REP(E.VanjskiSaradnik).Id);
			C.Parameters.Add ("@DATE",  System.Data.DbType.String).Value = DT(E.DatumSklapanja.Date);
			return E;
		}

		public void Delete(EksterniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("DELETE FROM EUGOVORI WHERE ID = @ID");
			C.Parameters.Add ("@ID",  System.Data.DbType.Int32);
			C.Parameters["@ID"].Value = E.ID;
			C.ExecuteNonQuery ();
		}
	}
}
