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
    public class LanguageTalentTests_01 : LanguageAbstractTalentTests
    {
        public override List<DSA_ATTRIBUTE> getProbeList()
        {
            return new List<DSA_ATTRIBUTE> { DSA_ATTRIBUTE.KL, DSA_ATTRIBUTE.IN, DSA_ATTRIBUTE.CH };
        }

        public override LanguageAbstractTalent getLanguageAbstractTalentWithDeviate()
        {
            return getLanguageAbstractTalentWithoutDeviateRequirement();
        }
        public override LanguageAbstractTalent getLanguageAbstractTalentWithDeviateRequirement()
        {
            return getLanguageAbstractTalentWithoutDeviateRequirement();
        }
        public override LanguageAbstractTalent getLanguageAbstractTalentWithoutDeviateRequirement()
        {
            return new LanguageTalent(TalentName, BE);
        }
        public override LanguageAbstractTalent getLanguageAbstractTalentWithRequirement()
        {
            return getLanguageAbstractTalentWithoutDeviateRequirement();
        }

        [TestInitialize]
        public void setUP_LanguageAbstract()
        {
            BE = new List<String> { "2" };
        }
    }
}