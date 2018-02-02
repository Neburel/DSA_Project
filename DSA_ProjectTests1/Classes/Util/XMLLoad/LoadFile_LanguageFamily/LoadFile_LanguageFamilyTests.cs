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
    public class LoadFile_LanguageFamilyTests
    {
        [TestMethod()]
        public void LanguageFamily_loadFile_Garethi()
        {
            Charakter charakter = new Charakter();
            String Resource = ResourceAcess.getResourceDir("TestResources_LoadLanguageFamily01_Standart");
            String file = ResourceAcess.getLanguageFamilyFile("TestResources_LoadLanguageFamily01_Standart", "Garethi.xml");
            ControllTalent controll = new ControllTalent(Resource);
            LoadFile_LanguageFamily loader = new LoadFile_LanguageFamily();
            charakter.addTalent(controll.getTalentList<LanguageTalent>());
            charakter.addTalent(controll.getTalentList<FontTalent>());

            LanguageFamily family = loader.loadFile(file, charakter);

            Assert.AreEqual(family.getName(), "Garethi-Familie");

            Assert.AreEqual(charakter.getTalent("Garethi"), family.getLanguageTalent(0));
            Assert.AreEqual(charakter.getTalent("Bosparano"), family.getLanguageTalent(1));
            Assert.AreEqual(charakter.getTalent("Aureliani"), family.getLanguageTalent(2));
            Assert.AreEqual("", family.getLanguageTalent(3).getName());

            Assert.AreEqual(charakter.getTalent("Kusliker Zeichen"), family.GetFontTalent(0));
            Assert.AreEqual(charakter.getTalent("Kusliker Zeichen"), family.GetFontTalent(1));
            Assert.AreEqual("", family.GetFontTalent(2).getName());
            Assert.AreEqual(charakter.getTalent("Imperiale Schriftzeichen"), family.GetFontTalent(3));
        }
        [TestMethod()]
        public void LanguageFamily_loadFileNotXML()
        {
            Charakter charakter = new Charakter();
            String Resource = ResourceAcess.getResourceDir("TestResources_LoadLanguageFamily01_Standart");
            String file = ResourceAcess.getLanguageFamilyFile("TestResources_LoadLanguageFamily01_Standart", "Garethi");
            ControllTalent controll = new ControllTalent(Resource);
            LoadFile_LanguageFamily loader = new LoadFile_LanguageFamily();
            charakter.addTalent(controll.getTalentList<LanguageTalent>());
            charakter.addTalent(controll.getTalentList<FontTalent>());

            LanguageFamily family = loader.loadFile(file, charakter);

            Assert.AreEqual(null, family);
            
        }
    }
}