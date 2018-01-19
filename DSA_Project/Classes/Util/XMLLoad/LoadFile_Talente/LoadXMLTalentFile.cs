using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DSA_Project
{
    public class LoadXMLTalentFile : Interface_LoadXMLTalentFile
    {
        private String[] AttributeNames = Enum.GetNames(typeof(DSA_ATTRIBUTE));

        int pos = 0;
        //Einfache Talente
        private string TalentName;
        private List<DSA_ATTRIBUTE> probe               = new List<DSA_ATTRIBUTE>();
        private List<TalentDeviate> diverates           = new List<TalentDeviate>();
        private List<TalentRequirement>requirements     = new List<TalentRequirement>();
        private List<String> BElist                     = new List<String>();
        private string BE = "";
        private bool parade = false;
        private DSA_ADVANCEDVALUES attace;

        //Language
        String FamilyName = "";
        String languageTalentName = "";
        int languageTalentComplex = 0;
        int languageTalentComplex2 = 0;

        private void clear()
        {
            pos = 0;

            TalentName      = "";
            parade          = false;
            probe           = new List<DSA_ATTRIBUTE>(0);
            diverates       = new List<TalentDeviate>(0);
            requirements    = new List<TalentRequirement>(0);
            BElist          = new List<String>(0);

            FamilyName = "";
            languageTalentName = "";
            languageTalentComplex = 0;
            languageTalentComplex2 = 0;
        }

        public T loadFile<T>(String fileName) where T: InterfaceTalent
        {
            clear();
            load(fileName);

            String BE = "";

            if(BElist.Count > 0)
            {
                BE = BElist[BElist.Count - 1];
            }
            
            ConstructorInfo constructor = null;
            object magicClassObject     = null;
            Type type                   = typeof(T);
            Type[] typeArray            = null;
            
            if (typeof(TalentGeneral).IsAssignableFrom(type))
            {
                typeArray = new Type[] { typeof(String), typeof(List<DSA_ATTRIBUTE>), typeof(String), typeof(List<TalentDeviate>), typeof(List<TalentRequirement>) };
                constructor = type.GetConstructor(typeArray);
                magicClassObject = constructor.Invoke(new object[] { TalentName, probe, BE, diverates, requirements });
            } else
            if (typeof(TalentFighting).IsAssignableFrom(type))
            {
                typeArray = new Type[] { typeof(String), typeof(String), typeof(List<TalentDeviate>), typeof(DSA_ADVANCEDVALUES), typeof(bool) };
                constructor = type.GetConstructor(typeArray);
                magicClassObject = constructor.Invoke(new object[] { TalentName, BE, diverates, attace, parade });
            } else
            if (typeof(LanguageTalent).IsAssignableFrom(type) || typeof(FontTalent).IsAssignableFrom(type))
            {
                typeArray = new Type[] { typeof(String), typeof(List<String>) };
                constructor = type.GetConstructor(typeArray);
                magicClassObject = constructor.Invoke(new object[] { TalentName, BElist });                
            } else
            if (typeof(GiftTalent).IsAssignableFrom(type))
            {
                typeArray = new Type[] { typeof(String), typeof(List<DSA_ATTRIBUTE>) };
                constructor = type.GetConstructor(typeArray);
                magicClassObject = constructor.Invoke(new object[] { TalentName, probe });
            }
            else
            {
                throw new Exception("Hierfür nicht Configuriert");
            }
            return (T)magicClassObject;
        }
        private void load(String fileName)
        {
            XmlDocument talentFile = new XmlDocument();
            talentFile.Load(fileName);

            XmlNode TalentLetterElement = talentFile.SelectSingleNode("/" + ManagmentXMLStrings.TalentLetterElement);
            XmlNode TalentElement = TalentLetterElement.SelectSingleNode(ManagmentXMLStrings.TalentElement);

            if (TalentElement != null)
            {
                loadGeneralTalent(TalentElement);
            }
        }
        //################################################################################################
        private void loadGeneralTalent(XmlNode TalentElement)
        {
            foreach (XmlNode node in TalentElement)
            {
                switch (node.Name)
                {
                    case ManagmentXMLStrings.Name: TalentName = node.InnerText; break;
                    case ManagmentXMLStrings.Probe: loadProbe(node); break;
                    case ManagmentXMLStrings.BE: BElist.Add(node.InnerText); break;
                    case ManagmentXMLStrings.Diverates: loadDiverates(node); break;
                    case ManagmentXMLStrings.Requirements: loadRequirements(node); break;
                    case ManagmentXMLStrings.FightingTalent: loadFightingTalent(node); break;
                    default: throw new Exception("CorrupT File Detected");
                }
            }
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
                TalentDeviate diverate;
                String TalentName = "";
                int Value = 0;

                foreach (XmlNode node in Diveratenode)
                {
                    switch (node.Name)
                    {
                        case ManagmentXMLStrings.TalentElement:    TalentName = node.InnerText; break;
                        case ManagmentXMLStrings.Value:            int x; Int32.TryParse(node.InnerText, out x); Value = x; ; break;
                    }
                }
                diverate = new TalentDeviate(TalentName, Value);
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
                        case ManagmentXMLStrings.TalentElement:    TalentName = node.InnerText; break;
                        case ManagmentXMLStrings.Value:            Int32.TryParse(node.InnerText, out x); Value = x;   break;
                        case ManagmentXMLStrings.NeedAT:           Int32.TryParse(node.InnerText, out x); NeedAt = x;  break;
                    }
                }
                requirement = new TalentRequirement(TalentName, Value, NeedAt);
                requirements.Add(requirement);
            }
        }
        private void loadFightingTalent(XmlNode FightingNode)
        {
            foreach (XmlNode node in FightingNode)
            {
                String[] NamesOFAdvantageElements = Enum.GetNames(typeof(DSA_ADVANCEDVALUES));

                switch (node.Name)
                {
                    case ManagmentXMLStrings.attack:
                        for (int i = 0; i < NamesOFAdvantageElements.Length; i++)
                        {
                            if (0 == String.Compare(NamesOFAdvantageElements[i], node.InnerText))
                            {
                                attace = (DSA_ADVANCEDVALUES)i;
                            }
                        }
                        break;
                    case ManagmentXMLStrings.Parade:
                        parade = Convert.ToBoolean(node.InnerText);
                        break;

                }

            }
        }
        //################################################################################################
    }
}
