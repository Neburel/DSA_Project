using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{   
    class TalentRequirement
    {
        InterfaceTalent talent = null;
        String TalentName;
        int Value;
        int NeededAtValue;

        public TalentRequirement(String TalentName, int value)
        {
            this.TalentName = TalentName;
            this.Value = value;
            this.NeededAtValue = 0;
        }
        public TalentRequirement(String TalentName, int value, int neededAtValue)
        {
            this.TalentName = TalentName;
            this.Value = value;
            this.NeededAtValue = neededAtValue;
        }
        public String getTalentName()
        {
            return this.TalentName;
        }
        public int getValue()
        {
            return Value;
        }
        public int getNeededAtValue()
        {
            return NeededAtValue;
        }
    }
}
