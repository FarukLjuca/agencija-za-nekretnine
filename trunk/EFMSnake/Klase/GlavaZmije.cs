using System;
using System.Drawing;
namespace EFMSnake
{
	/// <summary>
	/// Klasa koja opisuje Glavu Zmije
	/// </summary>
	public class GlavaZmije : IBlock
	{
		/// <summary>
		/// Kreira glavu zmije
		/// </summary>
		/// <param name="B">Slika glave zmije</param>
		public GlavaZmije(Image B = null)
		{
			Slika = B;
		}
		/// <summary>
		/// Slika glave zmije
		/// </summary>
		public Image Slika { get; set; }
	}
}
