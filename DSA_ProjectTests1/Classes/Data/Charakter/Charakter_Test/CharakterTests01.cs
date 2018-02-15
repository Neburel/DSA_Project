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
    public class CharakterTests01 : CharakterTestsAbstract
    {
        private List<InterfaceTalent> talentList;

        [TestInitialize]
        public void setUP_this()
        {
            talentList = new List<InterfaceTalent>();
            Console.WriteLine("CharakterTests01");
            Console.WriteLine(this);
        }

        public override Dictionary<DSA_ATTRIBUTE, int> getAttributeDictonary()
        {
            Dictionary<DSA_ATTRIBUTE, int> dic = new Dictionary<DSA_ATTRIBUTE, int>();
            dic.Add(DSA_ATTRIBUTE.MU, 5);
            dic.Add(DSA_ATTRIBUTE.KL, 10);

            return dic;
        }
        public override Dictionary<DSA_ADVANCEDVALUES, int> getAdvancedDictonary()
        {
            Dictionary<DSA_ADVANCEDVALUES, int> dic = new Dictionary<DSA_ADVANCEDVALUES, int>();
            dic.Add(DSA_ADVANCEDVALUES.ATTACKE_BASIS, 2);
            dic.Add(DSA_ADVANCEDVALUES.WUNDSCHWELLE, 5);
            dic.Add(DSA_ADVANCEDVALUES.ENTRÜCKUNG, 5);

            return dic;
        }
        public override Dictionary<DSA_ATTRIBUTE, bool> getAttributeMarkedDictonary()
        {
            Dictionary<DSA_ATTRIBUTE, bool> dic = new Dictionary<DSA_ATTRIBUTE, bool>();
            dic.Add(DSA_ATTRIBUTE.IN, true);

            return dic;
        }
        public override Dictionary<Feature, int> getFeatureDictionary()
        {
            Dictionary<Feature, int> dic = new Dictionary<Feature, int>(0);

            Feature feature1 = new Feature("F1", "F1", "0", "0");
            Feature feature2 = new Feature("F2", "F2", "10", "7");
            Feature feature3 = new Feature("F3", "F3", "2", "8");

            TalentCrafting talent = new TalentCrafting("Crafting", RandomGenerator.generateAttributList(), "BE", new List<TalentDeviate>(), new List<TalentRequirement>());

            dic.Add(feature1, 1);
            dic.Add(feature2, 2);
            dic.Add(feature3, 3);

            feature1.setAdvancedValues(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS, 20);
            feature1.setTalentBonusTaW(talent, 5);
            feature2.setEnergieBonus(DSA_ENERGIEN.AUSDAUER, 8);
            feature3.setAttributeBonus(DSA_ATTRIBUTE.IN, 9);

            return dic;
        }
        public override Dictionary<DSA_BASICVALUES, String> getBasicValuesDictionary()
        {
            Dictionary<DSA_BASICVALUES, String> dic = new Dictionary<DSA_BASICVALUES, String>();
            dic.Add(DSA_BASICVALUES.ANREDE, "HALLO");
            dic.Add(DSA_BASICVALUES.FREEVALUE5, "T");
            dic.Add(DSA_BASICVALUES.GEWICHT, "G");
            dic.Add(DSA_BASICVALUES.GRÖSE, "HAO");

            return dic;
        }

        public override List<InterfaceTalent> getTalentList()
        {
            List<InterfaceTalent> list = new List<InterfaceTalent>(0);

            InterfaceTalent talent01 = new TalentCrafting("CraftingTalent01", RandomGenerator.generateAttributList(), "Crafting_BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            InterfaceTalent talent02 = new TalentKnwoldage("TalentKnowldage", RandomGenerator.generateAttributList(), "Crafting_BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            InterfaceTalent talent03 = new TalentPhysical("TalentPhysical1", RandomGenerator.generateAttributList(), "Crafting_BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            InterfaceTalent talent04 = new TalentPhysical("TalentPhysical2", RandomGenerator.generateAttributList(), "Crafting_BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            InterfaceTalent talent05 = new GiftTalent("GiftTalent", RandomGenerator.generateAttributList());
            InterfaceTalent talent06 = new TalentClose("TalentClose", "BE_Close", new List<TalentDeviate>(), DSA_ADVANCEDVALUES.ATTACKE_BASIS, true);
            InterfaceTalent talent07 = new TalentCrafting("CraftingTalent02", RandomGenerator.generateAttributList(), "Crafting_BE", new List<TalentDeviate>(), new List<TalentRequirement>());
            InterfaceTalent talent08 = new TalentWeaponless("TalentClose01", "BE_Close", new List<TalentDeviate>(), DSA_ADVANCEDVALUES.ATTACKE_BASIS, true);

            list.Add(talent01);
            list.Add(talent02);
            list.Add(talent03);
            list.Add(talent04);
            list.Add(talent05);
            list.Add(talent06);
            list.Add(talent07);
            list.Add(talent08);

            return list;
        }

        public override Dictionary<DSA_MONEY, int> getmoneyDictionary()
        {
            Dictionary<DSA_MONEY, int> dic = new Dictionary<DSA_MONEY, int>() ;
            dic.Add(DSA_MONEY.H, 10);
            return dic;
        }

        public override int getAdventurePoints()
        {
            return 5;
        }

        public override Dictionary<String, int> getTalentTaWDictionary()
        {
            Dictionary<String, int> dic = new Dictionary<String, int>();
            dic.Add("CraftingTalent01", 5);
            dic.Add("TalentClose", 0);
            dic.Add("CraftingTalent02", -3);

            return dic;
        }
    }
}