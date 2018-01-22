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
    public class TalentWeaponlessTests : TalentFightingTests
    {
        public override TalentFighting getTalentFightingWithDeviate()
        {
            return new TalentWeaponless(TalentName, BE, diverateList, advancedvalue, parade);
        }
        public override TalentFighting getTalentFightingWithDeviateRequirement()
        {
            return new TalentWeaponless(TalentName, BE, diverateList, advancedvalue, parade);
        }
        public override TalentFighting getTalentightingWithoutDeviateRequirement()
        {
            return new TalentWeaponless(TalentName, BE, new List<TalentDeviate>(0), advancedvalue, parade);
        }
        public override TalentFighting getTalentightingWithRequirement()
        {
            return new TalentWeaponless(TalentName, BE, new List<TalentDeviate>(0), advancedvalue, parade);
        }
    }
}