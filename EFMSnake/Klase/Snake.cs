using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace EFMSnake
{
	public class Snake
	{
		const int SIZE = 10;
		Timer T = new Timer ();
		public enum Level : uint {Level1 = 1, Level2, Level3, Level4, Level5, Level6, Level7, Level8, Level9, LevelExtreme}
		private List<Image> S = new List<Image> ();
		////private Bitmap iHrana = new Bitmap ();
		//private void Dodaj ()
		//{
		//	Image I = new Image ();
		//	I.Height = I.Width = SIZE;
		//	I.Source = Tijelo.Slika;
			
		//	S.Add (I);
			
		//}
		//public Snake(ContentControl Cont, GlavaZmije G, TijeloZmije T, HranaZmije H, Level L)
		//{
		//	Image I = new Image (), U = new Image();
		//	I.Height = I.Width = SIZE;
		//	I.Source = G.Slika;
		//	S.Add (I);
		//	U.Height = U.Width = SIZE;
		//	U.Source = T.Slika;
		//	S.Add (U);
		//	S.Add (U);
		//	iHrana.Source = H.Slika;


		//}
		GlavaZmije Glava { get; set; }
		TijeloZmije Tijelo { get; set; }
		HranaZmije Hrana { get; set; }
	}
}
