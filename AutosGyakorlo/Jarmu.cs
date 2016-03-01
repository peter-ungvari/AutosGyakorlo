using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosGyakorlo
{
   public abstract class Jarmu
    {
        string marka;

        public string Marka
        {
            get { return marka; }
            set { marka = value; }
        }

        string tipus;

        public string Tipus
        {
            get { return tipus; }
            set { tipus = value; }
        }

        int futottKm = 1;

        public int FutottKm
        {
            get { return futottKm; }
            set {
                if (value<1)
                {
                    throw new Exception("Nem lehet egynél kissebb");
                }
                futottKm = value; 
            }
        }

        int hengerurt;

        public int Hengerurt
        {
            get { return hengerurt; }
            set {
                if (value<800 || value>10000)
                {
                    throw new Exception("Minimum 800 maximum 10000");
                }
                hengerurt = value;
            }
        }

        string rendszam;

        public string Rendszam
        {
            get { return rendszam; }
            set { rendszam = value; }
        }

        string alvazszam;

        public string Alvazszam
        {
            get { return alvazszam; }
            set { alvazszam = value.ToUpper(); }
        }

        int szallithatoSzemelyek;

        public int SzallithatoSzemelyek
        {
            get { return szallithatoSzemelyek; }
            set {
                if (value<2)
                {
                     throw new Exception("Minimum 2");
                }
                szallithatoSzemelyek = value; 
            }
        }

        int hasznosTeher;

        public int HasznosTeher
        {
            get { return hasznosTeher; }
            set {
                if (value < 160)
                {
                    throw new Exception("Minimum 160");
                }
                hasznosTeher = value;
            }
        }

        public abstract long Ar();
    }

}
