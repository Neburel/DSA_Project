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
    public class ManagmentFeatureTests
    {
        ManagmentFeature featureManagment;
        Feature feature1;
        Feature feature5;
        InterfaceTalent talent1;

        [TestInitialize]
        public void setUP()
        {
            featureManagment = new ManagmentFeature();

            feature1 = new Feature("Feature1", "Description1", "0", "0");
            Feature feature2 = new Feature("Feature2", "Description1", "0", "0");
            Feature feature3 = new Feature("Feature3", "Description1", "0", "0");
            Feature feature4 = new Feature("Feature4", "Description1", "0", "0");
            feature5 = new Feature("Feature5", "Description1", "0", "0");
            Feature feature6 = new Feature("Feature6", "Description1", "0", "0");

            talent1 = new TalentCrafting("TestTalent", new List<DSA_ATTRIBUTE>(), "BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            
            feature3.setAttributeBonus(DSA_ATTRIBUTE.CH, 5);
            feature6.setAttributeBonus(DSA_ATTRIBUTE.CH, -2);

            feature4.setAdvancedValues(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS, 5);

            feature1.setEnergieBonus(DSA_ENERGIEN.ASTRALENERGIE, 10);
            feature2.setEnergieBonus(DSA_ENERGIEN.ASTRALENERGIE, 2);
            feature3.setEnergieBonus(DSA_ENERGIEN.ASTRALENERGIE, 3);
            feature4.setEnergieBonus(DSA_ENERGIEN.ASTRALENERGIE, 8);
            feature5.setEnergieBonus(DSA_ENERGIEN.ASTRALENERGIE, -10);
            feature6.setEnergieBonus(DSA_ENERGIEN.ASTRALENERGIE, -10);

            feature1.addTalent(talent1, 10);
            feature3.addTalent(talent1, 10);

            featureManagment.addFeature(feature1, 1);
            featureManagment.addFeature(feature2, 2);
            featureManagment.addFeature(feature3, 3);
            featureManagment.addFeature(feature4, 4);
            featureManagment.addFeature(feature5, 5);
            featureManagment.addFeature(feature6, 6);
            
        }

        [TestMethod]
        public void ManagmentFeature_getFeature()
        {
            Assert.AreEqual(feature1, featureManagment.GetFeature(1));
            Assert.AreEqual(feature5, featureManagment.GetFeature(5));
        }
        [TestMethod]
        public void ManagmentFeature_attributBons()
        {
            Assert.AreEqual(3, featureManagment.getAttributeBonus(DSA_ATTRIBUTE.CH));
        }
        [TestMethod]
        public void ManagmentFeature_advancedBonus()
        {
            Assert.AreEqual(5, featureManagment.getAdvancedBonus(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS));
        }
        [TestMethod]
        public void ManagmentFeature_energeiBonus()
        {
            Assert.AreEqual(23, featureManagment.getEnergienBonus(DSA_ENERGIEN.ASTRALENERGIE));
            Assert.AreEqual(-20, featureManagment.getEnergienMALI(DSA_ENERGIEN.ASTRALENERGIE));
        }
        [TestMethod]
        public void ManagmentFeature_TalentTest()
        {
            Assert.AreEqual(20, featureManagment.getTalentTawBonus(talent1));
        }
        [TestMethod]
        public void ManagmentFeature_getHighestNumber()
        {
            Assert.AreEqual(7, featureManagment.Count());
        }
        [TestMethod]
        public void ManagmentFeature_NumberOutofRange()
        {
            Feature feature = featureManagment.GetFeature(featureManagment.Count() + 2);
            Assert.AreEqual(7, featureManagment.Count());
            Assert.AreEqual("", feature.getName());
            Assert.AreEqual("", feature.getValue());
            Assert.AreEqual("", feature.getGP());
            Assert.AreEqual("", feature.getDescription());
        }
    }
}