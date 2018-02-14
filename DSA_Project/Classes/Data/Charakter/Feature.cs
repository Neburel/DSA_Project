﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class Feature
    {
        private String[] attributeAcronyms  = Enum.GetNames(typeof(DSA_ATTRIBUTE));
        private String[] energienAcronyms   = Enum.GetNames(typeof(DSA_ENERGIEN));
        private String[] advancedAcronyms   = Enum.GetNames(typeof(DSA_ADVANCEDVALUES));

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
            var isNumeric = int.TryParse(GP, out var wert_int);
            if (isNumeric == true)
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
        public void addTalent(InterfaceTalent talent, int BonusTaw)
        {
            talentBoni.Remove(talent);
            talentBoni.Add(talent, BonusTaw);
        }
        public void removeTalent(InterfaceTalent talent)
        {
            talentBoni.Remove(talent);
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
            totalDescription = totalDescription + ", " + getAttributeString();
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription + ", " + getEnergieString();
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription + ", " + getAdvancedString();
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
            int x = 0;
            if (talentBoni.TryGetValue(talent, out x))
            {
                return x;
            }
            return 0;
        }
        public int getEnergieBonus(DSA_ENERGIEN energie)
        {
            int x;
            energieBonus.TryGetValue(energie, out x);
            return x;
        }
        public int getAttributeBonus(DSA_ATTRIBUTE attribute)
        {
            int x;
            attributeBonus.TryGetValue(attribute, out x);
            return x;
        }
        public int getAdvancedValues(DSA_ADVANCEDVALUES value)
        {
            int x;
            advancedBonus.TryGetValue(value, out x);
            return x;
        }

        public List<InterfaceTalent> getTalentListwithBonus()
        {
            return new List<InterfaceTalent>(this.talentBoni.Keys);
        }
        
        private String getAttributeString()
        {
            String ret = "";
            int x = 0;
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                attributeBonus.TryGetValue((DSA_ATTRIBUTE)i, out x);
                if (x != 0)
                {
                    if (0 != String.Compare(ret, ""))
                    {
                        ret = ret + ", " + x + attributeAcronyms[i];
                    }
                    else
                    {
                        ret = x + attributeAcronyms[i];
                    }
                }
            }
            return ret;
        }
        private String getEnergieString()
        {
            String ret = "";
            int x = 0;
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ENERGIEN)).Length; i++)
            {
                energieBonus.TryGetValue((DSA_ENERGIEN)i, out x);
                if (x != 0)
                {
                    if (0 != String.Compare(ret, ""))
                    {
                        ret = ret + ", " + x + energienAcronyms[i];
                    }
                    else
                    {
                        ret = x + energienAcronyms[i];
                    }
                }
            }
            return ret;
        }
        private String getAdvancedString()
        {
            String ret = "";
            int x = 0;
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length; i++)
            {
                advancedBonus.TryGetValue((DSA_ADVANCEDVALUES)i, out x);
                if (x != 0)
                {
                    ret = ret + " " + x + advancedAcronyms[i];
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
    }
}
