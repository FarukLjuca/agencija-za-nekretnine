using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM.Klase_EFM
{
    public class DTGIugovori
    {
        public long ID { get; set; }
        public DateTime Datum { get; set; }
        public string Opis { get; set; }
        public string Agent { get; set; }
        public string Klijent { get; set; }
        public string Nekretnina { get; set; }

        public DTGIugovori(InterniUgovor iu)
        {
            ID = iu.ID;
            Datum = iu.DatumSklapanja;
            Opis = iu.Opis;
            Agent = iu.Agent.ToString();
            Klijent = iu.Klijent.ToString();
            Nekretnina = iu.Nekretnina.ToString();
        }
    }
}
