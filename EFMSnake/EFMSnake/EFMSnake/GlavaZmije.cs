using System;
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
		public GlavaZmije(System.Windows.Media.Imaging.BitmapImage B = null)
		{
			Slika = B;
		}
		/// <summary>
		/// Slika glave zmije
		/// </summary>
		public System.Windows.Media.Imaging.BitmapImage Slika { get; set; }
	}
}
