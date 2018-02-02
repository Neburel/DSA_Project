using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSA_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DSA_ProjectTests1._01_TestUtil;

namespace DSA_Project.Tests
{
    [TestClass()]
    public class ControllLanguageFamilyTests
    {
        [TestMethod]
        public void LanguageFamily_loadFile_Garethi()
        {
            Charakter charakter = new Charakter();
            String Resource = ResourceAcess.getResourceDir("TestResources_LoadLanguageFamily01_Standart");;

            ControllTalent controll = new ControllTalent(Resource);
            charakter.addTalent(controll.getTalentList<LanguageTalent>());
            charakter.addTalent(controll.getTalentList<FontTalent>());

            ControllLanguageFamily familyController = new ControllLanguageFamily(charakter, Resource);

            Assert.AreEqual(1, familyController.getFamilyList().Count);
            Assert.AreEqual(charakter.getTalent("Garethi"), familyController.getFamilyList()[0].getLanguageTalent(0));
            Assert.AreEqual(charakter.getTalent("Imperiale Schriftzeichen"), familyController.getFamilyList()[0].GetFontTalent(3));

        }
    }
}
