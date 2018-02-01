using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DSA_Project
{
    public class LoadFile_LanguageFamily 
    {
        LanguageFamily LanguageFamily;
        Charakter charakter;
        String FileName;
        
        private Boolean TestIFxmlFile(String filename)
        {
            String ending = filename.Substring(filename.Length-3);
            if(String.Compare(ending.ToLower(), "xml") == 0)
            {
                return true;
            }
            return false;
        }
        private void clear()
        {
            LanguageFamily = null;
            charakter = null;
            FileName = "";
        }
        public LanguageFamily loadFile(String fileName, Charakter charakter) 
        {
            clear();
            this.charakter = charakter;
            this.FileName = fileName;
            if (!TestIFxmlFile(fileName))
            {
                return null;
            }
            
            load(fileName);
            return LanguageFamily;
        }
        private void load(String fileName)
        {
            XmlDocument talentFile = new XmlDocument();
            talentFile.Load(fileName);

            XmlNode TalentLetterElement = talentFile.SelectSingleNode("/" + ManagmentXMLStrings.TalentLetterElement);
            XmlNode LanguageFamilyElement = TalentLetterElement.SelectSingleNode(ManagmentXMLStrings.LanguageFamily);

            if (LanguageFamilyElement != null)
            {
                loadFamily(LanguageFamilyElement);
            }
        }
        //################################################################################################
        private void loadFamily(XmlNode LanguageFamilyElement)
        {
            String FamilyName;

            foreach (XmlNode node in LanguageFamilyElement)
            {
                switch (node.Name)
                {
                    case ManagmentXMLStrings.Name:
                        FamilyName = node.InnerText;
                        LanguageFamily = new LanguageFamily(FamilyName);
                        break;
                    case ManagmentXMLStrings.Row: loadRow(node); break;
                }
            }
        }
        private void loadRow(XmlNode rowElement)
        {
            String FontName = null;
            String LanguageName = null;

            FontTalent fTalent = null;
            LanguageTalent ltalent = null;

            foreach (XmlNode node in rowElement)
            {
                switch (node.Name)
                {
                    case ManagmentXMLStrings.Language: LanguageName = node.InnerText; break;
                    case ManagmentXMLStrings.Font: FontName = node.InnerText; break;
                }
            }
            if (0 != String.Compare("", FontName) && FontName != null)
            {
                fTalent = (FontTalent)charakter.getTalent(FontName);
            }
            else
            {
                fTalent = new FontTalent("",new List<string>());
            }
            if (0 != String.Compare("", LanguageName) && LanguageName != null)
            {
                ltalent = (LanguageTalent)charakter.getTalent(LanguageName);
            } else
            {
                ltalent = new LanguageTalent("", new List<string>());
            }

            LanguageFamily.addLanguageRow(ltalent, fTalent);
        }
        //################################################################################################
    }
}
