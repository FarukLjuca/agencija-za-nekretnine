﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
	/// <summary>
	/// Ugovor koji se sklapa između klijenta i agencije u cilju postizanja obostranog povjerenja i 
	/// koji služi kao garancija redovnog obavljanja dužnosti sa obje strane
	/// </summary>
	public class InterniUgovor : IUgovor
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