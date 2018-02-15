using System;
using System.Collections.Generic;
namespace DSA_Project
{
    public class Charakter
    {
        //###############################################################################################################################################
        //Features
        private ManagmentFeature featureManagment = new ManagmentFeature();
        public void setFeature(int number, Feature feature)
        {
            featureManagment.addFeature(feature, number);
        }
        public Feature getFeature(int number)
        {
            return featureManagment.GetFeature(number);
        }
        public int Count_Feature()
        {
            return featureManagment.Count();
        }
        //###############################################################################################################################################
        //Sonstige
        private Dictionary<DSA_MONEY, int> money    = new Dictionary<DSA_MONEY, int>();
        private int adventurePoints                 = 0;
        public void setAdventurePoints(int points)
        {
            this.adventurePoints = points;
        }
        public void setMoney(DSA_MONEY type, int value)
        {
            money.Remove(type);
            money.Add(type, value);
        }
        public int getAdvanturePoints()
        {
            return this.adventurePoints;
        }
        public int getMoney(DSA_MONEY type)
        {
            money.TryGetValue(type, out int x);
            return x;
        }
        //###############################################################################################################################################
        //BasicValues
        private Dictionary<DSA_BASICVALUES, String> basicValues = new Dictionary<DSA_BASICVALUES, String>();
        public void setBasicValues(DSA_BASICVALUES value, String stringValue)
        {
            basicValues.Remove(value);
            basicValues.Add(value, stringValue);
        }
        public String getBasicValue(DSA_BASICVALUES value)
        {
            basicValues.TryGetValue(value, out String x);
            return x;
        }
        //###############################################################################################################################################
        //Attribute
        private Dictionary<DSA_ATTRIBUTE, int> attributeAKT         = new Dictionary<DSA_ATTRIBUTE, int>();
        private Dictionary<DSA_ATTRIBUTE, bool> markedAttributs     = new Dictionary<DSA_ATTRIBUTE, bool>();    
        public void setAttribute(DSA_ATTRIBUTE attribute, int wert)
        {
            attributeAKT.Remove(attribute);
            attributeAKT.Add(attribute, wert);
        }
        public void setMarkedAttribut(DSA_ATTRIBUTE att, bool b)
        {
            markedAttributs.Remove(att);
            markedAttributs.Add(att, b);
        }
        public int getSummeAttributeAKT()
        {
            int summe = 0;
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                summe = summe + getAttributeAKT((DSA_ATTRIBUTE)i);
            }
            return summe;
        }
        public int getSummeAttributeMAX()
        {
            int summe = 0;
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                summe = summe + getAttribute_Max((DSA_ATTRIBUTE)i);
            }
            return summe;
        }
        public int getAttributeAKT(DSA_ATTRIBUTE attribute)
        {
            attributeAKT.TryGetValue(attribute, out int x);
            return x;
        }
        public int getAttribute_Mod(DSA_ATTRIBUTE attribute)
        {
            return featureManagment.getAttributeBonus(attribute);
        }
        public int getAttribute_Max(DSA_ATTRIBUTE attribute)
        {
            attributeAKT.TryGetValue(attribute, out int akt);
            return (akt + featureManagment.getAttributeBonus(attribute));
        }
        public bool getMarkedAttribut(DSA_ATTRIBUTE att)
        {
            markedAttributs.TryGetValue(att, out bool b);
            return b;
        }
        //###############################################################################################################################################
        //Advanced Values
        private Dictionary<DSA_ADVANCEDVALUES, int> advancedValues = new Dictionary<DSA_ADVANCEDVALUES, int>();
        private int Beherschungswert = 0;
        private int Entrückung = 0;
        private int Geschwindigkeit = 0;
        public void setAdvancedValueAKT(DSA_ADVANCEDVALUES type, int value)
        {
            switch (type)
            {
                case DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT:   this.Beherschungswert = value; break;
                case DSA_ADVANCEDVALUES.ENTRÜCKUNG:         this.Entrückung = value; break;
                case DSA_ADVANCEDVALUES.GESCHWINDIGKEIT:    this.Geschwindigkeit = value; break;
            }
        }
        public int getAdvancedValueAKT(DSA_ADVANCEDVALUES value)
        {
            int ret = 0;

            switch (value)
            {
                case DSA_ADVANCEDVALUES.ATTACKE_BASIS:
                    Double attacBasis = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.MU) + getAttribute_Max(DSA_ATTRIBUTE.GE) + getAttribute_Max(DSA_ATTRIBUTE.KK)) / 5;
                    ret = (int)Math.Ceiling(attacBasis);
                    break;
                case DSA_ADVANCEDVALUES.PARADE_BASIS:
                    Double paradeBasis = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.IN) + getAttribute_Max(DSA_ATTRIBUTE.GE) + getAttribute_Max(DSA_ATTRIBUTE.KK)) / 5;
                    ret = (int)Math.Ceiling(paradeBasis);
                    break;
                case DSA_ADVANCEDVALUES.FERNKAMPF_BASIS:
                    Double fernkampfBasis = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.IN) + getAttribute_Max(DSA_ATTRIBUTE.FF) + getAttribute_Max(DSA_ATTRIBUTE.KK)) / 5;
                    ret = (int)Math.Ceiling(fernkampfBasis);
                    break;
                case DSA_ADVANCEDVALUES.INITATIVE_BASIS:
                    Double initativeBasis = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.MU) + getAttribute_Max(DSA_ATTRIBUTE.MU) + getAttribute_Max(DSA_ATTRIBUTE.IN) + getAttribute_Max(DSA_ATTRIBUTE.GE)) / 5;
                    ret = (int)Math.Ceiling(initativeBasis);
                    break;
                case DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT:
                    ret = (Beherschungswert);
                    break;
                case DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE:
                    Double artefaktkontrolle = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.IN) + getEnergieMAX(DSA_ENERGIEN.MAGIERESISTENZ));
                    ret = (int)Math.Ceiling(artefaktkontrolle);
                    break;
                case DSA_ADVANCEDVALUES.WUNDSCHWELLE:
                    Double wundschwelle = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.KO)) / 2;
                    ret = (int)Math.Ceiling(wundschwelle);
                    break;
                case DSA_ADVANCEDVALUES.ENTRÜCKUNG:
                    ret = (Entrückung);
                    break;
                case DSA_ADVANCEDVALUES.GESCHWINDIGKEIT:
                    ret = (Geschwindigkeit);
                    break;
            }
            return ret;
        }
        public int getAdvancedValueMOD(DSA_ADVANCEDVALUES value)
        {
            return featureManagment.getAdvancedBonus(value);
        }
        public int getAdvancedValueMAX(DSA_ADVANCEDVALUES value)
        {
            return getAdvancedValueAKT(value) + getAdvancedValueMOD(value);
        }
        //###############################################################################################################################################
        //Energien
        public int getEnergieVOR(DSA_ENERGIEN energie)
        {
            switch (energie)
            {
                case (DSA_ENERGIEN.LEBENSENERGIE):
                    Double lebensenergie = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.KO) + getAttribute_Max(DSA_ATTRIBUTE.KO) + getAttribute_Max(DSA_ATTRIBUTE.KK)) / 2;
                    return (int)Math.Ceiling(lebensenergie);
                case (DSA_ENERGIEN.AUSDAUER):
                    Double ausdauer = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.MU) + getAttribute_Max(DSA_ATTRIBUTE.GE) + getAttribute_Max(DSA_ATTRIBUTE.KO)) / 2;
                    return (int)Math.Ceiling(ausdauer);
                case (DSA_ENERGIEN.ASTRALENERGIE):
                    Double astralenergie = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.MU) + getAttribute_Max(DSA_ATTRIBUTE.IN) + getAttribute_Max(DSA_ATTRIBUTE.CH)) / 2;
                    return (int)Math.Ceiling(astralenergie);
                case (DSA_ENERGIEN.MAGIERESISTENZ):
                    Double magieresistenz = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.MU) + getAttribute_Max(DSA_ATTRIBUTE.KL) + getAttribute_Max(DSA_ATTRIBUTE.KO)) / 5;
                    return (int)Math.Ceiling(magieresistenz);
            }
            return 0;
        }
        public int getEnergiePERM(DSA_ENERGIEN energie)
        {
            return featureManagment.getEnergienBonus(energie);
        }
        public int getEnergieMALI(DSA_ENERGIEN energie)
        {
            return featureManagment.getEnergienMALI(energie);
        }
        public int getEnergieMAX(DSA_ENERGIEN energie)
        {
            return (getEnergieVOR(energie) + getEnergiePERM(energie)) + getEnergieMALI(energie);
        }
        //###############################################################################################################################################
        //Talente
        private Dictionary<Type, List<InterfaceTalent>> TalentDictionary = new Dictionary<Type, List<InterfaceTalent>>();
        public void addTalent<T>(List<T> talent) where T: InterfaceTalent
        {
            if (talent == null) return;
            for (int i=0; i<talent.Count; i++)
            {
                this.addTalent(talent[i]);
            }
        }
        public void addTalent(InterfaceTalent talent)
        {
            if (talent == null) return;
            if (controll_TalentExist(talent)) { return; }
            if (getTalent(talent.getName())!=null) { return; }

            talent.setCharacter(this);
            if (TalentDictionary.TryGetValue(talent.GetType(), out List<InterfaceTalent> list))
            {
                list.Add(talent);
            }
            else
            {
                list = new List<InterfaceTalent>(0);
                TalentDictionary.Add(talent.GetType(), list);
                list.Add(talent);
            }
        }
        private Boolean controll_TalentExist(InterfaceTalent talent)
        {
            foreach (KeyValuePair<Type, List<InterfaceTalent>> pair in TalentDictionary)
            {
                List<InterfaceTalent> list = pair.Value;
                for (int i = 0; i < list.Count; i++)
                {
                    InterfaceTalent listTalent = list[i];
                    if(talent == listTalent)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public int getTaWBons(InterfaceTalent talent)
        {
            return featureManagment.getTalentTawBonus(talent);
        }
        public InterfaceTalent getTalent(InterfaceTalent talent, int number) 
        {
            if (talent == null) { return null; }
            
            if (TalentDictionary.TryGetValue(talent.GetType(), out List<InterfaceTalent> list)){
                if (number < list.Count)
                {
                    return list[number];
                }
                return null;
            }
            else
            {
                list = new List<InterfaceTalent>(0);
                TalentDictionary.Add(talent.GetType(), list);
            }
            return null;
        }
        public InterfaceTalent getTalent(String name)
        {
            foreach (KeyValuePair<Type, List<InterfaceTalent>> pair in TalentDictionary)
            {
                List<InterfaceTalent> list = pair.Value;
                for(int i=0; i<list.Count; i++)
                {
                    InterfaceTalent talent = list[i];
                    if(String.Compare(talent.getName(), name) == 0)
                    {
                        return talent;
                    }
                }
            }
            return null;
        }
        public List<InterfaceTalent>getTalentList_TalentType(InterfaceTalent talent)
        {
            if (!TalentDictionary.TryGetValue(talent.GetType(), out List<InterfaceTalent> list))
            {
                list = new List<InterfaceTalent>(0);
                TalentDictionary.Add(talent.GetType(), list);
            }
            return list;
        }
        public List<InterfaceTalent>getTalentList_allTalents()
        {
            List<InterfaceTalent> allTalents = new List<InterfaceTalent>();
            foreach (KeyValuePair<Type, List<InterfaceTalent>> pair in TalentDictionary)
            {
                List<InterfaceTalent> list = pair.Value;
                for (int i = 0; i < list.Count; i++)
                {
                    allTalents.Add(list[i]);
                }
            }
            return allTalents;
        }
        //###############################################################################################################################################
    }
}
