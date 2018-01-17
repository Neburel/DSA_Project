using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    abstract public class notFighting : Talent<DSA_ATTRIBUTE>
    {
        public notFighting(String name, List<DSA_ATTRIBUTE> probe, String be, List<TalentDeviate>diverates, List<TalentRequirement>requirements) : base(name, probe, be, diverates)
        {
            requirement = requirements;
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
            if(learned == false)
            {
                return "-";
            }

            int ret = 0;
            for (int i = 0; i < getProbeCount(); i++)
            {
                ret = ret + Charakter.getAttribute_Max(Probe[i]) + getTawWithBonus();
            }
            return ret.ToString();
        }
        public String getRequirementString()
        {
            if (requirement == null) return "";

            if (requirement.Count == 0)
            {
                return "-";
            }

            String ret = "";
            for(int i=0; i<requirement.Count; i++)
            {
                if (i != 0) { ret = ret + ", "; }
                String TalentName = requirement[i].getTalentName();
                int value = requirement[i].getValue();
                int needAt = requirement[i].getNeededAtValue();

                if (needAt != 0) { ret = ret + needAt.ToString() + "+" + " "; }
                ret = ret + TalentName;
                if (value != 0) { ret = ret + " " + value.ToString(); }
            }
            return ret;
        }
    }
}
