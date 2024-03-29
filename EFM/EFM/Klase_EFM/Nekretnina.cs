﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EFM
{
    //TODO: konstruktor bez parametara
    public class Nekretnina
    {
        /// <summary>
        /// Nabrojani objekat koji obiljezava kojeg je kenretnina tipa
        /// </summary>
        public enum EnumTipNekretnine
        {
            Stan,
            Kuca,
            Zemljiste,
            PoslovniProstor,
            Soba,
            Apartman,
            Vikendica,
            Garaza,
            /// <summary>
            /// Tu spadaju: hotleli, njive, itd.
            /// </summary>
            Ostalo
        };

        public string Lokacija { get; set; }
        /// <summary>
        /// Označava koji je tip nekretnine
        /// </summary>
        public EnumTipNekretnine TipNekretnine { get; set; }
        public bool DaLiJeRezervisana { get; set; }
        public string Opis { get; set; }
        public decimal Cijena { get; set; }
		public int ID { get; set; }
        public List<BitmapImage> Slike { get; set; }
        public bool prikazi { get; set; }
        public Klijent klijent { get; set; }
        /// <summary>
        /// Kreira novi objekat tipa Nekretnina
        /// </summary>
        /// <param name="Lokacija">Lokacija nekretnine</param>
        /// <param name="TipNekretnine">Tip Nekretnine (Stan, Kuca, Zemljite, PoslovniProstor, Soba, Apartman, Vikendica, Garaza ili Ostalo)</param>
        /// <param name="DaLiJeCista">True ako je nekretnina cista (opcionalno)</param>
        /// <param name="DaLiJeRezervisana">True ako je nekretnina rezervisana (opcionalno)</param>
        public Nekretnina(string Lokacija, string opis, EnumTipNekretnine TipNekretnine, decimal cijena, int ID,
            bool DaLiJeRezervisana = false, Klijent klijent = null)
        {
            this.Lokacija = Lokacija;
            Opis = opis;
            this.TipNekretnine = TipNekretnine;
            this.DaLiJeRezervisana = DaLiJeRezervisana;
            Cijena = cijena;
			this.ID = ID;
            prikazi = true;
            this.klijent = klijent;
            Slike = new List<BitmapImage>();
        }

        /// <summary>
        /// Konstrukor bez parametara, namjenjes iskljucivo za serijalizaciju/deserijalizaciju
        /// </summary>
        public Nekretnina()
        {

        }

        public string ToString1()
        {
            string rez = "Jeste";
            if (DaLiJeRezervisana == false) rez = "Nije";
            return "Detalji podaci o nekretnini\n" +
                "\nLokacija: " + Lokacija +
                "\nOpis: " + Opis +
                "\nTip nekretnine: " + TipNekretnine.ToString() +
                "\nRezervisana: " + rez +
                "\nCijena: " + Cijena.ToString() + " KM" +
                "\nKlijent: " + klijent.ToString();
        }

        public override string ToString()
        {
            return Opis;
        }
    }
}
