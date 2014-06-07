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

            byte[] slika;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(Entity.Slika));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                slika = ms.ToArray();
            }
            komanda.CommandText = "insert into slikenekretnina (nekretnina, slika) values (" + id.ToString() + ", '" + slika + "');";
            komanda.ExecuteNonQuery();
            konekcija.Diskonektuj();

            return 0;
        }

        public List<SlikeNekretnina> getAll()
        {
            try
            {
                DAL konekcija = DAL.Instanca;
                SQLiteCommand c = new SQLiteCommand("select * from student", konekcija.Konekcija);
                SQLiteDataReader r = c.ExecuteReader();
                List<SlikeNekretnina> slike = new List<SlikeNekretnina>();
                while (r.Read())
                {
                    NekretninaDAO nek = new NekretninaDAO();
                    int redniBr = r.GetInt32(1);
                    Nekretnina n = nek.getAll()[redniBr];

                    byte[] byteval = null;
                    MemoryStream strmImg = new MemoryStream(byteval);
                    BitmapImage myBitmapImage = new BitmapImage();
                    myBitmapImage.BeginInit();
                    myBitmapImage.StreamSource = strmImg;
                    //myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();

                    slike.Add(new SlikeNekretnina(n, myBitmapImage));
                }
                return slike;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public SlikeNekretnina Read(int id)
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
