using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ZadacaDao
{
    public class EUgovorDAO : IDaoCrud<EUgovor>
        {
            protected MySqlCommand c;

            public long create(EUgovor entity)
            {
                try
                {

                    c = new MySqlCommand(String.Format("INSERT INTO eUgovor VALUES ('{0}','{1}','{2}');",
                        entity.IdEUgovor, entity.Datum, entity.Opis),con);
                    c.ExecuteNonQuery();
                    return c.LastInsertedId;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public EUgovor read(EUgovor entity)
            {
                try
                {
                    c = new MySqlCommand(String.Format("SELECT * FROM eUgovor WHERE idEUgovor='{0}'", entity.IdEUgovor), con);

                    MySqlDataReader r = c.ExecuteReader();

                    if (r.Read())
                    {
                        EUgovor eUgovor = new EUgovor(r.GetInt32("idEUgovor"), r.GetInt32("datum"), r.GetString("opis"));
                        r.Close();
                        return eUgovor ;
                    }
                    else throw
                     new Exception("Nema podataka za citanje");

                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public EUgovor  update(int id, EUgovor  entity)
            {
                try
                {
                    c = new MySqlCommand(String.Format("UPDATE uposlenik SET idEUgovor ='{0}', datum='{1}', opis='{2}', maticniBroj = '{3}' where idEUgovor  = '{8}';",
                        entity.IdEUgovor , entity.Datum, entity.Opis, id), con);
                    c.ExecuteNonQuery();
                    return entity;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public void delete(EUgovor entity)
            {
                try
                {
                    c = new MySqlCommand(String.Format("DELETE FROM uposlenik WHERE idEUgovor  ='{0}';", entity.IdEUgovor ), con);
                    c.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public EUgovor  getById(long id)
            {
                try
                {
                    c = new MySqlCommand(String.Format("SELECT * FROM eUgovor WHERE idEUgovor ='{0}';", id), con);
                    MySqlDataReader r = c.ExecuteReader();
                    if (r.Read())
                    {
                        EUgovor  a = new EUgovor (r.GetInt32("idEUgovor"), r.GetInt32("datum"), r.GetString("opis"));
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

            public List<EUgovor> GetAll()
            {
                try
                {
                    c = new MySqlCommand(String.Format("SELECT * FROM eUgovor;"), con);
                    MySqlDataReader r = c.ExecuteReader();
                    List<EUgovor> eUgovori = new List<EUgovor>();
                    while (r.Read())
                        eUgovori.Add(new EUgovor(r.GetInt32("idEUgovor"), r.GetInt32("datum"), r.GetString("opis")));

                    r.Close();
                    return eUgovori;

                }
                catch (Exception e)
                {
                    throw e;
                }
            }

            public List<EUgovor> getByExample(string name, string values)
            {
                try
                {
                    c = new MySqlCommand(String.Format("SELECT * FROM eUgovor WHERE {0}='{1}';", name, values), con);
                    MySqlDataReader r = c.ExecuteReader();
                    List<EUgovor> eUgovori = new List<EUgovor>();
                    while (r.Read())
                        eUgovori.Add(new EUgovor(r.GetInt32("idEUgovor"), r.GetInt32("datum"), r.GetString("opis")));
                    r.Close();
                    return eUgovori;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
