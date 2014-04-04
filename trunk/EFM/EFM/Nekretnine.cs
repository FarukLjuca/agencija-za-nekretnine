using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    class Nekretnine
    {
        public List<Nekretnina> ListaNekretnina { get; set; }

        /// <summary>
        /// Kreira novi objekat tipa Nekretnine, sto pretstavlja listu pojedinacnih Nekretnina
        /// </summary>
        /// <param name="Nekretnine">Lista Nekretnina</param>
        public Nekretnine(List<Nekretnina> ListaNekretnina = null)
        {
            if (ListaNekretnina == null)
                this.ListaNekretnina = new List<Nekretnina>();
            else
                this.ListaNekretnina = ListaNekretnina;
        }
    }
}
