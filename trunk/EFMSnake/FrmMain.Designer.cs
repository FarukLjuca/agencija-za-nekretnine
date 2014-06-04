namespace EFMSnake
{
	partial class FrmMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose ();
			}
			base.Dispose (disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxIgrac1 = new System.Windows.Forms.GroupBox();
            this.gbxIgrac2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.gbxIgrac1.SuspendLayout();
            this.gbxIgrac2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panel1.Controls.Add(this.gbxIgrac2);
            this.panel1.Controls.Add(this.gbxIgrac1);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(300, 409);
            this.panel1.TabIndex = 0;
            // 
            // gbxIgrac1
            // 
            this.gbxIgrac1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbxIgrac1.Controls.Add(this.label7);
            this.gbxIgrac1.Controls.Add(this.label5);
            this.gbxIgrac1.Controls.Add(this.label1);
            this.gbxIgrac1.Location = new System.Drawing.Point(3, 3);
            this.gbxIgrac1.Name = "gbxIgrac1";
            this.gbxIgrac1.Size = new System.Drawing.Size(140, 403);
            this.gbxIgrac1.TabIndex = 1;
            this.gbxIgrac1.TabStop = false;
            this.gbxIgrac1.Text = "Igrac 1";
            // 
            // gbxIgrac2
            // 
            this.gbxIgrac2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbxIgrac2.Controls.Add(this.label4);
            this.gbxIgrac2.Controls.Add(this.label2);
            this.gbxIgrac2.Controls.Add(this.label3);
            this.gbxIgrac2.Location = new System.Drawing.Point(154, 3);
            this.gbxIgrac2.Name = "gbxIgrac2";
            this.gbxIgrac2.Size = new System.Drawing.Size(140, 403);
            this.gbxIgrac2.TabIndex = 1;
            this.gbxIgrac2.TabStop = false;
            this.gbxIgrac2.Text = "Igrac 2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Odaberite glavu zmije:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 265);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Odaberite hranu zmije:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Odaberite tijelo zmije:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Odaberite glavu zmije:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Odaberite tijelo zmije:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 265);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Odaberite hranu zmije:";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::EFMSnake.Properties.Resources.BGround;
            this.ClientSize = new System.Drawing.Size(899, 433);
            this.Controls.Add(this.panel1);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EFM Snake";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.panel1.ResumeLayout(false);
            this.gbxIgrac1.ResumeLayout(false);
            this.gbxIgrac1.PerformLayout();
            this.gbxIgrac2.ResumeLayout(false);
            this.gbxIgrac2.PerformLayout();
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbxIgrac2;
        private System.Windows.Forms.GroupBox gbxIgrac1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
	}
}

