using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DSA_Project
{
    class LoadXMLTalentFile
    {
        private bool fightingTalent = false;
        

        private String[] AttributeNames = Enum.GetNames(typeof(DSA_ATTRIBUTE));

        private string TalentName;
        private List<DSA_ATTRIBUTE> probe               = new List<DSA_ATTRIBUTE>();
        private List<TalentDiverate> diverates          = new List<TalentDiverate>();
        private List<TalentRequirement>requirements     = new List<TalentRequirement>();
        private string BE = "";
        private bool parade = false;
        private DSA_ADVANCEDVALUES attace;


        public LoadXMLTalentFile()
        {
            
            return;
        }
        public InterfaceTalent loadFile(String fileName)
        {
            XmlDocument talentFile = new XmlDocument();
            talentFile.Load(fileName);

            XmlNode TalentLetterElement = talentFile.SelectSingleNode("/" + ManagmentLoadXML.TalentLetterElement);
            XmlNode TalentElement = TalentLetterElement.SelectSingleNode(ManagmentLoadXML.TalentElement);


            foreach (XmlNode node in TalentElement)
            {
                switch (node.Name)
                {
                    case ManagmentLoadXML.Name: TalentName = node.InnerText; break;
                    case ManagmentLoadXML.Probe: loadProbe(node); break;
                    case ManagmentLoadXML.BE: BE = node.InnerText; break;
                    case ManagmentLoadXML.Diverates: loadDiverates(node); break;
                    case ManagmentLoadXML.Requirements: loadRequirements(node); break;
                    case ManagmentLoadXML.FightingTalent: loadFightingTalent(node); break;
                    default: throw new Exception("No such case");
                }
            }

            if (fightingTalent == true)
            {
                return new FightTalent(TalentName, BE, diverates, attace, parade);
            }
            return new GeneralTalent(TalentName, probe, BE, diverates, requirements);

        }
        
        private void loadProbe(XmlNode ProbeNode)
        {
            foreach(XmlNode node in ProbeNode)
            {
                for(int i=0; i<AttributeNames.Length; i++)
                {
                    if(String.Compare(node.InnerText, AttributeNames[i]) == 0)
                    {
                        probe.Add((DSA_ATTRIBUTE)i);
                        break;
                    }
                }
            }
        }
        private void loadDiverates(XmlNode DiveratesNodes)
        {
            foreach (XmlNode Diveratenode in DiveratesNodes)
            {
                TalentDiverate diverate;
                String TalentName = "";
                int Value = 0;

                foreach (XmlNode node in Diveratenode)
                {
                    switch (node.Name)
                    {
                        case ManagmentLoadXML.TalentElement:    TalentName = node.InnerText; break;
                        case ManagmentLoadXML.Value:            int x; Int32.TryParse(node.InnerText, out x); Value = x; ; break;
                    }
                }
                diverate = new TalentDiverate(TalentName, Value);
                this.diverates.Add(diverate);
            }
        }
        private void loadRequirements(XmlNode Requirements)
        {
            foreach(XmlNode Requirmenet in Requirements)
            {
                TalentRequirement requirement;
                String TalentName = "";
                int Value = 0;
                int NeedAt = 0;
                int x = 0;

                foreach(XmlNode node in Requirmenet)
                {
                    switch (node.Name)
                    {
                        case ManagmentLoadXML.TalentElement:    TalentName = node.InnerText; break;
                        case ManagmentLoadXML.Value:            Int32.TryParse(node.InnerText, out x); Value = x;   break;
                        case ManagmentLoadXML.NeedAT:           Int32.TryParse(node.InnerText, out x); NeedAt = x;  break;
                    }
                }
                requirement = new TalentRequirement(TalentName, Value, NeedAt);
                requirements.Add(requirement);
            }
        }
        private void loadFightingTalent(XmlNode FightingNode)
        {
            fightingTalent = true;
            foreach(XmlNode node in FightingNode)
            {
                String[] NamesOFAdvantageElements = Enum.GetNames(typeof(DSA_ADVANCEDVALUES));

                switch (node.Name)
                {
                    case ManagmentLoadXML.attack:
                        for(int i=0; i<NamesOFAdvantageElements.Length; i++)
                        {
                            if(0 == String.Compare(NamesOFAdvantageElements[i], node.InnerText))
                            {
                                attace = (DSA_ADVANCEDVALUES)i;
                            }
                        }
                        break;
                    case ManagmentLoadXML.Parade:
                        parade = Convert.ToBoolean(node.InnerText);
                        break;

                }

            }
        }
    }
}
