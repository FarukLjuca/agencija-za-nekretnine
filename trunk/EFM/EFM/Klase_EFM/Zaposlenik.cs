using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
    public class Zaposlenik : Osoba
    {
        /// <summary>
        /// Db Id
        /// </summary>
        public double plata;
        public long Id { get; set; }
        public string Jmbg { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }


        /// <summary>
        /// Kreira novi objekat tipa Zaposlenik
        /// </summary>
        /// <param name="Ime">Ime zaposlenika</param>
        /// <param name="Prezime">Prezime zaposlenika</param>
        /// <param name="DatumRodjenja">Datum rodjenja zaposlenika</param>
        /// <param name="BrojLicneKarte">Broj licne karte od zaposlenika</param>
        /// <param name="Plata">Plata od zaposlenika</param>
        /// <exception cref="EFM.Exc.ArgumentException">Izuzetak biva bacen kada je plata negativna</exception>
        /// <param name="Plata">Username od zaposlenika</param>
        /// <param name="Plata">Password od zaposlenika</param>

        public Zaposlenik(string Ime, string Prezime, DateTime DatumRodjenja, string BrojLicneKarte, double Plata, string Username, string Password)
            : base(Ime, Prezime, DatumRodjenja, BrojLicneKarte)
        {
            this.Plata = Plata;
            this.Username = Username;
            this.Password = Password;
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

        public override string ToString()
        {
            return Ime + " " + Prezime;
        }
    }
}

