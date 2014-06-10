using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFMSnake.Klase
{
	public partial class Test : Form
	{
		public EFMPanel Pnl { get { return EnilPanel; } }
			public void PostaviSnake(Snake sss) {  s = sss; }
		public Test(Snake ss)
		{
			InitializeComponent ();
			s = ss;
			this.KeyDown += Test_KeyDown;
		}
		Snake s;
		void Test_KeyDown(object sender, KeyEventArgs e)
		{
			Keys k = e.KeyData;
			if (k == Keys.Enter || k == Keys.Space)
			{
				if (s.DaLiJePauzirana) s.Pokreni ();
				else s.Pauziraj ();
			}
			else if (k == Keys.A) s.UpravljajZmijom1 (Snake.Direct.Lijevo);
			else if (k == Keys.W) s.UpravljajZmijom1 (Snake.Direct.Gore);
			else if (k == Keys.D) s.UpravljajZmijom1 (Snake.Direct.Desno);
			else if (k == Keys.S) s.UpravljajZmijom1 (Snake.Direct.Dolje);

			else if (k == Keys.Left) s.UpravljajZmijom2 (Snake.Direct.Lijevo);
			else if (k == Keys.Up) s.UpravljajZmijom2 (Snake.Direct.Gore);
			else if (k == Keys.Right) s.UpravljajZmijom2 (Snake.Direct.Desno);
			else if (k == Keys.Down) s.UpravljajZmijom2 (Snake.Direct.Dolje);
		}

		private void Test_Load(object sender, EventArgs e)
		{

		}
	}
}
