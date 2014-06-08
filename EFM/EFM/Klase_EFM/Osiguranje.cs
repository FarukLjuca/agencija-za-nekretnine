using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{   
    /// <summary>
	/// Osiguranje agencije. Vanjski saradnik koji se brine o sigurnosti zgrade agencije, 
	/// dokumenata u agenciji i zaposlenima.
	/// </summary>
    public class Osiguranje : VanjskiSaradnik 
    {
        /// <summary>
        /// Kreira novi objekat tipa Osiguranje
        /// </summary>
        /// <param name="Naziv">Naziv Osiguranja</param>
        /// <param name="Plata">Plata od Osiguranja</param>
        public Osiguranje(string Naziv, double Plata)
            : base(Naziv, Plata)
        {

        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjen za inicijaliziranje Osiguranja
        /// </summary>
        public Osiguranje()
        {

        }
    }
}

