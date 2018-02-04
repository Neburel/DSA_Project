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
    public abstract class LanguageAbstractTalentTests : notFightingTests
    {
        static int maxComplexHigh = 50;
        static int maxComplexCount = 4;
        internal List<String> BE;

        public abstract LanguageAbstractTalent getLanguageAbstractTalentWithoutDeviateRequirement();
        public abstract LanguageAbstractTalent getLanguageAbstractTalentWithDeviate();
        public abstract LanguageAbstractTalent getLanguageAbstractTalentWithRequirement();
        public abstract LanguageAbstractTalent getLanguageAbstractTalentWithDeviateRequirement();

        public override TalentnotFighting getnotFightingWithDeviate()
        {
            return getLanguageAbstractTalentWithoutDeviateRequirement();
        }
        public override TalentnotFighting getNotFightingWithDeviateRequirement()
        {
            return getLanguageAbstractTalentWithDeviate();
        }
        public override TalentnotFighting getnotFightingWithoutDeviateRequirement()
        {
            return getLanguageAbstractTalentWithRequirement();
        }
        public override TalentnotFighting getnotFightingWithRequirement()
        {
            return getLanguageAbstractTalentWithDeviateRequirement();
        }

        public override string getBEString()
        {
            String be = convertComplexListtoString(BE);
            if (0 == String.Compare(be, ""))
            {
                return "-";
            }
            return convertComplexListtoString(BE);
        }

        public override List<TalentDeviate> getTalentDeviateList()
        {
            return new List<TalentDeviate>(0);
        }
        public override List<TalentRequirement> getTalentRequirementList()
        {
            return new List<TalentRequirement>(0);
        }

        internal List<String> generateComplexList()
        {
            Random random = new Random();
            List<String> ret = new List<String>(0);
            int x = random.Next(2, maxComplexCount);

            for (int i = 0; i < x; i++)
            {
                ret.Add(random.Next(maxComplexHigh).ToString());
            }
            return ret;
        }
        private String convertComplexListtoString(List<String> complex)
        {
            String ret = "";
            for (int i = 0; i < complex.Count; i++)
            {
                int x = 0;

                if (Int32.TryParse(complex[i], out x))
                {
                    if (i == 0)
                    {
                        ret = ret + complex[i].ToString();
                    }
                    else
                    {
                        if (i == 1)
                        {
                            ret = ret + "(" + complex[i].ToString();
                        }
                        else
                        {
                            ret = ret + "," + complex[i].ToString();
                        }
                        if (i == (complex.Count - 1))
                        {
                            ret = ret + ")";
                        }
                    }
                }
            }
            return ret;
        }

        [TestInitialize]
        public void setUPLanguageAbstractTest()
        {
            BE = generateComplexList();
        }

        [TestMethod]
        public void testStringComplex()
        {
            Random random = new Random();
            List<String> ret = new List<String>(0);
            int x = random.Next(maxComplexCount);

            for (int i = 0; i < x; i++)
            {
                ret.Add(RandomGenerator.generateName());
            }
            BE = ret;
            LanguageAbstractTalent talent = getLanguageAbstractTalentWithDeviateRequirement();

            Assert.AreEqual(getBEString(), talent.getBe());
        }

        [TestMethod]
        public void testMotherMark_RandomString_notEmpty()
        {
            LanguageAbstractTalent talent = getLanguageAbstractTalentWithDeviateRequirement();
            talent.setMotherMark(RandomGenerator.generateName());

            String.Compare("X", talent.getMotherMark());
        }

        [TestMethod]
        public void testMotherMark_EmptyString()
        {
            LanguageAbstractTalent talent = getLanguageAbstractTalentWithDeviateRequirement();
            talent.setMotherMark("");

            String.Compare("X", "");
        }
    }
}