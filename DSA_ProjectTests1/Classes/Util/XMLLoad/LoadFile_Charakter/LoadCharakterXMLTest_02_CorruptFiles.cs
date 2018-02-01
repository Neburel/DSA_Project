using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSA_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;

namespace DSA_Project.Tests
{
    [TestClass()]
    public class LoadCharakterXMLTest_02_CorruptFiles
    {
        ControllTalent controllTalent;
        
        private Charakter loadCharakter(String ResourceName, String SaveFileName)
        {
            Charakter charakter = new Charakter();
            String path;
            path = Path.Combine(ManagmentSaveStrings.currentDirectory, ManagmentSaveStrings.Recources);
            path = Path.Combine(path, ResourceName);
            controllTalent = new ControllTalent(path);
            path = Path.Combine(path, ManagmentSaveStrings.SaveLocation);
            path = Path.Combine(path, SaveFileName);

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
            charakter.addTalent(list);

            charakter = LoadCharakterXML.loadCharakter(path, charakter, this.controllTalent);
            return charakter;
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Das Talent Übeeden exestiert nicht, wurde aber versucht in dem Feature Abenteuer Gefängnis zu laden")]
        public void LoadFile_Charakter_CorruptFeatureTalent()
        {
            Charakter charakter = loadCharakter("TestResources_LoadCharakter02_CorruptFiles", "Kazarik_CorruptFeatureTalent.xml");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "Fehler bei der Featurenummerierung")]
        public void LoadFile_Charakter_CorruptFeatureNumber()
        {
            Charakter charakter = loadCharakter("TestResources_LoadCharakter02_CorruptFiles", "Kazarik_CorruptFeatureNumber.xml");            
        }
        [TestMethod]
        public void LoadFile_Charakter_CorruptTalentName()
        {
            Charakter charakter = loadCharakter("TestResources_LoadCharakter02_CorruptFiles", "Kazarik_CorruptTalentName.xml");
            Assert.IsTrue(true);
        }
        [TestMethod]
        [ExpectedException(typeof(MissingMemberException), "Corrput File. Talent Without Name")]
        public void LoadFile_Charakter_CorruptTalentNameMissing()
        {
            Charakter charakter = loadCharakter("TestResources_LoadCharakter02_CorruptFiles", "Kazarik_CorruptTalentNameMissing.xml");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "this file is not Supported")]
        public void LoadFile_Charakter_CorruptMissingTalentNode()
        {
            Charakter charakter = loadCharakter("TestResources_LoadCharakter02_CorruptFiles", "Kazarik_CorruptMissingTalentNode.xml");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "this file is not Supported")]
        public void LoadFile_Charakter_CorruptMissingCharakterNode()
        {
            Charakter charakter = loadCharakter("TestResources_LoadCharakter02_CorruptFiles", "Kazarik_CorruptCharakterNodeMissing.xml");
        }
        [TestMethod]
        [ExpectedException(typeof(Exception), "this file is not Supported")]
        public void LoadFile_Charakter_CorruptMissingHeroLetterNode()
        {
            Charakter charakter = loadCharakter("TestResources_LoadCharakter02_CorruptFiles", "Kazarik_CorruptMissingHeroLetterNode.xml");
        }
    }
}