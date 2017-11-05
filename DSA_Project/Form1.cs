using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DSA_Project
{
    public partial class Form1 : Form
    {
        Charakter charakter = new Charakter();

        List<TextBox> txtBoxListGöttergeschenke = new List<TextBox>();
        List<TextBox> txtBoxListModifikatoren   = new List<TextBox>();
        public Form1()
        {
            InitializeComponent();
            /*Nötige Listen Erstellen*/
            txtBoxListGöttergeschenke.Add(txtGöttergeschenke1);
            txtBoxListGöttergeschenke.Add(txtGöttergeschenke2);
            txtBoxListGöttergeschenke.Add(txtGöttergeschenke3);

            txtBoxListModifikatoren.Add(txtModifikation1);
            txtBoxListModifikatoren.Add(txtModifikation2);
            txtBoxListModifikatoren.Add(txtModifikation3);

            /*Initialisierung Aktuelle Werte
            txtMutAKT.Text              = this.AttributeAktChange(DSA_Attribute.MUT, txtMutAKT.Text).ToString();
            txtKlugheitAKT.Text         = this.AttributeAktChange(DSA_Attribute.KLUGHEIT, txtKlugheitAKT.Text).ToString();
            txtIntuitionAKT.Text        = this.AttributeAktChange(DSA_Attribute.INTUITION, txtIntuitionAKT.Text).ToString();
            txtCharismaAKT.Text         = this.AttributeAktChange(DSA_Attribute.CHARISMA, txtCharismaAKT.Text).ToString();
            txtFingerfertigkeitAKT.Text = this.AttributeAktChange(DSA_Attribute.FINGERFERTIGKEIT, txtFingerfertigkeitAKT.Text).ToString();
            textGewandheitAKT.Text      = this.AttributeAktChange(DSA_Attribute.GEWANDHEIT, textGewandheitAKT.Text).ToString();
            txtKonstitutionAKT.Text     = this.AttributeAktChange(DSA_Attribute.KONSTITUTION, txtKonstitutionAKT.Text).ToString();
            txtKörperkraftAKT.Text      = this.AttributeAktChange(DSA_Attribute.KÖRPERKRAFT, txtKörperkraftAKT.Text).ToString();
            txtSozialstatusAKT.Text     = this.AttributeAktChange(DSA_Attribute.SOZAILSTATUS, txtSozialstatusAKT.Text).ToString();
            /*

            /*Initialisierung Attribute Modifikatoren*/
            txtMutMOD.Text              = this.AttributeModChange(DSA_Attribute.MUT, txtMutMOD.Text).ToString();
            txtKlugheitMOD.Text         = this.AttributeModChange(DSA_Attribute.KLUGHEIT, txtKlugheitMOD.Text).ToString();
            txtIntuitionMOD.Text        = this.AttributeModChange(DSA_Attribute.INTUITION, txtIntuitionMOD.Text).ToString();
            txtCharismaMOD.Text         = this.AttributeModChange(DSA_Attribute.CHARISMA, txtCharismaMOD.Text).ToString();
            txtFingerfertigkeitMOD.Text = this.AttributeModChange(DSA_Attribute.FINGERFERTIGKEIT, txtFingerfertigkeitMOD.Text).ToString();
            textGewandheitMOD.Text      = this.AttributeModChange(DSA_Attribute.GEWANDHEIT, textGewandheitMOD.Text).ToString();
            txtKonstitutionMOD.Text     = this.AttributeModChange(DSA_Attribute.KONSTITUTION, txtKonstitutionMOD.Text).ToString();
            txtKörperkraftMOD.Text      = this.AttributeModChange(DSA_Attribute.KÖRPERKRAFT, txtKörperkraftMOD.Text).ToString();
            txtSozialstatusMOD.Text     = this.AttributeModChange(DSA_Attribute.SOZAILSTATUS, txtSozialstatusMOD.Text).ToString();
            /*Initialisierung Attribute Max*/
            /*Geschiet in aktualisierung()*/

            load();
            aktualisierung();
        }

        /*
         * Ereignisse
         **/
        private int AttributeAktChange(DSA_Attribute attribute, String wert)
        {
            var isNumeric = int.TryParse(wert, out var wert_int);
            if (isNumeric == true)
            {
                charakter.setAttribute(attribute, wert_int);
            }
            aktualisierung();
            return charakter.getAttribute(attribute);
        }
        private int AttributeModChange(DSA_Attribute attribute, String wert)
        {
            var isNumeric = int.TryParse(wert, out var wert_int);
            if (isNumeric == true)
            {
                /*Noch Nicht Veränderbar*/
            }
            aktualisierung();
            return charakter.getAttribute_Mod(attribute);
        }
        private int AttributeMaxChange(DSA_Attribute attribute, String Wert)
        {
            /*Nicht zu verändern*/
            return charakter.getAttribute_Max(attribute);
        }
        private int BasicValuesAktChange(DSA_ADVANCEDVALUES attribute)
        {
            return charakter.getBasicValue_AKT(attribute);
        }
        private int BasicValuesAktChange(DSA_ADVANCEDVALUES attribute, String Wert)
        {
            return BasicValuesAktChange(attribute);
        }
        /*Aktualisiert alle Werte, führt Berechnungen durch etc...*/
        private void load()
        {
            txtName.Text            = (charakter.getBasicValues(DSA_BASICVALUES.NAME))[0];
            txtAlter.Text           = (charakter.getBasicValues(DSA_BASICVALUES.ALTER))[0];
            txtGeschlecht.Text      = (charakter.getBasicValues(DSA_BASICVALUES.GESCHLECHT))[0];
            txtGröße.Text           = (charakter.getBasicValues(DSA_BASICVALUES.GRÖSE))[0];
            txtGewicht.Text         = (charakter.getBasicValues(DSA_BASICVALUES.GEWICHT))[0];
            txtAugenfarbe.Text      = (charakter.getBasicValues(DSA_BASICVALUES.AUGENFARBE))[0];
            txtHaarfarbe.Text       = (charakter.getBasicValues(DSA_BASICVALUES.HAARFARBE))[0];
            txtHautfarbe.Text       = (charakter.getBasicValues(DSA_BASICVALUES.HAUTFARBE))[0];
            txtFamulienstand.Text   = (charakter.getBasicValues(DSA_BASICVALUES.FAMILIENSTAND))[0];
            txtAnrede.Text          = (charakter.getBasicValues(DSA_BASICVALUES.ANREDE))[0];
            txtGottheit.Text        = (charakter.getBasicValues(DSA_BASICVALUES.GOTTHEIT))[0];
            txtRasse.Text           = (charakter.getBasicValues(DSA_BASICVALUES.RASSE))[0];
            txtKultur.Text          = (charakter.getBasicValues(DSA_BASICVALUES.KULTUR))[0];
            txtProfession.Text      = (charakter.getBasicValues(DSA_BASICVALUES.PROFESSION))[0];

            String[] Göttergeschenke    = charakter.getBasicValues(DSA_BASICVALUES.GÖTTERGESCHENKE);
            String[] Modifikatoren      = charakter.getBasicValues(DSA_BASICVALUES.MODIFIKATOREN);

            Console.WriteLine(Göttergeschenke.Length);
            Console.WriteLine(txtBoxListGöttergeschenke.Count);

            for (int i=0; i< Göttergeschenke.Length; i++)
            {
                if(i >= txtBoxListGöttergeschenke.Count){ break; }

                TextBox Box = txtBoxListGöttergeschenke[i];
                Box.Text = Göttergeschenke[i];
            }

            for (int i = 0; i < Modifikatoren.Length; i++)
            {
                if (i >= txtBoxListModifikatoren.Count) { break; }

                TextBox Box = txtBoxListModifikatoren[i];
                Box.Text = Modifikatoren[i];
            }

            txtMutAKT.Text = AttributeAktChange(DSA_Attribute.MUT, "notNumeric").ToString();
            txtKlugheitAKT.Text = AttributeAktChange(DSA_Attribute.KLUGHEIT, "notNumeric").ToString();
            txtIntuitionAKT.Text = AttributeAktChange(DSA_Attribute.INTUITION, "notNumeric").ToString();
            txtCharismaAKT.Text = AttributeAktChange(DSA_Attribute.CHARISMA, "notNumeric").ToString();
            txtFingerfertigkeitAKT.Text = AttributeAktChange(DSA_Attribute.FINGERFERTIGKEIT, "notNumeric").ToString();
            textGewandheitAKT.Text = AttributeAktChange(DSA_Attribute.GEWANDHEIT, "notNumeric").ToString();
            txtKonstitutionAKT.Text = AttributeAktChange(DSA_Attribute.KONSTITUTION, "notNumeric").ToString();
            txtKörperkraftAKT.Text = AttributeAktChange(DSA_Attribute.KÖRPERKRAFT, "notNumeric").ToString();
            txtSozialstatusAKT.Text = AttributeAktChange(DSA_Attribute.SOZAILSTATUS, "notNumeric").ToString();



        }
        private void aktualisierung()
        {            
            txtMutMAX.Text              = charakter.getAttribute_Max(DSA_Attribute.MUT).ToString();
            txtKlugheitMAX.Text         = charakter.getAttribute_Max(DSA_Attribute.KLUGHEIT).ToString();
            txtIntuitionMAX.Text        = charakter.getAttribute_Max(DSA_Attribute.INTUITION).ToString();
            txtCharismaMAX.Text         = charakter.getAttribute_Max(DSA_Attribute.CHARISMA).ToString();
            txtFingerfertigkeitMAX.Text = charakter.getAttribute_Max(DSA_Attribute.FINGERFERTIGKEIT).ToString();
            textGewandheitMAX.Text      = charakter.getAttribute_Max(DSA_Attribute.GEWANDHEIT).ToString();
            txtKonstitutionMAX.Text     = charakter.getAttribute_Max(DSA_Attribute.KONSTITUTION).ToString();
            txtKörperkraftMAX.Text      = charakter.getAttribute_Max(DSA_Attribute.KÖRPERKRAFT).ToString();
            txtSozialstatusMAX.Text     = charakter.getAttribute_Max(DSA_Attribute.SOZAILSTATUS).ToString();

            txtGesamtAKT.Text           = charakter.getAttributeGesamt_AKT().ToString();
            txtGesamtMAX.Text           = charakter.getAttributeGesamt_MAX().ToString();

            txtAttackeBaisAKT.Text      = BasicValuesAktChange(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
            txtParadeBasisAKT.Text      = BasicValuesAktChange(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
            txtFernkampfBasisAKT.Text   = BasicValuesAktChange(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
            txtInitativeBasisAKT.Text   = BasicValuesAktChange(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
            txtBeherschungswertAKT.Text = BasicValuesAktChange(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
            txtArtefaktkontrolleAKT.Text= BasicValuesAktChange(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE).ToString();
            txtWundschwelleAKT.Text     = BasicValuesAktChange(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();
            txtEntrückungAKT.Text       = BasicValuesAktChange(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
            txtGeschwindigkeitAKT.Text  = BasicValuesAktChange(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }
        private void btnLoadCharacter_Click(object sender, EventArgs e)
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

            load();
            aktualisierung();
        }
        private void btnSaveCharacter_Click(object sender, EventArgs e)
        {
            String directoryPath = Directory.GetCurrentDirectory();
            String destinationPath = @"Ressources"; ;
            String completePath = Path.Combine(directoryPath, destinationPath);

            SaveFileDialog savefileDialog = new SaveFileDialog();
            savefileDialog.InitialDirectory = completePath;
            savefileDialog.Filter = "xmlFiles |*xml";

            if(savefileDialog.ShowDialog() == DialogResult.OK)
            {
                SaveCharakterXML.saveCharakter(charakter, savefileDialog.FileName);
            }
        }
        /*Attribut Änderungen Aktuelle Werte*/
        private void txtMutAKT_TextChanged(object sender, EventArgs e)
        {
            txtMutAKT.Text = this.AttributeAktChange(DSA_Attribute.MUT, txtMutAKT.Text).ToString();
        }
        private void txtKlugheitAKT_TextChanged(object sender, EventArgs e)
        {
            txtKlugheitAKT.Text = this.AttributeAktChange(DSA_Attribute.KLUGHEIT, txtKlugheitAKT.Text).ToString();
        }
        private void txtIntuitionAKT_TextChanged(object sender, EventArgs e)
        {
            txtIntuitionAKT.Text = this.AttributeAktChange(DSA_Attribute.INTUITION, txtIntuitionAKT.Text).ToString();
        }
        private void txtCharismaAKT_TextChanged(object sender, EventArgs e)
        {
            txtCharismaAKT.Text = this.AttributeAktChange(DSA_Attribute.CHARISMA, txtCharismaAKT.Text).ToString();
        }
        private void txtFingerfertigkeitAKT_TextChanged(object sender, EventArgs e)
        {
            txtFingerfertigkeitAKT.Text = this.AttributeAktChange(DSA_Attribute.FINGERFERTIGKEIT, txtFingerfertigkeitAKT.Text).ToString();
        }
        private void textGewandheitAKT_TextChanged(object sender, EventArgs e)
        {
            textGewandheitAKT.Text = this.AttributeAktChange(DSA_Attribute.GEWANDHEIT, textGewandheitAKT.Text).ToString();
        }
        private void txtKonstitutionAKT_TextChanged(object sender, EventArgs e)
        {
            txtKonstitutionAKT.Text = this.AttributeAktChange(DSA_Attribute.KONSTITUTION, txtKonstitutionAKT.Text).ToString();
        }
        private void txtKörperkraftAKT_TextChanged(object sender, EventArgs e)
        {
            txtKörperkraftAKT.Text = this.AttributeAktChange(DSA_Attribute.KÖRPERKRAFT, txtKörperkraftAKT.Text).ToString();
        }
        private void txtSozialstatusAKT_TextChanged(object sender, EventArgs e)
        {
            txtSozialstatusAKT.Text = this.AttributeAktChange(DSA_Attribute.SOZAILSTATUS, txtSozialstatusAKT.Text).ToString();
        }
        private void txtGesamtAKT_TextChanged(object sender, EventArgs e)
        {
            aktualisierung();
        }
        /*Attribut Änderungen Aktuelle Werte Ende*/

        /*Attribut Änderungen Modifikatoren*/
        private void txtMutMOD_TextChanged(object sender, EventArgs e)
        {
            txtMutMOD.Text = this.AttributeModChange(DSA_Attribute.MUT, txtMutMOD.Text).ToString();
        }   
        private void txtKlugheitMOD_TextChanged(object sender, EventArgs e)
        {
            txtKlugheitMOD.Text = this.AttributeModChange(DSA_Attribute.KLUGHEIT, txtKlugheitMOD.Text).ToString();
        }
        private void txtIntuitionMOD_TextChanged(object sender, EventArgs e)
        {
            txtIntuitionMOD.Text = this.AttributeModChange(DSA_Attribute.INTUITION, txtIntuitionMOD.Text).ToString();
        }
        private void txtCharismaMOD_TextChanged(object sender, EventArgs e)
        {
            txtCharismaMOD.Text = this.AttributeModChange(DSA_Attribute.CHARISMA, txtCharismaMOD.Text).ToString();
        }
        private void txtFingerfertigkeitMOD_TextChanged(object sender, EventArgs e)
        {
            txtFingerfertigkeitMOD.Text = this.AttributeModChange(DSA_Attribute.FINGERFERTIGKEIT, txtFingerfertigkeitMOD.Text).ToString();
        }
        private void textGewandheitMOD_TextChanged(object sender, EventArgs e)
        {
            textGewandheitMOD.Text = this.AttributeModChange(DSA_Attribute.GEWANDHEIT, textGewandheitMOD.Text).ToString();
        }
        private void txtKonstitutionMOD_TextChanged(object sender, EventArgs e)
        {
            txtKonstitutionMOD.Text = this.AttributeModChange(DSA_Attribute.KONSTITUTION, txtKonstitutionMOD.Text).ToString();
        }
        private void txtKörperkraftMOD_TextChanged(object sender, EventArgs e)
        {
            txtKörperkraftMOD.Text = this.AttributeModChange(DSA_Attribute.KÖRPERKRAFT, txtKörperkraftMOD.Text).ToString();
        }
        private void txtSozialstatusMOD_TextChanged(object sender, EventArgs e)
        {
            txtSozialstatusMOD.Text = this.AttributeModChange(DSA_Attribute.SOZAILSTATUS, txtSozialstatusMOD.Text).ToString();
        }
        /*Attribut Änderungen Modifikatoren Ende*/
        /*Attribut Änderungen MAX*/
        private void txtMutMAX_TextChanged(object sender, EventArgs e)
        {
            txtMutMAX.Text = this.AttributeMaxChange(DSA_Attribute.MUT, txtMutMAX.Text).ToString();
        }
        private void txtKlugheitMAX_TextChanged(object sender, EventArgs e)
        {
            txtKlugheitMAX.Text = this.AttributeMaxChange(DSA_Attribute.KLUGHEIT, txtKlugheitMAX.Text).ToString();
        }
        private void txtIntuitionMAX_TextChanged(object sender, EventArgs e)
        {
            txtIntuitionMAX.Text = this.AttributeMaxChange(DSA_Attribute.INTUITION, txtIntuitionMAX.Text).ToString();
        }
        private void txtCharismaMAX_TextChanged(object sender, EventArgs e)
        {
            txtCharismaMAX.Text = this.AttributeMaxChange(DSA_Attribute.CHARISMA, txtCharismaMAX.Text).ToString();
        }
        private void txtFingerfertigkeitMAX_TextChanged(object sender, EventArgs e)
        {
            txtFingerfertigkeitMAX.Text = this.AttributeMaxChange(DSA_Attribute.FINGERFERTIGKEIT, txtFingerfertigkeitMAX.Text).ToString();
        }
        private void textGewandheitMAX_TextChanged(object sender, EventArgs e)
        {
            textGewandheitMAX.Text = this.AttributeMaxChange(DSA_Attribute.GEWANDHEIT, textGewandheitMAX.Text).ToString();
        }
        private void TxtKonstitutionMAX_TextChanged(object sender, EventArgs e)
        {
            txtKonstitutionMAX.Text = this.AttributeMaxChange(DSA_Attribute.KONSTITUTION, txtKonstitutionMAX.Text).ToString();
        }
        private void txtKörperkraftMAX_TextChanged(object sender, EventArgs e)
        {
            txtKörperkraftMAX.Text = this.AttributeMaxChange(DSA_Attribute.KÖRPERKRAFT, txtKörperkraftMAX.Text).ToString();
        }
        private void txtSozialstatusMAX_TextChanged(object sender, EventArgs e)
        {
            txtSozialstatusMAX.Text = this.AttributeMaxChange(DSA_Attribute.SOZAILSTATUS, txtSozialstatusMAX.Text).ToString();
        }
        private void txtGesamtMAX_TextChanged(object sender, EventArgs e)
        {
            aktualisierung();
        }
        /*Attribut Änderungen MAX Ende*/
        /*Basic Values Änderungen AKT*/
        private void txtAttackeBaisAKT_TextChanged(object sender, EventArgs e)
        {
            aktualisierung();
        }
        private void txtParadeBasisAKT_TextChanged(object sender, EventArgs e)
        {
            aktualisierung();
        }
        private void txtFernkampfBasisAKT_TextChanged(object sender, EventArgs e)
        {
            aktualisierung();
        }
        private void txtInitativeBasisAKT_TextChanged(object sender, EventArgs e)
        {
            aktualisierung();
        }
        private void txtBeherschungswertAKT_TextChanged(object sender, EventArgs e)
        {
            aktualisierung();
        }
        private void txtArtefaktkontrolleAKT_TextChanged(object sender, EventArgs e)
        {
            aktualisierung();
        }
        private void txtWundschwelleAKT_TextChanged(object sender, EventArgs e)
        {
            aktualisierung();
        }
        private void txtEntrückungAKT_TextChanged(object sender, EventArgs e)
        {
            aktualisierung();
        }
        private void txtGeschwindigkeitAKT_TextChanged(object sender, EventArgs e)
        {
            aktualisierung();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }




        /*Vasiv Values Änderungen AKT ENDE*/
    }
}
