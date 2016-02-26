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

        Database1DataSetTableAdapters.JarmuTableAdapter jta = new Database1DataSetTableAdapters.JarmuTableAdapter();
        Database1DataSetTableAdapters.SzemelyGepjarmuTableAdapter szta = new Database1DataSetTableAdapters.SzemelyGepjarmuTableAdapter();
        Database1DataSetTableAdapters.KisteherGepjarmuTableAdapter kta = new Database1DataSetTableAdapters.KisteherGepjarmuTableAdapter();
        Database1DataSetTableAdapters.TableAdapterManager tam = new Database1DataSetTableAdapters.TableAdapterManager();

        public JarmuAdatbazisKezelo()
        {
            tam.UpdateOrder = Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            tam.SzemelyGepjarmuTableAdapter = szta;
            tam.JarmuTableAdapter = jta;
            tam.KisteherGepjarmuTableAdapter = kta;
        }

        public void Beszur(Jarmu jarmu)
        {
            Database1DataSet dataset = new Database1DataSet();

            Database1DataSet.JarmuRow jarmuRow = dataset.Jarmu.NewJarmuRow();
            jarmuRow.alvazszam = jarmu.Alvazszam;
            jarmuRow.futottKm = jarmu.FutottKm;
            jarmuRow.hasznosTeher = jarmu.HasznosTeher;
            jarmuRow.marka = jarmu.Marka;
            jarmuRow.hengerurt = jarmu.Hengerurt;
            jarmuRow.rendszam = jarmu.Rendszam;
            jarmuRow.szallithatoSzemelyek = jarmu.SzallithatoSzemelyek;
            jarmuRow.tipus = jarmu.Tipus;
            dataset.Jarmu.Rows.Add(jarmuRow);

            if (jarmu is SzemelyGepjarmu)
            {
                SzemelyGepjarmu sz = jarmu as SzemelyGepjarmu;
                Database1DataSet.SzemelyGepjarmuRow row = dataset.SzemelyGepjarmu.NewSzemelyGepjarmuRow();
                row.felszereltseg = sz.Felszereltseg.ToString();
                row.hangredszer = Convert.ToInt32(sz.Hangredszer);
                row.jarmuId = jarmuRow.Id;
                dataset.SzemelyGepjarmu.Rows.Add(row);

            }
            else if (jarmu is KisteherGepjarmu)
            {
                KisteherGepjarmu k = jarmu as KisteherGepjarmu;
                Database1DataSet.KisteherGepjarmuRow row = dataset.KisteherGepjarmu.NewKisteherGepjarmuRow();
                row.kialakitas = k.Kialakitas.ToString();
                row.onsuly = Convert.ToInt32(k.Onsuly);
                row.jarmuId = jarmuRow.Id;
                dataset.KisteherGepjarmu.Rows.Add(row);

            }

            tam.UpdateAll(dataset);
        }

        public List<SzemelyGepjarmu> SzemelyGepjarmuListaz()
        {
            Database1DataSet dataset = new Database1DataSet();
            jta.Fill(dataset.Jarmu);
            szta.Fill(dataset.SzemelyGepjarmu);
            List<SzemelyGepjarmu> jarmuvek = new List<SzemelyGepjarmu>();

            foreach (Database1DataSet.SzemelyGepjarmuRow row in dataset.SzemelyGepjarmu.Rows)
            {
                Database1DataSet.JarmuRow jarmuRow = row.JarmuRow;
                SzemelyGepjarmu sz = new SzemelyGepjarmu();

                JarmuInicializalas(sz, jarmuRow);
                sz.Hangredszer = Convert.ToBoolean(row.hangredszer);

                Felszereltseg f;
                Felszereltseg.TryParse(row.felszereltseg, out f);
                sz.Felszereltseg = f;

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

                Kialakitas kia;
                Kialakitas.TryParse(row.kialakitas, out kia);
                k.Kialakitas = kia;

                k.Onsuly = row.onsuly;

                jarmuvek.Add(k);
            }

            return jarmuvek;
        }

        private void JarmuInicializalas(Jarmu jarmu, Database1DataSet.JarmuRow jarmuRow)
        {
            jarmu.Tipus = jarmuRow.tipus;
            jarmu.Marka = jarmuRow.marka;
            jarmu.FutottKm = jarmuRow.futottKm;
            jarmu.Hengerurt = jarmuRow.hengerurt;
            jarmu.HasznosTeher = jarmuRow.hasznosTeher;
            jarmu.Rendszam = jarmuRow.rendszam;
            jarmu.SzallithatoSzemelyek = jarmuRow.szallithatoSzemelyek;
            jarmu.Alvazszam = jarmuRow.alvazszam;
        }

    }
}
