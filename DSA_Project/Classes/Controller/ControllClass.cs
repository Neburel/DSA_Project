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
    public enum DSA_BASICVALUES { NAME, ALTER, GESCHLECHT, GRÖSE, GEWICHT, AUGENFARBE, HAUTFARBE, HAARFARBE, FAMILIENSTAND, ANREDE, GOTTHEIT, RASSE, KULTUR, PROFESSION }
    public enum DSA_MONEY { D, S, H, K, BANK }
  
    /// <summary>
    /// Die Kontroll Klasse dient als Zentrale Anlaufstelle für das Programm
    /// Sie bestimmt was bei Wereänderungen Passiert, wie und wohin sie geschrieben werden
    /// Sie bestimmt welche Werte bei Anfragen zurückgegeben weden
    /// Wie wird gespeichert, geladen
    /// etc....
    /// <summary>
    class ControllClass
    {
        DSA form;
        Charakter Charakter;
        Dictionary<int, Feature> Advantages = new Dictionary<int, Feature>();


        public ControllClass(DSA form)
        {
            this.form = form;
            Charakter = createNewCharater();
        }

        public void save()
        {
            String directoryPath = Directory.GetCurrentDirectory();
            String destinationPath = @ManagmentLoadXML.saveLocation; 
            String completePath = Path.Combine(directoryPath, destinationPath);

            Console.WriteLine(completePath);

            SaveFileDialog savefileDialog = new SaveFileDialog();
            savefileDialog.InitialDirectory = completePath;
            savefileDialog.Filter = "xmlFiles |*xml";

            if (savefileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveCharakterXML.saveCharakter(Charakter, savefileDialog.FileName);
            }
        }
        public void load()
        {
            String directoryPath = Directory.GetCurrentDirectory();
            String destinationPath = @ManagmentLoadXML.saveLocation;
            String completePath = Path.Combine(directoryPath, destinationPath);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = completePath;
            openFileDialog.Filter = "xmlFiles |*xml";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Charakter = LoadCharakterXML.loadCharakter(openFileDialog.FileName, createNewCharater());
            }

            form.load();
            form.refreshHeroPage();
            form.refreshTalentPage();
        }

        public Charakter createNewCharater()
        {
            Charakter charakter = new Charakter();
            new ControllTalent(charakter);


            return charakter;
        }
        /// <summary>
        /// Gibt ein Basic Value in Form eines Array Zurück
        /// mit Ausnahme von Modifikatoren und Göttergeschenke ist dieser Wert stets im 0 vorhanden
        /// Bessere Lösung Möglich?
        /// </summary>
        public String BasicValue(DSA_BASICVALUES value)
        {
            return Charakter.getBasicValue(value);
        }
        public String BasicValue(DSA_BASICVALUES value, String wert)
        {
            Charakter.setBasicValues(value, wert);
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
            return Charakter.getAttribute_Max(attribute);
        }
        public int AttributeMAX(DSA_ATTRIBUTE attribute, String Wert)
        {
            /*Dieser Wert soll nicht verändert werden*/
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

        public InterfaceTalent getTalent<Tenum>(Tenum type, int number) where Tenum : struct, IComparable, IFormattable, IConvertible
        {
            return Charakter.getTalent(type, number);
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

        public void setMarkedAttribut(DSA_ATTRIBUTE att, bool b)
        {
            Charakter.setMarkedAttribut(att, b);
        }
        public bool getMarkedAttribut(DSA_ATTRIBUTE att)
        {
            return Charakter.getMarkedAttribut(att);
        }

    }
}
