using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = System.Data.SQLite;

namespace EFM
{
	public class FinalniUgovorDAO : DAO.IDaoCrud<FinalniUgovor>
	{
		public long Create(FinalniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("INSERT INTO FUGOVORI (DATUM, OPIS, NEKRETNINA, KLIJENT_PRODAVAC"+
			", KLIJENT_KUPAC) VALUES ('{0}', '{1}', {2}, {3}, {4})", E.DatumSklapanja.ToShortDateString(),
			 E.Opis, E.Nekretnina.ID, E.Prodavac.ID, E.Kupac.ID);
			long x = C.ExecuteNonQuery ();
			return x;

		}

		public FinalniUgovor Read(FinalniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("SELECT * FROM FUGOVORI WHERE ID = @ID");
			C.Parameters.Add ("@ID");
			C.Parameters["@ID"].Value = E.ID;
			DB.SQLiteDataReader R = C.ExecuteReader ();
			if (R.Read ())
			{
				FinalniUgovor F = new FinalniUgovor ();
				F.ID = E.ID;
				F.Kupac = (KupacProdavac) ((new DAO.KlijentDAO()).Read (new Klijent {ID = R.GetInt32 (5)}));
				F.Prodavac = (KupacProdavac) ((new DAO.KlijentDAO ()).Read (new Klijent { ID = R.GetInt32 (4) }));
				F.Opis = R.GetString (2);
				F.DatumSklapanja = R.GetDateTime (1);
				F.Nekretnina = (new DAO.NekretninaDAO ()).Read (new Nekretnina { ID = R.GetInt32 (3) });
				return F;
			}
			else return null;
		}

		public FinalniUgovor Update(FinalniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("UPDATE FUGOVORI SET " +
				"SET DATUM = '{0}', OPIS = '{1}', NEKRETNINA = {2}, KLIJENT_PRODAVAC = " + 
			"{3}, KLIJENT_KUPAC = {4}", E.DatumSklapanja.ToShortDateString (),
			 E.Opis, E.Nekretnina.ID, E.Prodavac.ID, E.Kupac.ID);
			return E;
		}

		public void Delete(FinalniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("DELETE FROM FUGOVORI WHERE ID = @ID");
			C.Parameters.Add ("@ID");
			C.Parameters["@ID"].Value = E.ID;
			C.ExecuteNonQuery ();
		}
	}
}
