using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class Notar : VanjskiSaradnik 
    {
        /// <summary>
        /// Kreira novi objekat tipa Notar
        /// </summary>
        /// <param name="Ime">Naziv Notara</param>
        /// <param name="Plata">Plata od notara</param>
        public Notar(string Naziv, double Plata)
            : base(Naziv, Plata)
        {

        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjen za inicijaliziranje notara
        /// </summary>
        public Notar()
        {

        }
    }
}

