using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project
{
    public class ManagmentFeature
    {
        List<Feature> featureList = new List<Feature>(0);

        public ManagmentFeature()
        {
        }
        public void addFeature(Feature feature, int number)
        {
            if (number == 32)
            {
                Console.WriteLine();
            }

            if (featureList.Count <= number)
            {
                for(int i=featureList.Count; i <= number; i++)
                {
                    featureList.Add(new Feature());                    
                }
            }
            featureList[number] = feature;
        }
        public Feature GetFeature(int number)
        {
            if (number >= featureList.Count) return new Feature();

            return featureList[number];
        }
        public int getAttributeBonus(DSA_ATTRIBUTE attribute)
        {
            int x = 0;            
            for(int i=0; i<featureList.Count; i++)
            {
                x = x + featureList[i].getAttributeBonus(attribute);
            }
            return x;
        }
        public int getAdvancedBonus(DSA_ADVANCEDVALUES value)
        {
            int x = 0;
            for (int i = 0; i < featureList.Count; i++)
            {
                x = x + featureList[i].getAdvancedValues(value);
            }
            return x;
        }
        public int getEnergienBonus(DSA_ENERGIEN energie)
        {
            int x = 0;
            for (int i = 0; i < featureList.Count; i++)
            {
                int y = featureList[i].getEnergieBonus(energie);
                if (y > 0)
                {
                    x = x + y;
                }
            }
            return x;
        }
        public int getEnergienMALI(DSA_ENERGIEN energie)
        {
            int x = 0;
            for (int i = 0; i < featureList.Count; i++)
            {
                int y = featureList[i].getEnergieBonus(energie);
                if (y < 0)
                {
                    x = x + y;
                }
            }
            return x;
        }
        public int getTalentTawBonus(InterfaceTalent talent)
        {
            int x = 0;
            for (int i = 0; i < featureList.Count; i++)
            {
                x = x + featureList[i].getTaWBonus(talent);
            }
            return x;
        }        
        public int Count()
        {
            return featureList.Count;
        }
    }
}
