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
    abstract public class CharakterTestsAbstract
    {
        internal Charakter charakter;
        private ManagmentFeature managmentFeature;
        private Dictionary<DSA_BASICVALUES, String> basicValueDicionary;
        private Dictionary<DSA_ENERGIEN, int> energienDictionary_VOR;
        private Dictionary<DSA_ATTRIBUTE, int> attributeDictionary;
        private Dictionary<DSA_ADVANCEDVALUES, int> advancedDictionary;
        private Dictionary<DSA_ATTRIBUTE, bool> attributeMarkedDictionary;
        private Dictionary<DSA_MONEY, int> moneyDictionary;
        private List<InterfaceTalent> talentList;
        private Dictionary<Feature, int> featureDictionary;
        private int advanturePoints;


        public abstract Dictionary<DSA_BASICVALUES, String> getBasicValuesDictionary();
        public abstract Dictionary<DSA_ATTRIBUTE, int> getAttributeDictonary();
        public abstract Dictionary<DSA_ADVANCEDVALUES, int> getAdvancedDictonary();
        public abstract Dictionary<DSA_ATTRIBUTE, bool> getAttributeMarkedDictonary();
        public abstract Dictionary<DSA_MONEY, int> getmoneyDictionary();
        public abstract Dictionary<Feature, int> getFeatureDictionary();
        public abstract List<InterfaceTalent> getTalentList();
        public abstract int getAdventurePoints();

        [TestInitialize]
        public void setUP()
        {
            charakter           = new Charakter();
            managmentFeature    = new ManagmentFeature();

            setUP_Talente();
            setUP_Features();
            setUP_BasicValues();
            setUP_Attribute();
            setUP_Energien();
            setUP_Advanced();
            setUP_Andere();
        }
        private void setUP_BasicValues()
        {
            basicValueDicionary = getBasicValuesDictionary();

            for(int i=0; i<Enum.GetNames(typeof(DSA_BASICVALUES)).Length; i++)
            {
                String value;
                if(!basicValueDicionary.TryGetValue((DSA_BASICVALUES)i, out value)){
                    value = "";
                    basicValueDicionary.Add((DSA_BASICVALUES)i, value);
                }
                charakter.setBasicValues((DSA_BASICVALUES)i, value);
            }
        }
        private void setUP_Attribute()
        {
            attributeDictionary = getAttributeDictonary();
            attributeMarkedDictionary = getAttributeMarkedDictonary();

            for(int i=0; i<Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                int value;
                bool boolvalue;

                attributeDictionary.TryGetValue((DSA_ATTRIBUTE)i, out value);
                attributeMarkedDictionary.TryGetValue((DSA_ATTRIBUTE)i, out boolvalue);     //wenn kein wert vorhanden ist boolvalue false

                charakter.setAttribute((DSA_ATTRIBUTE)i, value);
                charakter.setMarkedAttribut((DSA_ATTRIBUTE)i, boolvalue);
            }
        }
        private void setUP_Energien()
        {
            int ko = 0;
            int kk = 0;
            int mu = 0;
            int ge = 0;
            int IN = 0;
            int kl = 0;
            int ch = 0;

            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.KO, out ko);
            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.KK, out kk);
            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.MU, out mu);
            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.GE, out ge);
            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.IN, out IN);
            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.KL, out kl);
            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.CH, out ch);

            ko = ko + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.KO);
            kk = kk + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.KK);
            mu = mu + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.MU);
            ge = ge + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.GE);
            IN = IN + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.IN);
            kl = kl + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.KL);
            ch = ch + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.CH);
            

            energienDictionary_VOR = new Dictionary<DSA_ENERGIEN, int>();
            energienDictionary_VOR.Add(DSA_ENERGIEN.LEBENSENERGIE,  (int)Math.Ceiling(Convert.ToDouble(ko + ko + kk) / 2));
            energienDictionary_VOR.Add(DSA_ENERGIEN.AUSDAUER,       (int)Math.Ceiling(Convert.ToDouble(mu + ge + ko) / 2));
            energienDictionary_VOR.Add(DSA_ENERGIEN.ASTRALENERGIE,  (int)Math.Ceiling(Convert.ToDouble(mu + IN + ch) / 2)); 
            energienDictionary_VOR.Add(DSA_ENERGIEN.MAGIERESISTENZ, (int)Math.Ceiling(Convert.ToDouble(mu + kl + ko) / 5));
            energienDictionary_VOR.Add(DSA_ENERGIEN.KARMAENERGIE, 0);
        }
        private void setUP_Advanced()
        {
            advancedDictionary = getAdvancedDictonary();
            for(int i=0; i < Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length; i++)
            {
                int value;
                advancedDictionary.TryGetValue((DSA_ADVANCEDVALUES)i, out value);
                charakter.setAdvancedValueAKT((DSA_ADVANCEDVALUES)i, value);
            }

            int ko = 0;
            int kk = 0;
            int mu = 0;
            int ge = 0;
            int IN = 0;
            int kl = 0;
            int ch = 0;
            int ff = 0;

            int mr = 0;

            energienDictionary_VOR.TryGetValue(DSA_ENERGIEN.MAGIERESISTENZ, out mr);

            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.KO, out ko);
            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.KK, out kk);
            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.MU, out mu);
            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.GE, out ge);
            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.IN, out IN);
            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.KL, out kl);
            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.CH, out ch);
            attributeDictionary.TryGetValue(DSA_ATTRIBUTE.FF, out ff);

            ko = ko + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.KO);
            kk = kk + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.KK);
            mu = mu + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.MU);
            ge = ge + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.GE);
            IN = IN + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.IN);
            kl = kl + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.KL);
            ch = ch + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.CH);
            ff = ff + managmentFeature.getAttributeBonus(DSA_ATTRIBUTE.FF);

            advancedDictionary.Remove(DSA_ADVANCEDVALUES.ATTACKE_BASIS);
            advancedDictionary.Remove(DSA_ADVANCEDVALUES.PARADE_BASIS);
            advancedDictionary.Remove(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS);
            advancedDictionary.Remove(DSA_ADVANCEDVALUES.INITATIVE_BASIS);
            advancedDictionary.Remove(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE);
            advancedDictionary.Remove(DSA_ADVANCEDVALUES.WUNDSCHWELLE);
            advancedDictionary.Add(DSA_ADVANCEDVALUES.ATTACKE_BASIS, (int)Math.Ceiling(Convert.ToDouble(mu + ge + kk) / 5));
            advancedDictionary.Add(DSA_ADVANCEDVALUES.PARADE_BASIS, (int)Math.Ceiling(Convert.ToDouble(IN + ge + kk) / 5));
            advancedDictionary.Add(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS, (int)Math.Ceiling(Convert.ToDouble(IN + ff + kk) / 5));
            advancedDictionary.Add(DSA_ADVANCEDVALUES.INITATIVE_BASIS, (int)Math.Ceiling(Convert.ToDouble(mu + mu + IN + ge) / 5));
            advancedDictionary.Add(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE, IN + mr);
            advancedDictionary.Add(DSA_ADVANCEDVALUES.WUNDSCHWELLE, (int)Math.Ceiling(Convert.ToDouble(ko) / 2));            
        }
        private void setUP_Features()
        {
            featureDictionary = getFeatureDictionary();
            List<Feature> list = new List<Feature>(featureDictionary.Keys);

            for(int i=0; i < list.Count; i++)
            {
                int pos = 0;
                featureDictionary.TryGetValue(list[i], out pos);

                charakter.addFeature(pos, list[i]);
                managmentFeature.addFeature(list[i], pos);
            }
        }
        private void setUP_Talente()
        {
            talentList = getTalentList();

            for(int i=0; i< talentList.Count; i++)
            {
                charakter.addTalent(talentList[i]);
            }
        }
        private void setUP_Andere()
        {
            moneyDictionary = getmoneyDictionary();

            for (int i = 0; i < Enum.GetNames(typeof(DSA_MONEY)).Length; i++)
            {
                int value;

                moneyDictionary.TryGetValue((DSA_MONEY)i, out value);
                charakter.setMoney((DSA_MONEY)i, value);
            }

            advanturePoints = getAdventurePoints();
            charakter.setAdventurePoints(advanturePoints);
        }
        public void setCharater(Charakter charakter)
        {
            this.charakter = charakter;
        }
        //##################################################################################################################
        //FeatureTest
        [TestMethod]
        public void Charakter_getHighestFeatureNumber()
        {
            Assert.AreEqual(managmentFeature.getHighestNumber(), charakter.getHighistFeatureNumber());
        }
        private void testFeatureAdvanced(Feature feature1, Feature feature2)
        {
            for(int i=0; i< Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length; i++)
            {
                DSA_ADVANCEDVALUES value = (DSA_ADVANCEDVALUES)i;
                Assert.AreEqual(feature1.getAdvancedValues(value), feature1.getAdvancedValues(value));
            }
        }
        private void testFeatureAttribute(Feature feature1, Feature feature2)
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                DSA_ATTRIBUTE value = (DSA_ATTRIBUTE)i;
                Assert.AreEqual(feature1.getAttributeBonus(value), feature1.getAttributeBonus(value));
            }
        }
        private void testFeatureEnergie(Feature feature1, Feature feature2)
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ENERGIEN)).Length; i++)
            {
                DSA_ENERGIEN value = (DSA_ENERGIEN)i;
                Assert.AreEqual(feature1.getEnergieBonus(value), feature1.getEnergieBonus(value));
            }
        }
        private void testFeatureTalente(Feature feature1, Feature feature2)
        {
            List<InterfaceTalent> alist = feature1.getTalentListwithBonus();
            List<InterfaceTalent> blist = feature1.getTalentListwithBonus();

            Assert.AreEqual(alist.Count, blist.Count);

            for(int i=0; i < alist.Count; i++)
            {
                Assert.AreEqual(feature1.getTaWBonus(alist[i]), feature2.getTaWBonus(alist[i]));
            }

        }
        [TestMethod]
        public void Charakter_getFeature()
        {
            List<Feature> keys = new List<Feature>(featureDictionary.Keys);

            for(int i=0; i< keys.Count; i++)
            {
                int pos = 0;
                DSA_FEATURES type = keys[i].getFeatureType();
                featureDictionary.TryGetValue(keys[i], out pos);

                Feature currentFeature = keys[i];
                Feature charakterFeature = charakter.getFeature(type, pos);

                Assert.AreEqual(currentFeature.getDescription(), charakterFeature.getDescription());
                Assert.AreEqual(currentFeature.getGP(), charakterFeature.getGP());
                Assert.AreEqual(currentFeature.getName(), charakterFeature.getName());
                Assert.AreEqual(currentFeature.getSimpleDescription(), charakterFeature.getSimpleDescription());
                Assert.AreEqual(currentFeature.getFeatureType(), charakterFeature.getFeatureType());                

                testFeatureAdvanced(currentFeature, charakterFeature);
                testFeatureAttribute(currentFeature, charakterFeature);
                testFeatureEnergie(currentFeature, charakterFeature);
                testFeatureTalente(currentFeature, charakterFeature);

            }
        }
        [TestMethod]
        public void Charakter_getFeatureTaWBonus()
        {
            List<Feature> keys = new List<Feature>(featureDictionary.Keys);

            for (int i = 0; i < keys.Count; i++)
            {
                DSA_FEATURES type = keys[i].getFeatureType();
                
                for(int j=0; j<talentList.Count; j++)
                {   
                    Assert.AreEqual(managmentFeature.getTalentTawBonus(talentList[j]), charakter.getTaWBons(talentList[j]));
                }
            }
        }
        //##################################################################################################################
        //BasicValues
        [TestMethod]
        public void Charakter_getBasicValues()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_BASICVALUES)).Length; i++)
            {
                String value;
                basicValueDicionary.TryGetValue((DSA_BASICVALUES)i, out value);
                Assert.AreEqual(value, charakter.getBasicValue((DSA_BASICVALUES)i));
            }
        }
        //##################################################################################################################
        //Attribute
        [TestMethod]
        public void Charakter_getMarkedAttribut()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                bool value;
                attributeMarkedDictionary.TryGetValue((DSA_ATTRIBUTE)i, out value);
                Assert.AreEqual(value, charakter.getMarkedAttribut((DSA_ATTRIBUTE)i));
            }
        }
        [TestMethod]
        public void Charakter_getAttributeValue_AKT()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                int value;
                attributeDictionary.TryGetValue((DSA_ATTRIBUTE)i, out value);
                Assert.AreEqual(value, charakter.getAttributeAKT((DSA_ATTRIBUTE)i));
            }
        }
        [TestMethod]
        public void Character_getAttributeValue_MOD()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                Assert.AreEqual(managmentFeature.getAttributeBonus((DSA_ATTRIBUTE)i), charakter.getAttribute_Mod((DSA_ATTRIBUTE)i));
            }
        }
        [TestMethod]
        public void Character_getAttributeValue_MAX()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                int value;
                attributeDictionary.TryGetValue((DSA_ATTRIBUTE)i, out value);
                Assert.AreEqual(value + managmentFeature.getAttributeBonus((DSA_ATTRIBUTE)i), charakter.getAttribute_Max((DSA_ATTRIBUTE)i));
            }
        }
        [TestMethod]
        public void Charakter_getSummeAttributPunkte()
        {
            int attributeakt = 0;
            int attributeMAX = 0;

            for (int i = 0; i < Enum.GetNames(typeof(DSA_ATTRIBUTE)).Length; i++)
            {
                int value;
                attributeDictionary.TryGetValue((DSA_ATTRIBUTE)i, out value);
                attributeakt = attributeakt + value;
                attributeMAX = attributeMAX + value + managmentFeature.getAttributeBonus((DSA_ATTRIBUTE)i);
            }

            Assert.AreEqual(attributeakt, charakter.getSummeAttributeAKT());
            Assert.AreEqual(attributeMAX, charakter.getSummeAttributeMAX());
        }
        //##################################################################################################################
        //Advanced
        [TestMethod]
        public void Charakter_getAdvancedAKT()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length; i++)
            {
                int value = 0;
                advancedDictionary.TryGetValue((DSA_ADVANCEDVALUES)i, out value);
                Assert.AreEqual(value, charakter.getAdvancedValueAKT((DSA_ADVANCEDVALUES)i), 0, "DSA_ADVANCEDVALUES " + Enum.GetNames(typeof(DSA_ADVANCEDVALUES))[i]);
            }
        }
        [TestMethod]
        public void Charakter_getAdvancedMOD()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length; i++)
            {
                Assert.AreEqual(managmentFeature.getAdvancedBonus((DSA_ADVANCEDVALUES)i), charakter.getAdvancedValueMOD((DSA_ADVANCEDVALUES)i), 0, "DSA_ADVANCEDVALUES " + Enum.GetNames(typeof(DSA_ADVANCEDVALUES))[i]);
            }
        }
        [TestMethod]
        public void Charakter_getAdvancedMAX()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length; i++)
            {
                int value;
                advancedDictionary.TryGetValue((DSA_ADVANCEDVALUES)i, out value);
                value = value + managmentFeature.getAdvancedBonus((DSA_ADVANCEDVALUES)i);
                Assert.AreEqual(value, charakter.getAdvancedValueMAX((DSA_ADVANCEDVALUES)i), 0, "DSA_ADVANCEDVALUES " + Enum.GetNames(typeof(DSA_ADVANCEDVALUES))[i]);
            }
        }
        [TestMethod]
        public void Charakter_getAdvancedAKT_notExist()
        {
            int length = Enum.GetNames(typeof(DSA_ADVANCEDVALUES)).Length;
            Assert.AreEqual(0, charakter.getAdvancedValueAKT((DSA_ADVANCEDVALUES)length + 5));
        }
        //##################################################################################################################
        //Energien
        [TestMethod]
        public void Charakter_getEnergieVOR()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ENERGIEN)).Length; i++)
            {
                int value;
                energienDictionary_VOR.TryGetValue((DSA_ENERGIEN)i, out value);
                Assert.AreEqual(value, charakter.getEnergieVOR((DSA_ENERGIEN)i),0 ,"DSA_ENERGIEN " + Enum.GetNames(typeof(DSA_ENERGIEN))[i]);
            }
        }
        [TestMethod]
        public void Charakter_getEnergiePERM()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ENERGIEN)).Length; i++)
            {
                Assert.AreEqual(managmentFeature.getEnergienBonus((DSA_ENERGIEN)i), charakter.getEnergiePERM((DSA_ENERGIEN)i), 0, "DSA_ENERGIEN " + Enum.GetNames(typeof(DSA_ENERGIEN))[i]);
            }
        }
        [TestMethod]
        public void Charakter_getEnergieMALI()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ENERGIEN)).Length; i++)
            {
                int value;
                energienDictionary_VOR.TryGetValue((DSA_ENERGIEN)i, out value);
                Assert.AreEqual(managmentFeature.getEnergienMALI((DSA_ENERGIEN)i), charakter.getEnergieMALI((DSA_ENERGIEN)i), 0, "DSA_ENERGIEN " + Enum.GetNames(typeof(DSA_ENERGIEN))[i]);
            }
        }
        [TestMethod]
        public void Charakter_getEnergieMAX()
        {
            for (int i = 0; i < Enum.GetNames(typeof(DSA_ENERGIEN)).Length; i++)
            {
                int value;
                int bonus = managmentFeature.getEnergienBonus((DSA_ENERGIEN)i);
                int mali = managmentFeature.getEnergienMALI((DSA_ENERGIEN)i);
                energienDictionary_VOR.TryGetValue((DSA_ENERGIEN)i, out value);

                Assert.AreEqual(value + bonus + mali, charakter.getEnergieMAX((DSA_ENERGIEN)i), 0, "DSA_ENERGIEN " + Enum.GetNames(typeof(DSA_ENERGIEN))[i]);
            }
        }
        //##################################################################################################################
        //Andere
        [TestMethod]
        public void Charakter_getAdventurePoint()
        {
            Assert.AreEqual(advanturePoints, charakter.getAdvanturePoints());
        }
        [TestMethod]
        public void Charakter_getMoney()
        {
            for(int i=0; i<Enum.GetNames(typeof(DSA_MONEY)).Length; i++)
            {
                int value;
                moneyDictionary.TryGetValue((DSA_MONEY)i, out value);
                Assert.AreEqual(value, charakter.getMoney((DSA_MONEY)i));
            }
        }
        //##################################################################################################################
        //TalentTest
        [TestMethod]
        public void Charakter_addTalent_addDoppel()
        {
            Charakter charakter = new Charakter();
            for(int i=0; i<talentList.Count; i++)
            {
                charakter.addTalent(talentList[i]);
                charakter.addTalent(talentList[i]);
            }
            Assert.AreEqual(talentList.Count, charakter.getTalentList_allTalents().Count);
        }
        [TestMethod]
        public void Charakter_addTalent_byList()
        {
            Charakter charakter = new Charakter();
            charakter.addTalent(talentList);

            Assert.AreEqual(talentList.Count, charakter.getTalentList_allTalents().Count);
        }
        [TestMethod]
        public void Charakter_addTalent_null()
        {
            Charakter charakter = new Charakter();
            InterfaceTalent talent = null;
            charakter.addTalent(talent);

            Assert.AreEqual(0, charakter.getTalentList_allTalents().Count);
        }
        [TestMethod]
        public void Charakter_addTalent_ListWithnull()
        {
            List<InterfaceTalent> list = new List<InterfaceTalent>(0);
            InterfaceTalent talent = null;
            list.Add(talent);
            for (int i=0; i<talentList.Count; i++)
            {
                list.Add(talent);
                list.Add(talentList[i]);
                list.Add(talent);
            }
            Assert.AreEqual(talentList.Count, charakter.getTalentList_allTalents().Count);
        }
        [TestMethod]
        public void Charakter_addTalent_NullList()
        {
            Charakter charakter = new Charakter();
            List<InterfaceTalent> list = null;
            charakter.addTalent(list);

            Assert.AreEqual(0, (charakter.getTalentList_allTalents()).Count);
        }
        [TestMethod]
        public void Charakter_addTalent_differentType_sameName()
        {
            Charakter charakter = new Charakter();
            InterfaceTalent talent1 = new TalentCrafting("Talent", RandomGenerator.generateAttributList(), "", new List<TalentDeviate>(), new List<TalentRequirement>());
            InterfaceTalent talent2 = new TalentCrafting("Talent", RandomGenerator.generateAttributList(), "", new List<TalentDeviate>(), new List<TalentRequirement>());

            charakter.addTalent(talent1);
            charakter.addTalent(talent2);

            Assert.AreEqual(1, charakter.getTalentList_allTalents().Count);
        }
        [TestMethod]
        public void Charakter_getTalent_byTypeandNumber_TalentExist()
        {
            Dictionary<Type, List<InterfaceTalent>> talent = new Dictionary<Type, List<InterfaceTalent>>(0);
            for(int i=0; i<talentList.Count; i++)
            {
                List<InterfaceTalent> list;
                if (!talent.TryGetValue(talentList[i].GetType(), out list))
                {
                    list = new List<InterfaceTalent>(0);
                    talent.Add(talentList[i].GetType(), list);
                }
                list.Add(talentList[i]);
            }
            List<Type> typelist = new List<Type>(talent.Keys);

            for(int i=0; i<typelist.Count; i++)
            {
                List<InterfaceTalent> list;
                talent.TryGetValue(typelist[i], out list);
                for(int j=0; j<list.Count; j++)
                {
                    InterfaceTalent italent = charakter.getTalent(list[j], j);
                    Assert.AreEqual(list[j], italent);
                }
            }
        }
        [TestMethod]
        public void Charakter_getTalent_byTypeandNumber_TalentnotExist()
        {
            InterfaceTalent knowldageTalent_type = new TalentKnwoldage("KnowldageTalent" + "_Type", new List<DSA_ATTRIBUTE>(0), "BE_craftingTalent", new List<TalentDeviate>(), new List<TalentRequirement>());
            Assert.AreNotEqual(knowldageTalent_type, charakter.getTalent(knowldageTalent_type, 10));
        }
        [TestMethod]
        public void Charakter_getTalent_byTypeandNumber_TalentnotExistTypeNotexist()
        {
            InterfaceTalent knowldageTalent_type = new TalentRange("RangeTalent", "BE", new List<TalentDeviate>(), DSA_ADVANCEDVALUES.ATTACKE_BASIS, true);
            Assert.AreNotEqual(knowldageTalent_type, charakter.getTalent(knowldageTalent_type, 10));
        }
        [TestMethod]
        public void Charakter_getTalent_byTypeandNumber_TalentNull()
        {
            InterfaceTalent knowldageTalent_type = null;
            Assert.AreEqual(null, charakter.getTalent(knowldageTalent_type, 10));
        }
        [TestMethod]
        public void Charakter_getTalent_ByName_TalentExist()
        {
            for(int i=0; i<talentList.Count; i++)
            {
                Assert.AreEqual(talentList[i], charakter.getTalent(talentList[i].getName()));
            }
        }
        [TestMethod]
        public void Charakter_getTalent_ByName_TalentNotExist()
        {
            Assert.AreEqual(null, charakter.getTalent("IdontExist"));
        }
        [TestMethod]
        public void Charakter_getTalentList_byType()
        {
            Dictionary<Type, List<InterfaceTalent>> talent = new Dictionary<Type, List<InterfaceTalent>>(0);
            for (int i = 0; i < talentList.Count; i++)
            {
                List<InterfaceTalent> list;
                if (!talent.TryGetValue(talentList[i].GetType(), out list))
                {
                    list = new List<InterfaceTalent>(0);
                    talent.Add(talentList[i].GetType(), list);
                }
                list.Add(talentList[i]);
            }
            List<Type> typelist = new List<Type>(talent.Keys);

            for (int i = 0; i < typelist.Count; i++)
            {
                List<InterfaceTalent> list;
                talent.TryGetValue(typelist[i], out list);
                List<InterfaceTalent> list_out = charakter.getTalentList_TalentType(list[0]);

                Assert.AreEqual(list.Count, list_out.Count);

                for (int j = 0; j < list.Count; j++)
                {
                    Assert.AreEqual(list[j], list_out[j]);
                }
            }
        }
        [TestMethod]
        public void Charakter_getTalentList_byType_TypenotExist()
        {
            Charakter charakter = new Charakter();

            InterfaceTalent TalentRange = new TalentRange("RangeTalent", "BE", new List<TalentDeviate>(), DSA_ADVANCEDVALUES.ATTACKE_BASIS, true);
            List<InterfaceTalent> list = charakter.getTalentList_TalentType(TalentRange);

            Assert.AreEqual(0, list.Count);
        }
        [TestMethod]
        public void Charakter_getTalentList_allTalents()
        {
            List<InterfaceTalent> list = charakter.getTalentList_allTalents();
            Assert.AreEqual(talentList.Count, list.Count);
        }
        //##################################################################################################################
    }
}