using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB = System.Data.SQLite;
using System.Data.SqlClient;
namespace EFM
{
    public class DAL
    {
		public static T REP<T>(T E) where T : new()
		{
			
			if (E == null) return new T ();
			else return E;
		}
        private static DB.SQLiteConnection con = null;

        private static DAL instanca = null;
        public static DAL Instanca
        {
            get { return (instanca == null) ? instanca = new DAL() : instanca; }
        }
        private DAL() { }
        ~DAL() {/* Diskonektuj();*/ }
        public DB.SQLiteConnection Konekcija
        {
            get
            {
                if (con == null)
                {
                    Konektuj();
                    return con;
                }
                else return con;
            }
        }
        private void Konektuj()
        {
            con = new DB.SQLiteConnection(@"data source=C:\sqlite\efmooad.db;version=3;");
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
                if (con != null) { con.Close(); con = null; instanca = null; }
            }
            catch (Exception e) {  }
        }
    }
}
