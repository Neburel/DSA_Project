using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace DSA_Project
{
    static class SaveXMLTalent
    {        
        private static XmlDocument TalentFile;

        private static XmlElement LetterElement;
        private static XmlElement TalentElement;
        private static XmlElement NameElement;
        private static XmlElement ProbeElement;
        private static XmlElement Diverates;
        private static XmlElement Requirements;
        private static XmlElement BE;

        public static void saveXMLTalent(String Talentname, DSA_GENERALTALENTS talenttype, List<ListViewItem> probe, List<ListViewItem> requirements, List<ListViewItem> diverates, String BE)
        {
            constructGeneralStrukture(Talentname, BE);
            createProbeAttribute(ProbeElement, probe);
            createRequirements(Requirements, requirements);
            createDiverates(Diverates, diverates);

            SaveGeneralTalent(talenttype.ToString(), Talentname,ManagmentLoadXML.GeneralTalentFileSystemLocation);
        }
        public static void saveXMLTalent(String Talentname, DSA_FIGHTINGTALENTS talenttype, List<ListViewItem> diverates, String BE, Boolean parade)
        {
            constructGeneralStrukture(Talentname, BE);
            createDiverates(Diverates, diverates);

            DSA_ADVANCEDVALUES value = DSA_ADVANCEDVALUES.ATTACKE_BASIS;

            switch (talenttype)
            {
                case DSA_FIGHTINGTALENTS.RANGE: value = DSA_ADVANCEDVALUES.FERNKAMPF_BASIS; break;
                default: value = DSA_ADVANCEDVALUES.ATTACKE_BASIS; break;
            }

            CreateFightingTalent(TalentElement, value, parade);

            SaveGeneralTalent(talenttype.ToString(), Talentname, ManagmentLoadXML.FightingTalentsFileSystemLocation);
        }
        private static void constructGeneralStrukture(String TalentName, String be)
        {
            TalentFile = new XmlDocument();

            LetterElement   = TalentFile.CreateElement(ManagmentLoadXML.TalentLetterElement);
            TalentElement   = TalentFile.CreateElement(ManagmentLoadXML.TalentElement);
            NameElement     = TalentFile.CreateElement(ManagmentLoadXML.Name);
            ProbeElement    = TalentFile.CreateElement(ManagmentLoadXML.Probe);
            Diverates       = TalentFile.CreateElement(ManagmentLoadXML.Diverates);
            Requirements    = TalentFile.CreateElement(ManagmentLoadXML.Requirements);
            BE              = TalentFile.CreateElement(ManagmentLoadXML.BE);

            NameElement.InnerText = TalentName;
            BE.InnerText = be;

            TalentFile.AppendChild(LetterElement);
            LetterElement.AppendChild(TalentElement);
            TalentElement.AppendChild(NameElement);
            TalentElement.AppendChild(BE);
            TalentElement.AppendChild(ProbeElement);
            TalentElement.AppendChild(Diverates);
            TalentElement.AppendChild(Requirements);
        }

        private static void createProbeAttribute(XmlElement probeElement, List<ListViewItem> probe)
        {
            foreach(ListViewItem item in probe)
            {
                String attribute = item.Text;
                XmlElement attributeElement = TalentFile.CreateElement(ManagmentLoadXML.AttributeElement);
                attributeElement.InnerText = attribute;
                probeElement.AppendChild(attributeElement);
            }
        }
        private static void createRequirements(XmlElement requirementElement, List<ListViewItem> requirements)
        {
            foreach (ListViewItem item in requirements)
            {
                XmlElement RequirementElement   = TalentFile.CreateElement(ManagmentLoadXML.Requirements);
                XmlElement TalentElement        = TalentFile.CreateElement(ManagmentLoadXML.TalentElement);
                XmlElement ValueElement         = TalentFile.CreateElement(ManagmentLoadXML.Value);
                XmlElement nededATElement       = TalentFile.CreateElement(ManagmentLoadXML.NeedAT);

                TalentElement.InnerText         = item.SubItems[0].Text;
                ValueElement.InnerText          = item.SubItems[1].Text;
                nededATElement.InnerText        = item.SubItems[2].Text;

                requirementElement.AppendChild(RequirementElement);
                RequirementElement.AppendChild(TalentElement);
                RequirementElement.AppendChild(ValueElement);
                RequirementElement.AppendChild(nededATElement);
            }
        }
        private static void createDiverates(XmlElement diverateElement, List<ListViewItem> divarates)
        {
            foreach (ListViewItem item in divarates)
            {
                XmlElement DiverateElement      = TalentFile.CreateElement(ManagmentLoadXML.Diverate);
                XmlElement TalentElement        = TalentFile.CreateElement(ManagmentLoadXML.TalentElement);
                XmlElement ValueElement         = TalentFile.CreateElement(ManagmentLoadXML.Value);

                TalentElement.InnerText         = item.SubItems[0].Text;
                ValueElement.InnerText          = item.SubItems[1].Text;

                diverateElement.AppendChild(DiverateElement);
                DiverateElement.AppendChild(TalentElement);
                DiverateElement.AppendChild(ValueElement);
            }
        }

        private static void CreateFightingTalent(XmlElement TalentElement, DSA_ADVANCEDVALUES value, Boolean parade)
        {
            XmlElement FightigElement = TalentFile.CreateElement(ManagmentLoadXML.FightingTalent);
            XmlElement attacElement = TalentFile.CreateElement(ManagmentLoadXML.attack);
            XmlElement paradeElement = TalentFile.CreateElement(ManagmentLoadXML.Parade);

            attacElement.InnerText = value.ToString();
            paradeElement.InnerText = parade.ToString();

            TalentElement.AppendChild(FightigElement);
            FightigElement.AppendChild(attacElement);
            FightigElement.AppendChild(paradeElement);
        }

        private static void SaveGeneralTalent(String type, String name, String fileSystemLocation)
        {
            String Name = name;
            String filename = fileSystemLocation;
            Name = Name.Replace("/", "");
            filename = String.Concat(filename, "/", type, "/", Name, ".xml");
            
            save(filename);
        }

        private static void save(String fileName)
        {
            TalentFile.Save(fileName);
        }
    }
}
