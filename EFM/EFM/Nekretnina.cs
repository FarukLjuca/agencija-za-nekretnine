using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    class Nekretnina
    {
        enum EnumTipNekretnine
        {
            Stan,
            Kuca,
            Zemljiste,
            PoslovniProstor,
            Soba,
            Apartman,
            Vikendica,
            Garaza,
            Ostalo
        };

        public string Lokacija { get; set; }
        public EnumTipNekretnine TipNekretnine { get; set; }
        public bool DaLiJeCista { get; set; }
        public bool DaLiJeRezervisana { get; set; }

        /// <summary>
        /// Kreira novi objekat tipa Nekretnina sa parametrima
        /// </summary>
        /// <param name="Lokacija">Lokacija nekretnine</param>
        /// <param name="TipNekretnine">Tip Nekretnine (Stan, Kuca, Zemljite, PoslovniProstor, Soba, Apartman, Vikendica, Garaza ili Ostalo)</param>
        /// <param name="DaLiJeCista">True ako je nekretnina cista (opcionalno)</param>
        /// <param name="DaLiJeRezervisana">True ako je nekretnina rezervisana (opcionalno)</param>
        public Nekretnina(string Lokacija, EnumTipNekretnine TipNekretnine, bool DaLiJeCista = false, bool DaLiJeRezervisana = false)
        {
            this.Lokacija = Lokacija;
            this.TipNekretnine = TipNekretnine;
            this.DaLiJeCista = DaLiJeCista;
            this.DaLiJeRezervisana = DaLiJeRezervisana;
        }
    }
}
