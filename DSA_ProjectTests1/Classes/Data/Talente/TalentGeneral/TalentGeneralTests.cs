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
    abstract public class TalentGeneralTests : notFightingTests
    {
        internal String BE;
        internal List<TalentDeviate> deviateList;
        internal List<TalentRequirement> requirementList;
        
        public abstract TalentGeneral getTalentGeneralWithoutDeviateRequirement();
        public abstract TalentGeneral getTalentGeneralWithDeviate();
        public abstract TalentGeneral getTalentGeneralWithRequirement();
        public abstract TalentGeneral getTalentGeneralWithDeviateRequirement();
        
        public override TalentnotFighting getnotFightingWithoutDeviateRequirement()
        {
            return (TalentnotFighting)getTalentGeneralWithoutDeviateRequirement();
        }
        public override TalentnotFighting getnotFightingWithDeviate()
        {
            return (TalentnotFighting)getTalentGeneralWithDeviate();
        }
        public override TalentnotFighting getnotFightingWithRequirement()
        {
            return (TalentnotFighting)getTalentGeneralWithRequirement();
        }
        public override TalentnotFighting getNotFightingWithDeviateRequirement()
        {
            return (TalentnotFighting)getTalentGeneralWithDeviateRequirement();
        }

        public override String getBEString()
        {
            return BE;
        }

        [TestInitialize]
        public void setUPGeneralTest()
        {   
            requirementList = this.generateTestRequirements();
            deviateList = this.generateTestDeviates();
            BE = "BE_" + RandomGenerator.generateName();
        }
    }
}