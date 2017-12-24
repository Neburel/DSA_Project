using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DSA_Project
{
    class LoadXMLLanguage
    {
        public LanguageFamily loadFile(String fileName)
        {
            XmlDocument languageFile = new XmlDocument();
            languageFile.Load(fileName);

            XmlNode TalentLetterElement = languageFile.SelectSingleNode("/" + ManagmentXMLStrings.TalentLetterElement);
            XmlNode LanguageElement = TalentLetterElement.SelectSingleNode(ManagmentXMLStrings.LanguageFamily);

            LanguageFamily family = new LanguageFamily();

            foreach (XmlNode node in LanguageElement)
            {
                switch (node.Name)
                {
                    case ManagmentXMLStrings.FamilyName: family.setName(node.InnerText); break;
                    case ManagmentXMLStrings.Language: loadLanguage(node, family); break;
                    default: throw new Exception("No such case");
                }
            }
            return family;
        }
        public void loadLanguage(XmlNode languagenode, LanguageFamily family)
        {
            String speakingName = "";
            int speakingComplex = 0;
            int speakingComplex2 = 0;
            String fontName = "";
            int fontComplex = 0;
            int fontComplex2 = 0;

            foreach (XmlNode node in languagenode)
            {

                switch (node.Name)
                {
                    case ManagmentXMLStrings.SpeakingName: speakingName = node.InnerText; break;
                    case ManagmentXMLStrings.SpeakingComplex: Int32.TryParse(node.InnerText, out speakingComplex); break;
                    case ManagmentXMLStrings.SpeakingComplexSecond: Int32.TryParse(node.InnerText, out speakingComplex2); break;
                    case ManagmentXMLStrings.FontName: fontName = node.InnerText; break;
                    case ManagmentXMLStrings.FontComplex: Int32.TryParse(node.InnerText, out fontComplex); break;
                    case ManagmentXMLStrings.FontComplexSecond: Int32.TryParse(node.InnerText, out fontComplex2); break;
                }
            }

            FontTalent ft;
            LanguageTalent lt;

            if (speakingComplex2 != 0)
            {
                lt = new LanguageTalent(speakingName, speakingComplex, speakingComplex2);
            } else
            {
                lt = new LanguageTalent(speakingName, speakingComplex);
            }

            if (fontComplex2 != 0)
            {
                ft = new FontTalent(fontName, fontComplex, fontComplex2);
            } else
            {
                ft = new FontTalent(fontName, fontComplex);
            }

            family.add(lt, ft);
        }
    }

}
