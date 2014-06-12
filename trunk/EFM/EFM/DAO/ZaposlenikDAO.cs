using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = System.Data.SQLite;


namespace EFM.DAO
{
    public class ZaposlenikDAO : IDaoCrud<Zaposlenik>
    {
        protected DAL Conn = null;
        public ZaposlenikDAO()
        {

        }

        public long Create(Zaposlenik Entity)
        {
            string role = string.Empty;
            if (Entity is Agent)
            {
                role = "Agent";
            }
            else if (Entity is Racunovodja)
            {
                role = "Racunovodja";
            }
            else if (Entity is Cistacica)
            {
                role = "Cistacica";
            }
            else if (Entity is Administrator)
            {
                role = "Administrator";
            }

            DAL kon1 = DAL.Instanca;

            SQLiteCommand insertCommand = kon1.Konekcija.CreateCommand();
            insertCommand.CommandText = "INSERT INTO uposlenici(ime, prezime, jmbg, brojlk, plata, pozicija, datum_rodjenja, datum_zaposlenja, username, password) " +
                "VALUES (@ime, @prezime, @jmbg, @brojlk, @plata, @pozicija, @datum_rodjenja, @datum_zaposlenja, @username, @password); " +
                "SELECT last_insert_rowid();";
            insertCommand.Parameters.AddRange(new[]
                {
                    new SQLiteParameter("@ime", Entity.Ime),
                    new SQLiteParameter("@prezime", Entity.Prezime),
                    new SQLiteParameter("@jmbg", Entity.Jmbg),
                    new SQLiteParameter("@brojlk", Entity.BrojLicneKarte),
                    new SQLiteParameter("@pozicija", role),
                    new SQLiteParameter("@plata", Entity.Plata),
                    new SQLiteParameter("@datum_rodjenja", Entity.DatumRodjenja),
                    new SQLiteParameter("@datum_zaposlenja", Entity.DatumZaposlenja),
                    new SQLiteParameter("@username", Entity.Username),
                    new SQLiteParameter("@password", Entity.Password)
                    
                });
            Entity.Id = (long)insertCommand.ExecuteScalar();

            kon1.Diskonektuj();

            return Entity.Id;
        }

        public Zaposlenik Read(Zaposlenik Entity)
        {
            DAL kon1 = DAL.Instanca;

            SQLiteCommand insertCommand = new SQLiteCommand();
            insertCommand.CommandText = "select * from uposlenici where username = @user;";
            insertCommand.Connection = kon1.Konekcija;
            insertCommand.Parameters.Add(new SQLiteParameter("@user", Entity.Username));

            /*
             * CREATE TABLE uposlenici (id integer primary key autoincrement, ime text not null
, prezime text not null, jmbg text unique not null, brojlk text unique, datum_ro
djenja date not null, datum_zaposlenja date not null, plata real, pozicija text,
 username text, password text);
            */
            DB.SQLiteDataReader R = insertCommand.ExecuteReader();
            if (R.Read())
            {
                Zaposlenik z = new Zaposlenik();
                z.Id = (long)R["id"];
                z.Ime = (string)R["ime"];
                z.Pozicija = (string)R["pozicija"];
                z.Prezime = (string)R["prezime"];
                z.Jmbg = (string)R["jmbg"];
                z.BrojLicneKarte = (string)R["brojlk"];
                z.DatumRodjenja = R.GetDateTime(5);
                z.DatumZaposlenja = R.GetDateTime(6);
                z.Plata = R.GetDouble(7);
                z.Username = Entity.Username;
                z.Password = (string)R["password"];
                return z;
            }
            else return null;


            kon1.Diskonektuj();
        }

        public Zaposlenik Update(Zaposlenik Entity)
        {
            return null;
            throw new Exc.LazyDeveloperException();
        }

        public void Pass(string pass, int id)
        {
            DAL konekcija = DAL.Instanca;
            SQLiteCommand komanda = new SQLiteCommand("update uposlenici set password = @pass where id = @id");
            komanda.Parameters.Add(new SQLiteParameter("@pass", pass));
            komanda.Parameters.Add(new SQLiteParameter("@id", id));
            komanda.Connection = konekcija.Konekcija;
            komanda.ExecuteNonQuery();
        }

        public void Delete(Zaposlenik Entity)
        {
            DAL kon2 = DAL.Instanca;

            SQLiteCommand listCommand = kon2.Konekcija.CreateCommand();
            listCommand.CommandText = "DELETE FROM uposlenici WHERE id=@id";
            listCommand.Parameters.Add(new SQLiteParameter("@id", Entity.Id));
            // Change to base class
            listCommand.ExecuteNonQuery();

            kon2.Diskonektuj();
        }

        internal Zaposlenici List()
        {
            // TODO CHange to DbConnectionBase

            DAL kon3 = DAL.Instanca;

            SQLiteCommand listCommand = kon3.Konekcija.CreateCommand();
            listCommand.CommandText = "SELECT id, ime, prezime, jmbg, plata, pozicija, brojlk, datum_rodjenja, datum_zaposlenja, username FROM uposlenici;";
            
            // Change to base class
            SQLiteDataReader reader = listCommand.ExecuteReader();
            Zaposlenici zaposlenici = new Zaposlenici();
            while (reader.Read())
            {
                ZaposlenikFactory zaposlenikFactory = new ZaposlenikFactory();
                Zaposlenik zaposlenik = zaposlenikFactory.GetZaposlenik((string)reader["pozicija"]);
                zaposlenik.Id = (long)reader["id"];
                zaposlenik.Ime = (string)reader["ime"];
                zaposlenik.Prezime = (string)reader["prezime"];
                zaposlenik.Jmbg = (string)reader["jmbg"];
                zaposlenik.Plata = (double)reader["plata"];
                zaposlenik.Pozicija = (string)reader["pozicija"];
                zaposlenik.BrojLicneKarte = (string)reader["brojlk"];
                zaposlenik.Username = (string)reader["username"];

                zaposlenici.ListaZaposlenika.Add(zaposlenik);
            }

            kon3.Diskonektuj();

            return zaposlenici;

        }
    }
    // TODO move to separate class
    class ZaposlenikFactory
    {
        public Zaposlenik GetZaposlenik(string role)
        {
            switch (role)
            {
                case "Cistacica":
                    return new Cistacica();
                case "Agent":
                    return new Agent();
                case "Administrator":
                    return new Administrator();
                case "Racunovidja":
                    return new Racunovodja();
                default:
                    return null;
            }
        }
    }
}
