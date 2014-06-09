using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{   
    /// <summary>
	/// Vanjski saradnik koji promovira agenciju. 
	/// </summary>
    public class AgencijaZaReklamiranje : VanjskiSaradnik 
    {
        /// <summary>
        /// Kreira novi objekat tipa AgencijaZaReklamiranje
        /// </summary>
        /// <param name="Naziv">Naziv Agencije Za Reklamiranje</param>
        /// <param name="Plata">Plata od Agencije Za Reklamiranje</param>
        public AgencijaZaReklamiranje(string Naziv, double Plata, string Pozicija)
            : base(Naziv, Plata, Pozicija)
        {

        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjen za inicijaliziranje AgencijaZaReklamiranje
        /// </summary>
        public AgencijaZaReklamiranje()
        {

        }
    }
}

