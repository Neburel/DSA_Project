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
    public class TalentRequirementTests
    {
        String TalentName = "TalentRequirement";
        int value = 4;
        int needAt = 5;
        
        TalentRequirement requirement_withoutNeedAT;
        TalentRequirement requirement_withNeedAT;

        [TestInitialize]
        public void setUP()
        {
            requirement_withoutNeedAT   = new TalentRequirement(TalentName, value);
            requirement_withNeedAT      = new TalentRequirement(TalentName, value, needAt);
        }


        [TestMethod]
        public void TalentRequirement_getTalentName()
        {
            Assert.AreEqual(TalentName, requirement_withNeedAT.getTalentName());
            Assert.AreEqual(TalentName, requirement_withoutNeedAT.getTalentName());
        }
        [TestMethod]
        public void TalentRequirement_getNeedAT()
        {
            Assert.AreEqual(needAt, requirement_withNeedAT.getNeededAtValue());
            Assert.AreEqual(0, requirement_withoutNeedAT.getNeededAtValue());
        }
        [TestMethod]
        public void TalentRequirement_getValue()
        {
            Assert.AreEqual(value, requirement_withNeedAT.getValue());
            Assert.AreEqual(value, requirement_withoutNeedAT.getValue());
        }
    }
}