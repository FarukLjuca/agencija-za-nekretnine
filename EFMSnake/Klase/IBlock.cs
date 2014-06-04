using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFMSnake
{
	/// <summary>
	/// Interface koji predstavlja osnovu za tipove blokova koji 
	/// se pojavljuju u snake igri
	/// </summary>
	public interface IBlock
	{
		/// <summary>
		/// Slika koja opisuje blok (Glavu, Hranu, Tijelo)
		/// </summary>
		System.Drawing.Image Slika{ get; set; }
	}
}
