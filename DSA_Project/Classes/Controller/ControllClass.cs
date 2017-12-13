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
    //###################################################################################################################################################################################
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
    //###################################################################################################################################################################################
    //Enums
    public enum DSA_ATTRIBUTE { MU, KL, IN, CH, FF, GE, KO, KK, SO, LT, HT }
    public enum DSA_ENERGIEN { LEBENSENERGIE, AUSDAUER, ASTRALENERGIE, KARMAENERGIE, MAGIERESISTENZ }
    public enum DSA_ADVANCEDVALUES { ATTACKE_BASIS, PARADE_BASIS, FERNKAMPF_BASIS, INITATIVE_BASIS, BEHERSCHUNGSWERT, ARTEFAKTKONTROLLE, WUNDSCHWELLE, ENTRÜCKUNG, GESCHWINDIGKEIT }
    public enum DSA_BASICVALUES { NAME, ALTER, GESCHLECHT, GRÖSE, GEWICHT, AUGENFARBE, HAUTFARBE, HAARFARBE, FAMILIENSTAND, ANREDE, GOTTHEIT, RASSE, KULTUR, PROFESSION }
    public enum DSA_MONEY { D, S, H, K, BANK }
    //###################################################################################################################################################################################
    public abstract class ControllClass
    {
        private DSA form;
        private Charakter Charakter;
        private Dictionary<int, Feature> Advantages = new Dictionary<int, Feature>();

        private String GeneralTalentFileSystemLocation;
        private String FightingTalentFileSystemLocation;


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
        private String getResourcePath()
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
                Charakter = LoadCharakterXML.loadCharakter(openFileDialog.FileName, createNewCharater());
            }
            form.load();
        }
        public Charakter createNewCharater()
        {
            Charakter charakter = new Charakter();
            new ControllTalent(charakter, GeneralTalentFileSystemLocation, FightingTalentFileSystemLocation);              //Rüstet den Charakter mit den der Form zugehörigen Talenten aus


            return charakter;
        }
        //###################################################################################################################################
        //###################################################################################################################################
        //Einrichtung der Form
        private void setUP()
        {
            String path;
            path = Path.Combine(ManagmentSaveStrings.currentDirectory, getRootPath());
            path = Path.Combine(path, ManagmentSaveStrings.SaveLocation);

            GeneralTalentFileSystemLocation = Path.Combine(getResourcePath(), ManagmentSaveStrings.GeneralTalentFilesSystemLocation);
            FightingTalentFileSystemLocation = Path.Combine(getResourcePath(), ManagmentSaveStrings.FightTalentFilesSystemLocation);
            
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
        public String BasicValue(DSA_BASICVALUES value)
        {
            return Charakter.getBasicValue(value);
        }
        public String BasicValue(DSA_BASICVALUES value, String wert)
        {
            Charakter.setBasicValues(value, wert);
            return BasicValue(value);
        }
        public String Göttergeschenk(int number)
        {
            return Charakter.getGöttergeschenk(number);
        }
        public String Göttergeschenk(int number, String description)
        {
            Charakter.setGöttergeschenk(number, description);
            return Göttergeschenk(number);
        }
        public String Moodifikator(int number)
        {
            return Charakter.getModifikatoren(number);
        }
        public String Moodifikator(int number, String description)
        {
            Charakter.setModifikatoren(number, description);
            return Moodifikator(number);
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
                createFeature = new CreateFeature(Charakter.getAllTalentList(), type);
            }
            else
            {
                createFeature = new CreateFeature(feature, Charakter.getAllTalentList(), type);
            }
            createFeature.ShowDialog();
            feature = createFeature.feature();

            if (feature == null) return null;

            Charakter.addFeature(type, number, feature);

            Advantages.Remove(number);
            Advantages.Add(number, feature);
            

            return feature;
        }
        public Feature FeatureExisting(int number, DSA_FEATURES type)
        {
            return Charakter.getFeature(type, number);
        }
        //###################################################################################################################################
        //Einrichtung der Talente
        public List<InterfaceTalent> getTalent()
        {
            return Charakter.getAllTalentList();
        }
        public InterfaceTalent getTalent<Tenum>(Tenum type, int number) where Tenum : struct, IComparable, IFormattable, IConvertible
        {
            return Charakter.getTalent(type, number);
        }
        //###################################################################################################################################
    }
}
