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
        public Image glava1;
        public Image glava2;
        public Image tijelo1;
        public Image tijelo2;
        public Image hrana;

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

        private void glava1_Click (object seneder, EventArgs e)
        {
            glava1.
        }
        
        private void glava2_Click (object seneder, EventArgs e)
        {

        }

        private void tijelo1_Click (object seneder, EventArgs e)
        {

        }

        private void tijelo2_Click (object seneder, EventArgs e)
        {

        }

        private void hrana_Click (object seneder, EventArgs e)
        {

        }
	}
}