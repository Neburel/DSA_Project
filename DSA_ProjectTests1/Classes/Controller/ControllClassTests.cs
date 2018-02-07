using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSA_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project.Tests
{
    [TestClass()]
    public class ControllClassTests
    {
        private static int attrMax = 100;
        private Random random = new Random();


        private Dictionary<DSA_ATTRIBUTE, int> dictionaryAttr;

        ControllClass controll;
        [TestInitialize]
        public void ControllClass_setUP()
        {
            controll = new ControllClass("TestResources_LoadCharakter03_StandartVersion02");
            dictionaryAttr = new Dictionary<DSA_ATTRIBUTE, int>();

            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                dictionaryAttr.Add((DSA_ATTRIBUTE)i, random.Next(attrMax));
            }
        }

        //AtributeTest###########################################################################
        [TestMethod]
        public void ControllClass_SimpleTest_AttributeAKT()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                int x = 0;
                dictionaryAttr.TryGetValue((DSA_ATTRIBUTE)i, out x);
                int y = controll.AttributeAKT((DSA_ATTRIBUTE)i, x.ToString());

                Assert.AreEqual(x, y);
            }
        }
        [TestMethod]
        public void ControllClass_SimpleTest_AttributeMOD()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                int x = 0;
                dictionaryAttr.TryGetValue((DSA_ATTRIBUTE)i, out x);
                int y = controll.AttributeMOD((DSA_ATTRIBUTE)i, x.ToString());

                Assert.AreEqual(0, y);
            }
        }
        [TestMethod]
        public void ControllClass_SimpleTest_AttributeMAX()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                int x = 0;
                dictionaryAttr.TryGetValue((DSA_ATTRIBUTE)i, out x);
                int y = controll.AttributeMAX((DSA_ATTRIBUTE)i, x.ToString());

                Assert.AreEqual(0, y);
            }
        }
        [TestMethod]
        public void ControllClass_SimpleTest_getAttributeAKTSumme()
        {
            int w = 0;

            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                int x = 0;
                dictionaryAttr.TryGetValue((DSA_ATTRIBUTE)i, out x);
                int y = controll.AttributeAKT((DSA_ATTRIBUTE)i, x.ToString());
                
                Assert.AreEqual(x, y);

                int z = controll.getAttributeAKTSumme();

                w = w + y;
                Assert.AreEqual(w, z);
            }
        }
        [TestMethod]
        public void ControllClass_SimpleTest_getAttributeMAXSumme()
        {
            int w = 0;

            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                int x = 0;
                dictionaryAttr.TryGetValue((DSA_ATTRIBUTE)i, out x);
                int y = controll.AttributeAKT((DSA_ATTRIBUTE)i, x.ToString());

                Assert.AreEqual(x, y);

                int z = controll.getAttributeMAXSumme();

                w = w + y;
                Assert.AreEqual(w, z);
            }
        }
        [TestMethod]
        public void ControllClass_SimpleTest_getAttrbuteMark()
        {
            int w = 0;

            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                bool y = true;
                int x = random.Next(1);
                if (x == 0) y = false;
                if (x == 1) y = true;
                if (x != 0 && x != 1) Assert.Fail();

                controll.setAttributMark((DSA_ATTRIBUTE)i, y);

                Assert.AreEqual(y, controll.getAttributMark((DSA_ATTRIBUTE)i));
            }
        }
        [TestMethod]
        public void ControllClass_StringTest_AttributeAKT()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                int x = 0;
                int y = controll.AttributeAKT((DSA_ATTRIBUTE)i, "Test");

                Assert.AreEqual(x, y);
            }
        }
        [TestMethod]
        public void ControllClass_StringTest_AttributeMOD()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                String x = "Hallo";
                int y = controll.AttributeMOD((DSA_ATTRIBUTE)i, x.ToString());

                Assert.AreEqual(0, y);
            }
        }
        [TestMethod]
        public void ControllClass_StringTest_AttributeMAX()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                int x = 0;
                int y = controll.AttributeMAX((DSA_ATTRIBUTE)i, "Test");

                Assert.AreEqual(x, y);
            }
        }
        [TestMethod]
        public void ControllClass_StringTest_getAttributeAKTSumme()
        {
            int w = 0;

            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                String x = "Hallo";
                int y = controll.AttributeAKT((DSA_ATTRIBUTE)i, x);

                Assert.AreEqual(0, y);

                int z = controll.getAttributeAKTSumme();

                w = w + y;
                Assert.AreEqual(w, z);
            }
        }
        [TestMethod]
        public void ControllClass_StringTest_getAttributeMaxSumme()
        {
            int w = 0;

            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                String x = "Hallo";
                int y = controll.AttributeAKT((DSA_ATTRIBUTE)i, x);

                Assert.AreEqual(0, y);

                int z = controll.getAttributeMAXSumme();

                w = w + y;
                Assert.AreEqual(w, z);
            }
        }
        //BasicValueTest###########################################################################
        [TestMethod]
        public void ControllClass_SimpleTest_BasicValue()
        {
            int w = 0;

            for (int i = 0; i < Enum.GetNames(typeof(DSA_BASICVALUES)).Length; i++)
            {
                String x = "TestString";
                String y = controll.BasicValue((DSA_BASICVALUES)i, x);

                Assert.AreEqual(x, y);
            }
        }
        //AdvancedValues ###########################################################################
        [TestMethod]
        public void ControllClass_SimpleTest_AdvancedValue()
        {
            for(int i=0; i< Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length; i++)
            {
                DSA_ADVANCEDVALUES x = (DSA_ADVANCEDVALUES)i;
                int y = random.Next(attrMax);

                int z = controll.AdvancedValueAKT(x, y.ToString());
                int w = controll.AdvancedValueMOD(x);
                int v = controll.AdvancedValueMAX(x);

                if(x == DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT || x == DSA_ADVANCEDVALUES.ENTRÜCKUNG || x == DSA_ADVANCEDVALUES.GESCHWINDIGKEIT)
                {
                    Assert.AreEqual(y, z, 0, x.ToString());
                    Assert.AreEqual(0, w, 0, x.ToString());
                    Assert.AreEqual(y, v, 0, x.ToString());
                } else
                {
                    Assert.AreEqual(0, z, 0, x.ToString());
                    Assert.AreEqual(0, w, 0, x.ToString());
                    Assert.AreEqual(0, v, 0, x.ToString());
                }
            }
        }
        //AdvancedValues ###########################################################################
        [TestMethod]
        public void ControllClass_SimpleTest_Energie()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ENERGIEN)).Length; i++)
            {
                DSA_ENERGIEN x = (DSA_ENERGIEN)i;

                Assert.AreEqual(0, controll.EnergieVOR(x));
                Assert.AreEqual(0, controll.EnergiePERM(x));
                Assert.AreEqual(0, controll.EnergieMALI(x));
                Assert.AreEqual(0, controll.EnergieMAX(x));
            }
        }
        //Andere ###########################################################################
        [TestMethod]
        public void ControllClass_SimpleTest_Money()
        {
            for(int i=0; i<Enum.GetNames(typeof(DSA_MONEY)).Length; i++)
            {
                DSA_MONEY x = (DSA_MONEY)i;
                int y = random.Next(attrMax);

                int z = controll.Money(x, y.ToString());

                Assert.AreEqual(y, z);
            }
        }
        [TestMethod]
        public void ControllClass_SimpleTest_AdventurePoints()
        {
            int x = random.Next(attrMax);
            int y = controll.AdvanturePoints(x);

            Assert.AreEqual(x, y);
        }
        //Talente ###########################################################################
        [TestMethod]
        public void ControllClass_SimpleTest_Talente()
        {
            TalentCrafting crafting             = new TalentCrafting("Test", new List<DSA_ATTRIBUTE>(), "BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            controll.addTalent(crafting);
            
            List<TalentCrafting> controllerList     = controll.getTalentListController<TalentCrafting>();
            List<InterfaceTalent> talentListChar    = controll.getTalentList(crafting);
            List<InterfaceTalent> allTalentList     = controll.getallTalentList();

            InterfaceTalent talent              = controll.getTalent(crafting, controllerList.Count);

            Assert.AreEqual(crafting, talent);
            Assert.AreEqual(controllerList.Count + 1, talentListChar.Count);

            controll.setTaw("5", "Test");

            Assert.AreEqual(5.ToString(), crafting.getTaW());
        }
        //Family ###########################################################################
        [TestMethod]
        public void ControllClass_SimpleTest_Family()
        {
            List< String> list = controll.getFamilyList();
            LanguageFamily family =  controll.getFamilybyName(list[0]);

            LanguageTalent talent = family.getLanguageTalent(0);
            controll.setMotherMark("X", talent.getName());

            Assert.AreEqual("X", talent.getMotherMark());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ControllClass_ExceptionTest_Family()
        {
            List<String> list = controll.getFamilyList();
            LanguageFamily family = controll.getFamilybyName("FakeName");
        }
    }
}
