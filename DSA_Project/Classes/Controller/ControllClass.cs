using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel;
using System.Drawing;
using System.Diagnostics.CodeAnalysis;

namespace DSA_Project
{
    //##########################################################################################################################################################################################################################################################
    //Enums
    public enum DSA_ATTRIBUTE { MU, KL, IN, CH, FF, GE, KO, KK, SO }
    public enum DSA_ENERGIEN { LEBENSENERGIE, AUSDAUER, ASTRALENERGIE, KARMAENERGIE, MAGIERESISTENZ }
    public enum DSA_ADVANCEDVALUES { ATTACKE_BASIS, PARADE_BASIS, FERNKAMPF_BASIS, INITATIVE_BASIS, BEHERSCHUNGSWERT, ARTEFAKTKONTROLLE, WUNDSCHWELLE, ENTRÜCKUNG, GESCHWINDIGKEIT }
    public enum DSA_BASICVALUES { NAME, ALTER, GESCHLECHT, GRÖSE, GEWICHT, AUGENFARBE, HAUTFARBE, HAARFARBE, FAMILIENSTAND, ANREDE, GOTTHEIT, RASSE, KULTUR, PROFESSION, FREEVALUE1, FREEVALUE2, FREEVALUE3, FREEVALUE4, FREEVALUE5, FREEVALUE6, FREEVALUE7 }
    public enum DSA_MONEY { D, S, H, K, BANK }
    //###########################################################################################################################################################################################################################################################
    public class ControllClass
    {
        private String rootPath;
        private Charakter Charakter;
        private ControllTalent controllTalent;
        private ControllLanguageFamily controllLanguageFamily;


        public ControllClass(String rootPath)
        {
            this.rootPath = rootPath;
            Charakter = createNewCharater();
        }
        //###################################################################################################################################
        //Tools
        //###################################################################################################################################
        //Laden und Speichern von Daten 
        private String getResourcePath()
        {
            String path = Path.Combine(ManagmentSaveStrings.currentDirectory, ManagmentSaveStrings.Recources);
            path        = Path.Combine(path, rootPath);
            return path;
        }
        private Charakter createNewCharater()
        {
            Charakter charakter = new Charakter();

            String path;
            path = Path.Combine(ManagmentSaveStrings.currentDirectory, rootPath);
            path = Path.Combine(path, ManagmentSaveStrings.SaveLocation);

            controllTalent = new ControllTalent(getResourcePath());
            charakter.addTalent(controllTalent.getTalentList<TalentClose>());
            charakter.addTalent(controllTalent.getTalentList<TalentRange>());
            charakter.addTalent(controllTalent.getTalentList<TalentWeaponless>());

            charakter.addTalent(controllTalent.getTalentList<TalentCrafting>());
            charakter.addTalent(controllTalent.getTalentList<TalentKnwoldage>());
            charakter.addTalent(controllTalent.getTalentList<TalentNature>());
            charakter.addTalent(controllTalent.getTalentList<TalentPhysical>());
            charakter.addTalent(controllTalent.getTalentList<TalentSocial>());

            charakter.addTalent(controllTalent.getTalentList<LanguageTalent>());
            charakter.addTalent(controllTalent.getTalentList<FontTalent>());

            controllLanguageFamily = new ControllLanguageFamily(charakter, getResourcePath());

            return charakter;
        }
        [ExcludeFromCodeCoverage]
        public void save()
        {
            String path = Path.Combine(getResourcePath(), ManagmentSaveStrings.SaveLocation);

            SaveFileDialog savefileDialog = new SaveFileDialog();
            savefileDialog.InitialDirectory = path;
            savefileDialog.Filter = "xmlFiles |*xml";

            if (savefileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveCharakterXML.saveCharakter(Charakter, savefileDialog.FileName);
            }
        }
        [ExcludeFromCodeCoverage]
        public void load()
        {

            String path = Path.Combine(getResourcePath(), ManagmentSaveStrings.SaveLocation);
            
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = path;
            openFileDialog.Filter = "xmlFiles |*xml";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Charakter = LoadCharakterXML.loadCharakter(openFileDialog.FileName, createNewCharater(), controllTalent);
            }
        }
        //###################################################################################################################################
        //Einrichtung der Attribute
        public int AttributeAKT(DSA_ATTRIBUTE attribute)
        {
            return Charakter.getAttributeAKT(attribute);
        }
        public int AttributeAKT(DSA_ATTRIBUTE attribute, String wert)
        {
            var isNumeric = int.TryParse(wert, out var wert_int);
            if (isNumeric == true)
            {
                Charakter.setAttribute(attribute, wert_int);
            }
            return AttributeAKT(attribute);
        }
        public int AttributeMOD(DSA_ATTRIBUTE attribute)
        {
            return Charakter.getAttribute_Mod(attribute);
        }
        public int AttributeMOD(DSA_ATTRIBUTE attribute, String wert)
        {
            var isNumeric = int.TryParse(wert, out var wert_int);
            if (isNumeric == true)
            {
                /*Dieser Wert Soll Aktuell noch nicht geändert werden*/
            }            
            return AttributeMOD(attribute);
        }
        public int AttributeMAX(DSA_ATTRIBUTE attribute)
        {
            return Charakter.getAttribute_Max(attribute);
        }
        public int AttributeMAX(DSA_ATTRIBUTE attribute, String Wert)
        {
            return AttributeMAX(attribute);
        }
        public int getAttributeAKTSumme()
        {
            return Charakter.getSummeAttributeAKT();
        }
        public int getAttributeMAXSumme()
        {
            return Charakter.getSummeAttributeMAX();
        }
        public bool getAttributMark(DSA_ATTRIBUTE atr)
        {
            return Charakter.getMarkedAttribut(atr);    
        }
        public void setAttributMark(DSA_ATTRIBUTE atr, bool a)
        {
            Charakter.setMarkedAttribut(atr, a);
        }
        //###################################################################################################################################
        //Einrichtung der BasicValues
        public String BasicValue(DSA_BASICVALUES value)
        {
            return Charakter.getBasicValue(value);
        }
        public String BasicValue(DSA_BASICVALUES value, String wert)
        {
            Charakter.setBasicValues(value, wert);
            return BasicValue(value);
        }
        //###################################################################################################################################
        //Einrichtung der AdvancecValues
        public int AdvancedValueAKT(DSA_ADVANCEDVALUES advancedValue)
        {
            return Charakter.getAdvancedValueAKT(advancedValue);
        }
        public int AdvancedValueAKT(DSA_ADVANCEDVALUES advancedValue, string value)
        {
            var isNumeric = int.TryParse(value, out var value_out);
            if (isNumeric == true)
            {
                Charakter.setAdvancedValueAKT(advancedValue, value_out);
            }
            return AdvancedValueAKT(advancedValue);
        }
        public int AdvancedValueMOD(DSA_ADVANCEDVALUES advancedValue)
        {
            return Charakter.getAdvancedValueMOD(advancedValue);
        }
        public int AdvancedValueMAX(DSA_ADVANCEDVALUES advancedValue)
        {
            return Charakter.getAdvancedValueMAX(advancedValue);
        }
        //###################################################################################################################################
        //Einrichtung der Energie
        public int EnergieVOR(DSA_ENERGIEN energie)
        {
            return Charakter.getEnergieVOR(energie);
        }
        public int EnergiePERM(DSA_ENERGIEN energie)
        {
            return Charakter.getEnergiePERM(energie);
        }
        public int EnergieMALI(DSA_ENERGIEN energie)
        {
            return Charakter.getEnergieMALI(energie);
        }
        public int EnergieMAX(DSA_ENERGIEN energie)
        {
            return Charakter.getEnergieMAX(energie);
        }
        //###################################################################################################################################
        //Einrichtung der Anderen
        public int Money(DSA_MONEY type)
        {
            return Charakter.getMoney(type);
        }
        public int Money(DSA_MONEY type, String money)
        {
            var isNumeric = int.TryParse(money, out var wert_int);
            if (isNumeric == true)
            {
                Charakter.setMoney(type, wert_int);
            }
            return Money(type);
        }
        public int AdvanturePoints(int number)
        {
            Charakter.setAdventurePoints(number);
            return AdvanturePoints();
        }
        public int AdvanturePoints()
        {
            return Charakter.getAdvanturePoints();
        }
        //###################################################################################################################################
        //Einrichtung der Feature
        [ExcludeFromCodeCoverage]
        public Feature Feature(int number, DSA_FEATURES type)
        {
            Feature feature = Charakter.getFeature(type, number);
            ControllView_CreateFeature viewController = new ControllView_CreateFeature(Charakter.getTalentList_allTalents());

            if (feature == null)
            {
                feature = new Feature(type);
            }

            feature = viewController.editFeature(feature);
            Charakter.setFeature(number, feature);

            return feature;
        }
        [ExcludeFromCodeCoverage]
        public Feature FeatureExisting(int number, DSA_FEATURES type)
        {
            return Charakter.getFeature(type, number);
        }
        //###################################################################################################################################
        //Talente
        public void addTalent(InterfaceTalent talent)
        {
            Charakter.addTalent(talent);
        }
        public InterfaceTalent getTalent(InterfaceTalent type, int number)
        {
            return Charakter.getTalent(type, number);
        }
        public List<InterfaceTalent>getTalentList(InterfaceTalent type)
        {
            return Charakter.getTalentList_TalentType(type); 
        }
        public List<InterfaceTalent> getallTalentList()
        {
            return Charakter.getTalentList_allTalents();
        }
        public List<T> getTalentListController<T>() where T : InterfaceTalent
        {
            return controllTalent.getTalentList<T>();
        }
        //#######################################################################################################################################################################################################################
        //LanguageFamily
        public List<String> getFamilyList()
        {
            List<String> stringList = new List<String>();
            List<LanguageFamily> list = controllLanguageFamily.getFamilyList();
            for(int i=0; i<list.Count; i++)
            {
                stringList.Add(list[i].getName());
            }

            return stringList;
        }
        public LanguageFamily getFamilybyName(String name)
        {
            List<LanguageFamily> list = controllLanguageFamily.getFamilyList();
            for(int i=0; i<list.Count; i++)
            {
                if(String.Compare(list[i].getName(), name) == 0)
                {
                    return list[i];
                }
            }
            throw new ArgumentOutOfRangeException("The Name:" + name + " is no Possible choise");
        }
        public void setMotherMark(String mark, String TalentName)
        {
            LanguageTalent talent = null;
            try
            {
                talent = (LanguageTalent)Charakter.getTalent(TalentName);
            }
            finally
            {
                talent.setMotherMark(mark);
            }
        }




        public void setTaw(String TaW, String TalentName)
        {
            InterfaceTalent talent = Charakter.getTalent(TalentName);
            talent.setTaw(TaW);
        }
    }
}
