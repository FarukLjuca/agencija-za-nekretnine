using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    class SlikeNekretnine
    {
        public int Id { get; set; }
        public int Nekretnina { get; set; }
        public byte[] Slika { get; set; }

        public SlikeNekretnine(int id, int nekretnina, byte[] slika)
        {
            Id = id;
            Nekretnina = nekretnina;
            Slika = slika;
        }
    }
}
