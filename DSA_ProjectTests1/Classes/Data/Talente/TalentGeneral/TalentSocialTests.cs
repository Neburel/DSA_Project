﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSA_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project.Tests
{
    [TestClass()]
    public class TalentSocialTests : TalentGeneralTests
    {
        public override TalentGeneral getTalentGeneralWithoutDeviateRequirement()
        {
            return new TalentSocial(TalentName, attributeList, BE, new List<TalentDeviate>(0), new List<TalentRequirement>(0));
        }
        public override TalentGeneral getTalentGeneralWithDeviate()
        {
            return new TalentSocial(TalentName, attributeList, BE, deviateList, new List<TalentRequirement>(0));
        }
        public override TalentGeneral getTalentGeneralWithRequirement()
        {
            return new TalentSocial(TalentName, attributeList, BE, new List<TalentDeviate>(0), requirementList);
        }
        public override TalentGeneral getTalentGeneralWithDeviateRequirement()
        {
            return new TalentSocial(TalentName, attributeList, BE, deviateList, requirementList);
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
    }
}