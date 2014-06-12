using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = System.Data.SQLite;

namespace EFM
{
	public class InterniUgovorDAO : DAO.IDaoCrud<InterniUgovor>
	{
		public long Create(InterniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("INSERT INTO IUGOVORI (DATUM, OPIS, AGENT, KLIJENT" +
			", NEKRETNINA) VALUES ('{0}', '{1}', {2}, {3}, {4})", E.DatumSklapanja.ToShortDateString (),
			 E.Opis, DAL.REP(E.Agent).Id, DAL.REP(E.Klijent).ID, DAL.REP(E.Nekretnina).ID);
			long x = C.ExecuteNonQuery ();
			return x;

		}

		public InterniUgovor Read(InterniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("SELECT * FROM IUGOVORI WHERE ID = @ID");
			C.Parameters.Add ("@ID", System.Data.DbType.Int32);
			C.Parameters["@ID"].Value = E.ID;
			DB.SQLiteDataReader R = C.ExecuteReader ();
			if (R.Read ())
			{
				InterniUgovor F = new InterniUgovor ();
				F.ID = E.ID;
				F.Klijent = (KupacProdavac) ((new DAO.KlijentDAO ()).Read (new Klijent { ID = R.GetInt32 (4) }));
				F.Opis = R.GetString (2);
				F.Agent = (Agent) ((new DAO.ZaposlenikDAO ()).Read2 (new Agent { Id = R.GetInt32 (3) }));
				F.DatumSklapanja = DateTime.Parse (R.GetString (1));
				F.Nekretnina = (new DAO.NekretninaDAO ()).Read (new Nekretnina { ID = R.GetInt32 (5) });
				return F;
			}
			else return null;
		}

        public List<InterniUgovor> getAll()
        {
            DAL d = DAL.Instanca;
            DB.SQLiteCommand C = new DB.SQLiteCommand();
            C.Connection = d.Konekcija;
            C.CommandText = String.Format("SELECT * FROM IUGOVORI;");
            DB.SQLiteDataReader R = C.ExecuteReader();
            List<InterniUgovor> ugovori = new List<InterniUgovor>();
            while (R.Read())
            {
                InterniUgovor F = new InterniUgovor();
                F.ID = R.GetInt32(0);
                F.Klijent = (KupacProdavac)((new DAO.KlijentDAO()).Read(new Klijent { ID = R.GetInt32(4) }));
                F.Opis = R.GetString(2);
                F.Agent = (Agent)((new DAO.ZaposlenikDAO()).Read2(new Agent { Id = R.GetInt32(3) }));
                F.DatumSklapanja = DateTime.Parse(R.GetString(1));
                F.Nekretnina = (new DAO.NekretninaDAO()).Read(new Nekretnina { ID = R.GetInt32(5) });
                ugovori.Add(F);
            }
            return ugovori;
        }

		public InterniUgovor Update(InterniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("UPDATE IUGOVORI SET DATUM = '{0}', " +
						"OPIS = '{1}', AGENT = {2}, KLIJENT = {3}," + 
						"NEKRETNINA =  {4}", E.DatumSklapanja.ToShortDateString (),
						 E.Opis, DAL.REP(E.Agent).Id, DAL.REP(E.Klijent).ID, DAL.REP(E.Nekretnina).ID);
			return E;
		}

		public void Delete(InterniUgovor E)
		{
			DAL d = DAL.Instanca;
			DB.SQLiteCommand C = new DB.SQLiteCommand ();
			C.Connection = d.Konekcija;
			C.CommandText = String.Format ("DELETE FROM IUGOVORI WHERE ID = @ID");
			C.Parameters.Add ("@ID", System.Data.DbType.Int32);
			C.Parameters["@ID"].Value = E.ID;
			C.ExecuteNonQuery ();
		}
	}
}
