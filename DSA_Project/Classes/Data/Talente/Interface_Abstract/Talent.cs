using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public abstract class Talent<T> : TalentBase
    {
        internal bool learned = false;
        internal Charakter Charakter;
        internal List<T> Probe;
        private List<TalentDeviate> Deviate;
        private List<TalentDeviate> notUsedDeviate;
        private List<TalentDeviate> usedDeviate;
        private List<TalentRequirement> Requirement;
        private Dictionary<String, InterfaceTalent> talentDictonary;

        private int TaW;
        private String Name;
        private String Be;
        
        public Talent(String name, List<T> probe, String be, List<TalentDeviate> diverates, List<TalentRequirement> requirements)
        {
            this.Charakter          = null;
            this.Be                 = be;
            this.TaW                = 0;
            this.Name               = name.Trim();
            this.Probe              = probe;
            this.Deviate            = diverates;
            this.Requirement        = requirements;
            this.TaWDeviateBonus    = 0;
            this.notUsedDeviate     = new List<TalentDeviate>(0);
            this.usedDeviate        = new List<TalentDeviate>(0);
            this.talentDictonary    = new Dictionary<String, InterfaceTalent>(0);

            if(probe == null || diverates== null || requirements == null)
            {
                throw new ArgumentNullException("TalentCreationError: Tryed to Implement a Talent with a null List");
            }

            foreach(TalentDeviate dev in Deviate)
            {
                notUsedDeviate.Add(dev);
            }
        }
        
        public override void setCharacter(Charakter charakter)
        {
            this.Charakter = charakter;
        }
        public override void setTaw(String taw)
        {
            if (String.Compare(taw, "-") == 0)
            {
                learned = false;
            }
            if (Charakter == null) { throw new NullReferenceException("Character null"); }

            Boolean numeric = Int32.TryParse(taw, out int value);
            if (numeric)
            {
                setTaw(value);
            }
        }

        public override int getProbeCount()
        {
            return Probe.Count;
        }

        public override List<TalentDeviate> getDeviateList()
        {
            return Deviate;
        }
        public override List<TalentRequirement> getRequirementList()
        {
            return Requirement;
        }

        public override String ToString()
        { return this.Name; }
        public override String getBe()
        {
            if (Be == "") { return "-"; }
            return Be;
        }
        public override String getTaW()
        {
            if (learned == false) { return "-"; }

            return TaW.ToString();
        }
        public override String getName()
        {
            return Name;
        }
        public override String getTAWBonus()
        {
            if (Charakter == null)
            {
                return (0).ToString();
            }

            return (Charakter.getTaWBons(this) + TaWDeviateBonus).ToString();
        }
        public override String getDeviateString()
        {
            if (Deviate.Count == 0)
            {
                return "-";
            }

            String ret = "";
            for (int i = 0; i < Deviate.Count; i++)
            {
                if (i > 0)
                {
                    ret = ret + ", ";
                }
                TalentDeviate diverate = Deviate[i];
                if (diverate.getRequiredTaW() == 10)
                {
                    ret = ret + diverate.getName();
                }
                else
                {
                    ret = ret + diverate.getName() + "(" + diverate.getRequiredTaW().ToString() + ")";
                }
            }
            return ret;
        }
        public override String getRequirementString()
        {
            if (Requirement.Count == 0)
            {
                return "-";
            }

            String ret = "";
            for (int i = 0; i < Requirement.Count; i++)
            {
                if (i != 0) { ret = ret + ", "; }
                String TalentName = Requirement[i].getTalentName();
                int value = Requirement[i].getValue();
                int needAt = Requirement[i].getNeededAtValue();

                if (needAt != 0) { ret = ret + needAt.ToString() + "+" + " "; }
                ret = ret + TalentName;
                if (value != 0) { ret = ret + " " + value.ToString(); }
            }
            return ret;
        }

        private void setTaw(int taw)
        {
            learned = true;
            TaW = taw;

            int localTaW = getTawWithBonus();
            List<TalentDeviate> used        = new List<TalentDeviate>(0);
            List<TalentDeviate> notused     = new List<TalentDeviate>(0);

            DeviateCalculate();
        }
        private void DeviateCalculate()
        {
            int localTaW = getTawWithBonus();
            List<TalentDeviate> used = new List<TalentDeviate>(0);
            List<TalentDeviate> notused = new List<TalentDeviate>(0);

            foreach (TalentDeviate dev in notUsedDeviate)
            {
                int requiredTaW = dev.getRequiredTaW();

                if (requiredTaW <= localTaW)
                {
                    TalentBase talent = (TalentBase)talentSearch(dev.getName());
                    if (talent != null)
                    {
                        talent.addDeviateBonus();
                        used.Add(dev);
                    }
                }
            }
            foreach (TalentDeviate dev in usedDeviate)
            {
                if (dev.getRequiredTaW() > localTaW)
                {
                    TalentBase talent = (TalentBase)talentSearch(dev.getName());
                    if (talent != null)
                    {
                        talent.removeDeviateBonus();
                        notused.Add(dev);
                    }
                }
            }
            for (int i = 0; i < used.Count; i++)
            {
                notUsedDeviate.Remove(used[i]);
                usedDeviate.Add(used[i]);
            }
            for (int i = 0; i < notused.Count; i++)
            {
                usedDeviate.Remove(notused[i]);
                notUsedDeviate.Add(notused[i]);
            }
        }
                
        internal int getTawWithBonus()
        {
            return TaW + Charakter.getTaWBons(this) + TaWDeviateBonus; 
        }

        private InterfaceTalent talentSearch(String name)
        {
            InterfaceTalent talent = null;
            name = name.Trim();

            if (!talentDictonary.TryGetValue(name, out talent))
            {
                talent = this.Charakter.getTalent(name); ;
                if (talent != null)
                {
                    talentDictonary.Add(name, talent);
                } else
                {
                    Log.writeLogLine("Deviate Talent Name Exestiert im Charakter nicht. Talent " + this.Name + " muss Korregiert werden. TalentType: " + this.GetType() + " Deviate Name: " + name + ". Die Abeitung wird Ignoriert");
                }
            }

            return talent;
        }
    }
}
