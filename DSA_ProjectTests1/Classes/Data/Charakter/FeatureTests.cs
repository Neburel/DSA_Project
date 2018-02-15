using Microsoft.VisualStudio.TestTools.UnitTesting;
using DSA_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSA_Project.Tests
{
    /*
     * Keine Test bzüglich der Talente, Diese Finden in anderen Testen mit Statt und beweisen deren Funktionalitä
    */

    [TestClass()]
    public class FeatureTests
    {
        Random random = new Random();
        
        private static int maxValue = 40;
        private static int maxGP = 20;
        private static int DSA_AttributvalueMax = 50;
        private static int DSA_EnergienvalueMax = 50;
        private static int DSA_AdvancedvalueMax = 50;

        private String[] attributeAcronyms = Enum.GetNames(typeof(DSA_ATTRIBUTE));
        private String[] energienAcronyms = Enum.GetNames(typeof(DSA_ENERGIEN));
        private String[] advancedAcronyms = Enum.GetNames(typeof(DSA_ADVANCEDVALUES));

        private Dictionary<DSA_ATTRIBUTE, int> attributeBonus;
        private Dictionary<DSA_ENERGIEN, int> energieBonus;
        private Dictionary<DSA_ADVANCEDVALUES, int> advancedBonus;
        private Dictionary<InterfaceTalent, int> talentBoni;

        private void checkAttributValues(Feature feature)
        {
            int enumLenghtAdvanced = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;

            for (int i = 0; i < enumLenghtAdvanced; i++)
            {
                int valueout;
                if (!attributeBonus.TryGetValue((DSA_ATTRIBUTE)i, out valueout))
                {
                    throw new Exception("Test_Programming_Error");
                }
                Assert.AreEqual(valueout, feature.getAttributeBonus((DSA_ATTRIBUTE)i));
            }
        }
        private void checkEnergieValues(Feature feature)
        {
            int enumLenghtAdvanced = Enum.GetNames(typeof(DSA_ENERGIEN)).Length;

            for (int i = 0; i < enumLenghtAdvanced; i++)
            {
                int valueout;
                if (!energieBonus.TryGetValue((DSA_ENERGIEN)i, out valueout))
                {
                    throw new Exception("Test_Programming_Error");
                }
         
                Assert.AreEqual(valueout, feature.getEnergieBonus((DSA_ENERGIEN)i));
            }
        }
        private void checkAdvancedValues(Feature feature)
        {
            int enumLenghtAdvanced = Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length;

            for (int i=0; i< enumLenghtAdvanced; i++)
            {
                int valueout;
                if(!advancedBonus.TryGetValue((DSA_ADVANCEDVALUES)i, out valueout))
                {
                    throw new Exception("Test_Programming_Error");
                }

                Assert.AreEqual(valueout, feature.getAdvancedValues((DSA_ADVANCEDVALUES)i));
            }
        }
        
        private void setAttributValues(Feature feature)
        {
            int enumLenghtAttribut = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;

            for (int i = 0; i < enumLenghtAttribut; i++)
            {
                int valueout;
                if (!attributeBonus.TryGetValue((DSA_ATTRIBUTE)i, out valueout))
                {
                    throw new Exception("Test_Programming_Error");
                }
                feature.setAttributeBonus((DSA_ATTRIBUTE)i, valueout);
            }
        }
        private void setAttributValuesNegativ(Feature feature)
        {
            int enumLenghtAttribut = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;

            for (int i = 0; i < enumLenghtAttribut; i++)
            {
                int valueout;
                if (!attributeBonus.TryGetValue((DSA_ATTRIBUTE)i, out valueout))
                {
                    throw new Exception("Test_Programming_Error");
                }
                feature.setAttributeBonus((DSA_ATTRIBUTE)i, -valueout);
            }
        }

        private void setEnergieValues(Feature feature)
        {
            int enumLenghtAttribut = Enum.GetNames(typeof(DSA_ENERGIEN)).Length;

            for (int i = 0; i < enumLenghtAttribut; i++)
            {
                int valueout;
                if (!energieBonus.TryGetValue((DSA_ENERGIEN)i, out valueout))
                {
                    throw new Exception("Test_Programming_Error");
                }
                feature.setEnergieBonus((DSA_ENERGIEN)i, valueout);
            }
        }
        private void setAdvancedValues(Feature feature)
        {
            int enumLenghtAdvanced = Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length;

            for(int i=0; i< enumLenghtAdvanced; i++)
            {
                int valueout;
                if(!advancedBonus.TryGetValue((DSA_ADVANCEDVALUES)i, out valueout))
                {
                    throw new Exception("Test_Programming_Error");
                }
                feature.setAdvancedValues((DSA_ADVANCEDVALUES)i, valueout);
            }
        }
        
        private String getDescription(String Description)
        {
            Char[] trimSymbol = new Char[] { ' ', ',' };

            String totalDescription = String.Copy(Description);
            totalDescription = totalDescription + ", " + getAttributeString();
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription + ", " + getEnergieString();
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription + ", " + getAdvancedString();
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription.TrimEnd(trimSymbol);
            totalDescription = totalDescription + ", " + getTalentString();
            totalDescription = totalDescription.TrimStart(trimSymbol);
            totalDescription = totalDescription.TrimEnd(trimSymbol);

            return totalDescription;
        }
        private String getAttributeString()
        {
            String ret = "";
            int x = 0;
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                attributeBonus.TryGetValue((DSA_ATTRIBUTE)i, out x);
                if (x != 0)
                {
                    if (0 != String.Compare(ret, ""))
                    {
                        ret = ret + ", " + x + attributeAcronyms[i];
                    }
                    else
                    {
                        ret = x + attributeAcronyms[i];
                    }
                }
            }
            return ret;
        }
        private String getEnergieString()
        {
            String ret = "";
            int x = 0;
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ENERGIEN)).Length; i++)
            {
                energieBonus.TryGetValue((DSA_ENERGIEN)i, out x);
                if (x != 0)
                {
                    if (0 != String.Compare(ret, ""))
                    {
                        ret = ret + ", " + x + energienAcronyms[i];
                    }
                    else
                    {
                        ret = x + energienAcronyms[i];
                    }
                }
            }
            return ret;
        }
        private String getAdvancedString()
        {
            String ret = "";
            int x = 0;
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length; i++)
            {
                advancedBonus.TryGetValue((DSA_ADVANCEDVALUES)i, out x);
                if (x != 0)
                {
                    if (0 != String.Compare(ret, ""))
                    {
                        ret = ret + ", " + x + advancedAcronyms[i];
                    }
                    else
                    {
                        ret = x + advancedAcronyms[i];
                    }
                }
            }
            return ret;
        }
        private String getTalentString()
        {
            String ret = "";
            foreach (InterfaceTalent talent in talentBoni.Keys)
            {
                int x = 0;
                talentBoni.TryGetValue(talent, out x);
                ret = ret + talent.getName() + "(" + x + ")";
            }
            return ret;
        }


        [TestInitialize]
        public void setUP()
        {
            attributeBonus = new Dictionary<DSA_ATTRIBUTE, int>(0);
            energieBonus = new Dictionary<DSA_ENERGIEN, int>(0);
            advancedBonus = new Dictionary<DSA_ADVANCEDVALUES, int>(0);
            talentBoni = new Dictionary<InterfaceTalent, int>(0);

            int enumLenghtAttribut = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;
            int enumLenghtAdvanced = Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length;

            for (int i = 0; i < enumLenghtAttribut; i++)
            {
                attributeBonus.Add((DSA_ATTRIBUTE)i, random.Next(DSA_AttributvalueMax));
            }
            for (int i = 0; i < enumLenghtAttribut; i++)
            {
                energieBonus.Add((DSA_ENERGIEN)i, random.Next(DSA_EnergienvalueMax));
            }
            for (int i = 0; i < enumLenghtAdvanced; i++)
            {
                advancedBonus.Add((DSA_ADVANCEDVALUES)i, random.Next(DSA_AdvancedvalueMax));
            }
        }

        [TestMethod]
        public void FeatureTest_createBasic_CompleteTest_Advantage()
        {
            String Name         = "Name_" + RandomGenerator.generateName();
            String Description  = "Description_" + RandomGenerator.generateName();
            String GP           = (random.Next(maxGP)).ToString();
            String Value        = (random.Next(maxValue)).ToString();

            Feature feature = new Feature();
            feature.setGP(GP);
            feature.setName(Name);
            feature.setValue(Value);
            feature.setDescription(Description);

            setAdvancedValues(feature);
            setAttributValues(feature);
            setEnergieValues(feature);
            
            Assert.AreEqual(GP, feature.getGP());
            Assert.AreEqual(Name, feature.getName());
            Assert.AreEqual(Value, feature.getValue());
            Assert.AreEqual(Description, feature.getSimpleDescription());
            Assert.AreEqual(getDescription(Description), feature.getDescription());

            checkAdvancedValues(feature);
            checkAttributValues(feature);
            checkEnergieValues(feature);
        }
        [TestMethod]
        public void FeatureTest_createBasic_CompleteTest_DisAdvantage()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = (random.Next(maxGP)).ToString();
            String Value = (random.Next(maxValue)).ToString();

            Feature feature = new Feature();
            feature.setGP(GP);
            feature.setName(Name);
            feature.setValue(Value);
            feature.setDescription(Description);

            setAdvancedValues(feature);
            setAttributValues(feature);
            setEnergieValues(feature);

            Assert.AreEqual(GP, feature.getGP());
            Assert.AreEqual(Name, feature.getName());
            Assert.AreEqual(Value, feature.getValue());
            Assert.AreEqual(Description, feature.getSimpleDescription());
            Assert.AreEqual(getDescription(Description), feature.getDescription());

            checkAdvancedValues(feature);
            checkAttributValues(feature);
            checkEnergieValues(feature);
        }
        [TestMethod]
        public void FeatureTest_createFilled_CompleteTest_Advantage()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = (random.Next(maxGP)).ToString();
            String Value = (random.Next(maxValue)).ToString();

            Feature feature = new Feature("Test", "Test", "Test", "Test");
            feature.setGP(GP);
            feature.setName(Name);
            feature.setValue(Value);
            feature.setDescription(Description);

            setAdvancedValues(feature);
            setAttributValues(feature);
            setEnergieValues(feature);

            Assert.AreEqual(GP, feature.getGP());
            Assert.AreEqual(Name, feature.getName());
            Assert.AreEqual(Value, feature.getValue());
            Assert.AreEqual(Description, feature.getSimpleDescription());
            Assert.AreEqual(getDescription(Description), feature.getDescription());

            checkAdvancedValues(feature);
            checkAttributValues(feature);
            checkEnergieValues(feature);
        }
        [TestMethod]
        public void FeatureTest_createFilled_CompleteTest_DisAdvantage()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = (random.Next(maxGP)).ToString();
            String Value = (random.Next(maxValue)).ToString();

            Feature feature = new Feature("Test", "Test", "Test", "Test");
            feature.setGP(GP);
            feature.setName(Name);
            feature.setValue(Value);
            feature.setDescription(Description);

            setAdvancedValues(feature);
            setAttributValues(feature);
            setEnergieValues(feature);

            Assert.AreEqual(GP, feature.getGP());
            Assert.AreEqual(Name, feature.getName());
            Assert.AreEqual(Value, feature.getValue());
            Assert.AreEqual(Description, feature.getSimpleDescription());
            Assert.AreEqual(getDescription(Description), feature.getDescription());

            checkAdvancedValues(feature);
            checkAttributValues(feature);
            checkEnergieValues(feature);
        }

        [TestMethod]
        public void FeatureTest_createBasic_getGP()
        {
            Feature AD_feature = new Feature();
            Feature DI_feature = new Feature();

            Assert.AreEqual("", AD_feature.getGP());
            Assert.AreEqual("", DI_feature.getGP());
        }
        [TestMethod]
        public void FeatureTest_createFilled_getGP_Numeric()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = (random.Next(maxGP)).ToString();
            String Value = (random.Next(maxValue)).ToString();
             

            Feature AD_feature = new Feature(Name, Description, Value, GP);
            Feature DI_feature = new Feature(Name, Description, Value, GP);

            Assert.AreEqual(GP, AD_feature.getGP());
            Assert.AreEqual(GP, DI_feature.getGP());
        }
        [TestMethod]
        public void FeatureTest_createFilled_getGP_NotNumeric()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = "GP" + RandomGenerator.generateName();
            String Value = (random.Next(maxValue)).ToString();


            Feature AD_feature = new Feature(Name, Description, Value, GP);
            Feature DI_feature = new Feature(Name, Description, Value, GP);

            Assert.AreEqual("", AD_feature.getGP());
            Assert.AreEqual("", DI_feature.getGP());
        }

        [TestMethod]
        public void FeatureTest_createBasic_getName()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = "GP" + RandomGenerator.generateName();
            String Value = (random.Next(maxValue)).ToString();


            Feature AD_feature = new Feature();
            Feature DI_feature = new Feature();

            Assert.AreEqual("", AD_feature.getName());
            Assert.AreEqual("", DI_feature.getName());
        }
        [TestMethod]
        public void FeatureTest_createFilled_getName()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = "GP" + RandomGenerator.generateName();
            String Value = (random.Next(maxValue)).ToString();


            Feature AD_feature = new Feature(Name, Description, Value, GP);
            Feature DI_feature = new Feature(Name, Description, Value, GP);

            Assert.AreEqual(Name, AD_feature.getName());
            Assert.AreEqual(Name, DI_feature.getName());
        }

        [TestMethod]
        public void FeatureTest_createBasic_getValue()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = "GP" + RandomGenerator.generateName();
            String Value = (random.Next(maxValue)).ToString();


            Feature AD_feature = new Feature();
            Feature DI_feature = new Feature();

            Assert.AreEqual("", AD_feature.getValue());
            Assert.AreEqual("", DI_feature.getValue());
        }
        [TestMethod]
        public void FeatureTest_createBasic_getValue_X()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = (random.Next(maxGP)).ToString();
            String Value = "X";


            Feature AD_feature = new Feature(Name, Description, Value, GP);
            Feature DI_feature = new Feature(Name, Description, Value, GP);

            Assert.AreEqual(Value, AD_feature.getValue());
            Assert.AreEqual(Value, DI_feature.getValue());
        }
        [TestMethod]
        public void FeatureTest_createBasic_getValue_x()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = (random.Next(maxGP)).ToString();
            String Value = "x";


            Feature AD_feature = new Feature(Name, Description, Value, GP);
            Feature DI_feature = new Feature(Name, Description, Value, GP);

            Assert.AreEqual(Value.ToUpper(), AD_feature.getValue());
            Assert.AreEqual(Value.ToUpper(), DI_feature.getValue());
        }
        [TestMethod]
        public void FeatureTest_createFilled_getValue_Numeric()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = (random.Next(maxGP)).ToString();
            String Value = (random.Next(maxValue)).ToString();


            Feature AD_feature = new Feature(Name, Description, Value, GP);
            Feature DI_feature = new Feature(Name, Description, Value, GP);

            Assert.AreEqual(Value, AD_feature.getValue());
            Assert.AreEqual(Value, DI_feature.getValue());
        }
        [TestMethod]
        public void FeatureTest_createFilled_getValue_NotNumeric()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = "GP" + RandomGenerator.generateName();
            String Value = "Value" + RandomGenerator.generateName();


            Feature AD_feature = new Feature(Name, Description, Value, GP);
            Feature DI_feature = new Feature(Name, Description, Value, GP);

            Assert.AreEqual("", AD_feature.getValue());
            Assert.AreEqual("", DI_feature.getValue());
        }

        [TestMethod]
        public void FeatureTest_createBasic_getDescription()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = "GP" + RandomGenerator.generateName();
            String Value = (random.Next(maxValue)).ToString();


            Feature AD_feature = new Feature();
            Feature DI_feature = new Feature();

            Assert.AreEqual("", AD_feature.getSimpleDescription());
            Assert.AreEqual("", DI_feature.getSimpleDescription());

            Assert.AreEqual("", AD_feature.getDescription());
            Assert.AreEqual("", DI_feature.getDescription());
        }
        [TestMethod]
        public void FeatureTest_createFilled_getDescription()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = "GP" + RandomGenerator.generateName();
            String Value = (random.Next(maxValue)).ToString();
            
            Feature AD_feature = new Feature(Name, Description, Value, GP);
            Feature DI_feature = new Feature(Name, Description, Value, GP);

            Assert.AreEqual(Description, AD_feature.getSimpleDescription());
            Assert.AreEqual(Description, DI_feature.getSimpleDescription());

            Assert.AreEqual(Description, AD_feature.getDescription());
            Assert.AreEqual(Description, DI_feature.getDescription());
        }
        [TestMethod]
        public void FeatureTest_createFilled_gedComplexDescription()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = "GP" + RandomGenerator.generateName();
            String Value = (random.Next(maxValue)).ToString();
            
            Feature AD_feature = new Feature(Name, Description, Value, GP);
            Feature DI_feature = new Feature(Name, Description, Value, GP);

            setAttributValues(AD_feature);
            setEnergieValues(AD_feature);
            setAdvancedValues(AD_feature);

            setAttributValues(DI_feature);
            setEnergieValues(DI_feature);
            setAdvancedValues(DI_feature);

            Assert.AreEqual(Description, AD_feature.getSimpleDescription());
            Assert.AreEqual(Description, DI_feature.getSimpleDescription());

            Assert.AreEqual(getDescription(Description), AD_feature.getDescription());
            Assert.AreEqual(getDescription(Description), DI_feature.getDescription());
        }

        [TestMethod]
        public void FeatureTest_createBasic_getAttribute()
        {
            int enumLenghtAttribut = Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length;
            for (int i = 0; i < enumLenghtAttribut; i++)
            {
                attributeBonus.Remove((DSA_ATTRIBUTE)i);
                attributeBonus.Add((DSA_ATTRIBUTE)i, 0);
            }
            Feature AD_feature = new Feature();
            Feature DI_feature = new Feature();

            checkAttributValues(AD_feature);
            checkAttributValues(DI_feature);
        }
        [TestMethod]
        public void FeatureTest_createFilled_getAttribute()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = "GP" + RandomGenerator.generateName();
            String Value = (random.Next(maxValue)).ToString();

            Feature AD_feature = new Feature(Name, Description, Value, GP);
            Feature DI_feature = new Feature(Name, Description, Value, GP);

            setAttributValues(AD_feature);
            setAttributValues(DI_feature);

            checkAttributValues(AD_feature);
            checkAttributValues(DI_feature);
        }
        
        [TestMethod]
        public void FeatureTest_createBasic_getEnergie()
        {
            int enumLenghtAttribut = Enum.GetNames(typeof(DSA_ENERGIEN)).Length;
            for (int i = 0; i < enumLenghtAttribut; i++)
            {
                energieBonus.Remove((DSA_ENERGIEN)i);
                energieBonus.Add((DSA_ENERGIEN)i, 0);
            }
            Feature AD_feature = new Feature();
            Feature DI_feature = new Feature();

            checkEnergieValues(AD_feature);
            checkEnergieValues(DI_feature);
        }
        [TestMethod]
        public void FeatureTest_createFilled_getEnergie()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = "GP" + RandomGenerator.generateName();
            String Value = (random.Next(maxValue)).ToString();

            Feature AD_feature = new Feature(Name, Description, Value, GP);
            Feature DI_feature = new Feature(Name, Description, Value, GP);

            setEnergieValues(AD_feature);
            setEnergieValues(DI_feature);

            checkEnergieValues(AD_feature);
            checkEnergieValues(DI_feature);
        }
                
        [TestMethod]
        public void FeatureTest_createBasic_getAdvantage()
        {
            int enumLenghtAdvanced = Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length;
            for (int i = 0; i < enumLenghtAdvanced; i++)
            {
                advancedBonus.Remove((DSA_ADVANCEDVALUES)i);
                advancedBonus.Add((DSA_ADVANCEDVALUES)i, 0);
            }
            Feature AD_feature = new Feature();
            Feature DI_feature = new Feature();

            checkAdvancedValues(AD_feature);
            checkAdvancedValues(DI_feature);
        }
        [TestMethod]
        public void FeatureTest_createFilled_getAdvantage()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = "GP" + RandomGenerator.generateName();
            String Value = (random.Next(maxValue)).ToString();

            Feature AD_feature = new Feature(Name, Description, Value, GP);
            Feature DI_feature = new Feature(Name, Description, Value, GP);

            setAdvancedValues(AD_feature);
            setAdvancedValues(DI_feature);

            checkAdvancedValues(AD_feature);
            checkAdvancedValues(DI_feature);
        }
        
        [TestMethod]
        public void FeatureTest_TalentValueUnknownTalent()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = "GP" + RandomGenerator.generateName();
            String Value = (random.Next(maxValue)).ToString();

            Feature AD_feature = new Feature(Name, Description, Value, GP);
            Feature DI_feature = new Feature(Name, Description, Value, GP);

            TalentCrafting testTalent = new TalentCrafting("", new List<DSA_ATTRIBUTE>(), "", new List<TalentDeviate>(), new List<TalentRequirement>());

            Assert.AreEqual(0, AD_feature.getTaWBonus(testTalent));
            Assert.AreEqual(0, DI_feature.getTaWBonus(testTalent));
        }

        [TestMethod]
        public void FeatureTest_DescriptionWithTalent()
        {
            String Name = "Name_" + RandomGenerator.generateName();
            String Description = "Description_" + RandomGenerator.generateName();
            String GP = "GP" + RandomGenerator.generateName();
            String Value = (random.Next(maxValue)).ToString();

            Feature AD_feature = new Feature(Name, Description, Value, GP);
            Feature DI_feature = new Feature(Name, Description, Value, GP);

            TalentCrafting testTalent = new TalentCrafting("CraftingTalent", new List<DSA_ATTRIBUTE>(), "", new List<TalentDeviate>(), new List<TalentRequirement>());

            AD_feature.setTalentBonusTaW(testTalent, 10);

            setAttributValues(AD_feature);

            setEnergieValues(AD_feature);

            setAdvancedValues(AD_feature);

            String ADDescription = (getDescription(Description)) + ", CraftingTalent(10)";

            Assert.AreEqual(ADDescription, AD_feature.getDescription());
        }

    }
}