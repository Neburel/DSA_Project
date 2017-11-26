using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    abstract class Talent<T> : InterfaceTalent
    {
        protected Charakter Charakter;
        List<TalentDiverate> Diverates;

        private String Name;
        
        private String Be;
        protected List<T> Probe;
        
        private int TaW;                

        public Talent(String name, List<T> probe, String be, List<TalentDiverate> diverates)
        {
            this.Name = name;
            this.Probe = probe;
            this.Be = be;

            Diverates = diverates;
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
        public String getAbleitenString()
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
                TalentDiverate diverate = Diverates[i];
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
        public int getTaW()
            {
                return TaW;
            }

        public abstract String getProbeStringOne();
        public abstract String getProbeStringTwo();
    }
}
