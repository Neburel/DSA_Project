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
        
        public override notFighting getnotFightingWithoutDeviateRequirement()
        {
            return (notFighting)getTalentGeneralWithoutDeviateRequirement();
        }
        public override notFighting getnotFightingWithDeviate()
        {
            return (notFighting)getTalentGeneralWithDeviate();
        }
        public override notFighting getnotFightingWithRequirement()
        {
            return (notFighting)getTalentGeneralWithRequirement();
        }
        public override notFighting getNotFightingWithDeviateRequirement()
        {
            return (notFighting)getTalentGeneralWithDeviateRequirement();
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