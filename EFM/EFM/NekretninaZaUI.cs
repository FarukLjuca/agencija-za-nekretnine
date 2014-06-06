using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EFM
{
    public class NekretninaZaUI
        : Nekretnina
    {
        private int periodUI;
        
        public int PeriodUI
        {
            get { return periodUI; }
            set { if (value < 0) throw new Exception("Period unajmljivanja ili iznajmljivanja ne moze biti negativan!"); 
                periodUI = value; }
        }
        
        /// <summary>
        /// Kreira novi objetat tipa Nekretnina koja je predviđena za unajmljivanje ili iznajmljivanje
        /// </summary>
        /// <param name="Lokacija">Lokacija nekretnine</param>
        /// <param name="TipNekretnine">Tip Nekretnine (Stan, Kuca, Zemljite, PoslovniProstor, Soba, Apartman, Vikendica, Garaza ili Ostalo)</param>
        /// <param name="PeriodUI">Period unajmljivanja ili iznajmljivanja (u danima; opcionalno)</param>
        /// <param name="DaLiJeCista">True ako je nekretnina cista (opcionalno)</param>
        /// <param name="DaLiJeRezervisana">True ako je nekretnina rezervisana (opcionalno)</param>
        /// <exception cref="EFM.Exc.ArgumentException">Izuzetak biva bacen kada je period unajmljivanja ili iznajmnljivanja nanji od nule</exception>
        public NekretninaZaUI(string Lokacija, string opis, Nekretnina.EnumTipNekretnine TipNekretnine, decimal cijena, 
            int PeriodUI = 0, bool DaLiJeCista = false, bool DaLiJeRezervisana = false)
            : base (Lokacija, opis, TipNekretnine, cijena, DaLiJeCista, DaLiJeRezervisana)
        {
            this.periodUI = PeriodUI;
        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjes iskljucivo za serijalizaciju/deserijalizaciju
        /// </summary>
        public NekretninaZaUI()
        {

        }
    }
}
