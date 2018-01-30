using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSA_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DSA_Project.Tests
{
    [TestClass()]
    public abstract class Abstract_LoadCharakterXMLTests : CharakterTestsAbstract
    {
        private ControllTalent controllTalent;

        [TestInitialize]
        public void setUP_Abstract_LoadCharakterXMLTest()
        {
            setUP_Controller();

            String path;
            path = Path.Combine(ManagmentSaveStrings.currentDirectory, ManagmentSaveStrings.Recources);
            path = Path.Combine(path, "TestResources_LoadCharakter01");
            path = Path.Combine(path, ManagmentSaveStrings.SaveLocation);
            path = Path.Combine(path, "Kazarik.xml");

            charakter = LoadCharakterXML.loadCharakter(path, charakter, this.controllTalent);
        }

        private void setUP_Controller()
        {
            String path;
            path = Path.Combine(ManagmentSaveStrings.currentDirectory, ManagmentSaveStrings.Recources);
            path = Path.Combine(path, "TestResources_LoadCharakter01");

            if (controllTalent == null)
            {
                controllTalent = new ControllTalent(path);
            }
        }
        public override List<InterfaceTalent> getTalentList()
        {
            setUP_Controller();

            List<InterfaceTalent> list = new List<InterfaceTalent>();

            list.AddRange(controllTalent.getTalentList<TalentClose>());
            list.AddRange(controllTalent.getTalentList<TalentRange>());
            list.AddRange(controllTalent.getTalentList<TalentWeaponless>());

            list.AddRange(controllTalent.getTalentList<TalentCrafting>());
            list.AddRange(controllTalent.getTalentList<TalentKnwoldage>());
            list.AddRange(controllTalent.getTalentList<TalentNature>());
            list.AddRange(controllTalent.getTalentList<TalentPhysical>());
            list.AddRange(controllTalent.getTalentList<TalentSocial>());

            list.AddRange(controllTalent.getTalentList<LanguageTalent>());
            list.AddRange(controllTalent.getTalentList<FontTalent>());


            return list;
        }
    }
}