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
    public class SaveCharakterXMLTests02_SaveFileWithoutXML : Abstract_SaveCharakterXMLTests
    {
        internal override String getSaveFileName()
        {
            return "newKazarik";
        }

        public override Dictionary<DSA_BASICVALUES, string> getBasicValuesDictionary()
        {
            Dictionary<DSA_BASICVALUES, String> dic = new Dictionary<DSA_BASICVALUES, string>(0);
            dic.Add(DSA_BASICVALUES.NAME, "Kazarik");
            dic.Add(DSA_BASICVALUES.ALTER, "25");
            dic.Add(DSA_BASICVALUES.GESCHLECHT, "männlich");
            dic.Add(DSA_BASICVALUES.GRÖSE, "168");
            dic.Add(DSA_BASICVALUES.GEWICHT, "50");
            dic.Add(DSA_BASICVALUES.AUGENFARBE, "grün");
            dic.Add(DSA_BASICVALUES.HAUTFARBE, "hell");
            dic.Add(DSA_BASICVALUES.HAARFARBE, "schwarze");
            dic.Add(DSA_BASICVALUES.FAMILIENSTAND, "ledig");
            dic.Add(DSA_BASICVALUES.GOTTHEIT, "Firun");
            dic.Add(DSA_BASICVALUES.RASSE, "Tiefling");
            dic.Add(DSA_BASICVALUES.KULTUR, "Sonnenanbeter");
            dic.Add(DSA_BASICVALUES.PROFESSION, "Jäger");

            return dic;
        }
        public override Dictionary<DSA_ATTRIBUTE, int> getAttributeDictonary()
        {
            Dictionary<DSA_ATTRIBUTE, int> dic = new Dictionary<DSA_ATTRIBUTE, int>();
            dic.Add(DSA_ATTRIBUTE.MU, 8);
            dic.Add(DSA_ATTRIBUTE.KL, 9);
            dic.Add(DSA_ATTRIBUTE.IN, 10);
            dic.Add(DSA_ATTRIBUTE.CH, 7);
            dic.Add(DSA_ATTRIBUTE.FF, 10);
            dic.Add(DSA_ATTRIBUTE.GE, 12);
            dic.Add(DSA_ATTRIBUTE.KO, 8);
            dic.Add(DSA_ATTRIBUTE.KK, 12);
            dic.Add(DSA_ATTRIBUTE.SO, 5);


            return dic;
        }
        public override Dictionary<DSA_ADVANCEDVALUES, int> getAdvancedDictonary()
        {
            Dictionary<DSA_ADVANCEDVALUES, int> dic = new Dictionary<DSA_ADVANCEDVALUES, int>();
            dic.Add(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT, 0);
            dic.Add(DSA_ADVANCEDVALUES.INITATIVE_BASIS, 8);
            dic.Add(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT, 10);

            return dic;
        }
        public override Dictionary<DSA_MONEY, int> getmoneyDictionary()
        {
            Dictionary<DSA_MONEY, int> dic = new Dictionary<DSA_MONEY, int>(0);
            dic.Add(DSA_MONEY.D, 100);
            dic.Add(DSA_MONEY.S, 4);
            dic.Add(DSA_MONEY.H, 6);
            dic.Add(DSA_MONEY.K, 5);
            dic.Add(DSA_MONEY.BANK, 39);

            return dic;
        }
        public override Dictionary<Feature, int> getFeatureDictionary()
        {
            Dictionary<Feature, int> dic = new Dictionary<Feature, int>(0);
            Feature fa1 = new Feature("Tiefling(Sonnenanbeter)", "Intuition (+2) bei Dunkelheit, Geruchsimmun, Zwergenmagen", "X", "");
            Feature fa2 = new Feature("Schlangenmensch", "", "1", "");
            Feature fa3 = new Feature("Erdkruste", "", "2", "");
            Feature fa4 = new Feature("Diabolische Nächte", "", "X", "");
            Feature fa5 = new Feature("Leichte Krankheitsresistenz", "10%", "", "");
            Feature fa30 = new Feature("Belohnung Gewinnspiel", "1 Freies Talent (Noch zu Verteilen)", "", "");
            Feature fa31 = new Feature("Abenteuer Gefängnis", "1 Freier Talentpunkt(Noch zu Verteilen)", "", "");

            fa2.setAttributeBonus(DSA_ATTRIBUTE.GE, 1);
            fa3.setEnergieBonus(DSA_ENERGIEN.LEBENSENERGIE, 4);
            fa4.setAttributeBonus(DSA_ATTRIBUTE.CH, 1);
            fa4.setEnergieBonus(DSA_ENERGIEN.AUSDAUER, 5);
            fa31.setEnergieBonus(DSA_ENERGIEN.AUSDAUER, 5);
            fa31.setEnergieBonus(DSA_ENERGIEN.KARMAENERGIE, 10);
            fa31.setTalentBonusTaW(charakter.getTalent("Überzeugen"), 1);
            fa31.setTalentBonusTaW(charakter.getTalent("Überreden"), 1);

            dic.Add(fa1, 0);
            dic.Add(fa2, 1);
            dic.Add(fa3, 2);
            dic.Add(fa4, 3);
            dic.Add(fa5, 4);
            dic.Add(fa30, 30);
            dic.Add(fa31, 31);


            Feature fd1 = new Feature("Tiefling(Sonnenanbeter)", "Intuition (-1) + Überhitzung bei Helligkeit", "X", "");
            Feature fd2 = new Feature("Un-Charismatisch", "", "1", "");
            Feature fd3 = new Feature("Rassismus(höheres Volk)", "", "2", "");
            Feature fd4 = new Feature("Diabolische Nächte", "", "X", "");

            fd2.setAttributeBonus(DSA_ATTRIBUTE.CH, -1);
            fd2.setTalentBonusTaW(charakter.getTalent("Betören"), -2);
            fd4.setAdvancedValues(DSA_ADVANCEDVALUES.ENTRÜCKUNG, -1);

            dic.Add(fd1, 15);
            dic.Add(fd2, 16);
            dic.Add(fd3, 17);
            dic.Add(fd4, 18);

            return dic;
        }

        public override int getAdventurePoints()
        {
            return 0;
        }



        public override Dictionary<DSA_ATTRIBUTE, bool> getAttributeMarkedDictonary()
        {
            Dictionary<DSA_ATTRIBUTE, bool> dic = new Dictionary<DSA_ATTRIBUTE, bool>(0);
            dic.Add(DSA_ATTRIBUTE.MU, true);

            return dic;
        }

        public override Dictionary<string, int> getTalentTaWDictionary()
        {
            return new Dictionary<string, int>();
        }

        public override List<string> getGiftTalents()
        {
            return new List<string>();
        }
    }
}