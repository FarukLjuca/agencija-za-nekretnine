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
            SQLiteCommand komanda = konekcija.Konekcija.CreateCommand();
            komanda.CommandText =
                "insert into klijenti (datum_rodjenja, ime, prezime, jmbg, brojlk, slika, agent)" +
                "values (@datum_rodjenja, '" + Entity.Ime + "', '" + Entity.Prezime + "', '" + Entity.JMBG + 
                "', '" + Entity.BrojLicneKarte + "', @slika, @agent);";
            komanda.Parameters.Add(new SQLiteParameter("@datum_rodjenja", Entity.DatumRodjenja));

            if (Entity.Agent != null)
                komanda.Parameters.Add(new SQLiteParameter("@agent", Entity.Agent.Id));
            else
                komanda.Parameters.Add(new SQLiteParameter("@agent", null));

            komanda.Parameters.Add("@slika", System.Data.DbType.Binary).Value = Helper.DajByte(Entity.slika);
            komanda.ExecuteNonQuery();
            konekcija.Diskonektuj();
            
            return 0;
        }
        
        public List<Klijent> getAll(List<Zaposlenik> zaposlenici)
        {
            try
            {
                DAL konekcija = DAL.Instanca;
                SQLiteCommand c = new SQLiteCommand("select * from klijenti;", konekcija.Konekcija);
                SQLiteDataReader r = c.ExecuteReader();
                List<Klijent> klijenti = new List<Klijent>();
                while (r.Read())
                {
                    int a = r.GetInt32(0);
                    Klijent k = new Klijent(r.GetDateTime(1), r.GetString(2), r.GetString(3), r.GetString(4), r.GetString(5),
                        null, null);
                    BitmapImage img = Helper.DajSliku(r, 6);
                    int id = r.GetInt32(7);
                    foreach (Zaposlenik z in zaposlenici)
                    {
                        if (z.Id == id) { k.Agent = z as Agent; break; }
                    }
                    k.slika = img;
                    k.ID = a;
                    klijenti.Add(k);
                }
                r.Close();
                konekcija.Diskonektuj();
                return klijenti;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
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
            SQLiteCommand komanda = new SQLiteCommand("delete from klijenti where id = @id;", konekcija.Konekcija);
            komanda.Parameters.Add(new SQLiteParameter("@id", Entity.ID));
            komanda.ExecuteNonQuery();
        }
    }
}
