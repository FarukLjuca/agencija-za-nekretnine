using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EFMSnake
{
	public partial class FrmMain : Form
	{
		public FrmMain()
		{
			InitializeComponent ();
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			//Primjer, da vidite. Ovo sam u designeru postavio, ovdje ne treba
			//this.BackgroundImage = Properties.Resources.BGround;
            staviSlikice();
		}

        private void staviSlikice()
        {
            foreach (Image im in imglGlava.Images)
            {
                Button b = new Button();
                b.BackgroundImage = im;
                b.Size = new Size(30, 30);
                b.Margin = new System.Windows.Forms.Padding(2);
                b.BackgroundImageLayout = ImageLayout.Stretch;
                flpGlava1.Controls.Add(b);
            }

            foreach (Image im in imglGlava.Images)
            {
                Button b = new Button();
                b.BackgroundImage = im;
                b.Size = new Size(30, 30);
                b.Margin = new System.Windows.Forms.Padding(2);
                b.BackgroundImageLayout = ImageLayout.Stretch;
                flpGlava2.Controls.Add(b);
            }

            foreach (Image im in imglTijelo.Images)
            {
                Button b = new Button();
                b.BackgroundImage = im;
                b.Size = new Size(30, 30);
                b.Margin = new System.Windows.Forms.Padding(2);
                b.BackgroundImageLayout = ImageLayout.Stretch;
                flpTijelo1.Controls.Add(b);
            }

            foreach (Image im in imglTijelo.Images)
            {
                Button b = new Button();
                b.BackgroundImage = im;
                b.Size = new Size(30, 30);
                b.Margin = new System.Windows.Forms.Padding(2);
                b.BackgroundImageLayout = ImageLayout.Stretch;
                flpTijelo2.Controls.Add(b);
            }

            foreach (Image im in imglHrana.Images)
            {
                Button b = new Button();
                b.BackgroundImage = im;
                b.Size = new Size(30, 30);
                b.Margin = new System.Windows.Forms.Padding(2);
                b.BackgroundImageLayout = ImageLayout.Stretch;
                flpHrana1.Controls.Add(b);
            }

            foreach (Image im in imglHrana.Images)
            {
                Button b = new Button();
                b.BackgroundImage = im;
                b.Size = new Size(30, 30);
                b.Margin = new System.Windows.Forms.Padding(2);
                b.BackgroundImageLayout = ImageLayout.Stretch;
                flpHrana2.Controls.Add(b);
            }
        }
	}
}
