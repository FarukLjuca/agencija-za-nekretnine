using System;
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
            SQLiteCommand komanda = new SQLiteCommand("insert into nekretnine (lokacija, opis, tip_nekretnine, rezervisanost, cijena, slika) values (" +
                Entity.Lokacija + ", " + Entity.Opis + ", " + Entity.TipNekretnine.ToString() + ", " + rez.ToString() +
                ", " + Entity.Cijena);
            komanda.Connection = konekcija.Konekcija;
            komanda.ExecuteNonQuery();

            int id;
            komanda.CommandText = "select id from nekretnine where id = (select max(id) from nekretnine));";
            SQLiteDataReader citac = new SQLiteDataReader();
            while (citac.Read())
            {

            }
 
            foreach (BitmapImage i in Entity.Slike)
            {
                byte[] slika;
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(i));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    slika = ms.ToArray();
                }
                komanda.CommandText = "insert into slikenekretnine (nekretnina, slika) values (" + 
            }           
			return 0;
		}

		public Nekretnina Read(Nekretnina Entity)
		{
			return null;
			throw new Exc.LazyDeveloperException();
		}

		public Nekretnina Update(Nekretnina Entity)
		{
			return null;
			throw new Exc.LazyDeveloperException ();
		}

		public void Delete(Nekretnina Entity)
		{
		
			throw new Exc.LazyDeveloperException ();
		}
	}
}
