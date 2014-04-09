using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class Zaposlenici 
    {
     public List<Zaposlenik> ListaZaposlenika { get; set; }   
     private int brojZaposlenika;
     /// <summary>
     /// Kreira novi objekat tipa Zaposlenici
     /// </summary>
     /// <param name="BrojZaposlenika">Broj zaposlenih osoba</param>
     /// <exception cref="EFM.Exc.ArgumentException">Izuzetak biva bacen kada je broj zaposlenika negativan</exception>
     public Zaposlenici(int BrojZaposlenika)

        {
            this.ListaZaposlenika = new List<Zaposlenik>();   
            this.BrojZaposlenika = BrojZaposlenika;
        }
        
     public int BrojZaposlenika 
     { 
        get { return brojZaposlenika ;} 
        set { if (value < 0) throw new Exception("Broj zaposlenika ne moze biti negativan!"); brojZaposlenika  = value; } 
     }

     /// <summary>
     /// Konstrukor bez parametara, namjenjen za inicijaliziranje zaposlenika
     /// </summary>
     public Zaposlenici ()
        {

        }
    }
}

