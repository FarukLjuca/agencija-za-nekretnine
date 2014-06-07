using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public abstract class Zaposlenik : Osoba
    {
        /// <summary>
        /// Db Id
        /// </summary>
        public long Id { get; set; }
        public double plata;

        /// <summary>
        /// Kreira novi objekat tipa Zaposlenik
        /// </summary>
        /// <param name="Ime">Ime zaposlenika</param>
        /// <param name="Prezime">Prezime zaposlenika</param>
        /// <param name="AdresaStanovanja">Adresa zaposlenika</param>
        /// <param name="BrojTelefona">Broj telefona od zaposlenika</param>
        /// <param name="DatumRodjenja">Datum rodjenja zaposlenika</param>
        /// <param name="BrojLicneKarte">Broj licne karte od zaposlenika</param>
        /// <param name="Plata">Plata od zaposlenika</param>
        /// <exception cref="EFM.Exc.ArgumentException">Izuzetak biva bacen kada je plata negativna</exception>

        public Zaposlenik(string Ime, string Prezime, string AdresaStanovanja, string BrojTelefona, DateTime DatumRodjenja, string BrojLicneKarte, double Plata)
            : base(Ime, Prezime, AdresaStanovanja, BrojTelefona, DatumRodjenja, BrojLicneKarte)
        {
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
        public Zaposlenik()
        {

        }

        public string Jmbg { get; set; }
        public DateTime DatumZaposlenja { get; set; }
    }
}

