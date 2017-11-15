using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace DSA_Project
{
    //*toDO: try Am obersten Punkt, bei Misserfolg alles als Korrupt erklären (Simple Lösung)
    static class LoadCharakterXML
    {
        public static Charakter loadCharakter(String fileName, Charakter charakter)
        {
            XmlDocument characterFile = new XmlDocument();
            characterFile.Load(fileName);

            XmlNode characterNode       = characterFile.SelectSingleNode("/" + ManagmentSave.CharacterBogenElement);
            XmlNode heldenbriefNode     = characterNode.SelectSingleNode(ManagmentSave.HeldenBriefElement);
            XmlNode talentbriefNode     = characterNode.SelectSingleNode(ManagmentSave.TalentBriefElement);

            loadHeldenbrief(heldenbriefNode, charakter);
            loadTalentbrief(talentbriefNode, charakter);

            return charakter;
        }

        private static void loadHeldenbrief(XmlNode HeldenbriefNode, Charakter charakter)
        {
            foreach (XmlNode node in HeldenbriefNode)
            {
                switch (node.Name)
                {
                    case ManagmentSave.BasisDatenElement: loadBasicData(node, charakter); break;
                    case ManagmentSave.AttributeElement: loadAttribute(node, charakter); break;
                    case ManagmentSave.MoneyElement: loadMoney(node, charakter); break;
                    case ManagmentSave.FeatureElement: loadFeature(node, charakter); break;
                }
            }
        }
        private static void loadBasicData(XmlNode BasicDataNode, Charakter charakter)
        {
            String[] name = Enum.GetNames(typeof(DSA_BASICVALUES));
            int length = Enum.GetNames(typeof(DSA_BASICVALUES)).Length;

            for (int i = 0; i < length; i++)
            {
                foreach (XmlNode node in BasicDataNode)
                {
                    if ((node.Name).ToUpper() == name[i].ToUpper())
                    {
                        charakter.setBasicValues((DSA_BASICVALUES)i, node.InnerText);
                    }
                }
            }

            foreach (XmlNode node in BasicDataNode)
            {
                if (ManagmentSave.Modification.Length < node.Name.Length)
                {
                    if (String.Compare(node.Name.Substring(0, ManagmentSave.Modification.Length), ManagmentSave.Modification, true) == 0)
                    {
                        int number = 0;
                        String numberString = node.Name.Substring(ManagmentSave.Modification.Length, node.Name.Length - ManagmentSave.Modification.Length);
                        Int32.TryParse(numberString, out number);

                        charakter.setModifikatoren(number, node.InnerText);
                    }
                }
                if (ManagmentSave.Göttergeschenke.Length < node.Name.Length)
                {
                    if (String.Compare(node.Name.Substring(0, ManagmentSave.Göttergeschenke.Length), ManagmentSave.Göttergeschenke, true) == 0)
                    {
                        int number = 0;
                        String numberString = node.Name.Substring(ManagmentSave.Göttergeschenke.Length, node.Name.Length - ManagmentSave.Göttergeschenke.Length);
                        Int32.TryParse(numberString, out number);

                        charakter.setGöttergeschenk(number, node.InnerText);
                    }
                }
            }

        }
        private static void loadAttribute(XmlNode AttributeNode, Charakter charakter)
        {
            String[] name = Enum.GetNames(typeof(DSA_ATTRIBUTE));
            int length = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;

            for (int i = 0; i < length; i++)
            {
                foreach (XmlNode node in AttributeNode)
                {
                    if ((node.Name).ToUpper() == name[i].ToUpper())
                    {
                        int x;
                        Int32.TryParse(node.InnerText, out x);
                        charakter.setAttribute((DSA_ATTRIBUTE)i, x);
                    }
                }
            }
        }
        private static void loadMoney(XmlNode MoneyNode, Charakter charakter)
        {
            String[] name = Enum.GetNames(typeof(DSA_MONEY));
            int length = Enum.GetNames(typeof(DSA_MONEY)).Length;

            for (int i = 0; i < length; i++)
            {
                foreach (XmlNode node in MoneyNode)
                {
                    if ((node.Name).ToUpper() == name[i].ToUpper())
                    {
                        int x;
                        Int32.TryParse(node.InnerText, out x);
                        charakter.setMoney((DSA_MONEY)i, x);
                    }
                }
            }
        }
        private static void loadFeature(XmlNode featureNode, Charakter charakter)
        {
            foreach (XmlNode node in featureNode)
            {
                switch (node.Name)
                {
                    case ManagmentSave.Advantages: loadFeature(node, charakter, DSA_FEATURES.VORTEIL); break;
                    case ManagmentSave.DisAdvantages: loadFeature(node, charakter, DSA_FEATURES.NACHTEIL); break;
                }
            }
        }
        private static void loadFeature(XmlNode featureNode, Charakter charakter, DSA_FEATURES type)
        {
            int i = 0;
            foreach (XmlNode node in featureNode)
            {
                i++;
                Feature feature = loadFeature(node, i);
                charakter.addFeature(type, i, feature);
            }
        }
        private static Feature loadFeature(XmlNode featureNode, int number)
        {
            Feature feature = new Feature();

            foreach (XmlNode node in featureNode)
            {
                switch (node.Name)
                {
                    case ManagmentSave.Name: feature.setName(node.InnerText); break;
                    case ManagmentSave.Description: feature.setDescription(node.InnerText); break;
                    case ManagmentSave.Value: feature.setValue(node.InnerText); break;
                    case ManagmentSave.GP: feature.setGP(node.InnerText); break;
                    case ManagmentSave.AttributeElement: LoadAttribute(node, feature); break;
                    case ManagmentSave.EnergienElement: LoadEnergien(node, feature); break;
                    case ManagmentSave.AdvancedElement: LoadAdvanced(node, feature); break;
                }
            }

            return feature;
        }
        private static void LoadAttribute(XmlNode attributenode, Feature feature)
        {
            String[] Attributenames = Enum.GetNames(typeof(DSA_ATTRIBUTE));


            foreach (XmlNode node in attributenode)
            {
                for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
                {
                    if (String.Equals(Attributenames[i], node.Name))
                    {
                        int x;
                        Int32.TryParse(node.InnerText, out x);
                        feature.setAttributeBonus((DSA_ATTRIBUTE)i, x);
                        break;
                    }
                }
            }
        }
        private static void LoadEnergien(XmlNode attributenode, Feature feature)
        {
            String[] Energienames = Enum.GetNames(typeof(DSA_ENERGIEN));

            foreach (XmlNode node in attributenode)
            {
                for (int i = 0; i < Enum.GetNames(typeof(DSA_ENERGIEN)).Length; i++)
                {
                    if (String.Equals(Energienames[i], node.Name))
                    {
                        int x;
                        Int32.TryParse(node.InnerText, out x);
                        feature.setEnergieBonus((DSA_ENERGIEN)i, x);
                        break;
                    }
                }
            }
        }
        private static void LoadAdvanced(XmlNode advancedNode, Feature feature)
        {
            String[] AdvancedNames = Enum.GetNames(typeof(DSA_ADVANCEDVALUES));

            foreach (XmlNode node in advancedNode)
            {
                for (int i = 0; i < Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length; i++)
                {
                    if (String.Equals(AdvancedNames[i], node.Name))
                    {
                        int x;
                        Int32.TryParse(node.InnerText, out x);
                        feature.setAdvancedValues((DSA_ADVANCEDVALUES)i, x);
                        break;
                    }
                }
            }
        }

        private static void loadTalentbrief(XmlNode TalentNode, Charakter charakter)
        {
            String[] s = Enum.GetNames(typeof(DSA_TALENTS));
            foreach (XmlNode node in TalentNode)
            {
                Console.WriteLine(node.Name + "--------------------------------------------------------------");
                for(int i=0; i<s.Length; i++)
                {
                    if(String.Equals(s[i], node.Name))
                    {
                        loadTalentCatecorie(node, charakter, (DSA_TALENTS)i);
                    }
                }
            }
        }
        private static void loadTalentCatecorie(XmlNode CatecorieNode, Charakter charakter, DSA_TALENTS type)
        {
            int TalentListLength = charakter.getCounttalent(type);   
            for(int i=0; i < TalentListLength; i++)
            {
                Talent talent = charakter.getTalent(type, i);
                foreach(XmlNode node in CatecorieNode)
                {
                    if(String.Equals(node.Name, talent.getName())){
                        talent.setTaw(node.InnerText);
                    }
                }
            }

        }
        private static void loadTalent()
        {

        }

    }
}
