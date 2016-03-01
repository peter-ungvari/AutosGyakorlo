using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutosGyakorlo
{
    class JarmuAdatbazisKezelo
    {
        private SqlConnection KapcsolatLetrehoz()
        {
            return new SqlConnection(Properties.Settings.Default.Database1ConnectionString);
        }

        public void Beszur(Jarmu jarmu)
        {
            using (var conn = KapcsolatLetrehoz()) {

                conn.Open();

                using (SqlTransaction tr = conn.BeginTransaction())
                {

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = "insert into jarmu (alvazszam, futottkm, hasznosteher, hengerurt, marka, rendszam, szallithatoszemelyek, tipus) values (" +
                            "@alvazszam, @futottkm, @hasznosteher, @hengerurt, @marka, @rendszam, @szallithatoszemelyek, @tipus)";
                        cmd.Parameters.AddWithValue("@alvazszam", jarmu.Alvazszam);
                        cmd.Parameters.AddWithValue("@futottKm", jarmu.FutottKm);
                        cmd.Parameters.AddWithValue("@hasznosteher", jarmu.HasznosTeher);
                        cmd.Parameters.AddWithValue("@hengerurt", jarmu.Hengerurt);
                        cmd.Parameters.AddWithValue("@marka", jarmu.Marka);
                        cmd.Parameters.AddWithValue("@rendszam", jarmu.Rendszam);
                        cmd.Parameters.AddWithValue("@szallithatoszemelyek", jarmu.SzallithatoSzemelyek);
                        cmd.Parameters.AddWithValue("@tipus", jarmu.Tipus);
                        cmd.Transaction = tr;
                        cmd.ExecuteNonQuery();

                    }

                    if (jarmu is SzemelyGepjarmu)
                    {
                        SzemelyGepjarmu sz = jarmu as SzemelyGepjarmu;
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "insert into szemelygepjarmu (alvazszam, hangrendszer, felszereltseg) values (@alvazszam, @hangrendszer, @felszereltseg)";
                            cmd.Parameters.AddWithValue("@alvazszam", jarmu.Alvazszam);
                            cmd.Parameters.AddWithValue("@hangrendszer", sz.Hangrendszer);
                            cmd.Parameters.AddWithValue("@felszereltseg", sz.Felszereltseg);
                            cmd.Transaction = tr;
                            cmd.ExecuteNonQuery();
                        }
                    } 
                    else if(jarmu is KisteherGepjarmu)
                    {
                        KisteherGepjarmu k = jarmu as KisteherGepjarmu;
                        using (var cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = "insert into kistehergepjarmu (alvazszam, onsuly, kialakitas) values (@alvazszam, @onsuly, @kialakitas)";
                            cmd.Parameters.AddWithValue("@alvazszam", jarmu.Alvazszam);
                            cmd.Parameters.AddWithValue("@onsuly", k.Onsuly);
                            cmd.Parameters.AddWithValue("@kialakitas", k.Kialakitas);
                            cmd.Transaction = tr;
                            cmd.ExecuteNonQuery();
                        }
                    }

                    tr.Commit();
                }
            }
            
        }

        public List<SzemelyGepjarmu> SzemelyGepjarmuListaz()
        {
            
            List<SzemelyGepjarmu> jarmuvek = new List<SzemelyGepjarmu>();
            using (var conn = KapcsolatLetrehoz())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from jarmu j join szemelygepjarmu sz on j.alvazszam = sz.alvazszam";
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        SzemelyGepjarmu sz = new SzemelyGepjarmu();
                        JarmuOlvas(reader, sz);
                        sz.Felszereltseg = (Felszereltseg)reader["felszereltseg"];
                        sz.Hangrendszer = Convert.ToBoolean(reader["hangrendszer"]);
                        jarmuvek.Add(sz);
                    }
                }
            }
            
            return jarmuvek;
        }

        private void JarmuOlvas(SqlDataReader reader, Jarmu jarmu)
        {
            jarmu.Alvazszam = (string)reader["alvazszam"];
            jarmu.FutottKm = (int)reader["futottKm"];
            jarmu.HasznosTeher = (int)reader["hasznosTeher"];
            jarmu.Hengerurt = (int)reader["hengerurt"];
            jarmu.Marka = (string)reader["marka"];
            jarmu.Rendszam = (string)reader["rendszam"];
            jarmu.SzallithatoSzemelyek = (int)reader["szallithatoSzemelyek"];
            jarmu.Tipus = (string)reader["tipus"];
        }

        public List<KisteherGepjarmu> KisteherGepjarmuListaz()
        {
           
            List<KisteherGepjarmu> jarmuvek = new List<KisteherGepjarmu>();

            using (var conn = KapcsolatLetrehoz())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "select * from jarmu j join kistehergepjarmu k on j.alvazszam = k.alvazszam";
                    conn.Open();
                    var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        KisteherGepjarmu k = new KisteherGepjarmu();
                        JarmuOlvas(reader, k);
                        k.Kialakitas = (Kialakitas)reader["kialakitas"];
                        k.Onsuly = (int)reader["onsuly"];
                        jarmuvek.Add(k);
                    }
                }
            }
           
            return jarmuvek;
        }

       
        public void Torol(SzemelyGepjarmu sz)
        {
            
        }

        public void Torol(KisteherGepjarmu k)
        {
           
        }

        public void Modosit(SzemelyGepjarmu sz)
        {
            
        }

        public void Modosit(KisteherGepjarmu k)
        {
            
        }

        private void Modosit(Jarmu jarmu)
        {
            
        }

        public List<Jarmu> KeresFutottKmAlapjan(int futottKmMin, int futottKmMax) {


            List<Jarmu> jarmuvek = new List<Jarmu>();
            

            return jarmuvek;
        }
    }
}
