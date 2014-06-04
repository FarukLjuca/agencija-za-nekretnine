using System;
using System.Drawing;
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
		public HranaZmije(Image B = null)
		{
			Slika = B;
		}
		/// <summary>
		/// Slika hrane za zmiju
		/// </summary>
		public Image Slika { get; set; }
	}
}
