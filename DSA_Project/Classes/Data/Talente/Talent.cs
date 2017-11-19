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
        private String Name;
        private String Ableiten;
        private String Be;
        protected List<T> Probe;

        private int Billiger;
        private int TaW;                

        public Talent(String name, String ableiten, List<T> probe, String be)
        {
            this.Name = name;
            this.Ableiten = ableiten;
            this.Probe = probe;
            this.Be = be;

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
                return Ableiten;
            }
        public int getProbeCount()
            {
                return Probe.Count;
            }
        public String getBe()
            {
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
