using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosGyakorlo
{
    public enum Felszereltseg
    { 
        Alap,
        Kozepes,
        Magas
    }

    public class SzemelyGepjarmu: Jarmu
    {
        
        Felszereltseg felszereltseg;

        public Felszereltseg Felszereltseg
        {
            get { return felszereltseg; }
            set { felszereltseg = value; }
        }

        bool hangredszer;

        public bool Hangrendszer
        {
            get { return hangredszer; }
            set { hangredszer = value; }
        }

        //A Jarmu Ar funkcióját felülírja (override)
        override public long Ar()
        {
            long alapAr = (long)(1.0 / FutottKm * 500000);

            long ar;

            switch (felszereltseg)
            {
                case Felszereltseg.Alap:
                    ar = alapAr + 50000;
                    break;
                case Felszereltseg.Kozepes:
                    ar = alapAr * 2;
                    break;
                case Felszereltseg.Magas:
                    ar = alapAr * 3 + 30000;
                    break;
                default:
                    throw new Exception("Érvénytelen felszereltség");
            }

            return ar;
        }

        public override string ToString()
        {
            return String.Format("Szemelygepjarmu: [marka: {0}, tipus: {1}, futottKm: {2}, hengerurt: {3}, " +
                    "rendszam: {4}, alvazszam: {5}, szallithato: {6}, hasznos teher: {7}, felszereltseg: {8}, hangrendszer: {9}]", 
                    Marka, Tipus, FutottKm, Hengerurt, Rendszam, Alvazszam, SzallithatoSzemelyek, HasznosTeher, Felszereltseg, Hangrendszer);
        }
    }
}
