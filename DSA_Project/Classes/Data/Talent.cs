using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    class Talent
    {
        private Charakter Charakter;
        private String Name;
        private String Ableiten;
        private String Anforderungen;
        private List<DSA_ATTRIBUTE> Probe;

        private int Be;
        private int TaW;


        public Talent(String name, List<DSA_ATTRIBUTE> probe, String anforderungen, String ableiten)
        {
            this.Name = name;
            this.Probe = probe;
            this.Ableiten = ableiten;
            this.Anforderungen = anforderungen;

            this.TaW = 0;
            this.Be = 0;
        }
        public Talent(String name, List<DSA_ATTRIBUTE> probe, int be, String anforderungen, String ableiten)
        {
            this.Name = name;
            this.Probe = probe;
            this.Be = be;
            this.Ableiten = ableiten;
            this.Anforderungen = anforderungen;

            this.TaW = 0;
        }
        

        public void setCharacter(Charakter charakter)
        {
            this.Charakter = charakter;
        }
        public void setTaw(int taw)
        {
            TaW = taw;
        }
        public void setTaw(String taw)
        {
            Boolean numeric = Int32.TryParse(taw, out int value);
            if (numeric)
            {
                setTaw(value);
            }
        }

        public String getName()
            {
                return Name;
            }
        public String getAnforderungen()
            {
                return Anforderungen;
            }
        public String getAbleitenString()
            {
                return Ableiten;
            }
        public String getProbeString()
            {
                String ret = "";
                for (int i = 0; i < Probe.Count(); i++)
                {
                    if (i > 0) { ret = ret + "/"; }
                    ret = ret + Probe[i].ToString();
                }
                return ret;
            }
        public int getProbe()
            {
                return Probe.Count;
            }
        public int getProbeValue()
            {
                int x = 0;
                for (int i = 0; i < getProbe(); i++)
                {
                    x = x + Charakter.getAttribute_Max(Probe[i]) + TaW;
                }
                return x;
            }
        public int getBe()
            {
                return Be;
            }
        public int getTaW()
            {
                return TaW;
            }


        }
}
