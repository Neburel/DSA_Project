using System;
using DSA_Project;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project.Tests
{
    static class RandomGenerator
    {
        public static Random random = new Random();
        public static int MaxNameLength = 50;
        public static int maxAttributLength = 10;
        public static int maxAttribut = 30;
        public static int maxDeviates = 10;

        public static String generateName()
        {
            Random numberGenerator = new Random();

            String ret = "";
            int nameLenght = numberGenerator.Next(MaxNameLength);

            for (int i = 0; i < nameLenght; i++)
            {
                ret = ret + (Char)numberGenerator.Next(33, 126);
            }
            return ret;
        }
        public static List<DSA_ATTRIBUTE> generateAttributList()
        {
            //Generiert eine Zufällige Reihenfolge von Attributen

            Random random = new Random();
            int length = random.Next(maxAttributLength);
            int enumLength = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;
            List<DSA_ATTRIBUTE> attributList = new List<DSA_ATTRIBUTE>();

            for (int i = 0; i<length; i++)
            {
                attributList.Add((DSA_ATTRIBUTE)random.Next(enumLength));
            }
            return attributList;
        }

        //Generiert einen zufälligen Character in dem Random werte Gesetzt werden, !Die Abfragbar sind!
        public static Charakter generateCharacter()
        {
            Charakter charakter = new Charakter();
            int enumLength = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;

            for (int i=0; i<enumLength; i++)
            {
                charakter.setAttribute((DSA_ATTRIBUTE)i, random.Next(maxAttribut));
            }

            return charakter;
        }

      
    }
}
