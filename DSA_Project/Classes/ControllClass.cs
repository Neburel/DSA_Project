using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Project
{
    enum DSA_BASICVALUES { NAME, ALTER, GESCHLECHT, GRÖSE, GEWICHT, AUGENFARBE, HAUTFARBE, HAARFARBE, FAMILIENSTAND, ANREDE, GOTTHEIT, GÖTTERGESCHENKE, RASSE, KULTUR, PROFESSION, MODIFIKATOREN }
    enum DSA_ATTRIBUTE { MUT, KLUGHEIT, INTUITION, CHARISMA, FINGERFERTIGKEIT, GEWANDHEIT, KONSTITUTION, KÖRPERKRAFT, SOZAILSTATUS, SUMME }
    enum DSA_ADVANCEDVALUES { ATTACKE_BASIS, PARADE_BASIS, FERNKAMPF_BASIS, INITATIVE_BASIS, BEHERSCHUNGSWERT, ARTEFAKTKONTROLLE, WUNDSCHWELLE, ENTRÜCKUNG, GESCHWINDIGKEIT }
    enum DSA_ENERGIEN { LEBENSENERGIE, AUSDAUER, ASTRALENERGIE, KARMAENERGIE, MAGIERESISTENZ }
    /// <summary>
    /// Die Kontroll Klasse dient als Zentrale Anlaufstelle für das Programm
    /// Sie bestimmt was bei Wereänderungen Passiert, wie und wohin sie geschrieben werden
    /// Sie bestimmt welche Werte bei Anfragen zurückgegeben weden
    /// Wie wird gespeichert, geladen
    /// etc....
    /// 
    /// 
    /// Die Mehtoden für AKT, MOD, MAX sind einzehlnd, damit kein Zeitverlust durch noch weitere Entscheidungen entsteht
    /// <summary>
    class ControllClass
    {
        Form1 form;
        Charakter charakter = new Charakter();

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
        public String[] BasicValue(DSA_BASICVALUES attribute)
        {
            return charakter.getBasicValue(attribute);
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

        
        public int AdvancedValue_AKT(DSA_ADVANCEDVALUES advancedValue)
        {
            /*Besseres Verhalten implementieren*/
            return charakter.getAdvancedValue_AKT(advancedValue);
        }


    }
}
