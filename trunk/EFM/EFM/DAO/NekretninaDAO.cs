﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows.Controls;
using System.IO;
using System.Windows.Media.Imaging;

namespace EFM.DAO
{
	/// <summary>
	/// Pomoćna klasa koja služi kao adapter za pristup SQL-u
	/// </summary>
	public class NekretninaDAO : IDaoCrud<Nekretnina>
	{
		protected Object Conn = null;
		public long Create(Nekretnina Entity)
		{
            DAL konekcija = DAL.Instanca;
            int rez = 0;
            if (Entity.DaLiJeRezervisana == true) rez = 1;
            SQLiteCommand komanda = new SQLiteCommand("insert into nekretnine (lokacija, opis, tip_nekretnine, rezervisanost, cijena) values ('" +
                Entity.Lokacija + "', '" + Entity.Opis + "', '" + Entity.TipNekretnine.ToString() + "', " + rez.ToString() +
                ", " + Entity.Cijena.ToString() + ");");
            komanda.Connection = konekcija.Konekcija;
            komanda.ExecuteNonQuery();
            konekcija.Diskonektuj();
           
			return 0;
		}

        public List<Nekretnina> getAll()
        {
            try
            {
                DAL konekcija = DAL.Instanca;
                SQLiteCommand c = new SQLiteCommand("select * from nekretnine;", konekcija.Konekcija);
                SQLiteDataReader r = c.ExecuteReader();
                List<Nekretnina> nekretnine = new List<Nekretnina>();
                while (r.Read())
                {
                    int test = r.GetInt32(0);
                    nekretnine.Add(new Nekretnina(r.GetString(1), r.GetString(2), 
                        (Nekretnina.EnumTipNekretnine)Enum.Parse(typeof(Nekretnina.EnumTipNekretnine), r.GetString(3), true),
                        0, 0,  true));
                    if (r.GetInt32(4) == 0)
                        nekretnine[nekretnine.Count - 1].DaLiJeRezervisana = false;
                    nekretnine[nekretnine.Count - 1].Id = test;
                    nekretnine[nekretnine.Count - 1].Cijena = r.GetDecimal(5);
                }
                konekcija.Diskonektuj();
                return nekretnine;                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

		public Nekretnina Read(Nekretnina N)
		{
            DAL kon = DAL.Instanca;
            SQLiteCommand com = new SQLiteCommand("select * from nekretnine where id = " + N.ID.ToString(), kon.Konekcija);
            SQLiteDataReader r = com.ExecuteReader();
            Nekretnina n = null;
            while (r.Read())
            {
                n = new Nekretnina(r.GetString(1), r.GetString(2),
                        (Nekretnina.EnumTipNekretnine)Enum.Parse(typeof(Nekretnina.EnumTipNekretnine), r.GetString(3), true),
                        r.GetDecimal(5), N.ID, true);
                if (r.GetInt32(5) == 0) n.DaLiJeRezervisana = false;
                n.Id = r.GetInt32(0);
            }
            kon.Diskonektuj();
			return n;
		}

        public Nekretnina getById(int id)
        {
            DAL kon = DAL.Instanca;
            SQLiteCommand com = new SQLiteCommand("select * from nekretnine where id = " + id + ";", kon.Konekcija);
            SQLiteDataReader r = com.ExecuteReader();
            Nekretnina n = null;
            while (r.Read())
            {
                int test = r.GetInt32(0);
                n = new Nekretnina(r.GetString(1), r.GetString(2),
                        (Nekretnina.EnumTipNekretnine)Enum.Parse(typeof(Nekretnina.EnumTipNekretnine), r.GetString(3), true),
                        r.GetDecimal(5), id, true);
                if (test == 0) n.DaLiJeRezervisana = false;
                n.Id = test;
            }
            kon.Diskonektuj();
            return n;
        }

		public Nekretnina Update(Nekretnina Entity)
		{
			return null;
			throw new Exc.LazyDeveloperException ();
		}

		public void Delete(Nekretnina Entity)
		{
            DAL konekcija = DAL.Instanca;
            SQLiteCommand komanda = new SQLiteCommand("delete from nekretnine where id = " + Entity.ID + ");", konekcija.Konekcija);
            komanda.ExecuteNonQuery();
		}
	}
}
