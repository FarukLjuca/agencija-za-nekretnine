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
            byte[] slike = null;
            /*foreach (Image i in Entity.Slike)
            {
                JpegBitmapEncoder encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(i));
                using (MemoryStream ms = new MemoryStream())
                {
                    encoder.Save(ms);
                    slike += ms.ToArray();
                } 
            }*/
            SQLiteCommand komanda = new SQLiteCommand("insert into nekretnine (lokacija, opis, tip_nekretnine, rezervisanost, cijena, slika) values (" +
                Entity.Lokacija + ", " + Entity.Opis + ", " + Entity.TipNekretnine.ToString() + ", " + rez.ToString() + ", " + Entity.Cijena + ", " +
                slike);
            
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
