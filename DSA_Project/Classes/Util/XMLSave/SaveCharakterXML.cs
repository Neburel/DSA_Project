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
            XmlDocument characterFile               = new XmlDocument();
            XmlElement CharakterBogenElement        = characterFile.CreateElement(ManagmentLoadXML.CharacterBogenElement);  
            XmlElement HeldenBriefElement           = characterFile.CreateElement(ManagmentLoadXML.HeldenBriefElement);
            XmlElement BasisDatenElement            = characterFile.CreateElement(ManagmentLoadXML.BasisDatenElement);
            XmlElement AttributeElement             = characterFile.CreateElement(ManagmentLoadXML.AttributeElement);
            XmlElement AdvancedValue                = characterFile.CreateElement(ManagmentLoadXML.AdvancedElement);
            XmlElement MoneyElement                 = characterFile.CreateElement(ManagmentLoadXML.MoneyElement);
            XmlElement FeatureElement               = characterFile.CreateElement(ManagmentLoadXML.FeatureElement);
            XmlElement AdvantageElement             = characterFile.CreateElement(ManagmentLoadXML.Advantages);
            XmlElement DisAdvantageElement          = characterFile.CreateElement(ManagmentLoadXML.DisAdvantages);
            XmlElement TalentBriefElement           = characterFile.CreateElement(ManagmentLoadXML.TalentBriefElement);
            XmlElement AdvanturePoints              = characterFile.CreateElement(ManagmentLoadXML.AdvanturePoints);


            saveBasisDaten(charakter, characterFile, BasisDatenElement);
            saveAttribute(charakter, characterFile, AttributeElement);
            saveAdvancedValues(charakter, characterFile, AdvancedValue);
            saveMoney(charakter, characterFile, MoneyElement);
            saveFeature(charakter, characterFile, AdvantageElement, DSA_FEATURES.VORTEIL);
            saveFeature(charakter, characterFile, DisAdvantageElement, DSA_FEATURES.NACHTEIL);
            saveTalents(charakter, characterFile, TalentBriefElement);
            saveAdventurePoints(charakter, AdvanturePoints);

            characterFile.AppendChild(CharakterBogenElement);
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
            if(fileEndung != ".xml")
            {
                fileName = fileName + ".xml";
            }
            characterFile.Save(fileName);
        }
        public static void saveBasisDaten(Charakter charakter, XmlDocument characterFile, XmlElement element)
        {
            String[] names      = Enum.GetNames(typeof(DSA_BASICVALUES));
            int length          = Enum.GetNames(typeof(DSA_BASICVALUES)).Length;

            for (int i = 0; i < length; i++)
            {
                String innerText = charakter.getBasicValue((DSA_BASICVALUES)i).ToString();
                if(innerText != "" && innerText != null)
                {
                    element.AppendChild(characterFile.CreateElement(names[i])).InnerText = innerText;
                }
            }
            
            for (int i=1, j=1; i <= 4; i++)
            {
                String innerTextMod = charakter.getModifikatoren(i);

                if(innerTextMod != null && innerTextMod != "")
                {
                    element.AppendChild(characterFile.CreateElement(ManagmentLoadXML.Modification + j)).InnerText = innerTextMod;
                    j++;
                }
            }
            for (int i = 1, j = 1; i <= 4; i++)
            {
                String innerTextGötter = charakter.getGöttergeschenk(i);

                if (innerTextGötter != null && innerTextGötter != "")
                {
                    element.AppendChild(characterFile.CreateElement(ManagmentLoadXML.Göttergeschenke + j)).InnerText = innerTextGötter;
                    j++;
                }
            }

        }
        public static void saveAttribute(Charakter charakter, XmlDocument characterFile, XmlElement element)
        {
            String[] names      = Enum.GetNames(typeof(DSA_ATTRIBUTE));
            int length          = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;

            for (int i = 0; i < length; i++)
            {
                element.AppendChild(characterFile.CreateElement(names[i])).InnerText = charakter.getAttributeAKT((DSA_ATTRIBUTE) i).ToString();
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
            String[] names      = Enum.GetNames(typeof(DSA_MONEY));
            int length          = Enum.GetNames(typeof(DSA_MONEY)).Length;

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
            for(int i=0; i<=charakter.getHighistFeatureNumber(type); i++)
            {
                Feature feature = charakter.getFeature(type, i);
                if(feature != null)
                {
                    XmlElement newFeature = characterFile.CreateElement(ManagmentLoadXML.Number + i.ToString());
                    saveFeature(feature, characterFile, newFeature);
                    element.AppendChild(newFeature);
                }
            }
        }
        private static void saveFeature(Feature feature, XmlDocument characterFile, XmlElement element)
        {
            String[] Attributenames = Enum.GetNames(typeof(DSA_ATTRIBUTE));
            String[] EnergienNames  = Enum.GetNames(typeof(DSA_ENERGIEN));
            String[] AdvanedNames   = Enum.GetNames(typeof(DSA_ADVANCEDVALUES));

            XmlElement AttributeElement = characterFile.CreateElement(ManagmentLoadXML.AttributeElement);
            XmlElement EnergienElement = characterFile.CreateElement(ManagmentLoadXML.EnergienElement);
            XmlElement AdvancedElement = characterFile.CreateElement(ManagmentLoadXML.AdvancedElement);
            XmlElement TalentElement = characterFile.CreateElement(ManagmentLoadXML.Talente);

            element.AppendChild(characterFile.CreateElement(ManagmentLoadXML.Name)).InnerText          = feature.getName();
            element.AppendChild(characterFile.CreateElement(ManagmentLoadXML.Description)).InnerText   = feature.getSimpleDescription();
            element.AppendChild(characterFile.CreateElement(ManagmentLoadXML.Value)).InnerText         = feature.getValue();
            element.AppendChild(characterFile.CreateElement(ManagmentLoadXML.GP)).InnerText            = feature.getGP();
            element.AppendChild(AttributeElement);
            element.AppendChild(EnergienElement);
            element.AppendChild(AdvancedElement);
            element.AppendChild(TalentElement);

            for(int i=0; i< Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                int x = feature.getAttributeBonus((DSA_ATTRIBUTE)i);
                if (x != 0)
                {
                    AttributeElement.AppendChild(characterFile.CreateElement(Attributenames[i])).InnerText = x.ToString();
                }
            }
            for(int i=0; i< Enum.GetNames(typeof(DSA_ENERGIEN)).Length; i++)
            {
                int x = feature.getEnergieBonus((DSA_ENERGIEN)i);
                if (x != 0)
                {
                    EnergienElement.AppendChild(characterFile.CreateElement(EnergienNames[i])).InnerText = x.ToString();
                }
            }
            for(int i=0; i< Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length; i++)
            {
                int x = feature.getAdvancedValues((DSA_ADVANCEDVALUES)i);
                if (x != 0)
                {
                    AdvancedElement.AppendChild(characterFile.CreateElement(AdvanedNames[i])).InnerText = x.ToString();
                }
            }
            foreach (InterfaceTalent talent in feature.TalentListwithBonus())
            {
                XmlElement talentinnerElement = characterFile.CreateElement(ManagmentLoadXML.TalentElement);
                XmlElement nameElement = characterFile.CreateElement(ManagmentLoadXML.Name);
                XmlElement tawBonus = characterFile.CreateElement(ManagmentLoadXML.TAW);

                nameElement.InnerText = talent.getName();
                tawBonus.InnerText = feature.getTaWBonus(talent).ToString();

                TalentElement.AppendChild(talentinnerElement);
                talentinnerElement.AppendChild(nameElement);
                talentinnerElement.AppendChild(tawBonus);
            } 
        }
        private static void saveTalents(Charakter charakter, XmlDocument characterFile, XmlElement element)
        {
            XmlElement GeneralElement   = characterFile.CreateElement(ManagmentLoadXML.GeneralTalent);
            XmlElement FightingElement  = characterFile.CreateElement(ManagmentLoadXML.FightingTalent);

            int i = 0;
            foreach (string s in Enum.GetNames(typeof(DSA_GENERALTALENTS)))
            {
                InterfaceTalent talent = null;
                XmlElement TalentElement = characterFile.CreateElement(s);

                int j = 0;
                while ((talent = charakter.getTalent((DSA_GENERALTALENTS)i,j)) != null)
                {
                    saveTalent(talent, characterFile, TalentElement);
                    j++;
                }
                i++;
                GeneralElement.AppendChild(TalentElement);                
            }
            i = 0;
            foreach (string s in Enum.GetNames(typeof(DSA_FIGHTINGTALENTS)))
            {
                InterfaceTalent talent = null;
                XmlElement TalentElement = characterFile.CreateElement(s);

                int j = 0;
                while ((talent = charakter.getTalent((DSA_FIGHTINGTALENTS)i, j)) != null)
                {
                    XmlElement TElement = saveTalent(talent, characterFile, TalentElement);
                    String pa = ((FightTalent)talent).getPA();
                    String at = ((FightTalent)talent).getAT().ToString();

                    XmlElement atElement = characterFile.CreateElement(ManagmentLoadXML.attack);
                    XmlElement paElement = characterFile.CreateElement(ManagmentLoadXML.Parade);

                    TElement.AppendChild(atElement).InnerText = at;
                    TElement.AppendChild(paElement).InnerText = pa;

                    j++;
                }
                i++;
                FightingElement.AppendChild(TalentElement);
            }


            element.AppendChild(GeneralElement);
            element.AppendChild(FightingElement);
        }
        private static XmlElement saveTalent(InterfaceTalent talent, XmlDocument characterFile, XmlElement element)
        {
            String name = talent.getName();
            String taw  = talent.getTaW().ToString();

            name = nameRplacements(name);

            XmlElement TalentElement = characterFile.CreateElement(ManagmentLoadXML.TalentElement);
            XmlElement NameElement = characterFile.CreateElement(ManagmentLoadXML.Name);            
            XmlElement TawElement  = characterFile.CreateElement(ManagmentLoadXML.TAW);
            
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
