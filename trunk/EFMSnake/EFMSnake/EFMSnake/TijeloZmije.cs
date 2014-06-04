using System;
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
		public TijeloZmije(System.Windows.Media.Imaging.BitmapImage B = null)
		{
			Slika = B;
		}
		/// <summary>
		/// Slika tijela zmije
		/// </summary>
		public System.Windows.Media.Imaging.BitmapImage Slika { get; set; }
	}
}
