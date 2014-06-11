using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
	/// <summary>
	/// Ugovor koji se sklapa između agencije i vanjskog saradnika
	/// </summary>
	public class EksterniUgovor : IUgovor
	{
		//TODO: pod hitno ovo izmijeniti
		public bool SklopiUgovor()
		{
			throw new EFM.Exc.LazyDeveloperException ();
		}

		public long ID { get; set; }
		public DateTime DatumSklapanja { get; set; }
		public string Opis { get; set; }
		public VanjskiSaradnik VanjskiSaradnik { get; set; }
        public bool prikazi { get; set; }
	}
}
