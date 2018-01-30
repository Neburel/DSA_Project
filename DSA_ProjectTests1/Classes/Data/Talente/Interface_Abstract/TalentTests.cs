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
    public abstract class TalentTests<T>
    {
        private Random random = new Random();
        internal Charakter charakter;

        private static int maxTaW = 50;
        private static int minDeviateTaW = 5;
        private static int minCountDeviates = 1;
        private static int maxFeatureTaW = 3;
        private static int maxDeviateTaW = 30;
        private static int maxRequirementTaW = 23;
        private static int maxRequirmentTaWat = 5;
        private static int maxCountRequiremnts = 4;
        private static int maxCountDeviates = 3;

        private static int maxFeatures = 3;

        internal String TalentName;

        public abstract InterfaceTalent getTalentWithoutDeviateRequirement();
        public abstract InterfaceTalent getTalentWithDeviate();
        public abstract InterfaceTalent getTalentWithRequirement();
        public abstract InterfaceTalent getTalentWithDeviateRequirement();
        public abstract List<TalentDeviate> getTalentDeviateList();
        public abstract List<TalentRequirement> getTalentRequirementList();
        public abstract List<T> getProbeList();
        public abstract int calculateProbeWithoutTaW(Charakter charakter);
        public abstract String getBEString();
        public abstract String getProbeStringOne();
        public abstract String getProbeStringTwo();


        internal List<TalentDeviate> generateTestDeviates()
        {
            List<TalentDeviate> deviateList = new List<TalentDeviate>(0);
            for (int i = 0; i < random.Next(minCountDeviates, maxCountDeviates); i++)
            {
                String name = "Deviate_Talent_" + i + "_" + RandomGenerator.generateName();
                List<DSA_ATTRIBUTE> atl = RandomGenerator.generateAttributList();
                String be = "Be_Deviate_" + RandomGenerator.generateName();
                
                InterfaceTalent DeviateTestTalent   = new TalentCrafting(name, atl, be, new List<TalentDeviate>(0), new List<TalentRequirement>(0));
                TalentDeviate talentDeviate         = new TalentDeviate(name, random.Next(minDeviateTaW, maxDeviateTaW));

                deviateList.Add(talentDeviate);
                charakter.addTalent(DeviateTestTalent);
            }
            return deviateList;
        }
        internal List<TalentRequirement> generateTestRequirements()
        {
            List<TalentRequirement> requirementList = new List<TalentRequirement>(0);

            for (int i = 0; i < random.Next(maxCountRequiremnts); i++)
            {
                String name = "Requirement_Talent" + RandomGenerator.generateName();
                List<DSA_ATTRIBUTE> at1 = RandomGenerator.generateAttributList();
                String be = "Be_Deviate_" + RandomGenerator.generateName();

                InterfaceTalent DeviateTestTalent = new TalentCrafting(name, at1, be, new List<TalentDeviate>(0), new List<TalentRequirement>(0));
                TalentRequirement talentRequirement = new TalentRequirement(name, random.Next(maxRequirementTaW), maxRequirmentTaWat);

                requirementList.Add(talentRequirement);
                charakter.addTalent(DeviateTestTalent);
            }

            return requirementList;
        }
        internal int generateFeatures(Charakter charakter, InterfaceTalent talent)
        {
            int BonusTaW = 0;
            int advantages = random.Next(maxFeatures);
            int disadvantages = maxFeatures - advantages;

            for(int i=0; i<advantages; i++)
            {
                int j       = random.Next(1, maxFeatureTaW);
                BonusTaW    = BonusTaW + j;
                Feature Advancedfeature = new Feature("TestAdvancedFeature_" + i, "Test", "", "", DSA_FEATURES.VORTEIL);
                Advancedfeature.addTalent(talent, j);
                charakter.addFeature(i, Advancedfeature);
            }
            for (int i = 0; i < disadvantages; i++)
            {
                int j = random.Next(1, maxFeatureTaW);
                BonusTaW = BonusTaW - j;
                Feature DisAdvancedfeature = new Feature("TestDisAdvancedFeature_" + i, "Test", "", "", DSA_FEATURES.NACHTEIL);
                DisAdvancedfeature.addTalent(talent, j);
                charakter.addFeature(i, DisAdvancedfeature);
            }

            return BonusTaW;
        }

        public String getRequirementString(List<TalentRequirement> trl) 
        {
            if (trl.Count == 0)
            {
                return "-";
            }

            String ret = "";
            for (int i = 0; i < trl.Count; i++)
            {
                if (i != 0) { ret = ret + ", "; }
                String TalentName = trl[i].getTalentName();
                int value = trl[i].getValue();
                int needAt = trl[i].getNeededAtValue();

                if (needAt != 0) { ret = ret + needAt.ToString() + "+" + " "; }
                ret = ret + TalentName;
                if (value != 0) { ret = ret + " " + value.ToString(); }
            }
            return ret;
        }
        public String getDeviateString(List<TalentDeviate> trd)
        {
            if (trd.Count == 0)
            {
                return "-";
            }

            String ret = "";
            for (int i = 0; i < trd.Count; i++)
            {
                if (i > 0)
                {
                    ret = ret + ", ";
                }
                TalentDeviate diverate = trd[i];
                if (diverate.getRequiredTaW() == 0)
                {
                    ret = ret + diverate.getName();
                }
                else
                {
                    ret = ret + diverate.getName() + "(" + diverate.getRequiredTaW().ToString() + ")";
                }
            }
            return ret;
        }
        public String getTalentName()
        {
            return this.TalentName;
        }


        [TestInitialize]
        public void setUPTalentTest()
        {
            charakter = RandomGenerator.generateCharacter();
            TalentName = "Talent_" + RandomGenerator.generateName();
        }
        
        [TestMethod]
        public void JustGeneratetTest_WithoutDiverateRequirement()
        {
            charakter = null;

            InterfaceTalent talent          = getTalentWithoutDeviateRequirement();
            List<TalentRequirement> trl     = talent.getRequirementList();
            List<TalentDeviate> tdl         = talent.getDeviateList();

            Assert.AreEqual(getTalentName(), talent.getName());
            Assert.AreEqual(getProbeList().Count(), talent.getProbeCount());
            Assert.AreEqual(getProbeStringOne(), talent.getProbeStringOne());
            Assert.AreEqual(getProbeStringTwo(), talent.getProbeStringTwo());
            Assert.AreEqual("-", talent.getTaW());
            Assert.AreEqual("0", talent.getTAWBonus());
            Assert.AreEqual(getBEString(), talent.getBe());
            Assert.AreEqual(0, talent.getDeviateList().Count);
            Assert.AreEqual(0, talent.getRequirementList().Count);
            Assert.AreEqual("-", talent.getRequirementString());
            Assert.AreEqual("-", talent.getDeviateString());
            Assert.AreEqual("-", talent.getTaW());
            Assert.AreEqual("0", talent.getTAWBonus());
        }
        
        [TestMethod]
        abstract public void testGetProbeStringOne_CharakternotSet();
        [TestMethod]
        public void testGetProbeStringTwo_CharakterSet()
        {
            InterfaceTalent talent = getTalentWithDeviateRequirement();
            talent.setCharacter(charakter);
            Assert.AreEqual(getProbeStringTwo(), talent.getProbeStringTwo());
        }
        
        [TestMethod]
        public void testtoString()
        {
            InterfaceTalent talent = getTalentWithDeviateRequirement();
            Assert.AreEqual(getTalentName(), talent.ToString());
        }
        
        [TestMethod]
        public void setTaW()
        {
            InterfaceTalent talent  = getTalentWithoutDeviateRequirement();
            int TaW                 = random.Next(maxTaW);

            Assert.AreEqual("-", talent.getTaW());

            talent.setCharacter(charakter);
            talent.setTaw(TaW.ToString());

            Assert.AreEqual(TaW.ToString(), talent.getTaW());
            Assert.AreEqual(getProbeStringOne(), talent.getProbeStringOne());

            talent.setTaw("-");
            Assert.AreEqual("-", talent.getTaW());
        }

        [TestMethod]
        public void setBonusTaW()
        {
            InterfaceTalent talent = getTalentWithoutDeviateRequirement();
            Charakter charakter = RandomGenerator.generateCharacter();
            int BonusTaw = generateFeatures(charakter, talent);

            Assert.AreEqual((0).ToString(), talent.getTAWBonus());
            charakter.addTalent(talent);
            Assert.AreEqual(BonusTaw.ToString(), talent.getTAWBonus());
        }

        [TestMethod]
        public void testDeviate()
        {
            InterfaceTalent talent          = getTalentWithDeviate();
            List<TalentDeviate> deviateList = getTalentDeviateList();

            charakter.addTalent(talent);
            
            Assert.AreEqual(getDeviateString(deviateList), talent.getDeviateString());
            Assert.AreEqual(deviateList.Count, talent.getDeviateList().Count);
            
            if(deviateList.Count > 0)
            {
                Assert.AreEqual(deviateList, talent.getDeviateList());
            }

            talent.setTaw("0");
            for(int i=0; i< deviateList.Count; i++)
            {
                InterfaceTalent Dtalent = charakter.getTalent(deviateList[i].getName());
                Assert.AreEqual("0", Dtalent.getTAWBonus());
            }

            for (int i = 0; i < deviateList.Count; i++)
            {
                InterfaceTalent Dtalent = charakter.getTalent(deviateList[i].getName());
                talent.setTaw((deviateList[i].getRequiredTaW()).ToString());
                Assert.AreEqual("1", Dtalent.getTAWBonus());
            }

            //Das Doppelte ist für den Test des Entfernens (TAW sinkt) erforderlich
            talent.setTaw("0");
            for (int i = 0; i < deviateList.Count; i++)
            {
                InterfaceTalent Dtalent = charakter.getTalent(deviateList[i].getName());
                Assert.AreEqual("0", Dtalent.getTAWBonus());
            }
        }

        [TestMethod]
        public void testRequirement()
        {
            InterfaceTalent talent                  = getTalentWithRequirement();
            List<TalentRequirement> requirementList = getTalentRequirementList();

            charakter.addTalent(talent);

            Assert.AreEqual(requirementList.Count, talent.getRequirementList().Count);
            Assert.AreEqual(getRequirementString(requirementList), talent.getRequirementString());

            if(requirementList.Count > 0)
            {
                Assert.AreEqual(requirementList, talent.getRequirementList());
            }
        }

        [TestMethod()]
        [ExpectedException(typeof(NullReferenceException), "Character null")]
        public void setTaWwithoutTaW()
        {
            InterfaceTalent talent = getTalentWithDeviateRequirement();
            talent.setTaw("0");
            Assert.Fail();
        }

        [TestMethod()]
        [ExpectedException(typeof(Exception))]
        public void Talent_notExistingDiverate()
        {
            TalentCrafting craftingTalent = new TalentCrafting("notExist", RandomGenerator.generateAttributList(), "", new List<TalentDeviate> { new TalentDeviate("____", 0) }, new List<TalentRequirement>());
            charakter.addTalent(craftingTalent);
            craftingTalent.setTaw("10");
            Assert.Fail();
        }
    }
}