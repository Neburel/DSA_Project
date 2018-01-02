using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DSA_Project
{
    static class SaveCharakterXML
    {
        public static void saveCharakter(Charakter charakter, string fileName)
        {
            XmlDocument characterFile = new XmlDocument();
            XmlElement SaveFile = characterFile.CreateElement(ManagmentXMLStrings.SaveFile);
            XmlElement Version = characterFile.CreateElement(ManagmentXMLStrings.Version);
            XmlElement CharakterBogenElement = characterFile.CreateElement(ManagmentXMLStrings.CharacterBogenElement);
            XmlElement HeldenBriefElement = characterFile.CreateElement(ManagmentXMLStrings.HeldenBriefElement);
            XmlElement BasisDatenElement = characterFile.CreateElement(ManagmentXMLStrings.BasisDatenElement);
            XmlElement AttributeElement = characterFile.CreateElement(ManagmentXMLStrings.AttributeElement);
            XmlElement AdvancedValue = characterFile.CreateElement(ManagmentXMLStrings.AdvancedElement);
            XmlElement MoneyElement = characterFile.CreateElement(ManagmentXMLStrings.MoneyElement);
            XmlElement FeatureElement = characterFile.CreateElement(ManagmentXMLStrings.FeatureElement);
            XmlElement AdvantageElement = characterFile.CreateElement(ManagmentXMLStrings.Advantages);
            XmlElement DisAdvantageElement = characterFile.CreateElement(ManagmentXMLStrings.DisAdvantages);
            XmlElement TalentBriefElement = characterFile.CreateElement(ManagmentXMLStrings.TalentBriefElement);
            XmlElement AdvanturePoints = characterFile.CreateElement(ManagmentXMLStrings.AdvanturePoints);


            saveBasisDaten(charakter, characterFile, BasisDatenElement);
            saveAttribute(charakter, characterFile, AttributeElement);
            saveAdvancedValues(charakter, characterFile, AdvancedValue);
            saveMoney(charakter, characterFile, MoneyElement);
            saveFeature(charakter, characterFile, AdvantageElement, DSA_FEATURES.VORTEIL);
            saveFeature(charakter, characterFile, DisAdvantageElement, DSA_FEATURES.NACHTEIL);
            saveTalents(charakter, characterFile, TalentBriefElement);
            saveAdventurePoints(charakter, AdvanturePoints);

            characterFile.AppendChild(SaveFile);
            SaveFile.AppendChild(Version).InnerText = ManagmentXMLStrings.VersionsNumber;
            SaveFile.AppendChild(CharakterBogenElement);
            CharakterBogenElement.AppendChild(HeldenBriefElement);
            HeldenBriefElement.AppendChild(BasisDatenElement);
            HeldenBriefElement.AppendChild(AttributeElement);
            HeldenBriefElement.AppendChild(AdvancedValue);
            HeldenBriefElement.AppendChild(MoneyElement);
            HeldenBriefElement.AppendChild(FeatureElement);
            HeldenBriefElement.AppendChild(AdvanturePoints);

            FeatureElement.AppendChild(AdvantageElement);
            FeatureElement.AppendChild(DisAdvantageElement);


            CharakterBogenElement.AppendChild(TalentBriefElement);


            /*Dateiendung XML?*/
            string fileEndung = fileName.Substring(fileName.Length - 4);
            if (fileEndung != ".xml")
            {
                fileName = fileName + ".xml";
            }
            characterFile.Save(fileName);
        }
        public static void saveBasisDaten(Charakter charakter, XmlDocument characterFile, XmlElement element)
        {
            String[] names = Enum.GetNames(typeof(DSA_BASICVALUES));
            int length = Enum.GetNames(typeof(DSA_BASICVALUES)).Length;

            for (int i = 0; i < length; i++)
            {
                String innerText = charakter.getBasicValue((DSA_BASICVALUES)i).ToString();
                if (innerText != "" && innerText != null)
                {
                    element.AppendChild(characterFile.CreateElement(names[i])).InnerText = innerText;
                }
            }
        }
        public static void saveAttribute(Charakter charakter, XmlDocument characterFile, XmlElement element)
        {
            String[] names = Enum.GetNames(typeof(DSA_ATTRIBUTE));
            int length = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;

            for (int i = 0; i < length; i++)
            {
                XmlElement type = characterFile.CreateElement(names[i]);
                XmlElement value = characterFile.CreateElement(ManagmentXMLStrings.Value);
                XmlElement marked = characterFile.CreateElement(ManagmentXMLStrings.Marked);

                value.InnerText = charakter.getAttributeAKT((DSA_ATTRIBUTE)i).ToString();

                if (charakter.getMarkedAttribut((DSA_ATTRIBUTE)i))
                {
                    marked.InnerText = true.ToString();
                    type.AppendChild(marked);
                }
                type.AppendChild(value);
                element.AppendChild(type);
            }
        }
        public static void saveAdvancedValues(Charakter charakter, XmlDocument characterFile, XmlElement element)
        {
            String[] names = Enum.GetNames(typeof(DSA_ADVANCEDVALUES));
            int length = Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length;

            for (int i = 0; i < length; i++)
            {
                element.AppendChild(characterFile.CreateElement(names[i])).InnerText = charakter.getAdvancedValueAKT((DSA_ADVANCEDVALUES)i).ToString();
            }
        }
        public static void saveMoney(Charakter charakter, XmlDocument characterFile, XmlElement element)
        {
            String[] names = Enum.GetNames(typeof(DSA_MONEY));
            int length = Enum.GetNames(typeof(DSA_MONEY)).Length;

            for (int i = 0; i < length; i++)
            {
                element.AppendChild(characterFile.CreateElement(names[i])).InnerText = charakter.getMoney((DSA_MONEY)i).ToString();
            }
        }
        public static void saveAdventurePoints(Charakter charakter, XmlElement Elementadvanturepoints)
        {
            Elementadvanturepoints.InnerText = charakter.getAdvanturePoints().ToString();
        }
        public static void saveFeature(Charakter charakter, XmlDocument characterFile, XmlElement element, DSA_FEATURES type)
        {
            for (int i = 0; i <= charakter.getHighistFeatureNumber(type); i++)
            {
                Feature feature = charakter.getFeature(type, i);
                if (feature != null)
                {
                    XmlElement newFeature = characterFile.CreateElement(ManagmentXMLStrings.Number + i.ToString());
                    saveFeature(feature, characterFile, newFeature);
                    element.AppendChild(newFeature);
                }
            }
        }
        private static void saveFeature(Feature feature, XmlDocument characterFile, XmlElement element)
        {
            String[] Attributenames = Enum.GetNames(typeof(DSA_ATTRIBUTE));
            String[] EnergienNames = Enum.GetNames(typeof(DSA_ENERGIEN));
            String[] AdvanedNames = Enum.GetNames(typeof(DSA_ADVANCEDVALUES));

            XmlElement AttributeElement = characterFile.CreateElement(ManagmentXMLStrings.AttributeElement);
            XmlElement EnergienElement = characterFile.CreateElement(ManagmentXMLStrings.EnergienElement);
            XmlElement AdvancedElement = characterFile.CreateElement(ManagmentXMLStrings.AdvancedElement);
            XmlElement TalentElement = characterFile.CreateElement(ManagmentXMLStrings.Talente);

            element.AppendChild(characterFile.CreateElement(ManagmentXMLStrings.Name)).InnerText = feature.getName();
            element.AppendChild(characterFile.CreateElement(ManagmentXMLStrings.Description)).InnerText = feature.getSimpleDescription();
            element.AppendChild(characterFile.CreateElement(ManagmentXMLStrings.Value)).InnerText = feature.getValue();
            element.AppendChild(characterFile.CreateElement(ManagmentXMLStrings.GP)).InnerText = feature.getGP();
            element.AppendChild(AttributeElement);
            element.AppendChild(EnergienElement);
            element.AppendChild(AdvancedElement);
            element.AppendChild(TalentElement);

            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                int x = feature.getAttributeBonus((DSA_ATTRIBUTE)i);
                if (x != 0)
                {
                    AttributeElement.AppendChild(characterFile.CreateElement(Attributenames[i])).InnerText = x.ToString();
                }
            }
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ENERGIEN)).Length; i++)
            {
                int x = feature.getEnergieBonus((DSA_ENERGIEN)i);
                if (x != 0)
                {
                    EnergienElement.AppendChild(characterFile.CreateElement(EnergienNames[i])).InnerText = x.ToString();
                }
            }
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length; i++)
            {
                int x = feature.getAdvancedValues((DSA_ADVANCEDVALUES)i);
                if (x != 0)
                {
                    AdvancedElement.AppendChild(characterFile.CreateElement(AdvanedNames[i])).InnerText = x.ToString();
                }
            }
            foreach (InterfaceTalent talent in feature.TalentListwithBonus())
            {
                XmlElement talentinnerElement = characterFile.CreateElement(ManagmentXMLStrings.TalentElement);
                XmlElement nameElement = characterFile.CreateElement(ManagmentXMLStrings.Name);
                XmlElement tawBonus = characterFile.CreateElement(ManagmentXMLStrings.TAW);

                nameElement.InnerText = talent.getName();
                tawBonus.InnerText = feature.getTaWBonus(talent).ToString();

                TalentElement.AppendChild(talentinnerElement);
                talentinnerElement.AppendChild(nameElement);
                talentinnerElement.AppendChild(tawBonus);
            }
        }
        private static void saveTalents(Charakter charakter, XmlDocument characterFile, XmlElement element)
        {
            XmlElement GeneralElement = characterFile.CreateElement(ManagmentXMLStrings.GeneralTalent);
            XmlElement FightingElement = characterFile.CreateElement(ManagmentXMLStrings.FightingTalent);

            List<InterfaceTalent> talentList = charakter.getallTalentList();
                       

            for(int i=0; i<talentList.Count; i++)
            {
                if(talentList[i] as TalentGeneral != null)
                {
                    saveTalent(talentList[i], characterFile, GeneralElement);
                } else 
                if(talentList[i] as TalentFighting != null)
                {
                    TalentFighting fighting = (TalentFighting)talentList[i];
                    XmlElement TElement =  saveTalent(talentList[i], characterFile, FightingElement);

                    String pa = fighting.getPA();
                    String at = fighting.getAT().ToString();

                    XmlElement atElement = characterFile.CreateElement(ManagmentXMLStrings.attack);
                    XmlElement paElement = characterFile.CreateElement(ManagmentXMLStrings.Parade);

                    TElement.AppendChild(atElement).InnerText = at;
                    TElement.AppendChild(paElement).InnerText = pa;
                }
                
            }
            

            //Language
            XmlElement LanguageElement = characterFile.CreateElement(ManagmentXMLStrings.Language);
            int x = charakter.getFamilyCount();
            for (int i = 0; i < x; i++)
            {
                XmlElement FamilyElement = characterFile.CreateElement(ManagmentXMLStrings.LanguageFamily);
                LanguageElement.AppendChild(FamilyElement);

                LanguageFamily family = charakter.getFamily(i);
                XmlElement FamilyName = characterFile.CreateElement(ManagmentXMLStrings.FamilyName);
                FamilyName.InnerText = family.getName();
                FamilyElement.AppendChild(FamilyName);
                
                for (int j = 0; j < family.count(); j++)
                {
                    XmlElement underLanguage = characterFile.CreateElement(ManagmentXMLStrings.Language);
                    FamilyElement.AppendChild(underLanguage);

                    LanguageTalent lt = family.getlanguageTalent(j);
                    XmlElement ltName = characterFile.CreateElement(ManagmentXMLStrings.SpeakingName);
                    XmlElement TaWElement = characterFile.CreateElement(ManagmentXMLStrings.SpeakingTaW);
                    XmlElement MotherElement = characterFile.CreateElement(ManagmentXMLStrings.SpeakingMother);

                    ltName.InnerText = lt.getName();
                    TaWElement.InnerText = lt.getTaW();
                    MotherElement.InnerText = lt.getMotherMark();

                    underLanguage.AppendChild(ltName);
                    underLanguage.AppendChild(TaWElement);
                    underLanguage.AppendChild(MotherElement);

                    FontTalent ft = family.getFontTalent(j);
                    XmlElement FTName = characterFile.CreateElement(ManagmentXMLStrings.FontName);
                    XmlElement TaWElement2 = characterFile.CreateElement(ManagmentXMLStrings.FontTaW);
                    FTName.InnerText = ft.getName();
                    TaWElement2.InnerText = ft.getTaW();

                    underLanguage.AppendChild(FTName);
                    underLanguage.AppendChild(TaWElement2);
                }


            }

            element.AppendChild(GeneralElement);
            element.AppendChild(FightingElement);
            element.AppendChild(LanguageElement);
        }
        private static XmlElement saveTalent(InterfaceTalent talent, XmlDocument characterFile, XmlElement element)
        {
            String name = talent.getName();
            String taw = talent.getTaW().ToString();

            name = nameRplacements(name);

            XmlElement TalentElement = characterFile.CreateElement(ManagmentXMLStrings.TalentElement);
            XmlElement NameElement = characterFile.CreateElement(ManagmentXMLStrings.Name);
            XmlElement TawElement = characterFile.CreateElement(ManagmentXMLStrings.TAW);

            TalentElement.AppendChild(NameElement).InnerText = name;
            TalentElement.AppendChild(TawElement).InnerText = taw;
            element.AppendChild(TalentElement);

            return TalentElement;
        }
        private static String nameRplacements(string name)
        {
            name = name.Replace(" ", ".");
            return name;
        }
    }
}
