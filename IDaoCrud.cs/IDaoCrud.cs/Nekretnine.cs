using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ZadacaDao
{
    public class Nekretnine
    {
        long id;
        string lokacija, tipNekretnine, rezervisanostNekretnine, cistocaNekretnine;
        int cijenaNekretnine;

        List<Single> ocjene = new List<Single>();

        public Nekretnine(string i, string j, string k, string l, int m)
        {
            lokacija = i;
            tipNekretnine = j;
            rezervisanostNekretnine = k;
            cistocaNekretnine = l;
            cijenaNekretnine = m;
        }

        public long Id
        {
            get;
            set;
        }
        public string Lokacija
        {
            get;
            set;
        }
        public string TipNekretnine
        {
            get;
            set;
        }
        public string RezervisanostNekretnine
        {
            get;
            set;
        }
        public string CistocaNekretnine
        {
            get;
            set;
        }
        public int CijenaNekretnine
        {
            get;
            set;
        }

    }
}