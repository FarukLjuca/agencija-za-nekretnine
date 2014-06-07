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
            byte[] slika;
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(Entity.Slika));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                slika = ms.ToArray();
            }
            komanda.CommandText = "insert into slikenekretnina (nekretnina, slika) values (" + id.ToString() + ", '" + slika + "');";
            komanda.Connection = kon1.Konekcija;
            komanda.ExecuteNonQuery();
            kon1.Diskonektuj();

            return 0;
        }

        public List<SlikeNekretnina> getAll()
        {
            try
            {
                DAL connection = DAL.Instanca;
                SQLiteCommand c = new SQLiteCommand("select * from slikenekretnina;", connection.Konekcija);
                List<SlikeNekretnina> slike = new List<SlikeNekretnina>();

                FileStream stream;                          
                BinaryWriter writer;                        

                int bufferSize = 100;                   
                byte[] outByte = new byte[bufferSize];  
                long retval;                            
                long startIndex = 0;                                        

                SQLiteDataReader reader = c.ExecuteReader();

                while (reader.Read())
                {
                    NekretninaDAO nek = new NekretninaDAO();
                    int redniBr = reader.GetInt32(1);
                    Nekretnina n = nek.getById(redniBr);

                    stream = new FileStream("tmp" + ".bmp", FileMode.OpenOrCreate, FileAccess.Write);
                    writer = new BinaryWriter(stream);

                    startIndex = 0;

                    retval = reader.GetBytes(2, startIndex, outByte, 0, bufferSize);

                    while (retval == bufferSize)
                    {
                        writer.Write(outByte);
                        writer.Flush();

                        startIndex += bufferSize;
                        retval = reader.GetBytes(2, startIndex, outByte, 0, bufferSize);
                    }
                    writer.Write(outByte, 0, (int)retval - 1);
                    writer.Flush();

                    writer.Close();
                    stream.Close();

                    MemoryStream strmImg = new MemoryStream(outByte);
                    BitmapImage myBitmapImage = new BitmapImage();
                    myBitmapImage.BeginInit();
                    myBitmapImage.StreamSource = strmImg;
                    myBitmapImage.DecodePixelWidth = 200;
                    myBitmapImage.EndInit();

                    slike.Add(new SlikeNekretnina(n, myBitmapImage));
                }
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
