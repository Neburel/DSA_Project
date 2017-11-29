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

            XmlNode characterNode       = characterFile.SelectSingleNode("/" + ManagmentLoadXML.CharacterBogenElement);
            XmlNode heldenbriefNode     = characterNode.SelectSingleNode(ManagmentLoadXML.HeldenBriefElement);
            XmlNode talentbriefNode     = characterNode.SelectSingleNode(ManagmentLoadXML.TalentBriefElement);

            loadHeldenbrief(heldenbriefNode, charakter);
            loadTalentbrief(talentbriefNode, charakter);

            return charakter;
        }

        private static void loadAdvanturePoints(XmlNode AdvanturePoints, Charakter charakter)
        {
            int x;
            Int32.TryParse(AdvanturePoints.InnerText, out x);
            charakter.setAdventurePoints(x);
        }

        private static void loadHeldenbrief(XmlNode HeldenbriefNode, Charakter charakter)
        {
            foreach (XmlNode node in HeldenbriefNode)
            {
                switch (node.Name)
                {
                    case ManagmentLoadXML.BasisDatenElement: loadBasicData(node, charakter); break;
                    case ManagmentLoadXML.AttributeElement: loadAttribute(node, charakter); break;
                    case ManagmentLoadXML.AdvancedElement: loadAdvanced(node, charakter); break;
                    case ManagmentLoadXML.MoneyElement: loadMoney(node, charakter); break;
                    case ManagmentLoadXML.FeatureElement: loadFeature(node, charakter); break;
                    case ManagmentLoadXML.AdvanturePoints: loadAdvanturePoints(node, charakter); break;
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
                if (ManagmentLoadXML.Modification.Length < node.Name.Length)
                {
                    if (String.Compare(node.Name.Substring(0, ManagmentLoadXML.Modification.Length), ManagmentLoadXML.Modification, true) == 0)
                    {
                        int number = 0;
                        String numberString = node.Name.Substring(ManagmentLoadXML.Modification.Length, node.Name.Length - ManagmentLoadXML.Modification.Length);
                        Int32.TryParse(numberString, out number);

                        charakter.setModifikatoren(number, node.InnerText);
                    }
                }
                if (ManagmentLoadXML.Göttergeschenke.Length < node.Name.Length)
                {
                    if (String.Compare(node.Name.Substring(0, ManagmentLoadXML.Göttergeschenke.Length), ManagmentLoadXML.Göttergeschenke, true) == 0)
                    {
                        int number = 0;
                        String numberString = node.Name.Substring(ManagmentLoadXML.Göttergeschenke.Length, node.Name.Length - ManagmentLoadXML.Göttergeschenke.Length);
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
        private static void loadAdvanced(XmlNode advancedNode, Charakter charakter)
        {
            String[] name = Enum.GetNames(typeof(DSA_ADVANCEDVALUES));
            int length = Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length;

            for (int i = 0; i < length; i++)
            {
                foreach (XmlNode node in advancedNode)
                {
                    if ((node.Name).ToUpper() == name[i].ToUpper())
                    {
                        int x;
                        Int32.TryParse(node.InnerText, out x);
                        charakter.setAdvancedValueAKT((DSA_ADVANCEDVALUES)i, x);
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
                    case ManagmentLoadXML.Advantages: loadFeature(node, charakter, DSA_FEATURES.VORTEIL); break;
                    case ManagmentLoadXML.DisAdvantages: loadFeature(node, charakter, DSA_FEATURES.NACHTEIL); break;
                }
            }
        }
        private static void loadFeature(XmlNode featureNode, Charakter charakter, DSA_FEATURES type)
        {
            int i = 0;
            foreach (XmlNode node in featureNode)
            {
                i++;
                Feature feature = loadFeature(node, charakter, i);
                charakter.addFeature(type, i, feature);
            }
        }
        private static Feature loadFeature(XmlNode featureNode, Charakter charakter, int number)
        {
            Feature feature = new Feature();

            foreach (XmlNode node in featureNode)
            {
                switch (node.Name)
                {
                    case ManagmentLoadXML.Name: feature.setName(node.InnerText); break;
                    case ManagmentLoadXML.Description: feature.setDescription(node.InnerText); break;
                    case ManagmentLoadXML.Value: feature.setValue(node.InnerText); break;
                    case ManagmentLoadXML.GP: feature.setGP(node.InnerText); break;
                    case ManagmentLoadXML.AttributeElement: LoadAttribute(node, feature); break;
                    case ManagmentLoadXML.EnergienElement: LoadEnergien(node, feature); break;
                    case ManagmentLoadXML.AdvancedElement: LoadFeatureAdvanced(node, feature); break;
                    case ManagmentLoadXML.Talente: LoadFeatureTalente(node, charakter, feature); break;
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
        private static void LoadFeatureAdvanced(XmlNode advancedNode, Feature feature)
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
        private static void LoadFeatureTalente(XmlNode talentNode, Charakter charakter, Feature feature)
        {
            List<InterfaceTalent> listTalente = charakter.getAllTalentList();

            foreach(XmlNode innerTalent in talentNode)
            {
                InterfaceTalent talent = null;
                String name = "";
                String TaWBonus = "";

                foreach (XmlNode node in innerTalent)
                {
                    switch (node.Name)
                    {
                        case ManagmentLoadXML.Name: name = node.InnerText; break;
                        case ManagmentLoadXML.TAW: TaWBonus = node.InnerText; break;
                    }
                }
                for(int i=0; i<listTalente.Count; i++)
                {
                    if(0==String.Compare(listTalente[i].getName(), name))
                    {
                        talent = listTalente[i];
                        break;
                    }
                }

                int x;
                Int32.TryParse(TaWBonus, out x);

                feature.addTalent(talent, x);
            }
        }

        private static void loadTalentbrief(XmlNode TalentNode, Charakter charakter) 
        {
            foreach (XmlNode TalentType in TalentNode)
            {
                foreach (XmlNode CatecorieNode in TalentType)
                {
                    DSA_GENERALTALENTS Gtype;
                    DSA_FIGHTINGTALENTS FType;

                    if (Enum.TryParse(CatecorieNode.Name, out Gtype))
                    {
                        foreach (XmlNode Talent in CatecorieNode)
                        {
                            loadTalent(Talent, Gtype, charakter);
                        }
                    }
                    else
                    if (Enum.TryParse(CatecorieNode.Name, out FType))
                    {
                        foreach (XmlNode Talent in CatecorieNode)
                        {
                            loadTalent(Talent, FType, charakter);
                        }
                    }
                    else
                    {
                        throw new Exception();
                    }
                }
            }
        }
        private static void loadTalent<Tenum>(XmlNode TalentNode, Tenum type,  Charakter charakter) where Tenum : struct, IComparable, IFormattable, IConvertible
        {
            String Name = null;
            String Taw = null;
            String AT = null;
            String PA = null;

            foreach(XmlNode node in TalentNode)
            {
                switch (node.Name)
                {
                    case ManagmentLoadXML.Name: Name = node.InnerText; break;
                    case ManagmentLoadXML.TAW: Taw = node.InnerText; break;
                    case ManagmentLoadXML.attack: AT = node.InnerText; break;
                    case ManagmentLoadXML.Parade: PA = node.InnerText; break;
                    default: throw new Exception();
                }
            }

            Name = Name.Replace(".", " ");

            InterfaceTalent talent = charakter.getTalent(type, Name);
            if (talent == null) return;
            talent.setTaw(Taw);            

            if(AT!=null & PA != null)
            {
                FightTalent ftalent = (FightTalent)talent;

                int x = 0;

                Int32.TryParse(AT, out x);
                ftalent.setAT(x);

                Int32.TryParse(PA, out x);
                ftalent.setPA(x);
            }
            
        }
    }
}
