using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace EFM
{
	/// <summary>
	/// Helper Class by Enil Pajić.  Nalazi se metoda koja pomaže SQLiteDataReaderu da čita slike.
	/// </summary>
	public static class Helper

	{
		/// <summary>
		/// Čita sliku iz SQLite baze podataka, byte po byte.
		/// </summary>
		/// <param name="RD">SQLiteDataReader - reader koji je SPREMAN za čitanje</param>
		/// <param name="K">Kolona koju treba čitati</param>
		/// <returns>BitmapImage ili null u slučaju da je nema ili da je došlo do greške</returns>
		public static BitmapImage DajSliku(this SQLiteDataReader RD, int K)
		{
			try
			{
				byte[] B = new byte[RD.GetBytes (K, 0L, null, 0, Int32.MaxValue)];
				RD.GetBytes (K, 0L, B, 0, B.Length);
				using (System.IO.MemoryStream M = new System.IO.MemoryStream (B))
				{
					BitmapImage S = new BitmapImage ();
					S.BeginInit ();
					//Da se MemoryStream ne disposuje prije nego što završi regeneracija slike
					S.CacheOption = BitmapCacheOption.OnLoad;
					S.StreamSource = M;
					S.EndInit ();
					return S;
				}
			}
			catch (Exception)
			{
				return null;
			}

		}
		/// <summary>
		/// Pretvara sliku u niz byteova (byte []) spremnih za pohranu u datoteke, baze podataka...
		/// </summary>
		/// <param name="B">Slika (System.Windows.Media.Imaging.BitmapImage) koja se pretvara u byte[]</param>
		/// <returns>byte [], ili null u sličaju greške</returns>
		public static byte[] DajByte (this BitmapImage B)
		{
			try
			{
				BmpBitmapEncoder BE = new BmpBitmapEncoder ();
				BE.Frames.Add (BitmapFrame.Create (B));
				using (System.IO.MemoryStream M = new System.IO.MemoryStream ())
					{
						BE.Save (M);
						return M.ToArray ();
					}
			}
			catch (Exception)
			{
				return null;
				throw;
			}
		}
	}
}
