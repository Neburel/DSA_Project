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

namespace DSA_Project
{
    //##########################################################################################################################################################################################################################################################
    //Structs
    public struct HeroPageFeatureTag
    {
        public DSA_FEATURES type;
        public int number;

        public HeroPageFeatureTag(DSA_FEATURES t, int n)
        {
            type = t;
            number = n;
        }
    }
    //##########################################################################################################################################################################################################################################################
    //Enums
    public enum DSA_ATTRIBUTE { MU, KL, IN, CH, FF, GE, KO, KK, SO }
    public enum DSA_ENERGIEN { LEBENSENERGIE, AUSDAUER, ASTRALENERGIE, KARMAENERGIE, MAGIERESISTENZ }
    public enum DSA_ADVANCEDVALUES { ATTACKE_BASIS, PARADE_BASIS, FERNKAMPF_BASIS, INITATIVE_BASIS, BEHERSCHUNGSWERT, ARTEFAKTKONTROLLE, WUNDSCHWELLE, ENTRÜCKUNG, GESCHWINDIGKEIT }
    public enum DSA_BASICVALUES { NAME, ALTER, GESCHLECHT, GRÖSE, GEWICHT, AUGENFARBE, HAUTFARBE, HAARFARBE, FAMILIENSTAND, ANREDE, GOTTHEIT, RASSE, KULTUR, PROFESSION, FREEVALUE1, FREEVALUE2, FREEVALUE3, FREEVALUE4, FREEVALUE5, FREEVALUE6, FREEVALUE7 }
    public enum DSA_MONEY { D, S, H, K, BANK }
    //###########################################################################################################################################################################################################################################################
    public abstract class ControllClass
    {
        protected DSA form;
        private Charakter Charakter;
        private ControllTalent controllTalent;
        
        public ControllClass(DSA form)
        {
            this.form = form;
            setUP();
            Charakter = createNewCharater();
        }
        //###################################################################################################################################
        //Tools
        //###################################################################################################################################
        //Laden und Speichern von Daten 
        protected abstract String getRootPath();
        public String getResourcePath()
        {
            String path = Path.Combine(ManagmentSaveStrings.currentDirectory, ManagmentSaveStrings.Recources);
            path        = Path.Combine(path, getRootPath());
            return path;
        }
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
            form.load();
        }
        public Charakter createNewCharater()
        {
            Charakter charakter = new Charakter();

            String path;
            path = Path.Combine(ManagmentSaveStrings.currentDirectory, getRootPath());
            path = Path.Combine(path, ManagmentSaveStrings.SaveLocation);
            
            controllTalent = new ControllTalent(charakter, getResourcePath());
            charakter.addTalent<TalentClose>(controllTalent.getTalentList<TalentClose>());
            charakter.addTalent<TalentRange>(controllTalent.getTalentList<TalentRange>());
            charakter.addTalent<TalentWeaponless>(controllTalent.getTalentList<TalentWeaponless>());

            charakter.addTalent<TalentCrafting>(controllTalent.getTalentList<TalentCrafting>());
            charakter.addTalent<TalentKnwoldage>(controllTalent.getTalentList<TalentKnwoldage>());
            charakter.addTalent<TalentNature>(controllTalent.getTalentList<TalentNature>());
            charakter.addTalent<TalentPhysical>(controllTalent.getTalentList<TalentPhysical>());
            charakter.addTalent<TalentSocial>(controllTalent.getTalentList<TalentSocial>());

            charakter.addTalent<LanguageTalent>(controllTalent.getTalentList<LanguageTalent>());
            charakter.addTalent<FontTalent>(controllTalent.getTalentList<FontTalent>());

            return charakter;
        }
        //###################################################################################################################################
        //Einrichtung der Form
        private void setUP()
        {
            setUPBasicValues();
            setUPMoney();
            setUPAttribute();
        }
        //###################################################################################################################################
        //Einrichtung der Attribute
        protected abstract void setUPAttribute();
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
            form.refreshHeroPage();
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
            form.refreshHeroPage();
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
        public void changeAttributMark(DSA_ATTRIBUTE att, Label lblAttribut, TextBox txtAKT, TextBox txtMOD, TextBox txtMax)
        {
            bool x = !Charakter.getMarkedAttribut(att);
            Charakter.setMarkedAttribut(att, x);

            if (!x)
            {
                lblAttribut.ForeColor = Color.Black;
                lblAttribut.Font = new Font(lblAttribut.Font, FontStyle.Regular);

                txtAKT.BackColor = ManagmentForm.activeColor;
                txtMOD.BackColor = ManagmentForm.inactiveColor;
                txtMax.BackColor = ManagmentForm.inactiveColor;
            }
            else
            {
                lblAttribut.ForeColor = Color.Red;

                txtAKT.BackColor = Color.Yellow;
                txtMOD.BackColor = Color.GreenYellow;
                txtMax.BackColor = Color.GreenYellow;
            }
            Charakter.setMarkedAttribut(att, x);
        }
        //###################################################################################################################################
        //Einrichtung der BasicValues
        protected abstract void setUPBasicValues();
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
            form.refreshHeroPage();
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
        public int EnergieMOD(DSA_ENERGIEN enegie)
        {
            return Charakter.getEnergieMOD(enegie);
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
        protected abstract void setUPMoney();
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
            return Charakter.getAdvanturePoints();
        }
        public int AdvanturePoints()
        {
            return Charakter.getAdvanturePoints();
        }
        //###################################################################################################################################
        //Einrichtung der Feature
        public Feature Feature(int number, DSA_FEATURES type)
        {
            CreateFeature createFeature;
            Feature feature = Charakter.getFeature(type, number);


            if (feature == null)
            {
                createFeature = new CreateFeature(Charakter.getallTalentList(), type);
            }
            else
            {
                createFeature = new CreateFeature(feature, Charakter.getallTalentList(), type);
            }
            createFeature.ShowDialog();
            feature = createFeature.feature();

            if (feature == null) return null;

            Charakter.addFeature(type, number, feature);

            return feature;
        }
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
            return Charakter.getTalentList(type); 
        }
        public List<InterfaceTalent>getTalentListController<T>() where T : InterfaceTalent
        {
            return controllTalent.getTalentList<T>();
        }
        public List<InterfaceTalent> getallTalentList()
        {
            return Charakter.getallTalentList();
        }
    }
}
