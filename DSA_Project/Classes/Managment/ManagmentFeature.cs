using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    class ManagmentFeature
    {
        private enum ACTION { ADD, REMOVE}

        Dictionary<int, Feature> AdvantageFeatures          = new Dictionary<int, Feature>();
        Dictionary<int, Feature> DisAdvantageFeatures       = new Dictionary<int, Feature>();
        Dictionary<DSA_ATTRIBUTE, int> attributeBonus       = new Dictionary<DSA_ATTRIBUTE, int>();
        Dictionary<DSA_ADVANCEDVALUES, int> advantageBonus  = new Dictionary<DSA_ADVANCEDVALUES, int>();
        Dictionary<DSA_ENERGIEN, int> energienBonus         = new Dictionary<DSA_ENERGIEN, int>();
        Dictionary<DSA_ENERGIEN, int> energienMali          = new Dictionary<DSA_ENERGIEN, int>();

        Dictionary<InterfaceTalent, int> TalentTawBonus     = new Dictionary<InterfaceTalent, int>();

        int HighestNumber                                   = 0;


        public ManagmentFeature()
        {
            int attributeCount  = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;
            int energienCount   = Enum.GetNames(typeof(DSA_ENERGIEN)).Length;
            for(int i=0; i<attributeCount; i++)
            {
                attributeBonus.Add((DSA_ATTRIBUTE)i, 0);
            }
            for(int i=0; i<energienCount; i++)
            {
                energienBonus.Add((DSA_ENERGIEN)i, 0);
                energienMali.Add((DSA_ENERGIEN)i, 0);
            }
        }
        public void addFeature(Feature feature, int number)
        {
            DSA_FEATURES type = feature.getFeatureType();

            if (HighestNumber < number)
            {
                HighestNumber = number;
            }

            switch (type)
            {
                case DSA_FEATURES.VORTEIL: addAdvantage(feature, number); break;
                case DSA_FEATURES.NACHTEIL: addDisAdvantage(feature, number); break;
            }
        }
        private void addAdvantage(Feature feature, int number)
        {
            calculate(DSA_FEATURES.VORTEIL, number, ACTION.REMOVE);
            AdvantageFeatures.Remove(number);
            AdvantageFeatures.Add(number, feature);
            calculate(DSA_FEATURES.VORTEIL, number, ACTION.ADD);
        }
        private void addDisAdvantage(Feature feature, int number)
        {
            calculate(DSA_FEATURES.NACHTEIL, number, ACTION.REMOVE);
            DisAdvantageFeatures.Remove(number);
            DisAdvantageFeatures.Add(number, feature);
            calculate(DSA_FEATURES.NACHTEIL, number, ACTION.ADD);
        }
        private void calculate(DSA_FEATURES type, int number, ACTION action)
        {
            Dictionary<int, Feature> dictionary = null;
            Feature currentFeature;
            int factor = 1;

            switch (type)
            {
                case DSA_FEATURES.VORTEIL: dictionary = AdvantageFeatures; break;
                case DSA_FEATURES.NACHTEIL: dictionary = DisAdvantageFeatures; break;
            }
            if(action == ACTION.REMOVE)
            {
                factor = factor * (-1);
            }

            if(dictionary.TryGetValue(number, out currentFeature) == false)
            {
                return;
            }

            CalculateAttributeBonus(currentFeature, factor);

            switch (type)
            {
                case DSA_FEATURES.VORTEIL: CalculaeEnergieBonus(currentFeature, factor); break;
                case DSA_FEATURES.NACHTEIL: CalculaeEnergieMali(currentFeature, factor); break;
            }

            CalculateAdvancedBonus(currentFeature, factor);
            CalculateTalentBonus(currentFeature, factor);
        }
        private void CalculateAttributeBonus(Feature feature, int factor)
        {
            int x = 0;
            int y = 0;

            int attributeCount = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;
            for (int i = 0; i < attributeCount; i++)
            {
                attributeBonus.TryGetValue((DSA_ATTRIBUTE)i, out x);
                y = feature.getAttributeBonus((DSA_ATTRIBUTE)i);
                x = x + factor * y;

                attributeBonus.Remove((DSA_ATTRIBUTE)i);
                attributeBonus.Add((DSA_ATTRIBUTE)i, x);
            }
        }
        private void CalculateAdvancedBonus(Feature feature, int factor)
        {
            int x = 0;
            int y = 0;

            int count = Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length;
            for (int i = 0; i < count; i++)
            {
                advantageBonus.TryGetValue((DSA_ADVANCEDVALUES)i, out x);
                y = feature.getAdvancedValues((DSA_ADVANCEDVALUES)i);
                x = x + factor * y;

                advantageBonus.Remove((DSA_ADVANCEDVALUES)i);
                advantageBonus.Add((DSA_ADVANCEDVALUES)i, x);
            }
        }
        private void CalculaeEnergieBonus(Feature feature, int factor)
        {
            int energieCount = Enum.GetNames(typeof(DSA_ENERGIEN)).Length;
            int currentBonus;
            int featureBonus;

            for(int i=0; i<energieCount; i++)
            {
                energienBonus.TryGetValue((DSA_ENERGIEN)i, out currentBonus);
                featureBonus = feature.getEnergieBonus((DSA_ENERGIEN)i);
                currentBonus = currentBonus + factor * featureBonus;

                energienBonus.Remove((DSA_ENERGIEN)i);
                energienBonus.Add((DSA_ENERGIEN)i, currentBonus);
            }
        }
        private void CalculaeEnergieMali(Feature feature, int factor)
        {
            int energieCount = Enum.GetNames(typeof(DSA_ENERGIEN)).Length;
            int currentBonus;
            int featureBonus;

            for (int i = 0; i < energieCount; i++)
            {
                energienMali.TryGetValue((DSA_ENERGIEN)i, out currentBonus);
                featureBonus = feature.getEnergieBonus((DSA_ENERGIEN)i);
                currentBonus = currentBonus + factor * featureBonus;

                energienMali.Remove((DSA_ENERGIEN)i);
                energienMali.Add((DSA_ENERGIEN)i, currentBonus);
            }
        }
        private void CalculateTalentBonus(Feature feature, int factor)
        {
            List<InterfaceTalent> tlist = feature.TalentListwithBonus();
            foreach(InterfaceTalent talent in tlist)
            {
                int currentTaWBonus = 0;
                if (TalentTawBonus.ContainsKey(talent))
                {
                    TalentTawBonus.TryGetValue(talent, out currentTaWBonus);
                    TalentTawBonus.Remove(talent);
                }
                currentTaWBonus = currentTaWBonus + factor * feature.getTaWBonus(talent);
                TalentTawBonus.Add(talent, currentTaWBonus);
            }

        }

        public Feature GetFeature(DSA_FEATURES type, int number)
        {
            Feature feature = null;

            switch (type)
            {
                case DSA_FEATURES.VORTEIL: AdvantageFeatures.TryGetValue(number, out feature); break;
                case DSA_FEATURES.NACHTEIL: DisAdvantageFeatures.TryGetValue(number, out feature); break;
            }
            return feature;
        }
        public int getAttributeBonus(DSA_ATTRIBUTE attribute)
        {
            int x = 0;
            attributeBonus.TryGetValue(attribute, out x);
            return x;
        }
        public int getAdvancedBonus(DSA_ADVANCEDVALUES value)
        {
            int x = 0;
            advantageBonus.TryGetValue(value, out x);
            return x;
        }
        public int getEnergienBonus(DSA_ENERGIEN energie)
        {
            int x = 0;
            energienBonus.TryGetValue(energie, out x);
            return x;
        }
        public int getEnergienMALI(DSA_ENERGIEN energie)
        {
            int x = 0;
            energienMali.TryGetValue(energie, out x);
            return x;
        }

        public int getTalentTawBonus(InterfaceTalent talent)
        {
            int x = 0;
            if (TalentTawBonus.ContainsKey(talent))
            {
                TalentTawBonus.TryGetValue(talent, out x);
            }
            return x;
        }
        
        public int getHighestNumber()
        {
            return HighestNumber;
        }
    }
}
