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
    public class ControllTalentTests
    {
        [TestMethod]
        public void SimpleTest()
        {
            ControllTalent controller;
            String ResourcePath;
            ResourcePath = ManagmentSaveStrings.currentDirectory;
            ResourcePath = Path.Combine(ResourcePath, ManagmentSaveStrings.Recources);
            ResourcePath = Path.Combine(ResourcePath, "TestResources");
            controller = new ControllTalent(ResourcePath);

            List<InterfaceTalent> list = controller.getTalentList<TalentWeaponless>();
            Assert.AreEqual(2, list.Count);

            InterfaceTalent talent = controller.getTalent("Raufen");
            Assert.AreEqual(typeof(TalentWeaponless), talent.GetType());

            TalentFighting ftalent = (TalentFighting)talent;
            Assert.AreEqual("BE", ftalent.getBe());
            Assert.AreEqual("0", ftalent.getPA());
        }
        
        [TestMethod]
        public void trytoGetUnknownTalent()
        {
            ControllTalent controller;
            String ResourcePath;
            ResourcePath = ManagmentSaveStrings.currentDirectory;
            ResourcePath = Path.Combine(ResourcePath, ManagmentSaveStrings.Recources);
            ResourcePath = Path.Combine(ResourcePath, "TestResources");
            controller = new ControllTalent(ResourcePath);

            InterfaceTalent talent = controller.getTalent("Test");
            Assert.AreEqual(null, talent);
        }

        [TestMethod]
        [ExpectedException(typeof(SystemException))]
        public void NotAllStructures()
        {
            ControllTalent controller;
            String ResourcePath;
            ResourcePath = ManagmentSaveStrings.currentDirectory;
            ResourcePath = Path.Combine(ResourcePath, ManagmentSaveStrings.Recources);
            ResourcePath = Path.Combine(ResourcePath, "TestResources_01");
            controller = new ControllTalent(ResourcePath);
        }

        [TestMethod]
        [ExpectedException(typeof(FileLoadException))]
        public void checkForDoppelTalents()
        {
            ControllTalent controller;
            String ResourcePath;
            ResourcePath = ManagmentSaveStrings.currentDirectory;
            ResourcePath = Path.Combine(ResourcePath, ManagmentSaveStrings.Recources);
            ResourcePath = Path.Combine(ResourcePath, "TestResources_02");
            controller = new ControllTalent(ResourcePath);
        }

        [TestMethod]
        public void onlyStructure()
        {
            ControllTalent controller;
            String ResourcePath;
            ResourcePath = ManagmentSaveStrings.currentDirectory;
            ResourcePath = Path.Combine(ResourcePath, ManagmentSaveStrings.Recources);
            ResourcePath = Path.Combine(ResourcePath, "TestResources_03");
            controller = new ControllTalent(ResourcePath);
        }
    }
}