using System;
using System.Drawing;
namespace EFMSnake
{
	/// <summary>
	/// Klasa koja opisuje Tijelo Zmije
	/// </summary>
	public class TijeloZmije : IBlock
	{
		/// <summary>
		/// Kreira glavu zmije
		/// </summary>
		/// <param name="B">Slika tijela zmije</param>
		public TijeloZmije (Image B = null)
		{
			Slika = B;
		}
		/// <summary>
		/// Slika tijela zmije
		/// </summary>
		public Image Slika { get; set; }
	}
}
