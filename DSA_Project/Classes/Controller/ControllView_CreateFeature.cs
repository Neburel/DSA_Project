using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DSA_Project
{
    public class ControllView_CreateFeature
    {
        private Feature feature;
        private List<InterfaceTalent> talentlist;

        public ControllView_CreateFeature(List<InterfaceTalent> talentList)
        {
            this.talentlist = talentList;
        }
        //Tools##################################################################################################################################################
        [ExcludeFromCodeCoverage]
        public Feature editFeature(Feature feature)
        {
            /*Clone Feature* -> Nötig wegen Elementaren Fehler im Manager*/
            Feature cloneFeature = new Feature();
            cloneFeature.setName(feature.getName());
            cloneFeature.setDescription(feature.getSimpleDescription());
            cloneFeature.setGP(feature.getGP());
            cloneFeature.setValue(feature.getValue());
            for(int i=0; i<Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                DSA_ATTRIBUTE type = (DSA_ATTRIBUTE)i;
                cloneFeature.setAttributeBonus(type, feature.getAttributeBonus(type));
            }
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ENERGIEN)).Length; i++)
            {
                DSA_ENERGIEN type = (DSA_ENERGIEN)i;
                cloneFeature.setEnergieBonus(type, feature.getEnergieBonus(type));
            }
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length; i++)
            {
                DSA_ADVANCEDVALUES type = (DSA_ADVANCEDVALUES)i;
                cloneFeature.setAdvancedValues(type, feature.getAdvancedValues(type));
            }

            List<InterfaceTalent> list =  feature.getTalentListwithBonus();
            for(int i=0; i<list.Count; i++)
            {
                cloneFeature.addTalent(list[i], feature.getTaWBonus(list[i]));
            }
            this.feature = cloneFeature;

            View_CreateFeature Form = new View_CreateFeature(this);
            Form.ShowDialog();

            return this.feature;
        }
        public void setFeature(Feature feature)
        {
            this.feature = feature;
        }
        public Feature getFeature()
        {
            return feature;
        }
        private int convertToInt(String value)
        {
            var isNumeric = int.TryParse(value, out var wert_int);
            if (isNumeric == true)
            {
                return wert_int;
            }
            return 0;
        }
        //Allgemeines#############################################################################################################################################
        public String FeatureName()
        {
            return feature.getName();
        }
        public String FeatureName(String name)
        {
            feature.setName(name);
            return FeatureName();
        }
        public String FeatureDescription()
        {
            return feature.getSimpleDescription();
        }
        public String FeatureDescription(String description)
        {
            feature.setDescription(description);
            return FeatureDescription();
        }
        public String FeatureGP()
        {
            return feature.getGP();
        }
        public String FeatureGP(String gp)
        {
            feature.setGP(gp);
            return FeatureGP();
        }
        public String FeatureValue()
        {
            return feature.getValue();
        }
        public String FeatureValue(String value)
        {
            feature.setValue(value);
            return FeatureValue();
        }
        //Attribute#############################################################################################################################################
        public String Attribute(DSA_ATTRIBUTE attribut)
        {
            return feature.getAttributeBonus(attribut).ToString();
        }
        public String Attribute(DSA_ATTRIBUTE attribut, String value)
        {
            int x = convertToInt(value);
            feature.setAttributeBonus(attribut, x);
            return Attribute(attribut);
        }
        //Energue###############################################################################################################################################
        public String Energie(DSA_ENERGIEN energie)
        {
            return feature.getEnergieBonus(energie).ToString();
        }
        public String Energie(DSA_ENERGIEN energie, String value)
        {
            int x = convertToInt(value);
            feature.setEnergieBonus(energie, x);
            return Energie(energie);
        }
        //Advanced##############################################################################################################################################
        public String Advanced(DSA_ADVANCEDVALUES advanced)
        {
            return feature.getAdvancedValues(advanced).ToString();
        }
        public String Advanced(DSA_ADVANCEDVALUES advanced, String value)
        {
            int x = convertToInt(value);
            feature.setAdvancedValues(advanced, x);
            return Advanced(advanced);
        }
        //Talente###############################################################################################################################################
        private InterfaceTalent getTalentbyName(String name)
        {
            InterfaceTalent talent = null;
            for(int i=0; i< talentlist.Count; i++)
            {
                if(0==String.Compare(name, talentlist[i].getName()))
                {
                    talent = talentlist[i];
                    break;
                }
            }
            return talent;
        }
        public List<InterfaceTalent> getTalentList()
        {
            return talentlist;
        }
        public List<String> TalentewithBonus()
        {
            List<InterfaceTalent> tlist = feature.getTalentListwithBonus();
            List<String> slist = new List<String>();

            for(int i=0; i<tlist.Count; i++)
            {
                slist.Add(tlist[i].getName());
            }

            return slist;
        }
        public void removeTawBonus(String Talent)
        {
            InterfaceTalent italent = getTalentbyName(Talent);
            feature.removeTalent(italent);
        }
        public void setTawBonus(String Talent, String Taw)
        {
            InterfaceTalent italent = getTalentbyName(Talent);
            if (italent == null) return;

            int x = convertToInt(Taw);
            feature.addTalent(italent, x);
        }
        public int getTawBonus(String talent)
        {
            InterfaceTalent italent = getTalentbyName(talent);
            if (italent == null) return 0;

            return feature.getTaWBonus(italent);
        }
    }
}
