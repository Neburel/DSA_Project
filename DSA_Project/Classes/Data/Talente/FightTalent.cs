using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DSA_Project
{
    class FightTalent : Talent<DSA_ADVANCEDVALUES>
    {
        private int AT;
        private int PA;

        public FightTalent(String name, String be, String ableiten, DSA_ADVANCEDVALUES at, DSA_ADVANCEDVALUES pa) : base(name, ableiten, new List<DSA_ADVANCEDVALUES> { at, pa }, be)
        {
            AT = 0;
            PA = 0;
        }

        private int getATPA(int ownValue, int otherValue, int newValue)
        {
            int freeTaW = getTaW() - otherValue;
            if (newValue > freeTaW)
            {
                ownValue = freeTaW;
            } else
            {
                ownValue = newValue;
            }
            return ownValue;
        }
        public void setAT(int at)
        {
            AT = getATPA(AT, PA, at);
        }
        public void setPA(int pa)
        {
            PA = getATPA(PA, AT, pa);
        }

        public override String getProbeStringOne()
        {
            return getProbeValueAT().ToString(); ;
        }
        public int getAT()
        {
            return AT;
        }
        public int getPA()
        {
            return PA;
        }
        public int getProbeValueAT()
        {
            return Charakter.getAdvancedValueMAX(Probe[0]) + AT;
        }
        public int getProbeValuePA()
        {
            return Charakter.getAdvancedValueMAX(Probe[1]) + PA;
        }

        public override string getProbeStringTwo()
        {
            return getProbeValuePA().ToString();
        }
    }
}