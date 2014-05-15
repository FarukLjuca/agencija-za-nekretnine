using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ZadacaDao
{
    public class NekretnineDAO : IDaoCrud<Nekretnine>
        {
            protected MySqlCommand c;

            public long create(Nekretnine entity)
            {
                try
                {

                    c = new MySqlCommand(String.Format("INSERT INTO Nekretnine VALUES ('{0}','{1}','{2}','{3}','{4}','{5}');",
                        entity.Id, entity.Lokacija, entity.TipNekretnine, entity.RezervisanostNekretnine, entity.CistocaNekretnine, entity.CijenaNekretnine),con);
                    c.ExecuteNonQuery();
                    return c.LastInsertedId;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
       


            public Nekretnine read(Nekretnine entity)
            {
                try
                {
                    c = new MySqlCommand(String.Format("SELECT * FROM Nekretnine WHERE id='{0}'", entity.Id), con);

                    MySqlDataReader r = c.ExecuteReader();

                    if (r.Read())
                    {
                        Nekretnine nekretnine = new Nekretnine(r.GetInt32("id"), r.GetString("Lokacija"), r.GetString("TipNekretnine"), 
                            r.GetString("RezervisanostNekretnine"), r.GetString("CistocaNekretnine"), r.GetInt32("CijenaNekretnine"));
                        r.Close();
                        return nekretnine;
                    }
                    else throw
                     new Exception("Nema podataka za citanje");

                }
                catch (Exception e)
                {
                    throw e;
                }
            }


            public Nekretnine update(int id, Nekretnine entity)
            {
                try
                {
                    c = new MySqlCommand(String.Format("UPDATE nekretnine SET id='{0}', Lokacija='{1}', TipNekretnine='{2}', RezervisanostNekretnine = '{3}',CistocaNekretnine = '{4}', CijenaNekretnine = '{5}' where id = '{8}';",
                        entity.Id, entity.Lokacija, entity.TipNekretnine, entity.RezervisanostNekretnine, entity.CistocaNekretnine, entity.CijenaNekretnine, id), con);
                    c.ExecuteNonQuery();
                    return entity;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public void delete(Nekretnine entity)
            {
                try
                {
                    c = new MySqlCommand(String.Format("DELETE FROM nekretnine WHERE id ='{0}';", entity.Id), con);
                    c.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        

            public Nekretnine getById(long id)
            {
                try
                {
                    c = new MySqlCommand(String.Format("SELECT * FROM nekretnine WHERE id='{0}';", id), con);
                    MySqlDataReader r = c.ExecuteReader();
                    if (r.Read())
                    {
                        Nekretnine a = new Nekretnine(r.GetInt32("id"), r.GetString("Lokacija"), r.GetString("TipNekretnine"), 
                            r.GetString("RezervisanostNekretnine"), r.GetString("CistocaNekretnine"), r.GetInt32("CijenaNekretnine"));
                        r.Close();
                        return a;
                    }
                    else throw
                        new Exception("Nema podataka za prikaz");
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public List<Nekretnine> GetAll()
            {
                try
                {
                    c = new MySqlCommand(String.Format("SELECT * FROM nekretnine;"), con);
                    MySqlDataReader r = c.ExecuteReader();
                    List<Nekretnine> nekretninice = new List<Nekretnine>();
                    while (r.Read())
                        nekretninice.Add(new Nekretnine(r.GetInt32("id"), r.GetString("Lokacija"), r.GetString("TipNekretnine"), 
                            r.GetString("RezervisanostNekretnine"), r.GetString("CistocaNekretnine"), r.GetInt32("CijenaNekretnine")));

                    r.Close();
                    return nekretninice;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public List<Nekretnine> getByExample(string name, string values)
            {
                try
                {
                    c = new MySqlCommand(String.Format("SELECT * FROM nekretnine WHERE {0}='{1}';", name, values), con);
                    MySqlDataReader r = c.ExecuteReader();
                    List<Nekretnine> nekretninice = new List<Nekretnine>();
                    while (r.Read())
                        nekretninice.Add(new Nekretnine(r.GetInt32("id"), r.GetString("Lokacija"), r.GetString("TipNekretnine"), 
                            r.GetString("RezervisanostNekretnine"), r.GetString("CistocaNekretnine"), r.GetInt32("CijenaNekretnine")));
                    r.Close();
                    return nekretninice;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }

