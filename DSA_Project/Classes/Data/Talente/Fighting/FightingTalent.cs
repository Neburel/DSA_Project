using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DSA_Project
{
    class FightingTalent : Talent<DSA_ADVANCEDVALUES>
    {
        bool parade = true;
        private int AT;
        private int PA;

        public FightingTalent(String name, String be, List<TalentDeviate>diverates, DSA_ADVANCEDVALUES at, bool parade) :base (name, new List<DSA_ADVANCEDVALUES> { at, DSA_ADVANCEDVALUES.PARADE_BASIS }, be, diverates)
        {
            AT = 0;
            PA = 0;

            this.parade = parade;
        }

        private int getATPA(int ownValue, int otherValue, int newValue)
        {
            int freeTaW = getTawWithBonus() - otherValue;
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
            if (parade == false) return;
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
        public String getPA()
        {
            if (parade == false) return "---";
            return PA.ToString();
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