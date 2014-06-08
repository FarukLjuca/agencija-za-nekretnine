using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.IO;
using System.Windows.Media.Imaging;

namespace EFM.DAO
{
    class KlijentDAO
        :IDaoCrud<Klijent>
    {
        protected Object Conn = null;
        public long Create(Klijent Entity)
        {
            DAL konekcija = DAL.Instanca;

            byte[] photo = null;

            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(Entity.slika));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                photo = ms.ToArray();
            }

            SQLiteCommand komanda = new SQLiteCommand(
                "insert into klijenti (datum_rodjenja, ime, prezime, jmbg, brojlk, slika, agent) values ('" +
                Entity.DatumRodjenja.Year.ToString() + "-" + Entity.DatumRodjenja.Month.ToString() + "-" +
                Entity.DatumRodjenja.Day.ToString() + "', " + Entity.Ime + ", " + Entity.Prezime + ", " + Entity.JMBG + ", " +
                Entity.BrojLicneKarte + ", @photo, null");
            komanda.Parameters.Add("@photo", System.Data.DbType.Binary).Value = photo;
            komanda.Connection = konekcija.Konekcija;
            komanda.ExecuteNonQuery();
            konekcija.Diskonektuj();
            
            return 0;
        }
        /*
        public List<Klijent> getAll()
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
                        0, 0, true));
                    if (r.GetInt32(4) == 0)
                        nekretnine[nekretnine.Count - 1].DaLiJeRezervisana = false;
                    nekretnine[nekretnine.Count - 1].ID = test;
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
        */
        
        public Klijent Read(Klijent N)
        {
            return null;
        }

        public Klijent Update(Klijent Entity)
        {
            return null;
            throw new Exc.LazyDeveloperException();
        }

        public void Delete(Klijent Entity)
        {
            DAL konekcija = DAL.Instanca;
            SQLiteCommand komanda = new SQLiteCommand("delete from klijenti where id = " + Entity.ID + ");", konekcija.Konekcija);
            komanda.ExecuteNonQuery();
        }
    }
}
