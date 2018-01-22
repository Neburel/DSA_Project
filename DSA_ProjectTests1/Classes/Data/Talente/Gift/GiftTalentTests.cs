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

        public override notFighting getnotFightingWithoutDeviateRequirement()
        {
            return new GiftTalent(TalentName, attributeList);
        }
        public override notFighting getnotFightingWithDeviate()
        {
            return new GiftTalent(TalentName, attributeList);
        }
        public override notFighting getnotFightingWithRequirement()
        {
            return new GiftTalent(TalentName, attributeList);
        }
        public override notFighting getNotFightingWithDeviateRequirement()
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