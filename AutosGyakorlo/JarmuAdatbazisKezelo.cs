using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutosGyakorlo
{
    class JarmuAdatbazisKezelo
    {

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

            dataset.AcceptChanges();



            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.Database1ConnectionString))
            {
                Database1DataSetTableAdapters.JarmuTableAdapter jta = new Database1DataSetTableAdapters.JarmuTableAdapter();
                jta.Connection = conn;
                Database1DataSetTableAdapters.SzemelyGepjarmuTableAdapter szta = new Database1DataSetTableAdapters.SzemelyGepjarmuTableAdapter();
                szta.Connection = conn;

                Database1DataSetTableAdapters.TableAdapterManager tam = new Database1DataSetTableAdapters.TableAdapterManager();
                tam.Connection = conn;

                tam.UpdateOrder = Database1DataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;

                tam.SzemelyGepjarmuTableAdapter = szta;
                tam.JarmuTableAdapter = jta;

                tam.UpdateAll(dataset);
            }
            
        }
        
    }
}
