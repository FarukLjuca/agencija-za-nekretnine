﻿using System;
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
        public GlavaZmije glava1 = new GlavaZmije();
        public GlavaZmije glava2;
        public TijeloZmije tijelo1;
        public TijeloZmije tijelo2;
        public HranaZmije hrana;

		public FrmMain()
		{
			InitializeComponent ();
		}

		private void FrmMain_Load(object sender, EventArgs e)
		{
			//Primjer, da vidite. Ovo sam u designeru postavio, ovdje ne treba
			//this.BackgroundImage = Properties.Resources.BGround;
            staviSlikice();
            postaviDefault();
        }

        private void postaviDefault()
        {
            glava1 = new GlavaZmije(imglGlava.Images[10]);
            glava2 = new GlavaZmije(imglGlava.Images[11]);
            tijelo1 = new TijeloZmije(imglTijelo.Images[2]);
            tijelo2 = new TijeloZmije(imglTijelo.Images[2]);
            hrana = new HranaZmije(imglHrana.Images[3]);
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
                b.Click += new EventHandler(glava1_Click);
                flpGlava1.Controls.Add(b);
            }

            foreach (Image im in imglGlava.Images)
            {
                Button b = new Button();
                b.BackgroundImage = im;
                b.Size = new Size(30, 30);
                b.Margin = new System.Windows.Forms.Padding(2);
                b.BackgroundImageLayout = ImageLayout.Stretch;
                b.Click += new EventHandler(glava2_Click);
                flpGlava2.Controls.Add(b);
            }

            foreach (Image im in imglTijelo.Images)
            {
                Button b = new Button();
                b.BackgroundImage = im;
                b.Size = new Size(30, 30);
                b.Margin = new System.Windows.Forms.Padding(2);
                b.BackgroundImageLayout = ImageLayout.Stretch;
                b.Click += new EventHandler(tijelo1_Click);
                flpTijelo1.Controls.Add(b);
            }

            foreach (Image im in imglTijelo.Images)
            {
                Button b = new Button();
                b.BackgroundImage = im;
                b.Size = new Size(30, 30);
                b.Margin = new System.Windows.Forms.Padding(2);
                b.BackgroundImageLayout = ImageLayout.Stretch;
                b.Click += new EventHandler(tijelo2_Click);
                flpTijelo2.Controls.Add(b);
            }

            foreach (Image im in imglHrana.Images)
            {
                Button b = new Button();
                b.BackgroundImage = im;
                b.Size = new Size(30, 30);
                b.Margin = new System.Windows.Forms.Padding(2);
                b.BackgroundImageLayout = ImageLayout.Stretch;
                b.Click += new EventHandler(hrana_Click);
                flpHrana.Controls.Add(b);
            }
        }

        private void glava1_Click(object seneder, EventArgs e)
        {
            glava1.Slika = (seneder as Button).BackgroundImage;
        }

        private void glava2_Click(object seneder, EventArgs e)
        {
            glava2.Slika = (seneder as Button).BackgroundImage;
        }

        private void tijelo1_Click(object seneder, EventArgs e)
        {
            tijelo1.Slika = (seneder as Button).BackgroundImage;
        }

        private void tijelo2_Click(object seneder, EventArgs e)
        {
            tijelo2.Slika = (seneder as Button).BackgroundImage;
        }

        private void hrana_Click(object seneder, EventArgs e)
        {
            hrana.Slika = (seneder as Button).BackgroundImage;
        }

        private void START_Click(object sender, EventArgs e)
        {

			panel1.Visible = false;
			btnAbout.Visible = false;
			btnStart.Visible = false;
			this.BackgroundImage = null;

			EFMSnake.Klase.Test t = new EFMSnake.Klase.Test (null);
			Snake S = new Snake (t.Pnl, glava1, tijelo1, glava2, tijelo2, hrana, Snake.Brzina.Brzina5);
			t.PostaviSnake (S);
			t.ShowDialog (this);



            
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            var form = new AboutForm();
            form.Show();
        }

	}
}
