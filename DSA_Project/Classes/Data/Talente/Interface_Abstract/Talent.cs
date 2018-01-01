using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public abstract class Talent<T> : InterfaceTalent
    {
        internal bool learned = false;
        internal Charakter Charakter;
        internal List<T> Probe;
        internal List<TalentDeviate> Diverates;
        internal List<TalentRequirement> requirement;

        private int TaW;
        private String Name;
        private String Be;
        
        public Talent(String name, List<T> probe, String be, List<TalentDeviate> diverates)
        {
            this.Name = name;
            this.Probe = probe;
            this.Be = be;

            Diverates = diverates;
        }

        public abstract String getProbeStringOne();
        public abstract String getProbeStringTwo();
        
        public void setCharacter(Charakter charakter)
        {
            this.Charakter = charakter;
        }
        private void setTaw(int taw)
        {
            learned = true;
            TaW = taw;
        }
        public void setTaw(String taw)
        {
            if(String.Compare(taw, "-") == 0)
            {
                learned = false;
            }

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
        public String getDeviateString()
        {
            if (Diverates.Count == 0)
            {
                return "-";
            }

            String ret = "";
            for(int i=0; i<Diverates.Count;i++)
            {
                if (i > 0)
                {
                    ret = ret + ", ";
                }
                TalentDeviate diverate = Diverates[i];
                if (diverate.getRequiredTaW() == 0)
                {
                    ret = ret + diverate.getName();
                } else
                {
                    ret = ret + diverate.getName() + "(" + diverate.getRequiredTaW().ToString() + ")";
                }
            }
            return ret;
        }
        public int getProbeCount()
            {
                return Probe.Count;
            }
        public String getBe()
            {
                if (Be == "") { return "-"; }
                return Be;
            }
        public String getTaW()
        {
            if (learned == false) { return "-"; }

            return TaW.ToString();
        }
        internal int getTawWithBonus()
        {
            return TaW + Charakter.getTaWBons(this);
        }

        public override string ToString() { return this.Name; }

        public string getTAWBonus()
        {
            return Charakter.getTaWBons(this).ToString();
        }
    }
}
