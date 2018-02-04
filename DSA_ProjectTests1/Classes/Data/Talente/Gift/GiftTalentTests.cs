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
    public class GiftTalentTests : notFightingTests
    {

        public override TalentnotFighting getnotFightingWithoutDeviateRequirement()
        {
            return new GiftTalent(TalentName, attributeList);
        }
        public override TalentnotFighting getnotFightingWithDeviate()
        {
            return new GiftTalent(TalentName, attributeList);
        }
        public override TalentnotFighting getnotFightingWithRequirement()
        {
            return new GiftTalent(TalentName, attributeList);
        }
        public override TalentnotFighting getNotFightingWithDeviateRequirement()
        {
            return new GiftTalent(TalentName, attributeList);
        }
        public override List<TalentDeviate> getTalentDeviateList()
        {
            return new List<TalentDeviate>(0);
        }
        public override List<TalentRequirement> getTalentRequirementList()
        {
            return new List<TalentRequirement>(0);
        }

        public override string getBEString()
        {
            return "-";
        }
    }
}