﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EFM
{
    class SlikeNekretnina
    {
        public Nekretnina Nekretnina { get; set; }
        public BitmapImage Slika { get; set; }

        public SlikeNekretnina(Nekretnina nekretnina, BitmapImage slika)
        {
            Nekretnina = nekretnina;
            Slika = slika;
        }
    }
}
