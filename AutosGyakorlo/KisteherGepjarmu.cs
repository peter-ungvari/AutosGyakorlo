using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosGyakorlo
{
    public enum Kialakitas
    {
        Ponyvas,
        Szabadpadlos,
        Vontatos,
        ZartTeru
    }
    
    public class KisteherGepjarmu : Jarmu
    {
        Kialakitas kialakitas;

        public Kialakitas Kialakitas
        {
            get { return kialakitas; }
            set { kialakitas = value; }
        }
    
        int onsuly;

        public int Onsuly
        {
            get { return onsuly; }
            set {
                if (value < 1000)
                {
                    throw new Exception("Minimum 1000");
                }
                onsuly = value;
            }
        }

        //A Jarmu Ar funkcióját felülírja (override)
        override public long Ar()
        {
            return (long)(1.0 / FutottKm * 10000000);
        }

        public override string ToString()
        {
            return String.Format("Kisteher gepjarmu: [marka: {0}, tipus: {1}, futottKm: {2}, hengerurt: {3}, " +
                    "rendszam: {4}, alvazszam: {5}, szallithato: {6}, hasznos teher: {7}, kialakitas: {8}, onsuly: {9}]",
                    Marka, Tipus, FutottKm, Hengerurt, Rendszam, Alvazszam, SzallithatoSzemelyek, HasznosTeher, kialakitas, Onsuly);
        }
    }
}
