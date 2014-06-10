using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Diagnostics;

namespace EFMSnake
{
	public class Snake
	{
		const int SIZE = 15;
		Timer T = new Timer ();
		public enum Level : uint {Level1 = 1, Level2, Level3, Level4, Level5, Level6, Level7, Level8, Level9, LevelExtreme}
		private List<Panel> S = new List<Panel> ();
		private List<Panel> Q = new List<Panel> ();
		private Panel iHrana = new Panel ();
		private Panel CON;
		private void Dodaj(bool S1 = true)
		{
			Panel P = new Panel ();
			P.Height = P.Width = SIZE;
			P.BackgroundImageLayout = ImageLayout.Zoom;
			P.BackgroundImage = Tijelo1.Slika;
			int XX = 0, YY = 0;
			if (S1)
			{
				if (Dir1 == 0) { YY = 0; XX = SIZE; }
				else if (Dir1 == 1) { YY = -SIZE; XX = 0; }
				else if (Dir1 == 2) { YY = 0; XX = -SIZE; }
				else if (Dir1 == 3) { YY = SIZE; XX = 0; }
			}
			else
			{
				if (Dir2 == 0) { YY = 0; XX = SIZE; }
				else if (Dir2 == 1) { YY = -SIZE; XX = 0; }
				else if (Dir2 == 2) { YY = 0; XX = -SIZE; }
				else if (Dir2 == 3) { YY = SIZE; XX = 0; }
			}
			if (S1)
			{
				P.Left = S[S.Count - 1].Left + XX;
				P.Top = S[S.Count - 1].Top + YY;
				S.Add (P);
			}
			else 
			{
				P.Left = Q[Q.Count - 1].Left + XX;
				P.Top = Q[Q.Count - 1].Top + YY;
				Q.Add (P);
			}
			CON.Controls.Add (P);

		}
		public static int Rand(int Min, int Max)
		{
			Random R = new Random ();
			int S;
			while (true)
			{
				S = R.Next (Min, Max + 1);
				if ( (S) % SIZE == 0)
				{
					System.Diagnostics.Debug.WriteLine (S);
					return S;
				}
			}
		}
		private void RandFood(ref int X, ref int Y)
		{
			while (true)
			{
				int A = Rand (0, CON.Width - SIZE);
				int B = Rand (0, CON.Height - SIZE);
				Rectangle R = new Rectangle (A, B, SIZE, SIZE);
				bool SS = false;
				for (int I = 0; I < S.Count ; I++)
				{
					if (S[I].Bounds.IntersectsWith (R))
					{
						SS = true;
					}
				}
				if (!SS)
				{
					for (int I = 0; I < Q.Count; I++)
					{
						if (Q[I].Bounds.IntersectsWith (R))
						{
							SS = true;
						}
					}
					if (!SS)
					{
						Debug.WriteLine ("X = " + A.ToString ());
						Debug.WriteLine ("Y = " + B.ToString ());
						X = A;
						Y = B;
						break; 
					}
				}
			}
		}
		int Dir1 = 2, Dir2 = 0;
		private int[] Speeds = new int[] { 1000, 800, 700, 500, 320, 250, 150, 100, 75, 50 };
		public Snake(Panel Cont, GlavaZmije G1, TijeloZmije T1, GlavaZmije G2, TijeloZmije T2, HranaZmije H, Level L)
		{

			CON = Cont;
			CON.Controls.Clear ();
			Q.Clear ();
			S.Clear ();
			BrzinaZmije = (Brzina)L;
			Glava1 = G1; Glava2 = G2;
			Tijelo1 = T1; Tijelo2 = T2;
			Hrana = H;
			iHrana.Height = iHrana.Width = SIZE;
			iHrana.BackgroundImageLayout = ImageLayout.Zoom;
			iHrana.BackgroundImage = H.Slika;
			int ax = 0, ay = 0;
			RandFood (ref ax, ref ay);
			iHrana.Location = new Point (ax, ay);
			CON.Controls.Add (iHrana);
			
			Dir1 = 2; Dir2 = 0;
			{
				Panel P = new Panel ();
				CON.Controls.Add (P);
				P.Left =   3 * SIZE;
				P.Top = 0;
				P.Height = P.Width = SIZE;
				P.BackgroundImageLayout = ImageLayout.Zoom;
				P.BackgroundImage = Glava1.Slika;
				S.Add (P);
			}
			{
				Panel P = new Panel ();
				CON.Controls.Add (P);
				P.Left = Rand (CON.Width - 3 * SIZE, CON.Width - SIZE);
				P.Top = Rand (CON.Height - 2 * SIZE, CON.Height - SIZE);
				P.Height = P.Width = SIZE;
				P.BackgroundImageLayout = ImageLayout.Zoom;
				P.BackgroundImage = Glava2.Slika;
				
				Q.Add (P);
			}
			Dodaj ();
			Dodaj ();
			Dodaj (false);
			Dodaj (false);
			T.Tick += T_Tick;
			

		}
		public void Pokreni() { T.Enabled = true; }
		public void Pauziraj() { T.Enabled = false; }
		public bool DaLiJePauzirana { get { return !T.Enabled; } }
		public enum Brzina : uint
		{
			Brzina1 = 1,
			Brzina2 = 2,
			Brzina3 = 3,
			Brzina4 = 4,
			Brzina5 = 5,
			Brzina6 = 6,
			Brzina7 = 7,
			Brzina8 = 8,
			Brzina9 = 9,
			Brzina10 = 10
		};
		void T_Tick(object sender, EventArgs e)
		{
			HitSelf ();
			HitFood ();
			HitWall ();
			MoveSnake ();
			CON.Invalidate ();
		}
		void HitFood()
		{
			if (Q[0].Bounds.IntersectsWith (iHrana.Bounds))
			{ Dodaj (false); int a = 0, b = 0; RandFood (ref a, ref b); iHrana.Left = a; iHrana.Top = b; }
			if (S[0].Bounds.IntersectsWith (iHrana.Bounds))
			{ Dodaj (); int a = 0, b = 0; RandFood (ref a, ref b); iHrana.Left = a; iHrana.Top = b;}
		}
		private void HitWall(bool S1 = true)
		{
				for (int a = 1; a < S.Count; ++a)
					if (S[0].Left < 0 || S[0].Top < 0 || S[0].Right > CON.Width || S[0].Bottom > CON.Height)
					{ T.Enabled = false; MessageBox.Show ("Player1, GameOver"); T.Enabled = false; }
		for (int a = 1; a < S.Count; ++a)
					if (Q[0].Left < 0 || Q[0].Top < 0 || Q[0].Right > CON.Width || Q[0].Bottom > CON.Height)
					{ T.Enabled = false; MessageBox.Show ("Player2, GameOver"); }
		}
		private void HitSelf(bool S1 = true)
		{
				for (int a = 1; a < S.Count; ++a)
					if (S[0].Bounds.IntersectsWith (S[a].Bounds))
					{ T.Enabled = false; MessageBox.Show ("Player1, GameOver"); T.Enabled = false; }
				for (int a = 1; a < Q.Count; ++a)
					if (Q[0].Bounds.IntersectsWith (Q[a].Bounds))
					{ T.Enabled = false; MessageBox.Show ("Player2, GameOver"); T.Enabled = false; }
		}
		public Brzina BrzinaZmije
		{
			get { return eBrzina; }
			set { if (value != eBrzina) { eBrzina = value; T.Interval = Speeds[(int)eBrzina - 1]; } }
		}
		private void MoveSnake()
		{
			for (int a = S.Count - 1; a > 0; --a)
				S[a].Location = S[a - 1].Location;
			S[0].Left += X1;
			S[0].Top += Y1;
			Debug.WriteLine ("(X; Y) = (" + S[0].Left.ToString () + ", " + S[0].Top.ToString () + ")");
			for (int a = Q.Count - 1; a > 0; --a)
				Q[a].Location = Q[a - 1].Location;
			Q[0].Left += X2;
			Q[0].Top += Y2;
		}
		GlavaZmije Glava1 { get; set; }
		TijeloZmije Tijelo1 { get; set; }
		HranaZmije Hrana { get; set; }
		GlavaZmije Glava2 { get; set; }
		TijeloZmije Tijelo2 { get; set; }
		public enum Direct : byte {Lijevo = 1, Gore = 2, Desno = 3, Dolje = 4};
		private void DajBrojeve (Direct S, ref int a, ref int b)
		{
			if (S == Direct.Lijevo) { a = -SIZE; b = 0; }
			else if (S == Direct.Gore) { a = 0; b = -SIZE; }
			else if (S == Direct.Desno) { a = SIZE; b = 0; }
			else if (S == Direct.Dolje) { a = 0; b = SIZE; }
		}
		public void UpravljajZmijom1 (Direct Smjer)
		{
			DajBrojeve (Smjer, ref X1, ref Y1);
		}
		public void UpravljajZmijom2(Direct Smjer)
		{
			DajBrojeve (Smjer, ref X2, ref Y2);
		}
		int X1 = SIZE, Y1 = 0, X2 = -SIZE, Y2 = 0;
		private Brzina eBrzina;
	}
}
