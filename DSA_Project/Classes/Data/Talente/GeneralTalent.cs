using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    class GeneralTalent : Talent<DSA_ATTRIBUTE>
    {
        List<TalentRequirement> requirement;

        public GeneralTalent(String name, List<DSA_ATTRIBUTE> probe, String be, List<TalentDiverate>diverates, List<TalentRequirement>requirements) : base(name, probe, be, diverates)
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
            int ret = 0;
            for (int i = 0; i < getProbeCount(); i++)
            {
                ret = ret + Charakter.getAttribute_Max(Probe[i]) + getTaW();
            }
            return ret.ToString();
        }
        public String getRequirementString()
        {
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
