using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.IO;
using System.Data.SQLite;

namespace EFM.DAO
{
    class SlikeNekretninaDAO
        : IDaoCrud<SlikeNekretnina>
    {
        protected Object Conn = null;
        public long Create(SlikeNekretnina Entity)
        {
            DAL konekcija = DAL.Instanca;
            SQLiteCommand komanda = new SQLiteCommand("select id from nekretnine where id = (select max(id) from nekretnine);");
            komanda.Connection = konekcija.Konekcija;

            int id = 0;
            komanda.ExecuteNonQuery();
            SQLiteDataReader citac = komanda.ExecuteReader();
            while (citac.Read())
            {
                id = citac.GetInt32(0);
            }
            citac.Close();

            DAL kon1 = DAL.Instanca;
            komanda.CommandText = "insert into slikenekretnina (nekretnina, slika) values (" + id.ToString() + ", @slika);";
            komanda.Parameters.Add("@slika", System.Data.DbType.Binary).Value = Helper.DajByte(Entity.Slika);
            komanda.Connection = kon1.Konekcija;
            komanda.ExecuteNonQuery();
            kon1.Diskonektuj();

            return 0;
        }

        public List<SlikeNekretnina> getAll()
        {
            try
            {

                NekretninaDAO nek = new NekretninaDAO();
                List<Nekretnina> lista = nek.getAll();
                DAL connection = DAL.Instanca;
                SQLiteCommand c = new SQLiteCommand("select * from slikenekretnina;", connection.Konekcija);
                SQLiteDataReader reader = c.ExecuteReader();
                List<SlikeNekretnina> slike = new List<SlikeNekretnina>();

                while (reader.Read())
                {
                    int redniBr = reader.GetInt32(1);
                    Nekretnina n = null;
                    foreach (Nekretnina nekr in lista)
                    {
                        if (redniBr == nekr.ID) { n = nekr; break; }
                    }
                    BitmapImage sl = Helper.DajSliku(reader, 2);
                    SlikeNekretnina sln = new SlikeNekretnina(n, sl);
                    slike.Add(sln);
                }
                reader.Close();
                connection.Diskonektuj();
                return slike;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SlikeNekretnina Read(SlikeNekretnina S)
        {
            return null;
            throw new Exc.LazyDeveloperException();
        }

        public SlikeNekretnina Update(SlikeNekretnina Entity)
        {
            return null;
            throw new Exc.LazyDeveloperException();
        }

        public void Delete(SlikeNekretnina Entity)
        {

            throw new Exc.LazyDeveloperException();
        }
    }
}
