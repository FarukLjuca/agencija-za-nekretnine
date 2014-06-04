using System;
namespace EFMSnake
{
	/// <summary>
	/// Klasa koja opisuje Hranu za Zmiju
	/// </summary>
	public class HranaZmije : IBlock
	{
		/// <summary>
		/// Kreira hranu za zmiju
		/// </summary>
		/// <param name="B">Slika hrane za zmiju</param>
		public HranaZmije(System.Windows.Media.Imaging.BitmapImage B = null)
		{
			Slika = B;
		}
		/// <summary>
		/// Slika hrane za zmiju
		/// </summary>
		public System.Windows.Media.Imaging.BitmapImage Slika { get; set; }
	}
}
