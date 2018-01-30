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
    public class TalentCraftingTests : TalentGeneralTests
    {
        public override TalentGeneral getTalentGeneralWithoutDeviateRequirement()
        {
            return new TalentCrafting(TalentName, attributeList, BE, new List<TalentDeviate>(0), new List<TalentRequirement>(0));
        }
        public override TalentGeneral getTalentGeneralWithDeviate()
        {
            return new TalentCrafting(TalentName, attributeList, BE, deviateList, new List<TalentRequirement>(0));
        }
        public override TalentGeneral getTalentGeneralWithRequirement()
        {
            return new TalentCrafting(TalentName, attributeList, BE, new List<TalentDeviate>(0), requirementList);
        }
        public override TalentGeneral getTalentGeneralWithDeviateRequirement()
        {
            return new TalentCrafting(TalentName, attributeList, BE, deviateList, requirementList);
        }
        public override List<DSA_ATTRIBUTE> getProbeList()
        {
            return this.attributeList;
        }
        public override List<TalentDeviate> getTalentDeviateList()
        {
            return this.deviateList;
        }
        public override List<TalentRequirement> getTalentRequirementList()
        {
            return this.requirementList;
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "TalentCreationError: Tryed to Implement a Talent with a null List")]
        public void allNullTestRequirement()
        {
            TalentCrafting talent = new TalentCrafting("", null, "", null, null);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "TalentCreationError: Tryed to Implement a Talent with a null List")]
        public void ProbeNullTestRequirement()
        {
            TalentCrafting talent = new TalentCrafting("", null, "", new List<TalentDeviate>(), new List<TalentRequirement>());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "TalentCreationError: Tryed to Implement a Talent with a null List")]
        public void TalentDeviateNullTestRequirement()
        {
            TalentCrafting talent = new TalentCrafting("", new List<DSA_ATTRIBUTE>(), "", null, new List<TalentRequirement>());
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "TalentCreationError: Tryed to Implement a Talent with a null List")]
        public void TalentRequirementNullTestRequirement()
        {
            TalentCrafting talent = new TalentCrafting("", new List<DSA_ATTRIBUTE>(), "", new List<TalentDeviate>(), null);
        }
    }
}