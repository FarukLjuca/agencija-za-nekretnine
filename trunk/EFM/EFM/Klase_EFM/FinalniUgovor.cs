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

		public string ID
		{
			get
			{
				throw new EFM.Exc.LazyDeveloperException ();
			}
			set
			{
				throw new EFM.Exc.LazyDeveloperException ();
			}
		}
	}
}
