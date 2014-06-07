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
            Conn = DAL.Instanca;
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
            Conn = DAL.Instanca;
            SQLiteCommand insertCommand = Conn.Konekcija.CreateCommand();
            insertCommand.CommandText = "INSERT INTO uposlenici(ime, prezime, jmbg, brojlk, plata, pozicija, datum_rodjenja, datum_zaposlenja) " +
                "VALUES (@ime, @prezime, @jmbg, @brojlk, @plata, @pozicija, @datum_rodjenja, @datum_zaposlenja); " +
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
                    new SQLiteParameter("@datum_zaposlenja", Entity.DatumZaposlenja)
                });
            Entity.Id = (long)insertCommand.ExecuteScalar();
            return Entity.Id;
        }

        public Zaposlenik Read(Zaposlenik Entity)
        {

            return null;
        }

        public Zaposlenik Update(Zaposlenik Entity)
        {
            return null;
            throw new Exc.LazyDeveloperException();
        }

        public void Delete(Zaposlenik Entity)
        {
            SQLiteCommand listCommand = Conn.Konekcija.CreateCommand();
            listCommand.CommandText = "DELETE FROM uposlenici WHERE id=@id";
            listCommand.Parameters.Add(new SQLiteParameter("@id", Entity.Id));
            // Change to base class
            listCommand.ExecuteNonQuery();
        }

        internal Zaposlenici List()
        {
            // TODO CHange to DbConnectionBase
            SQLiteCommand listCommand = Conn.Konekcija.CreateCommand();
            listCommand.CommandText = "SELECT id, ime, prezime, jmbg, plata, pozicija FROM uposlenici;";
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

                zaposlenici.ListaZaposlenika.Add(zaposlenik);
            }

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
