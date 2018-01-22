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
    public abstract class notFightingTests : TalentTests<DSA_ATTRIBUTE>
    {
        internal List<DSA_ATTRIBUTE> attributeList;
        private notFighting talent;

        public override InterfaceTalent getTalentWithoutDeviateRequirement()
        {
            talent = getnotFightingWithoutDeviateRequirement();
            return talent;
        }
        public override InterfaceTalent getTalentWithDeviate()
        {
            talent = getnotFightingWithDeviate();
            return talent;
        }
        public override InterfaceTalent getTalentWithRequirement()
        {
            talent = getnotFightingWithRequirement();
            return talent;
        }
        public override InterfaceTalent getTalentWithDeviateRequirement()
        {
            talent = getNotFightingWithDeviateRequirement();
            return talent;
        }
        
        public abstract notFighting getnotFightingWithoutDeviateRequirement();
        public abstract notFighting getnotFightingWithDeviate();
        public abstract notFighting getnotFightingWithRequirement();
        public abstract notFighting getNotFightingWithDeviateRequirement();

        public override List<DSA_ATTRIBUTE> getProbeList()
        {
            return this.attributeList;
        }
        public override int calculateProbeWithoutTaW(Charakter charakter)
        {
            int ret = 0;
            List<DSA_ATTRIBUTE> dal = getProbeList();
            for (int i = 0; i < dal.Count; i++)
            {
                ret = ret + charakter.getAttribute_Max(dal[i]);
            }
            return ret;
        }

        public override String getProbeStringOne()
        {
            if (charakter == null) return "-";

            int ret = calculateProbeWithoutTaW(charakter);
            int taw = 0;
            if(!Int32.TryParse(talent.getTaW(), out taw))
            {
                throw new Exception("Error");
            }

            for (int i = 0; i < getProbeList().Count; i++)
            {
                ret = ret + taw;
            }
            return ret.ToString();
        }
        public override String getProbeStringTwo()
        {
            List<DSA_ATTRIBUTE> list = getProbeList();
            String ret = "";
            for (int i = 0; i < list.Count; i++)
            {
                if (i == 0)
                {
                    ret = ret + list[i].ToString();
                }
                else
                {
                    ret = ret + "/" + list[i].ToString();
                }
            }
            return ret;
        }

        [TestInitialize]
        public void setUPnotFighting()
        {
            attributeList = RandomGenerator.generateAttributList();
        }
    }
}