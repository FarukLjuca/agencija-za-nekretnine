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
    public class VanjskiSaradnikDAO : IDaoCrud<VanjskiSaradnik>
    {
        protected DAL Conn = null;
        public VanjskiSaradnikDAO()
        {

        }

        public long Create(VanjskiSaradnik Entity)
        {
            string role = string.Empty;
            if (Entity is Notar)
            {
                role = "Notar";
            }
            else if (Entity is Osiguranje)
            {
                role = "Osiguranje";
            }
            else if (Entity is AgencijaZaReklamiranje)
            {
                role = "AgencijaZaReklamiranje";
            }

            DAL kon4 = DAL.Instanca;

            SQLiteCommand insertCommand = kon4.Konekcija.CreateCommand();
            insertCommand.CommandText = "INSERT INTO vsaradnici(naziv, plata, pozicija) " +
                "VALUES (@naziv, @plata, @pozicija); " +
                "SELECT last_insert_rowid();";
            insertCommand.Parameters.AddRange(new[]
                {
                    new SQLiteParameter("@naziv", Entity.Naziv),
                    new SQLiteParameter("@plata", Entity.Plata),
                    new SQLiteParameter("@pozicija", role),
                });
            
            Entity.Id = (long)insertCommand.ExecuteScalar();

            kon4.Diskonektuj();

            return Entity.Id;
        }

        public VanjskiSaradnik Read(VanjskiSaradnik Entity)
        {

            return null;
        }

        public VanjskiSaradnik Update(VanjskiSaradnik Entity)
        {
            return null;
            throw new Exc.LazyDeveloperException();
        }

        public void Delete(VanjskiSaradnik Entity)
        {
         
        }

        internal VanjskiSaradnici List()
        {
            // TODO CHange to DbConnectionBase

            DAL kon5 = DAL.Instanca;

            SQLiteCommand listaSaradnika = kon5.Konekcija.CreateCommand();
            listaSaradnika.CommandText = "SELECT id, naziv, plata, pozicija FROM vsaradnici;";
            // Change to base class
            SQLiteDataReader reader = listaSaradnika.ExecuteReader();
            VanjskiSaradnici vanjskiSaradnici = new VanjskiSaradnici();
            while (reader.Read())
            {
                VanjskiSaradnikUloga vanjskiSaradnikUloga = new VanjskiSaradnikUloga();
                VanjskiSaradnik vanjskisaradnik = vanjskiSaradnikUloga.GetSaradnik((string)reader["pozicija"]);
                vanjskisaradnik.Id = (long)reader["id"];
                vanjskisaradnik.Naziv = (string)reader["naziv"];
                vanjskisaradnik.Plata = (double)reader["plata"];

                vanjskiSaradnici.ListaVanjskihSaradnika.Add(vanjskisaradnik);
            }

            kon5.Diskonektuj();

            return vanjskiSaradnici;

        }
    }
    // TODO move to separate class
    class VanjskiSaradnikUloga
    {
        public VanjskiSaradnik GetSaradnik(string role)
        {
            switch (role)
            {
                case "Notar":
                    return new Notar();
                case "Osiguranje":
                    return new Osiguranje();
                case "AgencijaZaReklamiranje":
                    return new AgencijaZaReklamiranje();
                default:
                    return null;
            }
        }
    }
}
