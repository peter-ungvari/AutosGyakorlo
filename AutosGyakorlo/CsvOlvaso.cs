using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace AutosGyakorlo
{
    class CsvOlvaso
    {

        public List<Jarmu> Beolvas(String fajl)
        {
            string[] sorok = File.ReadAllLines(fajl, Encoding.GetEncoding("windows-1250"));

            List<Jarmu> jarmuvek = new List<Jarmu>();
            
            foreach (string sor in sorok)
            {
                string[] oszlopok = sor.Split(';');
                
                string fajta = oszlopok[0];

                if ("Személygépjármű".Equals(fajta))
                {
                    SzemelyGepjarmu jarmu = SzemelyGepjarmuLetrehoz(oszlopok);
                    jarmuvek.Add(jarmu);
                }
                else if ("Kishaszon gépjármű".Equals(fajta))
                {
                    KisteherGepjarmu jarmu = KisteherGepjarmuLetrehoz(oszlopok);
                    jarmuvek.Add(jarmu);
                }
            }

            return jarmuvek;
        }

        private KisteherGepjarmu KisteherGepjarmuLetrehoz(string[] oszlopok)
        {
            KisteherGepjarmu jarmu = new KisteherGepjarmu();
            JarmuAdatokatFeltolt(jarmu, oszlopok);

            jarmu.Kialakitas = (Kialakitas) Convert.ToInt32(oszlopok[9]);
            jarmu.Onsuly = Convert.ToInt32(oszlopok[10]);

            return jarmu;
        }

        private void JarmuAdatokatFeltolt(Jarmu jarmu, string[] oszlopok)
        {
            jarmu.Marka = oszlopok[1];
            jarmu.Tipus = oszlopok[2];
            jarmu.FutottKm = Convert.ToInt32(oszlopok[3]);
            jarmu.Hengerurt = Convert.ToInt32(oszlopok[4]);
            jarmu.Rendszam = oszlopok[5];
            jarmu.Alvazszam = oszlopok[6];
            jarmu.SzallithatoSzemelyek = Convert.ToInt32(oszlopok[7]);
            jarmu.HasznosTeher = Convert.ToInt32(oszlopok[8]);
        }

        private SzemelyGepjarmu SzemelyGepjarmuLetrehoz(string[] oszlopok)
        {
            SzemelyGepjarmu jarmu = new SzemelyGepjarmu();
            JarmuAdatokatFeltolt(jarmu, oszlopok);

            jarmu.Felszereltseg = (Felszereltseg) Convert.ToInt32(oszlopok[9]);
            jarmu.Hangredszer = Convert.ToBoolean(oszlopok[10]);

            return jarmu;
        }

    }
}
