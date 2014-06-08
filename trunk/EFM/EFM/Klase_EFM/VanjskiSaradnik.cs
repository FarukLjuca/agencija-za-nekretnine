using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public abstract class VanjskiSaradnik
    {
        public string Naziv { get; set; }
        public long Id { get; set; }
        public double plata;
        /// <summary>
        /// Kreira novi objekat tipa VanjskiSaradnik
        /// </summary>
       
        /// <param name="Plata">Plata od Vanjskog Saradnika</param>
        /// <exception cref="EFM.Exc.ArgumentException">Izuzetak biva bacen kada je plata negativna</exception>
         public VanjskiSaradnik(string Naziv, double Plata)
        {
             this.Naziv = Naziv;
             this.Plata = Plata;
        }

        /// <summary>
        /// Plata za zaposlenika
        /// </summary>
        public double Plata
        {
            get { return plata; }
            set { if (value < 0) throw new Exception("PLata ne moze biti negativna!"); plata = value; }
        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjen za inicijaliziranje zaposlenika
        /// </summary>
        public VanjskiSaradnik()
        {

        }

    }
}

