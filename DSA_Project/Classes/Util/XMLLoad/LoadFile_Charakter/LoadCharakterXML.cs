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
            XmlDocument characterFile   = new XmlDocument();
            XmlNode saveFile            = null;
            XmlNode characterNode       = null;
            XmlNode heldenbriefNode     = null;
            XmlNode talentbriefNode     = null;

            characterFile.Load(fileName);

            try
            {
                //Load Current Save Version -> Version2 
                saveFile = characterFile.SelectSingleNode("/" + ManagmentXMLStrings.SaveFile);
                characterNode = saveFile.SelectSingleNode(ManagmentXMLStrings.CharacterBogenElement);
                heldenbriefNode = characterNode.SelectSingleNode(ManagmentXMLStrings.HeldenBriefElement);
                talentbriefNode = characterNode.SelectSingleNode(ManagmentXMLStrings.TalentBriefElement);
            }
            catch
            {
                //Try to Load old Save Version -> Version1
                characterNode = characterFile.SelectSingleNode("/" + ManagmentXMLStrings.CharacterBogenElement);
                heldenbriefNode = characterNode.SelectSingleNode(ManagmentXMLStrings.HeldenBriefElement);
                talentbriefNode = characterNode.SelectSingleNode(ManagmentXMLStrings.TalentBriefElement);
            }
            finally
            {
                if(characterNode == null || heldenbriefNode == null || talentbriefNode == null)
                {
                    throw new Exception("this file is not Supported");
                }
            }

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
                    case ManagmentXMLStrings.BasisDatenElement: loadBasicData(node, charakter); break;
                    case ManagmentXMLStrings.AttributeElement:  loadAttribute(node, charakter); break;
                    case ManagmentXMLStrings.AdvancedElement:   loadAdvanced(node, charakter); break;
                    case ManagmentXMLStrings.MoneyElement:      loadMoney(node, charakter); break;
                    case ManagmentXMLStrings.FeatureElement:    loadFeature(node, charakter); break;
                    case ManagmentXMLStrings.AdvanturePoints:   loadAdvanturePoints(node, charakter); break;
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

            foreach (XmlNode typeNode in AttributeNode)
            {
                for (int i = 0; i < length; i++)
                {
                    if (String.Compare(typeNode.Name, name[i]) == 0)
                    {
                        foreach (XmlNode node in typeNode)
                        {
                            switch (node.Name)
                            {
                                case ManagmentXMLStrings.Value:
                                    int x;
                                    Int32.TryParse(node.InnerText, out x);
                                    charakter.setAttribute((DSA_ATTRIBUTE)i, x);
                                    break;
                                case ManagmentXMLStrings.Marked:
                                    if (0 == String.Compare(true.ToString(), node.InnerText))
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
        private static void loadAdvanturePoints(XmlNode AdvanturePoints, Charakter charakter)
        {
            int x;
            Int32.TryParse(AdvanturePoints.InnerText, out x);
            charakter.setAdventurePoints(x);
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

                if (!Int32.TryParse(Number, out number))
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
                talent = charakter.getTalent(name);

                
                int x = 0;
                Int32.TryParse(TaWBonus, out x);

                if(talent == null)
                {
                    throw new Exception("Talent darf nicht null sein");
                }

                feature.addTalent(talent, x);
            }
        }

        private static void loadTalentbrief(XmlNode TalentNode, Charakter charakter) 
        {
            foreach (XmlNode TalentType in TalentNode)
            {
                switch (TalentType.Name)
                {
                    case (ManagmentXMLStrings.GeneralTalent): loadTalentVersion2(TalentType, charakter); break;
                    case (ManagmentXMLStrings.FightingTalent): loadTalentVersion2(TalentType, charakter); break;
                    case (ManagmentXMLStrings.Language): loadTalentLanguage(TalentType, charakter); break;
                }
            }
        }
        private static void loadTalentNode(XmlNode TalentNode, Charakter charakter)
        {
            String Name = null;
            String Taw = null;
            String AT = null;
            String PA = null;
            String speakingMother = null;

            foreach(XmlNode node in TalentNode)
            {
                switch (node.Name)
                {
                    case ManagmentXMLStrings.Name: Name = node.InnerText; break;
                    case ManagmentXMLStrings.TAW: Taw = node.InnerText; break;
                    case ManagmentXMLStrings.attack: AT = node.InnerText; break;
                    case ManagmentXMLStrings.Parade: PA = node.InnerText; break;
                    case ManagmentXMLStrings.SpeakingMother: speakingMother = node.InnerText; break; 
                    default: throw new Exception(node.Name + " " + node.InnerText);
                }
            }
            if (Name == null) return;

            Name = Name.Replace(".", " ");

            InterfaceTalent talent = charakter.getTalent(Name);
            if (talent == null) return;
            talent.setTaw(Taw);            

            if(AT!=null & PA != null)
            {
                TalentFighting ftalent = (TalentFighting)talent;

                int x = 0;

                Int32.TryParse(AT, out x);
                ftalent.setAT(x);

                Int32.TryParse(PA, out x);
                ftalent.setPA(x);
            }
            if (speakingMother != null)
            {
                LanguageTalent lt = (LanguageTalent)talent;
                lt.setMotherMark(speakingMother);
            }

        }
        private static void loadTalentVersion1(XmlNode TalentNode, Charakter charakter)
        {
            foreach (XmlNode CatecorieNode in TalentNode)
            {
                foreach (XmlNode Talent in CatecorieNode)
                {
                    loadTalentNode(Talent, charakter);
                }
            }
        }
        private static void loadTalentVersion2(XmlNode TalentNode, Charakter charakter)
        {
            try
            {
                foreach (XmlNode Talent in TalentNode)
                {
                    loadTalentNode(Talent, charakter);
                }
            } catch
            {
                loadTalentVersion1(TalentNode, charakter);
            }
        }
        private static void loadTalentLanguage(XmlNode TalentNode, Charakter charakter)
        {
            LanguageTalent Typelanguage = new LanguageTalent("Type", "", 0, 0);
            Dictionary<String, List<LanguageTalent>> dictonary = new Dictionary<String, List<LanguageTalent>>();
            List<InterfaceTalent> InterfaceTalentList = charakter.getTalentList(Typelanguage);
            List<LanguageTalent> languageTalentList = new List<LanguageTalent>();

            for (int i = 0; i < InterfaceTalentList.Count; i++)
            {
                languageTalentList.Add((LanguageTalent)InterfaceTalentList[i]);
            }
            for (int i = 0; i < languageTalentList.Count; i++)
            {
                List<LanguageTalent> talentList = null;
                String FamilyName = ((LanguageTalent)languageTalentList[i]).getFamilyName();
                if (!dictonary.TryGetValue(FamilyName, out talentList))
                {
                    talentList = new List<LanguageTalent>();
                    dictonary.Add(FamilyName, talentList);
                }
                talentList.Add((LanguageTalent)languageTalentList[i]);
            }

            foreach (XmlNode LanguageFamily in TalentNode)
            {
                foreach (XmlNode Node in LanguageFamily)
                {
                    switch (Node.Name)
                    {
                        case (ManagmentXMLStrings.Language): loadTalentVersion2(Node, charakter); ; break;
                    }
                }
            }
        }
        
    }
}
