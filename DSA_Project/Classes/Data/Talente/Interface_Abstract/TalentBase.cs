using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public abstract class TalentBase : InterfaceTalent
    {
        internal int TaWDeviateBonus;

        public abstract void setCharacter(Charakter charakter);
        public abstract void setTaw(string taw);

        public abstract List<TalentDeviate> getDeviateList();
        public abstract List<TalentRequirement> getRequirementList();

        public abstract int getProbeCount();

        public abstract String getBe();
        public abstract String getName();
        public abstract String getTaW();
        public abstract String getTAWBonus();
        public abstract String getDeviateString();
        public abstract String getProbeStringOne();
        public abstract String getProbeStringTwo();
        public abstract String getRequirementString();

        internal void addDeviateBonus()
        {
            TaWDeviateBonus = TaWDeviateBonus + 1;
        }
        internal void removeDeviateBonus()
        {
            TaWDeviateBonus = TaWDeviateBonus - 1;
        }
    }
}
