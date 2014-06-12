using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM.Klase_EFM
{
    class DTGFugovori
    {
        public long ID { get; set; }
        public DateTime Datum { get; set; }
        public string Opis { get; set; }
        public string Kupac { get; set; }
        public string Prodavac { get; set; }
        public string Nekretnina { get; set; }

        public DTGFugovori(FinalniUgovor fu)
        {
            ID = fu.ID;
            Datum = fu.DatumSklapanja;
            Opis = fu.Opis;
            Kupac = fu.Kupac.ToString();
            Prodavac = fu.Prodavac.ToString();
            Nekretnina = fu.Nekretnina.ToString();
        }
    }
}
