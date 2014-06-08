using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFM
{
	/// <summary>
	/// Interfejs IUgovor koji sadrži zajednički Sklopi() metodu
	/// </summary>
	public interface IUgovor
	{
		/// <summary>
		/// Sklapa ugovor između dvije strane.
		/// </summary>
		/// <returns>System.Boolean</returns>
		Boolean SklopiUgovor(); //TODO: moramo ovo skroz mijenjati!!
		/// <summary>
		/// ID ugovora pomoću kojeg se identificira
		/// </summary>
		long ID { get; set; }
		DateTime DatumSklapanja { get; set; }
		string Opis { get; set; }
	}
}
