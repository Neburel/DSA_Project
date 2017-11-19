using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    class GeneralTalent : Talent<DSA_ATTRIBUTE>
    {
        String Anforderungen; 

        public GeneralTalent(String name, List<DSA_ATTRIBUTE> probe, String be, String anforderungen, String ableiten) : base(name, ableiten, probe, be)
        {
            this.Anforderungen = anforderungen;
        }
        public GeneralTalent(String name, List<DSA_ATTRIBUTE> probe, String anforderungen, String ableiten) : base(name, ableiten, probe, "")
        {
            this.Anforderungen = anforderungen;
        }

        public String getAnforderungen()
        {
            return Anforderungen;
        }

        public override String getProbeStringTwo()
        {
            String ret = "";
            for(int i=0; i<Probe.Count; i++)
            {
                if (i != 0) ret = ret + "/";
                ret = ret + Probe[i];
            }
            return ret;
        }

        public override string getProbeStringOne()
        {
            int ret = 0;
            for (int i = 0; i < getProbeCount(); i++)
            {
                ret = ret + Charakter.getAttribute_Max(Probe[i]) + getTaW();
            }
            return ret.ToString();
        }
    }
}
