﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    class Charakter
    {
        ManagmentFeature featureManagment               = new ManagmentFeature();

        private Dictionary<DSA_ATTRIBUTE, int> attributeAKT;
        private Dictionary<DSA_ATTRIBUTE, int> attributeMod;
        private Dictionary<DSA_MONEY, int> money;
        private Dictionary<DSA_BASICVALUES, String> basicValues;
        private Dictionary<DSA_ADVANCEDVALUES, int> advancedValues;
        private Dictionary<DSA_ADVANCEDVALUES, int> advancedValuesMOD;
        private Dictionary<DSA_ENERGIEN, int> energieMod;
        private Dictionary<int, String> göttergerschenke;
        private Dictionary<int, String> modifikatoren;
       

        int Beherschungswert    = 0;
        int Entrückung          = 0;
        int Geschwindigkeit     = 0;

        
        public Charakter()
        {
            //Initialisierung der Dictonarys (benötigte Zurgiffe)
            int enumAttributLength          = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;
            int enumMoneyLength             = Enum.GetNames(typeof(DSA_MONEY)).Length;
            int enumBasicValueLength        = Enum.GetNames(typeof(DSA_BASICVALUES)).Length;
            int enumAdvatageValuesLength    = Enum.GetNames(typeof(DSA_BASICVALUES)).Length;
            int enumEnergienLength          = Enum.GetNames(typeof(DSA_ENERGIEN)).Length;

            attributeAKT                    = new Dictionary<DSA_ATTRIBUTE, int>();
            attributeMod                    = new Dictionary<DSA_ATTRIBUTE, int>();
            money                           = new Dictionary<DSA_MONEY, int>();
            basicValues                     = new Dictionary<DSA_BASICVALUES, string>();
            advancedValues                  = new Dictionary<DSA_ADVANCEDVALUES, int>();
            advancedValuesMOD               = new Dictionary<DSA_ADVANCEDVALUES, int>();
            energieMod                      = new Dictionary<DSA_ENERGIEN, int>();
            göttergerschenke                = new Dictionary<int, string>();
            modifikatoren                   = new Dictionary<int, string>();


            for (int i=0; i<enumAttributLength; i++)
            {
                attributeAKT.Add((DSA_ATTRIBUTE)i, 0);
                attributeMod.Add((DSA_ATTRIBUTE)i, 1);
            }
            for(int i=0; i<enumMoneyLength; i++)
            {
                money.Add((DSA_MONEY)i, 0);
            }
            for(int i=0; i<enumBasicValueLength; i++)
            {
                basicValues.Add((DSA_BASICVALUES)i, "");
            }
            for(int i=0; i<enumAdvatageValuesLength; i++)
            {
                advancedValues.Add((DSA_ADVANCEDVALUES)i, 0);
                advancedValuesMOD.Add((DSA_ADVANCEDVALUES)i, 1);
            }
            for(int i=0; i<enumEnergienLength; i++)
            {
                energieMod.Add((DSA_ENERGIEN)i, 1);
            }
        }

        public void setMoney(DSA_MONEY type, int value)
        {
            money.Remove(type);
            money.Add(type, value);
        }
        public int getMoney(DSA_MONEY type )
        {
            int x;
            money.TryGetValue(type, out x);
            return x;
        }

        public void setBasicValues(DSA_BASICVALUES value, String stringValue)
        {
            basicValues.Remove(value);
            basicValues.Add(value, stringValue);
        }
        public String getBasicValue(DSA_BASICVALUES value)
        {
            String x;
            basicValues.TryGetValue(value, out x);
            return x;            
        }

        public void setAttribute(DSA_ATTRIBUTE attribute, int wert)
        {
            attributeAKT.Remove(attribute);
            attributeAKT.Add(attribute, wert);
        }
        public int getAttributeAKT(DSA_ATTRIBUTE attribute)
        {
            int x;
            attributeAKT.TryGetValue(attribute, out x);
            return x;
        }
        public int getAttribute_Mod(DSA_ATTRIBUTE attribute)
        {
            int x;
            attributeMod.TryGetValue(attribute, out x);
            return x;
        }
        public int getAttribute_Max(DSA_ATTRIBUTE attribute)
        {
            int featurePoints;
            int akt;
            int mod;

            featurePoints = featureManagment.getAttributeBonus(attribute);
            attributeAKT.TryGetValue(attribute, out akt);
            attributeMod.TryGetValue(attribute, out mod);
            
            

            return (akt+featurePoints)*mod;
        }
        public int getSummeAttributeAKT()
        {
            int summe = 0;
            int attributeCount = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;
            for (int i = 0; i < attributeCount; i++)
            {
                summe = summe + getAttributeAKT((DSA_ATTRIBUTE)i);
            }
            return summe;
        }
        public int getSummeAttributeMAX()
        {
            int summe = 0;
            int attributeCount = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;
            for (int i = 0; i < attributeCount; i++)
            {
                summe = summe + getAttribute_Max((DSA_ATTRIBUTE)i);
            }
            return summe;
        }

        public void setAdvancedValueAKT(DSA_ADVANCEDVALUES type, int value)
        {
            switch(type)
            {
                case DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT:   this.Beherschungswert   = value; break;
                case DSA_ADVANCEDVALUES.ENTRÜCKUNG:         this.Entrückung         = value; break;
                case DSA_ADVANCEDVALUES.GESCHWINDIGKEIT:    this.Geschwindigkeit    = value; break;
            }
        }
        public int getAdvancedValueAKT(DSA_ADVANCEDVALUES value)
        {
            switch (value)
            {
                case DSA_ADVANCEDVALUES.ATTACKE_BASIS:
                    Double attacBasis = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.MU) + getAttribute_Max(DSA_ATTRIBUTE.GE) + getAttribute_Max(DSA_ATTRIBUTE.KK)) / 5;
                    return (int)Math.Ceiling(attacBasis);
                case DSA_ADVANCEDVALUES.PARADE_BASIS:
                    Double paradeBasis = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.IN) + getAttribute_Max(DSA_ATTRIBUTE.GE) + getAttribute_Max(DSA_ATTRIBUTE.KK)) / 5;
                    return (int)Math.Ceiling(paradeBasis);
                case DSA_ADVANCEDVALUES.FERNKAMPF_BASIS:
                    Double fernkampfBasis = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.IN) + getAttribute_Max(DSA_ATTRIBUTE.FF) + getAttribute_Max(DSA_ATTRIBUTE.KK)) / 5;
                    return (int)Math.Ceiling(fernkampfBasis);
                case DSA_ADVANCEDVALUES.INITATIVE_BASIS:
                    Double initativeBasis = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.MU) + getAttribute_Max(DSA_ATTRIBUTE.MU) + getAttribute_Max(DSA_ATTRIBUTE.IN) + getAttribute_Max(DSA_ATTRIBUTE.GE)) / 5;
                    return (int)Math.Ceiling(initativeBasis);
                case DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT:
                    return (Beherschungswert);
                case DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE:
                    Double artefaktkontrolle = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.IN)+getEnergieVOR(DSA_ENERGIEN.MAGIERESISTENZ));
                    return (int)Math.Ceiling(artefaktkontrolle);
                case DSA_ADVANCEDVALUES.WUNDSCHWELLE:
                    Double wundschwelle = Convert.ToDouble(getAttribute_Max(DSA_ATTRIBUTE.KO)) / 2;
                    return (int)Math.Ceiling(wundschwelle);
                case DSA_ADVANCEDVALUES.ENTRÜCKUNG:
                    return (Entrückung);
                case DSA_ADVANCEDVALUES.GESCHWINDIGKEIT:
                    return (Geschwindigkeit);
            }
            return 0;
        }
        public int getAdvancedValueMOD(DSA_ADVANCEDVALUES value)
        {
            int x;
            advancedValuesMOD.TryGetValue(value, out x);
            return x;
        }
        public int getAdvancedValueMAX(DSA_ADVANCEDVALUES value)
        {
            return (getAdvancedValueAKT(value)+featureManagment.getAdvancedBonus(value)) * getAdvancedValueMOD(value);
        }

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
                case (DSA_ENERGIEN.KARMAENERGIE):
                    return 0;
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
        public int getEnergieMOD(DSA_ENERGIEN energie)
        {
            int x;
            energieMod.TryGetValue(energie, out x);
            return x;
        }
        public int getEnergieMALI(DSA_ENERGIEN energie)
        {
            return featureManagment.getEnergienMALI(energie);
        }
        public int getEnergieMAX(DSA_ENERGIEN energie)
        {
            return (getEnergieVOR(energie)+getEnergiePERM(energie)) * getEnergieMOD(energie) + getEnergieMALI(energie);
        }
        
        public void addFeature(DSA_FEATURES type, int number, Feature feature)
        {
            featureManagment.addFeature(type, feature, number);
        }       
        public Feature getFeature(DSA_FEATURES type, int number)
        {
            return featureManagment.GetFeature(type, number);
        }

        public int getHighistFeatureNumber(DSA_FEATURES type)
        {
            return featureManagment.getHighestNumber();
        }
        
        public void setGöttergeschenk(int number, String description)
        {
            göttergerschenke.Remove(number);
            göttergerschenke.Add(number, description); 
        }
        public void setModifikatoren(int number, String description)
        {
            modifikatoren.Remove(number);
            modifikatoren.Add(number, description);
        }
        public string getGöttergeschenk(int number)
        {
            String x;
            göttergerschenke.TryGetValue(number, out x);
            return x;
        }
        public string getModifikatoren(int number)
        {
            String x;
            modifikatoren.TryGetValue(number, out x);
            return x;
        }
    }
}
