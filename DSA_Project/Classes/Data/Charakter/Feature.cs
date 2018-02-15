using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class Feature
    {
        private String Name;
        private String Description;
        private String Value;
        private String GP;

        private Dictionary<DSA_ATTRIBUTE, int> attributeBonus;
        private Dictionary<DSA_ENERGIEN, int> energieBonus;
        private Dictionary<DSA_ADVANCEDVALUES, int> advancedBonus;
        private Dictionary<InterfaceTalent, int> talentBoni;

        public Feature()
        {
            setName("");
            setDescription("");
            setValue("");
            setGP("");

            setUP();
        }
        public Feature(String Name, String Description, String Value, String GP)
        {
            setName(Name);
            setDescription(Description);
            setValue(Value);
            setGP(GP);

            setUP();
        }
        
        private void setUP()
        {
            attributeBonus  = new Dictionary<DSA_ATTRIBUTE, int>();
            energieBonus    = new Dictionary<DSA_ENERGIEN, int>();
            advancedBonus   = new Dictionary<DSA_ADVANCEDVALUES, int>();
            talentBoni      = new Dictionary<InterfaceTalent, int>();
        }
        public void setGP(String GP)
        {
            if (int.TryParse(GP, out var wert_int))
            {
                this.GP = wert_int.ToString();
            }
            else
            {
                this.GP = "";
            }
        }
        public void setName(String Name)
        {
            this.Name = Name;
        }
        public void setValue(String Value)
        {
            int x = 0;
            if (Value.ToUpper().CompareTo("X") == 0)
            {
                this.Value = "X"; 
            } else  
            {
                if(Int32.TryParse(Value, out x))
                {
                    this.Value = x.ToString();
                } else
                {
                    this.Value = "";
                }
            }
        }
        public void setDescription(String Description)
        {
            this.Description = Description;
        }

        public void setAttributeBonus(DSA_ATTRIBUTE attribute, int value)
        {
            attributeBonus.Remove(attribute);
            attributeBonus.Add(attribute, value);
        }
        public void setEnergieBonus(DSA_ENERGIEN energie, int value)
        {
            energieBonus.Remove(energie);
            energieBonus.Add(energie, value);
        }
        public void setAdvancedValues(DSA_ADVANCEDVALUES values, int value)
        {
            advancedBonus.Remove(values);
            advancedBonus.Add(values, value);
        }
        public void setTalentBonusTaW(InterfaceTalent talent, int BonusTaw)
        {
            talentBoni.Remove(talent);
            talentBoni.Add(talent, BonusTaw);
        }
        public void removeTalentBonusTaW(InterfaceTalent talent)
        {
            talentBoni.Remove(talent);
        }

        private String getEnumString<T>(Dictionary<T, int> dic) where T : struct, IConvertible
        {
            String[] Acronyms = Enum.GetNames(typeof(T));
            String ret = "";
            
            for (int i = 0; i < Acronyms.Length; i++)
            {
                T t = (T)(object)i;
                dic.TryGetValue(t, out int x);
                if (x != 0)
                {
                    if (0 != String.Compare(ret, ""))
                    {
                        ret = ret + ", " + x + Acronyms[i];
                    }
                    else
                    {
                        ret = x + Acronyms[i];
                    }
                }
            }
            return ret;
        }
        private String getTalentString()
        {
            String ret = "";
            foreach (InterfaceTalent talent in talentBoni.Keys)
            {
                int x = 0;
                talentBoni.TryGetValue(talent, out x);
                ret = ret + talent.getName() + "(" + x + ")";
            }
            return ret;
        }
        public String getGP()
        {
            return GP;
        }
        public String getName()
        {
            return Name;
        }
        public String getValue()
        {
            return Value;
        }
        public String getDescription()
        {
            Char[] trimSymbol = new Char[] { ' ', ',' };

            String totalDescription = String.Copy(this.Description);
            totalDescription = totalDescription + ", " + getEnumString(attributeBonus);
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription + ", " + getEnumString(energieBonus);
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription + ", " + getEnumString(advancedBonus);
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription + ", " + getTalentString();
            totalDescription = totalDescription.TrimStart(trimSymbol);
            totalDescription = totalDescription.TrimEnd(trimSymbol);

            return totalDescription;
        }
        public String getSimpleDescription()
        {
            return this.Description;
        }
        public int getTaWBonus(InterfaceTalent talent)
        {
            if (talentBoni.TryGetValue(talent, out int x))
            {
                return x;
            }
            return 0;
        }
        public int getEnergieBonus(DSA_ENERGIEN energie)
        {
            energieBonus.TryGetValue(energie, out int x);
            return x;
        }
        public int getAttributeBonus(DSA_ATTRIBUTE attribute)
        {
            attributeBonus.TryGetValue(attribute, out int x);
            return x;
        }
        public int getAdvancedValues(DSA_ADVANCEDVALUES value)
        {
            advancedBonus.TryGetValue(value, out int x);
            return x;
        }
        
        public List<InterfaceTalent> getTalentListwithBonus()
        {
            return new List<InterfaceTalent>(this.talentBoni.Keys);
        }
    }
}
