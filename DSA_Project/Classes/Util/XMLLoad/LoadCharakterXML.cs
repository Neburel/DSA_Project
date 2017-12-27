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

            XmlNode characterNode       = characterFile.SelectSingleNode("/" + ManagmentXMLStrings.CharacterBogenElement);
            XmlNode heldenbriefNode     = characterNode.SelectSingleNode(ManagmentXMLStrings.HeldenBriefElement);
            XmlNode talentbriefNode     = characterNode.SelectSingleNode(ManagmentXMLStrings.TalentBriefElement);

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
                    case ManagmentXMLStrings.BasisDatenElement: loadBasicData(node, charakter); break;
                    case ManagmentXMLStrings.AttributeElement: loadAttribute(node, charakter); break;
                    case ManagmentXMLStrings.AdvancedElement: loadAdvanced(node, charakter); break;
                    case ManagmentXMLStrings.MoneyElement: loadMoney(node, charakter); break;
                    case ManagmentXMLStrings.FeatureElement: loadFeature(node, charakter); break;
                    case ManagmentXMLStrings.AdvanturePoints: loadAdvanturePoints(node, charakter); break;
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
        }
        private static void loadAttribute(XmlNode AttributeNode, Charakter charakter)
        {
            String[] name = Enum.GetNames(typeof(DSA_ATTRIBUTE));
            int length = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;

            foreach(XmlNode typeNode in AttributeNode)
            {
                for(int i=0; i<length; i++)
                {
                    if(String.Compare(typeNode.Name, name[i]) == 0)
                    {
                        foreach(XmlNode node in typeNode)
                        {
                            switch (node.Name)
                            {
                                case ManagmentXMLStrings.Value:
                                    int x;
                                    Int32.TryParse(node.InnerText, out x);
                                    charakter.setAttribute((DSA_ATTRIBUTE)i, x);
                                    break;
                                case ManagmentXMLStrings.Marked:
                                    if(0 == String.Compare(true.ToString(), node.InnerText))
                                    {
                                        charakter.setMarkedAttribut((DSA_ATTRIBUTE)i, true);
                                    }
                                    break;
                            }
                        }
                        break;
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
                    case ManagmentXMLStrings.Advantages: loadFeature(node, charakter, DSA_FEATURES.VORTEIL); break;
                    case ManagmentXMLStrings.DisAdvantages: loadFeature(node, charakter, DSA_FEATURES.NACHTEIL); break;
                }
            }
        }
        private static void loadFeature(XmlNode featureNode, Charakter charakter, DSA_FEATURES type)
        {
            int i = 0;
            String BasicString = "Number";

            foreach (XmlNode node in featureNode)
            {
                i++;
                Feature feature = loadFeature(node, charakter, i, type);
                feature.setType(type);

                int number = 0;
                String Number = node.Name.Substring(BasicString.Length, node.Name.Length - BasicString.Length);

                if(!Int32.TryParse(Number, out number))
                {
                    throw new Exception();
                }
                charakter.addFeature(type, number, feature);                
            }
        }
        private static Feature loadFeature(XmlNode featureNode, Charakter charakter, int number, DSA_FEATURES type)
        {
            Feature feature = new Feature(type);

            foreach (XmlNode node in featureNode)
            {
                switch (node.Name)
                {
                    case ManagmentXMLStrings.Name: feature.setName(node.InnerText); break;
                    case ManagmentXMLStrings.Description: feature.setDescription(node.InnerText); break;
                    case ManagmentXMLStrings.Value: feature.setValue(node.InnerText); break;
                    case ManagmentXMLStrings.GP: feature.setGP(node.InnerText); break;
                    case ManagmentXMLStrings.AttributeElement: LoadAttribute(node, feature); break;
                    case ManagmentXMLStrings.EnergienElement: LoadEnergien(node, feature); break;
                    case ManagmentXMLStrings.AdvancedElement: LoadFeatureAdvanced(node, feature); break;
                    case ManagmentXMLStrings.Talente: LoadFeatureTalente(node, charakter, feature); break;
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
                        case ManagmentXMLStrings.Name: name = node.InnerText; break;
                        case ManagmentXMLStrings.TAW: TaWBonus = node.InnerText; break;
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
                switch (TalentType.Name)
                {
                    case (ManagmentXMLStrings.GeneralTalent): loadTalent(TalentType, charakter); break;
                    case (ManagmentXMLStrings.FightingTalent): loadTalent(TalentType, charakter); break;
                    case (ManagmentXMLStrings.Language): loadTalentLanguage(TalentType, charakter); break;
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
                    case ManagmentXMLStrings.Name: Name = node.InnerText; break;
                    case ManagmentXMLStrings.TAW: Taw = node.InnerText; break;
                    case ManagmentXMLStrings.attack: AT = node.InnerText; break;
                    case ManagmentXMLStrings.Parade: PA = node.InnerText; break;
                    default: throw new Exception();
                }
            }

            Name = Name.Replace(".", " ");

            InterfaceTalent talent = charakter.getTalent(type, Name);
            if (talent == null) return;
            talent.setTaw(Taw);            

            if(AT!=null & PA != null)
            {
                FightingTalent ftalent = (FightingTalent)talent;

                int x = 0;

                Int32.TryParse(AT, out x);
                ftalent.setAT(x);

                Int32.TryParse(PA, out x);
                ftalent.setPA(x);
            }
            
        }
        private static void loadTalent(XmlNode TalentNode, Charakter charakter)
        {
            foreach (XmlNode CatecorieNode in TalentNode)
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
            }
        }
        private static void loadTalentLanguage(XmlNode TalentNode, Charakter charakter)
        {
            foreach(XmlNode LanguageFamily in TalentNode)
            {
                String familyName = "";
                XmlNode innerNode = null;

                foreach (XmlNode Node in LanguageFamily)
                {
                    switch (Node.Name)
                    {
                        case (ManagmentXMLStrings.FamilyName): familyName = Node.InnerText; break;
                        case (ManagmentXMLStrings.Language): innerNode = Node; break;
                    }

                    if (String.Compare(familyName, "") != 0 && innerNode != null)
                    {
                        if (String.Compare(familyName, "Zwergisch-Familie") == 0)
                        {
                            Console.WriteLine("Test");
                        }


                        int x = charakter.getFamilyCount();
                        LanguageFamily family = null;

                        for (int i = 0; i < x; i++)
                        {
                            LanguageFamily fam = charakter.getFamily(i);
                            if (String.Compare(fam.getName(), familyName) == 0)
                            {
                                family = fam;
                                break;
                            }
                        }
                        if (family != null)
                        {
                            String Speakingname = "";
                            String SpeakingTaW = "";
                            String SpeakingMother = "";
                            String FontName = "";
                            String FontTaW = "";

                            foreach (XmlNode node in innerNode)
                            {
                                switch (node.Name)
                                {
                                    case (ManagmentXMLStrings.SpeakingName): Speakingname = node.InnerText; break;
                                    case (ManagmentXMLStrings.SpeakingTaW): SpeakingTaW = node.InnerText; break;
                                    case (ManagmentXMLStrings.SpeakingMother): SpeakingMother = node.InnerText; break;
                                    case (ManagmentXMLStrings.FontName): FontName = node.InnerText; break;
                                    case (ManagmentXMLStrings.FontTaW): FontTaW = node.InnerText; break;
                                }
                            }

                            for (int i = 0; i < family.count(); i++)
                            {
                                LanguageTalent lt = family.getlanguageTalent(i);
                                FontTalent ft = family.getFontTalent(i);

                                if (String.Compare(Speakingname, lt.getName()) == 0 && String.Compare(FontName, ft.getName()) == 0)
                                {
                                    lt.setTaw(SpeakingTaW);
                                    lt.setMotherMark(SpeakingMother);
                                    ft.setTaw(FontTaW);
                                }
                            }

                        }
                    }
                }
            }
        }
    }
}
