using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class VanjskiSaradnici
    {
        public List<VanjskiSaradnik> ListaVanjskihSaradnika { get; set; }
        private int brojVanjskihSaradnika;
        /// <summary>
        /// Kreira novi objekat tipa VanjskiSaradnici
        /// </summary>
        /// <param name="brojVanjskihSaradnika">Broj Vanjskih Saradnika</param>
        /// <exception cref="EFM.Exc.ArgumentException">Izuzetak biva bacen kada je broj Vanjskih Saradnika negativan</exception>
        
        public VanjskiSaradnici(int BrojVanjskihSaradnika)
        {
            this.ListaVanjskihSaradnika = new List<VanjskiSaradnik>();
            this.BrojVanjskihSaradnika = BrojVanjskihSaradnika;
        }

        public int BrojVanjskihSaradnika
        {
            get { return brojVanjskihSaradnika; }
            set { if (value < 0) throw new Exception("Broj Vanjskih Saradnika ne moze biti negativan!"); brojVanjskihSaradnika = value; }
        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjen za inicijaliziranje Vanjskog Saradnika
        /// </summary>
        public VanjskiSaradnici()
            : this(0)
        {

        }
    }
}

