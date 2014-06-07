﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = System.Data.SQLite;
using System.Data.SqlClient;
using System.Drawing;
namespace EFM
{
	public class DAL
	{
		public static byte[] ImgToBin(System.Drawing.Image imageIn)
		{
			System.IO.MemoryStream ms = new System.IO.MemoryStream ();
			imageIn.Save (ms, System.Drawing.Imaging.ImageFormat.Gif);
			return ms.ToArray ();
		}
		public static Image BinToImage(byte[] byteArrayIn)
		{
			System.IO.MemoryStream ms = new System.IO.MemoryStream (byteArrayIn);
			Image returnImage = Image.FromStream (ms);
			return returnImage;
		}
        private static DB.SQLiteConnection con = null;

        private static DAL instanca = null;
        public static DAL Instanca
        {
            get { return (instanca == null) ? instanca = new DAL() : instanca; }
        }
        private DAL() { }
         ~DAL() { Diskonektuj(); }
		public DB.SQLiteConnection Konekcija 
			{
				get 
				{
					if (con == null)
					{
						Instanca.Konektuj();
						return con;
					}
					else return con;
				}
			}
        private void Konektuj()
        {
            con = new DB.SQLiteConnection (@"data source=C:\sqlite\efmooad.db;version=3;");
            try
            {
                con.Open();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void Diskonektuj()
        {
            try
            {
                if (con != null) { con.Close(); instanca = null; con = null; }
            }
            catch (Exception e) { throw e; }
        }
    }
}