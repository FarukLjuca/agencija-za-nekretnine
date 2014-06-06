using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EFM
{
    class SlikeNekretnina
    {
        public int Id { get; set; }
        public int Nekretnina { get; set; }
        public BitmapImage Slika { get; set; }

        public SlikeNekretnina(int id, int nekretnina, BitmapImage slika)
        {
            Id = id;
            Nekretnina = nekretnina;
            Slika = slika;
        }
    }
}
