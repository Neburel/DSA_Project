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
    public abstract class TalentFightingTests : TalentTests<DSA_ADVANCEDVALUES>
    {
        private static int maxTaW = 30;
        private static int maxPA = 30;
        private static int maxAT = 30;

        private TalentFighting talent;
        internal bool parade;
        internal String BE;
        internal DSA_ADVANCEDVALUES advancedvalue;
        internal List<TalentDeviate> diverateList;
        internal List<TalentRequirement> requirementList;

        int at = 0;
        int pa = 0;

        public abstract TalentFighting getTalentFightingWithDeviate();
        public abstract TalentFighting getTalentFightingWithDeviateRequirement();
        public abstract TalentFighting getTalentightingWithoutDeviateRequirement();
        public abstract TalentFighting getTalentightingWithRequirement();

        public override InterfaceTalent getTalentWithDeviate()
        {
            talent = getTalentFightingWithDeviate(); 
            return talent;
        }
        public override InterfaceTalent getTalentWithDeviateRequirement()
        {
            talent = getTalentFightingWithDeviateRequirement();
            return talent;
        }
        public override InterfaceTalent getTalentWithoutDeviateRequirement()
        {
            talent = getTalentightingWithoutDeviateRequirement();
            return talent;
        }
        public override InterfaceTalent getTalentWithRequirement()
        {
            talent = getTalentightingWithRequirement();
            return talent;
        }
        
        public override int calculateProbeWithoutTaW(Charakter charakter)
        {
            throw new NotImplementedException();
        }

        public override String getBEString()
        {
            return BE;
        }
        public override String getProbeStringOne()
        {
            int ret;

            if (charakter == null)
            {
                ret = 0;
            } else
            {
                ret = charakter.getAdvancedValueMAX(advancedvalue) + at;
            }
            return ret.ToString();
        }
        public override String getProbeStringTwo()
        {
            if (charakter == null) { return (0).ToString(); }
            return (charakter.getAdvancedValueMAX(DSA_ADVANCEDVALUES.PARADE_BASIS) + pa).ToString();
            
        }

        public override List<DSA_ADVANCEDVALUES> getProbeList()
        {
            return new List<DSA_ADVANCEDVALUES> { advancedvalue, DSA_ADVANCEDVALUES.PARADE_BASIS };
        }
        public override List<TalentDeviate> getTalentDeviateList()
        {
            return diverateList;
        }
        public override List<TalentRequirement> getTalentRequirementList()
        {
            return requirementList;
        }

        
        [TestInitialize]
        public void setUPTalentFighting()
        {
            Random random = new Random();

            BE = "BE_" + RandomGenerator.generateName();
            diverateList = generateTestDeviates();
            requirementList = new List<TalentRequirement>(0);

            int enumlenght = Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length;
            int x = random.Next(enumlenght);
            advancedvalue = (DSA_ADVANCEDVALUES)enumlenght;
            parade = true;

            at = 0;
            pa = 0;
        }

        [TestMethod]
        public void getProbeStringThree()
        {
            talent = getTalentFightingWithDeviateRequirement();
            Assert.AreEqual(advancedvalue.ToString(), talent.getProbeStringThree());
        }

        [TestMethod]
        public void setATWithoutTaW()
        {
            talent = getTalentFightingWithDeviateRequirement();
            charakter.addTalent(talent);
            talent.setAT(10);

            Assert.AreEqual(0, talent.getAT());
        }

        [TestMethod]
        public void setATWithATMaxTaWW()
        {
            Random random = new Random();
            
            talent = getTalentFightingWithDeviateRequirement();
            charakter.addTalent(talent);

            int taw = random.Next(maxTaW);
            int at = random.Next(taw);

            talent.setTaw(taw.ToString());
            talent.setAT(at);

            Assert.AreEqual(at, talent.getAT());
        }

        [TestMethod]
        public void setATWithATGreateTAW()
        {
            Random random = new Random();
            
            talent = getTalentFightingWithDeviateRequirement();
            charakter.addTalent(talent);

            int taw = random.Next(maxTaW);
            int at = random.Next(maxAT) + taw;

            talent.setTaw(taw.ToString());
            talent.setAT(at);

            Assert.AreEqual(taw, talent.getAT());
        }

        [TestMethod]
        public void setPAwithoutTAW_ParadeTrue()
        {
            parade = true;
            talent = getTalentFightingWithDeviateRequirement();
            charakter.addTalent(talent);
            talent.setPA(10);

            Assert.AreEqual((0).ToString(), talent.getPA());
        }

        [TestMethod]
        public void setPAwithTaW_ParadeTrue_PAmaxTaw()
        {
            Random random = new Random();

            parade = true;
            talent = getTalentFightingWithDeviateRequirement();
            charakter.addTalent(talent);

            int taw = random.Next(maxTaW);
            int pa = random.Next(taw);

            talent.setTaw(taw.ToString());
            talent.setPA(pa);

            Assert.AreEqual(pa.ToString(), talent.getPA());
        }

        [TestMethod]
        public void setPAWithTaW_ParadeTrue_PAGreaterTaW()
        {
            Random random = new Random();

            parade = true;
            talent = getTalentFightingWithDeviateRequirement();
            charakter.addTalent(talent);

            int taw = random.Next(maxTaW);
            int pa = random.Next(maxPA) + taw;

            talent.setTaw(taw.ToString());
            talent.setPA(pa);

            Assert.AreEqual(taw.ToString(), talent.getPA());
        }

        [TestMethod]
        public void setPAwithTaW0_ParadeTrue()
        {
            parade = true;
            talent = getTalentFightingWithDeviateRequirement();
            charakter.addTalent(talent);

            talent.setTaw("0");
            talent.setPA(10);

            Assert.AreEqual((0).ToString(), talent.getPA());
        }

        [TestMethod]
        public void setPAwithoutTAW_ParadeFalse()
        {
            parade = false;
            talent = getTalentFightingWithDeviateRequirement();
            charakter.addTalent(talent);
            talent.setPA(10);

            Assert.AreEqual(("---").ToString(), talent.getPA());
        }

        [TestMethod]
        public void setTAandPA_ATfirst()
        {
            Random random = new Random();
            talent = getTalentFightingWithDeviateRequirement();
            charakter.addTalent(talent);
            parade = true;

            int expected = 0;
            int taw = random.Next(maxTaW);
            int at = random.Next(maxAT);
            int pa = random.Next(maxPA);
            
            talent.setTaw(taw.ToString());
            talent.setAT(at);
            talent.setPA(pa);

            expected = at;
            if(taw < at)
            {
                expected = taw;
            }

            Assert.AreEqual(expected, talent.getAT());

            expected = pa;
            if(taw-at < pa)
            {
                expected = taw - at;
                if (expected < 0)
                {
                    expected = 0;
                }
            }
            Assert.AreEqual(expected.ToString(), talent.getPA());
        }

        [TestMethod]
        public void setTAandPA_PAfirst()
        {
            Random random = new Random();
            talent = getTalentFightingWithDeviateRequirement();
            charakter.addTalent(talent);
            parade = true;

            int expected = 0;
            int taw = random.Next(maxTaW);
            int at = random.Next(maxAT);
            int pa = random.Next(maxPA);

            talent.setTaw(taw.ToString());
            talent.setPA(pa);
            talent.setAT(at);

            expected = pa;
            if (taw < pa)
            {
                expected = taw;
            }
            Assert.AreEqual(expected.ToString(), talent.getPA());

            expected = at;
            if (taw-pa < at)
            {
                expected = taw - pa;
                if (expected < 0)
                {
                    expected = 0;
                }
            }

            Assert.AreEqual(expected, talent.getAT());

            
        }
    }
}