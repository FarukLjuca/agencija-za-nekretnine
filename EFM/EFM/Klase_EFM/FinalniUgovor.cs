using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
	/// <summary>
	/// Ugovor koji se sklapa između dva zadovoljna klijenta nakon uspješne 
	/// prodaje/kupovine ili unajmnljivanja/iznajmljivanja
	/// </summary>
	public class FinalniUgovor : IUgovor
	{
		//TODO: pod hitno ovo izmijeniti
		public bool SklopiUgovor()
		{
			throw new EFM.Exc.LazyDeveloperException ();
		}

		public int ID { get; set; }
		public DateTime DatumSklapanja { get; set; }
		public KupacProdavac Kupac { get; set; }
		public KupacProdavac Prodavac { get; set; }
		public string Opis { get; set; }
		public Nekretnina Nekretnina { get; set; }
	}
}
