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
    public class ControllView_CreateFeatureTests
    {
        private List<InterfaceTalent> getTalentList()
        {
            List<InterfaceTalent> list = new List<InterfaceTalent>();
            InterfaceTalent talenta = new TalentCrafting("Crafting", RandomGenerator.generateAttributList(), "BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            InterfaceTalent talentb = new TalentNature("Nature", RandomGenerator.generateAttributList(), "BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            InterfaceTalent talentc = new TalentKnwoldage("Knowldage", RandomGenerator.generateAttributList(), "BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            InterfaceTalent talentd = new TalentPhysical("Physical", RandomGenerator.generateAttributList(), "BE", new List<TalentDeviate>(), new List<TalentRequirement>());

            list.Add(talenta);
            list.Add(talentb);
            list.Add(talentc);
            list.Add(talentd);

            return list;
        }


        [TestMethod]
        public void ControllView_CreateFeatureTests_setFeature()
        {
            ControllView_CreateFeature controll = new ControllView_CreateFeature(getTalentList());
            Feature feature = new Feature(DSA_FEATURES.VORTEIL);
            controll.setFeature(feature);

            Assert.AreEqual(feature, controll.getFeature());
        }
        [TestMethod]
        public void ControllView_CreateFeatureTests_setName()
        {
            ControllView_CreateFeature controll = new ControllView_CreateFeature(getTalentList());
            Feature feature = new Feature(DSA_FEATURES.VORTEIL);
            controll.setFeature(feature);

            Assert.AreEqual(feature, controll.getFeature());

            controll.FeatureName("FeatureName");

            Assert.AreEqual("FeatureName", feature.getName());
            Assert.AreEqual("FeatureName", controll.FeatureName());
        }
        [TestMethod]
        public void ControllView_CreateFeatureTests_setDescription()
        {
            ControllView_CreateFeature controll = new ControllView_CreateFeature(getTalentList());
            Feature feature = new Feature(DSA_FEATURES.VORTEIL);
            controll.setFeature(feature);

            Assert.AreEqual(feature, controll.getFeature());

            controll.FeatureDescription("FeatureDescription");

            Assert.AreEqual("FeatureDescription", feature.getSimpleDescription());
            Assert.AreEqual("FeatureDescription", controll.FeatureDescription());
        }
        [TestMethod]
        public void ControllView_CreateFeatureTests_setGP()
        {
            ControllView_CreateFeature controll = new ControllView_CreateFeature(getTalentList());
            Feature feature = new Feature(DSA_FEATURES.VORTEIL);
            controll.setFeature(feature);

            Assert.AreEqual(feature, controll.getFeature());

            String variable = "10";
            controll.FeatureGP(variable);

            Assert.AreEqual(variable, feature.getGP());
            Assert.AreEqual(variable, controll.FeatureGP());
        }
        [TestMethod]
        public void ControllView_CreateFeatureTests_setValue()
        {
            ControllView_CreateFeature controll = new ControllView_CreateFeature(getTalentList());
            Feature feature = new Feature(DSA_FEATURES.VORTEIL);
            controll.setFeature(feature);

            Assert.AreEqual(feature, controll.getFeature());

            String variable = "20";
            controll.FeatureValue(variable);

            Assert.AreEqual(variable, feature.getValue());
            Assert.AreEqual(variable, controll.FeatureValue());
        }
        [TestMethod]
        public void ControllView_CreateFeatureTests_setAttribute()
        {
            Random rand = new Random();
            ControllView_CreateFeature controll = new ControllView_CreateFeature(getTalentList());
            Feature feature = new Feature(DSA_FEATURES.VORTEIL);
            controll.setFeature(feature);

            Assert.AreEqual(feature, controll.getFeature());

            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                int value = rand.Next(100);
                DSA_ATTRIBUTE atr = (DSA_ATTRIBUTE)i;

                controll.Attribute(atr, value.ToString());

                Assert.AreEqual(value, feature.getAttributeBonus(atr));
                Assert.AreEqual(value.ToString(), controll.Attribute(atr));
            }
        }
        [TestMethod]
        public void ControllView_CreateFeatureTests_setAttributeString()
        {
            Random rand = new Random();
            ControllView_CreateFeature controll = new ControllView_CreateFeature(getTalentList());
            Feature feature = new Feature(DSA_FEATURES.VORTEIL);
            controll.setFeature(feature);

            Assert.AreEqual(feature, controll.getFeature());

            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                DSA_ATTRIBUTE atr = (DSA_ATTRIBUTE)i;

                controll.Attribute(atr, "Test");

                Assert.AreEqual(0, feature.getAttributeBonus(atr));
                Assert.AreEqual(0.ToString(), controll.Attribute(atr));
            }
        }
        [TestMethod]
        public void ControllView_CreateFeatureTests_setEnergien()
        {
            Random rand = new Random();
            ControllView_CreateFeature controll = new ControllView_CreateFeature(getTalentList());
            Feature feature = new Feature(DSA_FEATURES.VORTEIL);
            controll.setFeature(feature);

            Assert.AreEqual(feature, controll.getFeature());

            for (int i = 0; i < Enum.GetNames(typeof(DSA_ENERGIEN)).Length; i++)
            {
                int value = rand.Next(100);
                DSA_ENERGIEN type = (DSA_ENERGIEN)i;

                controll.Energie(type, value.ToString());

                Assert.AreEqual(value, feature.getEnergieBonus(type));
                Assert.AreEqual(value.ToString(), controll.Energie(type));
            }
        }
        [TestMethod]
        public void ControllView_CreateFeatureTests_setAdvanced()
        {
            Random rand = new Random();
            ControllView_CreateFeature controll = new ControllView_CreateFeature(getTalentList());
            Feature feature = new Feature(DSA_FEATURES.VORTEIL);
            controll.setFeature(feature);

            Assert.AreEqual(feature, controll.getFeature());

            for (int i = 0; i < Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length; i++)
            {
                int value = rand.Next(100);
                DSA_ADVANCEDVALUES type = (DSA_ADVANCEDVALUES)i;

                controll.Advanced(type, value.ToString());

                Assert.AreEqual(value, feature.getAdvancedValues(type));
                Assert.AreEqual(value.ToString(), controll.Advanced(type));
            }
        }
        [TestMethod]
        public void ControllView_CreateFeatureTests_getTalentbyName()
        {
            Random rand = new Random();
            List<InterfaceTalent> tlist = getTalentList();
            InterfaceTalent talenta;
            talenta = new TalentCrafting("ACrafting", RandomGenerator.generateAttributList(), "BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            tlist.Add(talenta);
            talenta = new TalentCrafting("CraftingTalent", RandomGenerator.generateAttributList(), "BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            tlist.Add(talenta);

            ControllView_CreateFeature controll = new ControllView_CreateFeature(tlist);
            Feature feature = new Feature(DSA_FEATURES.VORTEIL);
            controll.setFeature(feature);

            List<InterfaceTalent> list = controll.getTalentList();

            Assert.AreEqual(tlist, list);
        }
        [TestMethod]
        public void ControllView_CreateFeatureTests_setBonus()
        {
            Random rand = new Random();
            List<InterfaceTalent> tlist = getTalentList();
            InterfaceTalent talenta = new TalentCrafting("CraftingTalent", RandomGenerator.generateAttributList(), "BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            tlist.Add(talenta);

            ControllView_CreateFeature controll = new ControllView_CreateFeature(tlist);
            Feature feature = new Feature(DSA_FEATURES.VORTEIL);
            controll.setFeature(feature);

            List<String> list = controll.TalentewithBonus();

            Assert.AreEqual(0, list.Count);

            controll.setTawBonus("CraftingTalent", "10");
            Assert.AreEqual(10, controll.getTawBonus("CraftingTalent"));

            Assert.AreEqual(10, feature.getTaWBonus(talenta));

            list = controll.TalentewithBonus();
            Assert.AreEqual(1, list.Count);

        }
        [TestMethod]
        public void ControllView_CreateFeatureTests_setBonusTalentnotinList()
        {
            Random rand = new Random();
            List<InterfaceTalent> tlist = getTalentList();
            InterfaceTalent talenta = new TalentCrafting("CraftingTalent", RandomGenerator.generateAttributList(), "BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            
            ControllView_CreateFeature controll = new ControllView_CreateFeature(tlist);
            Feature feature = new Feature(DSA_FEATURES.VORTEIL);
            controll.setFeature(feature);

            List<String> list = controll.TalentewithBonus();

            Assert.AreEqual(0, list.Count);

            controll.setTawBonus("CraftingTalent", "10");
            Assert.AreEqual(0, controll.getTawBonus("CraftingTalent"));

            Assert.AreEqual(0, feature.getTaWBonus(talenta));            
        }
        [TestMethod]
        public void ControllView_CreateFeatureTests_removeBonus()
        {
            Random rand = new Random();
            List<InterfaceTalent> tlist = getTalentList();
            InterfaceTalent talenta = new TalentCrafting("CraftingTalent", RandomGenerator.generateAttributList(), "BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            tlist.Add(talenta);

            ControllView_CreateFeature controll = new ControllView_CreateFeature(tlist);
            Feature feature = new Feature(DSA_FEATURES.VORTEIL);
            controll.setFeature(feature);

            List<String> list = controll.TalentewithBonus();

            Assert.AreEqual(0, list.Count);

            controll.setTawBonus("CraftingTalent", "10");

            Assert.AreEqual(10, feature.getTaWBonus(talenta));
            Assert.AreEqual(10, controll.getTawBonus("CraftingTalent"));

            controll.removeTawBonus("CraftingTalent");

            Assert.AreEqual(0, feature.getTaWBonus(talenta));
            Assert.AreEqual(0, controll.getTawBonus("CraftingTalent"));
        }
    }       
}