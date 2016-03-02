using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosGyakorlo
{
    public class AdatbazisKezeloGyarto
    {
        const string szemelygepjarmuListazSql = @"select * from jarmu j join szemelygepjarmu sz on j.alvazszam = sz.alvazszam";

        const string kistehergepjarmuListazSql = @"select * from jarmu j join kistehergepjarmu k on j.alvazszam = k.alvazszam";

        const string jarmuBeszurSql = @"insert into jarmu (alvazszam, futottkm, hasznosteher, hengerurt, marka, rendszam, szallithatoszemelyek, tipus)
                values (@alvazszam, @futottkm, @hasznosteher, @hengerurt, @marka, @rendszam, @szallithatoszemelyek, @tipus)";

        const string szemelygepjarmuBeszurSql = @"insert into szemelygepjarmu (alvazszam, hangrendszer, felszereltseg) 
                values (@alvazszam, @hangrendszer, @felszereltseg)";

        const string kistehergepjarmuBeszurSql = @"insert into kistehergepjarmu (alvazszam, onsuly, kialakitas)
                values (@alvazszam, @onsuly, @kialakitas)";

        const string jarmuModositSql = @"update jarmu set 
                futottkm=@futottkm, hasznosteher=@hasznosteher, hengerurt=@hengerurt, marka=@marka, rendszam=@rendszam,
                szallithatoszemelyek=@szallithatoszemelyek, tipus=@tipus
                where alvazszam = @alvazszam";

        const string szemelyGepjarmuModositSql = @"update szemelygepjarmu set
                hangrendszer=@hangrendszer, felszereltseg=@felszereltseg
                where alvazszam = @alvazszam";

        const string kistehergepjarmuModositSql = @"update kistehergepjarmu set
                onsuly=@onsuly, kialakitas=@kialakitas
                where alvazszam = @alvazszam";

        const string jarmuTorolSql = @"delete from jarmu where alvazszam=@alvazszam";

        const string szemelygepjarmuTorolSql = @"delete from szemelygepjarmu where alvazszam=@alvazszam";

        const string kistehergepjarmuTorolSql = @"delete from kistehergepjarmu where alvazszam=@alvazszam";

        static readonly string connectionString = Properties.Settings.Default.Database1ConnectionString;

        public static AdatbazisKezelo<KisteherGepjarmu> UjKisteherGepjarmuAbk()
        {
            AdatbazisKezelo<KisteherGepjarmu> ak = new AdatbazisKezelo<KisteherGepjarmu>();
            ak.ConnectionString = connectionString;
            ak.ListazSql = kistehergepjarmuListazSql;
            ak.Olvas = KistehergepjarmuOlvas;

            ak.Beszurok.Add(jarmuBeszurSql, JarmuParameterez);
            ak.Beszurok.Add(kistehergepjarmuBeszurSql, KistehergepjarmuParameterez);

            ak.Modositok.Add(jarmuModositSql, JarmuParameterez);
            ak.Modositok.Add(kistehergepjarmuModositSql, KistehergepjarmuParameterez);

            ak.Torlok.Add(kistehergepjarmuTorolSql, KistehergepjarmuParameterez);
            ak.Torlok.Add(jarmuTorolSql, JarmuParameterez);
            return ak;
        }

        public static AdatbazisKezelo<SzemelyGepjarmu> UjSzemelygepjarmuAbk()
        {
            AdatbazisKezelo<SzemelyGepjarmu> ak = new AdatbazisKezelo<SzemelyGepjarmu>();
            ak.ConnectionString = connectionString;
            ak.ListazSql = szemelygepjarmuListazSql;
            ak.Olvas = SzemelygepjarmuOlvas;

            ak.Beszurok.Add(jarmuBeszurSql, JarmuParameterez);
            ak.Beszurok.Add(szemelygepjarmuBeszurSql, SzemelygepjamuParameterez);

            ak.Modositok.Add(jarmuModositSql, JarmuParameterez);
            ak.Modositok.Add(szemelyGepjarmuModositSql, SzemelygepjamuParameterez);

            ak.Torlok.Add(szemelygepjarmuTorolSql, SzemelygepjamuParameterez);
            ak.Torlok.Add(jarmuTorolSql, JarmuParameterez);            
            return ak;
        }

        private static void JarmuParameterez(SqlParameterCollection parameterek, Jarmu jarmu)
        {
            parameterek.AddWithValue("@alvazszam", jarmu.Alvazszam);
            parameterek.AddWithValue("@futottKm", jarmu.FutottKm);
            parameterek.AddWithValue("@hasznosteher", jarmu.HasznosTeher);
            parameterek.AddWithValue("@hengerurt", jarmu.Hengerurt);
            parameterek.AddWithValue("@marka", jarmu.Marka);
            parameterek.AddWithValue("@rendszam", jarmu.Rendszam);
            parameterek.AddWithValue("@szallithatoszemelyek", jarmu.SzallithatoSzemelyek);
            parameterek.AddWithValue("@tipus", jarmu.Tipus);
        }

        private static void SzemelygepjamuParameterez(SqlParameterCollection parameterek, SzemelyGepjarmu sz)
        {
            parameterek.AddWithValue("@alvazszam", sz.Alvazszam);
            parameterek.AddWithValue("@hangrendszer", sz.Hangrendszer);
            parameterek.AddWithValue("@felszereltseg", sz.Felszereltseg);
        }

        private static void KistehergepjarmuParameterez(SqlParameterCollection parameterek, KisteherGepjarmu k)
        {
            parameterek.AddWithValue("@alvazszam", k.Alvazszam);
            parameterek.AddWithValue("@onsuly", k.Onsuly);
            parameterek.AddWithValue("@kialakitas", k.Kialakitas);
        }

        private static SzemelyGepjarmu SzemelygepjarmuOlvas(SqlDataReader reader)
        {
            SzemelyGepjarmu sz = new SzemelyGepjarmu();
            JarmuOlvas(reader, sz);
            sz.Felszereltseg = (Felszereltseg)reader["felszereltseg"];
            sz.Hangrendszer = Convert.ToBoolean(reader["hangrendszer"]);
            return sz;
        }

        private static KisteherGepjarmu KistehergepjarmuOlvas(SqlDataReader reader)
        {
            KisteherGepjarmu k = new KisteherGepjarmu();
            JarmuOlvas(reader, k);
            k.Kialakitas = (Kialakitas)reader["kialakitas"];
            k.Onsuly = (int)reader["onsuly"];
            return k;
        }

        private static void JarmuOlvas(SqlDataReader reader, Jarmu jarmu)
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

    }
}
