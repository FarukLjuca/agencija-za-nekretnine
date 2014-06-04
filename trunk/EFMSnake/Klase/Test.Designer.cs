namespace EFMSnake.Klase
{
	partial class Test
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
			this.efmPanel1 = new EFMSnake.Klase.EFMPanel();
			this.SuspendLayout();
			// 
			// efmPanel1
			// 
			this.efmPanel1.Location = new System.Drawing.Point(5, 10);
			this.efmPanel1.Name = "efmPanel1";
			this.efmPanel1.Size = new System.Drawing.Size(735, 410);
			this.efmPanel1.TabIndex = 0;
			// 
			// Test
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(750, 430);
			this.Controls.Add(this.efmPanel1);
			this.Name = "Test";
			this.Text = "Test";
			this.ResumeLayout(false);

		}

		#endregion

		private EFMPanel efmPanel1;
	}
}