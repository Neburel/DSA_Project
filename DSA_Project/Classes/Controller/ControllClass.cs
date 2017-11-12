using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Project
{
    public enum DSA_ATTRIBUTE { MU, KL, IN, CH, FF, GE, KO, KK, SO }
    public enum DSA_ENERGIEN { LEBENSENERGIE, AUSDAUER, ASTRALENERGIE, KARMAENERGIE, MAGIERESISTENZ }
    public enum DSA_ADVANCEDVALUES { ATTACKE_BASIS, PARADE_BASIS, FERNKAMPF_BASIS, INITATIVE_BASIS, BEHERSCHUNGSWERT, ARTEFAKTKONTROLLE, WUNDSCHWELLE, ENTRÜCKUNG, GESCHWINDIGKEIT }
    enum DSA_BASICVALUES { NAME, ALTER, GESCHLECHT, GRÖSE, GEWICHT, AUGENFARBE, HAUTFARBE, HAARFARBE, FAMILIENSTAND, ANREDE, GOTTHEIT, RASSE, KULTUR, PROFESSION }
    enum DSA_MONEY { D, S, H, K, BANK}
    enum DSA_FEATURES { VORTEIL, NACHTEIL }
    enum DSA_FEATUREBONUS { NONE,  MUT, KLUGHEIT, INTUITION, CHARISMA, FINGERFERTIGKEIT, GEWANDHEIT, KONSTITUTION, KÖRPERKRAFT, SOZAILSTATUS, LEBENSENERGIE, AUSDAUER, ASTRALENERGIE, KARMAENERGIE, MAGIERESISTENZ }
    /// <summary>
    /// Die Kontroll Klasse dient als Zentrale Anlaufstelle für das Programm
    /// Sie bestimmt was bei Wereänderungen Passiert, wie und wohin sie geschrieben werden
    /// Sie bestimmt welche Werte bei Anfragen zurückgegeben weden
    /// Wie wird gespeichert, geladen
    /// etc....
    /// <summary>
    class ControllClass
    {
        Form1 form;
        Charakter charakter                 = new Charakter();
        Dictionary<int, Feature> Advantages = new Dictionary<int, Feature>();


        public ControllClass(Form1 form)
        {
            this.form = form;
        }


        public void save()
        {
            String directoryPath = Directory.GetCurrentDirectory();
            String destinationPath = @"Ressources"; ;
            String completePath = Path.Combine(directoryPath, destinationPath);

            SaveFileDialog savefileDialog = new SaveFileDialog();
            savefileDialog.InitialDirectory = completePath;
            savefileDialog.Filter = "xmlFiles |*xml";

            if (savefileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveCharakterXML.saveCharakter(charakter, savefileDialog.FileName);
            }
        }
        public void load()
        {
            String directoryPath = Directory.GetCurrentDirectory();
            String destinationPath = @"Ressources"; ;
            String completePath = Path.Combine(directoryPath, destinationPath);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = completePath;
            openFileDialog.Filter = "xmlFiles |*xml";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                charakter = LoadCharakterXML.loadCharakter(openFileDialog.FileName);
            }

            form.load();
            form.refresh();
        }

   
        /// <summary>
        /// Gibt ein Basic Value in Form eines Array Zurück
        /// mit Ausnahme von Modifikatoren und Göttergeschenke ist dieser Wert stets im 0 vorhanden
        /// Bessere Lösung Möglich?
        /// </summary>
        public String BasicValue(DSA_BASICVALUES value)
        {
            return charakter.getBasicValue(value);
        }
        public String BasicValue(DSA_BASICVALUES value, String wert)
        {
            charakter.setBasicValues(value, wert);
            return BasicValue(value);
        }


        /// <summary>
        /// Funktion die bei einer Eingabe in eienem AKT Attribute Feld feststellt ob diese Korrekt ist,
        /// und gibt den Neuen Wert(wenn dieser Korrekt ist) oder den Alten zurück
        /// </summary>
        /// <param name="attribute">Das Attribute welches geändert werden soll</param>
        /// <param name="wert">Der Wert in den das Attribute gewändert wird (Nummerisch, Integer).</param>
        /// <param name="form">Die Form die nach der Änderung Refresht werden soll.</param>
        /// <returns></returns>
        public int AttributeAKT(DSA_ATTRIBUTE attribute)
        {
            return charakter.getAttributeAKT(attribute);
        }
        public int AttributeAKT(DSA_ATTRIBUTE attribute, String wert)
        {
            var isNumeric = int.TryParse(wert, out var wert_int);
            if (isNumeric == true)
            {
                charakter.setAttribute(attribute, wert_int);
            }
            form.refresh();
            return AttributeAKT(attribute);
        }
        /// <summary>
        /// Funktion die bei einer Eingabe in eienem MOD Attribute Feld feststellt ob diese Korrekt ist,
        /// und gibt den Neuen Wert(wenn dieser Korrekt ist) oder den Alten zurück
        /// </summary>
        /// <param name="attribute">Das Attribute welches geändert werden soll</param>
        /// <param name="wert">Der Wert in den das Attribute gewändert wird (Nummerisch, Integer).</param>
        /// <param name="form">Die Form die nach der Änderung Refresht werden soll.</param>
        /// <returns></returns>
        public int AttributeMOD(DSA_ATTRIBUTE attribute)
        {
            return charakter.getAttribute_Mod(attribute);
        }
        public int AttributeMOD(DSA_ATTRIBUTE attribute, String wert)
        {
            var isNumeric = int.TryParse(wert, out var wert_int);
            if (isNumeric == true)
            {
                /*Dieser Wert Soll Aktuell noch nicht geändert werden*/
            }
            form.refresh();
            return AttributeMOD(attribute);
        }
        /// <summary>
        /// Funktion die bei einer Eingabe in eienem MAX Attribute Feld feststellt ob diese Korrekt ist,
        /// und gibt den Neuen Wert(wenn dieser Korrekt ist) oder den Alten zurück
        /// </summary>
        /// <param name="attribute">Das Attribute welches geändert werden soll</param>
        /// <param name="wert">Der Wert in den das Attribute gewändert wird (Nummerisch, Integer).</param>
        /// <param name="form">Die Form die nach der Änderung Refresht werden soll.</param>
        /// <returns></returns>
        public int AttributeMAX(DSA_ATTRIBUTE attribute)
        {
            return charakter.getAttribute_Max(attribute);
        }
        public int AttributeMAX(DSA_ATTRIBUTE attribute, String Wert)
        {
            /*Dieser Wert soll nicht verändert werden*/           
            return AttributeMAX(attribute);
        }
        public int getAttributeAKTSumme()
        {
            return charakter.getSummeAttributeAKT();
        }
        public int getAttributeMAXSumme()
        {
            return charakter.getSummeAttributeMAX();
        }
        
        public int AdvancedValueAKT(DSA_ADVANCEDVALUES advancedValue)
        {   
            return charakter.getAdvancedValueAKT(advancedValue);
        }
        public int AdvancedValueAKT(DSA_ADVANCEDVALUES advancedValue, string value)
        {
            var isNumeric = int.TryParse(value, out var value_out);
            if (isNumeric == true)
            {
                charakter.setAdvancedValueAKT(advancedValue, value_out);
            }
            form.refresh();
            return AdvancedValueAKT(advancedValue);
        }
        public int AdvancedValueMOD(DSA_ADVANCEDVALUES advancedValue)
        {
            return charakter.getAdvancedValueMOD(advancedValue);
        }
        public int AdvancedValueMAX(DSA_ADVANCEDVALUES advancedValue)
        {
            return charakter.getAdvancedValueMAX(advancedValue);
        }

        
        public int EnergieVOR(DSA_ENERGIEN energie)
        {
            return charakter.getEnergieVOR(energie);
        }
        public int EnergiePERM(DSA_ENERGIEN energie)
        {
            return charakter.getEnergiePERM(energie);
        }
        public int EnergieMOD(DSA_ENERGIEN enegie)
        {
            return charakter.getEnergieMOD(enegie);
        }
        public int EnergieMALI(DSA_ENERGIEN energie)
        {
            return charakter.getEnergieMALI(energie);
        }
        public int EnergieMAX(DSA_ENERGIEN energie)
        {
            return charakter.getEnergieMAX(energie);
        }


        public int Money(DSA_MONEY type)
        {
            return charakter.getMoney(type);
        }
        public int Money(DSA_MONEY type, String money)
        {
            var isNumeric = int.TryParse(money, out var wert_int);
            if (isNumeric == true)
            {
                charakter.setMoney(type, wert_int);
            }
            return Money(type);
        }


        public Feature Feature(int number, DSA_FEATURES type)
        {
            CreateFeature createFeature;
            Feature feature                 = charakter.getFeature(type,number);

            if (feature == null)
            {
                createFeature = new CreateFeature();
            }
            else
            {
                createFeature = new CreateFeature(feature);
            }
            createFeature.ShowDialog();
            feature = createFeature.feature();

            charakter.addFeature(type, number, feature);
            
            Advantages.Remove(number);
            Advantages.Add(number, feature);

            form.refresh();

            return feature;
        }
        public Feature FeatureExisting(int number, DSA_FEATURES type)
        {
            return charakter.getFeature(type, number);
        }

        public String Göttergeschenk(int number)
        {
            return charakter.getGöttergeschenk(number);
        }
        public String Göttergeschenk(int number, String description)
        {
            charakter.setGöttergeschenk(number, description);
            return Göttergeschenk(number);
        }
        public String Moodifikator(int number)
        {
            return charakter.getModifikatoren(number);
        }
        public String Moodifikator(int number, String description)
        {
            charakter.setModifikatoren(number, description);
            return Moodifikator(number);
        }

    }
}
