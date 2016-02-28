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

        // Table adapterek.
        // Ha kiír hibát a program, akkor az azért van, mert más a DataSet-ed neve, nem Database1DataSet.
        // A generált DataSet osztályod nevét a Data Sources ablakban látod bal oldalon.
        // Ha nincs ott semmi, létre kell egyet hozni az első ikonnal, majd Next > Next > Tables alatt mindent kiválaszt > Finish.
        Database1DataSetTableAdapters.JarmuTableAdapter jta = new Database1DataSetTableAdapters.JarmuTableAdapter();
        Database1DataSetTableAdapters.SzemelyGepjarmuTableAdapter szta = new Database1DataSetTableAdapters.SzemelyGepjarmuTableAdapter();
        Database1DataSetTableAdapters.KisteherGepjarmuTableAdapter kta = new Database1DataSetTableAdapters.KisteherGepjarmuTableAdapter();
        Database1DataSetTableAdapters.TableAdapterManager tam = new Database1DataSetTableAdapters.TableAdapterManager();

        // Konstruktor. Ezt létre kell hozni és benne a TableAdapterManager adatait (tam) beállítani.
        public JarmuAdatbazisKezelo()
        {
            tam.UpdateOrder = Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            tam.SzemelyGepjarmuTableAdapter = szta;
            tam.JarmuTableAdapter = jta;
            tam.KisteherGepjarmuTableAdapter = kta;
        }

        public void Beszur(Jarmu jarmu)
        {
            //üres DataSet létrehozása, ez egy tároló. Ennek is táblái, sorai lehetnek, mint az adatbázisnak.
            //a tartalmát fogjuk majd bepakolni az adatbázisba.
            Database1DataSet dataset = new Database1DataSet(); 

            //új JarmuRow sor létrehozása, amit be lehet majd tenni a DataSet Jarmu táblájába
            Database1DataSet.JarmuRow jarmuRow = dataset.Jarmu.NewJarmuRow();

            //alap adatok feltöltése az új JarmuRow sorba
            jarmuRow.alvazszam = jarmu.Alvazszam;
            jarmuRow.futottKm = jarmu.FutottKm;
            jarmuRow.hasznosTeher = jarmu.HasznosTeher;
            jarmuRow.marka = jarmu.Marka;
            jarmuRow.hengerurt = jarmu.Hengerurt;
            jarmuRow.rendszam = jarmu.Rendszam;
            jarmuRow.szallithatoSzemelyek = jarmu.SzallithatoSzemelyek;
            jarmuRow.tipus = jarmu.Tipus;

            //a feltöltött sor hozzáadása a DataSet Jarmu táblájához
            dataset.Jarmu.Rows.Add(jarmuRow);

            if (jarmu is SzemelyGepjarmu) //ha a jarmu SzemelyGepjarmu
            {
                SzemelyGepjarmu sz = jarmu as SzemelyGepjarmu; //átalakítás SzemelyGepjarmu típusra, az lesz az "sz"

                //új SzemelyGepjarmuRow sor létrehozása, amit be lehet majd tenni a DataSet SzemelyGepjarmu táblájába
                Database1DataSet.SzemelyGepjarmuRow row = dataset.SzemelyGepjarmu.NewSzemelyGepjarmuRow();

                //SzemelyGepjarmu adatok feltöltése az új SzemelyGepjarmuRow sorba
                row.felszereltseg = (int)sz.Felszereltseg;
                row.hangredszer = Convert.ToInt32(sz.Hangredszer);
                row.jarmuId = jarmuRow.Id;

                //a feltöltött sor hozzáadása a DataSet SzemelyGepjarmu táblájához
                dataset.SzemelyGepjarmu.Rows.Add(row);

            }
            else if (jarmu is KisteherGepjarmu) //ha a jarmu KisteherGepjarmu
            {
                KisteherGepjarmu k = jarmu as KisteherGepjarmu;
                Database1DataSet.KisteherGepjarmuRow row = dataset.KisteherGepjarmu.NewKisteherGepjarmuRow();
                row.kialakitas = (int)k.Kialakitas;
                row.onsuly = Convert.ToInt32(k.Onsuly);
                row.jarmuId = jarmuRow.Id;
                dataset.KisteherGepjarmu.Rows.Add(row);

            }

            //a DataSet adatainak beszúrása a valódi adatbázisba
            tam.UpdateAll(dataset);
        }

        public List<SzemelyGepjarmu> SzemelyGepjarmuListaz()
        {
            // Üres DataSet létrehozása
            Database1DataSet dataset = new Database1DataSet();

            // Jarmu tábla betöltése az adatbázisból a DataSet Jarmu táblájába
            jta.Fill(dataset.Jarmu);

            // SzemelyGepjarmu tábla betöltése az adatbázisból a DataSet SzemelyGepjarmu táblájába
            szta.Fill(dataset.SzemelyGepjarmu);

            // Üres lista létrehozása, ebbe pakoljuk az eredményhez szükséges SzemelyGepjarmu-ket
            List<SzemelyGepjarmu> jarmuvek = new List<SzemelyGepjarmu>();

            // Végigmegyünk a DataSet sorain és mindegyikből egy SzemelyGepjarmu-t csinálunk
            foreach (Database1DataSet.SzemelyGepjarmuRow row in dataset.SzemelyGepjarmu.Rows)
            {
                Database1DataSet.JarmuRow jarmuRow = row.JarmuRow;

                // Létrehozunk egy új SzemelyGepjarmu-t, hogy beletegyük a sorból az adatokat
                SzemelyGepjarmu sz = new SzemelyGepjarmu();

                JarmuInicializalas(sz, jarmuRow);

                sz.Azon = row.Id;
                sz.Hangredszer = Convert.ToBoolean(row.hangredszer);

                // int átalakítása enummá
                sz.Felszereltseg = (Felszereltseg)row.felszereltseg;

                // Hozzáadjuk a kész feltöltött SzemelyGepjarmu-t az eredménylistához.
                jarmuvek.Add(sz);
            }

            return jarmuvek;
        }

        public List<KisteherGepjarmu> KisteherGepjarmuListaz()
        {
            Database1DataSet dataset = new Database1DataSet();
            jta.Fill(dataset.Jarmu);
            kta.Fill(dataset.KisteherGepjarmu);
            List<KisteherGepjarmu> jarmuvek = new List<KisteherGepjarmu>();

            foreach (Database1DataSet.KisteherGepjarmuRow row in dataset.KisteherGepjarmu.Rows)
            {
                Database1DataSet.JarmuRow jarmuRow = row.JarmuRow;
                KisteherGepjarmu k = new KisteherGepjarmu();

                JarmuInicializalas(k, jarmuRow);

                k.Azon = row.Id;

                // int átalakítása enummá
                k.Kialakitas = (Kialakitas)row.kialakitas;

                k.Onsuly = row.onsuly;

                jarmuvek.Add(k);
            }

            return jarmuvek;
        }

        private void JarmuInicializalas(Jarmu jarmu, Database1DataSet.JarmuRow jarmuRow)
        {
            jarmu.JarmuAzon = jarmuRow.Id;
            jarmu.Tipus = jarmuRow.tipus;
            jarmu.Marka = jarmuRow.marka;
            jarmu.FutottKm = jarmuRow.futottKm;
            jarmu.Hengerurt = jarmuRow.hengerurt;
            jarmu.HasznosTeher = jarmuRow.hasznosTeher;
            jarmu.Rendszam = jarmuRow.rendszam;
            jarmu.SzallithatoSzemelyek = jarmuRow.szallithatoSzemelyek;
            jarmu.Alvazszam = jarmuRow.alvazszam;
        }

        public void Torol(SzemelyGepjarmu sz)
        {
            szta.Delete(sz.Azon, sz.JarmuAzon, (int)sz.Felszereltseg, Convert.ToInt32(sz.Hangredszer));
        }

        public void Torol(KisteherGepjarmu k)
        {
            kta.Delete(k.Azon, k.JarmuAzon, (int)k.Kialakitas, k.Onsuly);
        }

        public void Modosit(SzemelyGepjarmu sz)
        {
            Jarmu jarmu = (Jarmu)sz;
            Modosit(jarmu);
            szta.UpdateQuery(jarmu.JarmuAzon, (int)sz.Felszereltseg, Convert.ToInt32(sz.Hangredszer), sz.Azon);
        }

        public void Modosit(KisteherGepjarmu k)
        {
            Jarmu jarmu = (Jarmu)k;
            Modosit(jarmu);
            kta.UpdateQuery(jarmu.JarmuAzon, (int)k.Kialakitas, k.Onsuly, k.Azon);
        }

        private void Modosit(Jarmu jarmu)
        {
            jta.UpdateQuery(jarmu.Marka,
                jarmu.Tipus,
                jarmu.FutottKm,
                jarmu.Hengerurt,
                jarmu.Rendszam,
                jarmu.Alvazszam,
                jarmu.SzallithatoSzemelyek,
                jarmu.HasznosTeher,
                jarmu.JarmuAzon);
        }
    }
}
