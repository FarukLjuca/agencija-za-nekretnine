using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ZadacaDao
{
    public class EUgovor
    {
        long idEUgovor;
        DateTime datum;
        string opis;

        List<Single> ocjene = new List<Single>();

        public EUgovor(DateTime i, string j)
        {
            datum = i;
            opis = j;
        }

        public long IdEUgovor
        {
            get;
            set;
        }
        public DateTime Datum
        {
            get;
            set;
        }
        public string Opis
        {
            get;
            set;
        }

    }
}