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
        ControllClass controll;                  

        List<TextBox> txtBoxListGöttergeschenke = new List<TextBox>();
        List<TextBox> txtBoxListModifikatoren   = new List<TextBox>();
        public Form1()
        {
            controll = new ControllClass(this);
            InitializeComponent();
            /*Nötige Listen Erstellen*/
            txtBoxListGöttergeschenke.Add(txtGöttergeschenke1);
            txtBoxListGöttergeschenke.Add(txtGöttergeschenke2);
            txtBoxListGöttergeschenke.Add(txtGöttergeschenke3);

            txtBoxListModifikatoren.Add(txtModifikation1);
            txtBoxListModifikatoren.Add(txtModifikation2);
            txtBoxListModifikatoren.Add(txtModifikation3);
            
            load();
            refresh();
        }

        public void load()
        {
            txtName.Text                = (controll.BasicValue(DSA_BASICVALUES.NAME))[0];
            txtAlter.Text               = (controll.BasicValue(DSA_BASICVALUES.ALTER))[0];
            txtGeschlecht.Text          = (controll.BasicValue(DSA_BASICVALUES.GESCHLECHT))[0];
            txtGröße.Text               = (controll.BasicValue(DSA_BASICVALUES.GRÖSE))[0];
            txtGewicht.Text             = (controll.BasicValue(DSA_BASICVALUES.GEWICHT))[0];
            txtAugenfarbe.Text          = (controll.BasicValue(DSA_BASICVALUES.AUGENFARBE))[0];
            txtHaarfarbe.Text           = (controll.BasicValue(DSA_BASICVALUES.HAARFARBE))[0];
            txtHautfarbe.Text           = (controll.BasicValue(DSA_BASICVALUES.HAUTFARBE))[0];
            txtFamulienstand.Text       = (controll.BasicValue(DSA_BASICVALUES.FAMILIENSTAND))[0];
            txtAnrede.Text              = (controll.BasicValue(DSA_BASICVALUES.ANREDE))[0];
            txtGottheit.Text            = (controll.BasicValue(DSA_BASICVALUES.GOTTHEIT))[0];
            txtRasse.Text               = (controll.BasicValue(DSA_BASICVALUES.RASSE))[0];
            txtKultur.Text              = (controll.BasicValue(DSA_BASICVALUES.KULTUR))[0];
            txtProfession.Text          = (controll.BasicValue(DSA_BASICVALUES.PROFESSION))[0];

            String[] Göttergeschenke    = controll.BasicValue(DSA_BASICVALUES.GÖTTERGESCHENKE);
            String[] Modifikatoren      = controll.BasicValue(DSA_BASICVALUES.MODIFIKATOREN);

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

            txtMutAKT.Text              = controll.AttributeAKT(DSA_ATTRIBUTE.MUT, "notNumeric").ToString();
            txtKlugheitAKT.Text         = controll.AttributeAKT(DSA_ATTRIBUTE.KLUGHEIT, "notNumeric").ToString();
            txtIntuitionAKT.Text        = controll.AttributeAKT(DSA_ATTRIBUTE.INTUITION, "notNumeric").ToString();
            txtCharismaAKT.Text         = controll.AttributeAKT(DSA_ATTRIBUTE.CHARISMA, "notNumeric").ToString();
            txtFingerfertigkeitAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.FINGERFERTIGKEIT, "notNumeric").ToString();
            textGewandheitAKT.Text      = controll.AttributeAKT(DSA_ATTRIBUTE.GEWANDHEIT, "notNumeric").ToString();
            txtKonstitutionAKT.Text     = controll.AttributeAKT(DSA_ATTRIBUTE.KONSTITUTION, "notNumeric").ToString();
            txtKörperkraftAKT.Text      = controll.AttributeAKT(DSA_ATTRIBUTE.KÖRPERKRAFT, "notNumeric").ToString();
            txtSozialstatusAKT.Text     = controll.AttributeAKT(DSA_ATTRIBUTE.SOZAILSTATUS, "notNumeric").ToString();

            txtMutMOD.Text              = controll.AttributeMOD(DSA_ATTRIBUTE.MUT, txtMutMOD.Text).ToString();
            txtKlugheitMOD.Text         = controll.AttributeMOD(DSA_ATTRIBUTE.KLUGHEIT, txtKlugheitMOD.Text).ToString();
            txtIntuitionMOD.Text        = controll.AttributeMOD(DSA_ATTRIBUTE.INTUITION, txtIntuitionMOD.Text).ToString();
            txtCharismaMOD.Text         = controll.AttributeMOD(DSA_ATTRIBUTE.CHARISMA, txtCharismaMOD.Text).ToString();
            txtFingerfertigkeitMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.FINGERFERTIGKEIT, txtFingerfertigkeitMOD.Text).ToString();
            textGewandheitMOD.Text      = controll.AttributeMOD(DSA_ATTRIBUTE.GEWANDHEIT, textGewandheitMOD.Text).ToString();
            txtKonstitutionMOD.Text     = controll.AttributeMOD(DSA_ATTRIBUTE.KONSTITUTION, txtKonstitutionMOD.Text).ToString();
            txtKörperkraftMOD.Text      = controll.AttributeMOD(DSA_ATTRIBUTE.KÖRPERKRAFT, txtKörperkraftMOD.Text).ToString();
            txtSozialstatusMOD.Text     = controll.AttributeMOD(DSA_ATTRIBUTE.SOZAILSTATUS, txtSozialstatusMOD.Text).ToString();
        }
        /// <summary> 
        /// Ist bei einer Werteänderung eine Neuberechnung nötig muss dies Ausgelöst werden
        /// </summary>
        public void refresh()
        {
            txtMutMAX.Text              = controll.AttributeMAX(DSA_ATTRIBUTE.MUT).ToString();
            txtKlugheitMAX.Text         = controll.AttributeMAX(DSA_ATTRIBUTE.KLUGHEIT).ToString();
            txtIntuitionMAX.Text        = controll.AttributeMAX(DSA_ATTRIBUTE.INTUITION).ToString();
            txtCharismaMAX.Text         = controll.AttributeMAX(DSA_ATTRIBUTE.CHARISMA).ToString();
            txtFingerfertigkeitMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.FINGERFERTIGKEIT).ToString();
            textGewandheitMAX.Text      = controll.AttributeMAX(DSA_ATTRIBUTE.GEWANDHEIT).ToString();
            txtKonstitutionMAX.Text     = controll.AttributeMAX(DSA_ATTRIBUTE.KONSTITUTION).ToString();
            txtKörperkraftMAX.Text      = controll.AttributeMAX(DSA_ATTRIBUTE.KÖRPERKRAFT).ToString();
            txtSozialstatusMAX.Text     = controll.AttributeMAX(DSA_ATTRIBUTE.SOZAILSTATUS).ToString();
            
            txtAttackeBaisAKT.Text      = controll.AdvancedValue_AKT(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
            txtParadeBasisAKT.Text      = controll.AdvancedValue_AKT(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
            txtFernkampfBasisAKT.Text   = controll.AdvancedValue_AKT(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
            txtInitativeBasisAKT.Text   = controll.AdvancedValue_AKT(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
            txtBeherschungswertAKT.Text = controll.AdvancedValue_AKT(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
            txtArtefaktkontrolleAKT.Text = controll.AdvancedValue_AKT(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE).ToString();
            txtWundschwelleAKT.Text     = controll.AdvancedValue_AKT(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();
            txtEntrückungAKT.Text       = controll.AdvancedValue_AKT(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
            txtGeschwindigkeitAKT.Text  = controll.AdvancedValue_AKT(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();

            txtGesamtAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.SUMME).ToString();
            txtGesamtMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.SUMME).ToString();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
            
        }
        private void btnLoadCharacter_Click(object sender, EventArgs e)
        {
            controll.load();
        }
        private void btnSaveCharacter_Click(object sender, EventArgs e)
        {
            controll.save();
        }
        /*Attribut Änderungen Aktuelle Werte*/
        private void txtMutAKT_TextChanged(object sender, EventArgs e)
        {
            txtMutAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.MUT, txtMutAKT.Text).ToString();
        }
        private void txtKlugheitAKT_TextChanged(object sender, EventArgs e)
        {
            txtKlugheitAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.KLUGHEIT, txtKlugheitAKT.Text).ToString();
        }
        private void txtIntuitionAKT_TextChanged(object sender, EventArgs e)
        {
            txtIntuitionAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.INTUITION, txtIntuitionAKT.Text).ToString();
        }
        private void txtCharismaAKT_TextChanged(object sender, EventArgs e)
        {
            txtCharismaAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.CHARISMA, txtCharismaAKT.Text).ToString();
        }
        private void txtFingerfertigkeitAKT_TextChanged(object sender, EventArgs e)
        {
            txtFingerfertigkeitAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.FINGERFERTIGKEIT, txtFingerfertigkeitAKT.Text).ToString();
        }
        private void textGewandheitAKT_TextChanged(object sender, EventArgs e)
        {
            textGewandheitAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.GEWANDHEIT, textGewandheitAKT.Text).ToString();
        }
        private void txtKonstitutionAKT_TextChanged(object sender, EventArgs e)
        {
            txtKonstitutionAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.KONSTITUTION, txtKonstitutionAKT.Text).ToString();
        }
        private void txtKörperkraftAKT_TextChanged(object sender, EventArgs e)
        {
            txtKörperkraftAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.KÖRPERKRAFT, txtKörperkraftAKT.Text).ToString();
        }
        private void txtSozialstatusAKT_TextChanged(object sender, EventArgs e)
        {
            txtSozialstatusAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.SOZAILSTATUS, txtSozialstatusAKT.Text).ToString();
        }
        private void txtGesamtAKT_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        /*Attribut Änderungen Aktuelle Werte Ende*/

        /*Attribut Änderungen Modifikatoren*/
        private void txtMutMOD_TextChanged(object sender, EventArgs e)
        {
            txtMutMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.MUT, txtMutMOD.Text).ToString();
        }   
        private void txtKlugheitMOD_TextChanged(object sender, EventArgs e)
        {
            txtKlugheitMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.KLUGHEIT, txtKlugheitMOD.Text).ToString();
        }
        private void txtIntuitionMOD_TextChanged(object sender, EventArgs e)
        {
            txtIntuitionMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.INTUITION, txtIntuitionMOD.Text).ToString();
        }
        private void txtCharismaMOD_TextChanged(object sender, EventArgs e)
        {
            txtCharismaMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.CHARISMA, txtCharismaMOD.Text).ToString();
        }
        private void txtFingerfertigkeitMOD_TextChanged(object sender, EventArgs e)
        {
            txtFingerfertigkeitMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.FINGERFERTIGKEIT, txtFingerfertigkeitMOD.Text).ToString();
        }
        private void textGewandheitMOD_TextChanged(object sender, EventArgs e)
        {
            textGewandheitMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.GEWANDHEIT, textGewandheitMOD.Text).ToString();
        }
        private void txtKonstitutionMOD_TextChanged(object sender, EventArgs e)
        {
            txtKonstitutionMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.KONSTITUTION, txtKonstitutionMOD.Text).ToString();
        }
        private void txtKörperkraftMOD_TextChanged(object sender, EventArgs e)
        {
            txtKörperkraftMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.KÖRPERKRAFT, txtKörperkraftMOD.Text).ToString();
        }
        private void txtSozialstatusMOD_TextChanged(object sender, EventArgs e)
        {
            txtSozialstatusMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.SOZAILSTATUS, txtSozialstatusMOD.Text).ToString();
        }
        /*Attribut Änderungen Modifikatoren Ende*/
        /*Attribut Änderungen MAX*/
        private void txtMutMAX_TextChanged(object sender, EventArgs e)
        {
            txtMutMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.MUT, txtMutMAX.Text).ToString();
        }
        private void txtKlugheitMAX_TextChanged(object sender, EventArgs e)
        {
            txtKlugheitMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.KLUGHEIT, txtKlugheitMAX.Text).ToString();
        }
        private void txtIntuitionMAX_TextChanged(object sender, EventArgs e)
        {
            txtIntuitionMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.INTUITION, txtIntuitionMAX.Text).ToString();
        }
        private void txtCharismaMAX_TextChanged(object sender, EventArgs e)
        {
            txtCharismaMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.CHARISMA, txtCharismaMAX.Text).ToString();
        }
        private void txtFingerfertigkeitMAX_TextChanged(object sender, EventArgs e)
        {
            txtFingerfertigkeitMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.FINGERFERTIGKEIT, txtFingerfertigkeitMAX.Text).ToString();
        }
        private void textGewandheitMAX_TextChanged(object sender, EventArgs e)
        {
            textGewandheitMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.GEWANDHEIT, textGewandheitMAX.Text).ToString();
        }
        private void TxtKonstitutionMAX_TextChanged(object sender, EventArgs e)
        {
            txtKonstitutionMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.KONSTITUTION, txtKonstitutionMAX.Text).ToString();
        }
        private void txtKörperkraftMAX_TextChanged(object sender, EventArgs e)
        {
            txtKörperkraftMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.KÖRPERKRAFT, txtKörperkraftMAX.Text).ToString();
        }
        private void txtSozialstatusMAX_TextChanged(object sender, EventArgs e)
        {
            txtSozialstatusMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.SOZAILSTATUS, txtSozialstatusMAX.Text).ToString();
        }
        private void txtGesamtMAX_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        /*Attribut Änderungen MAX Ende*/
        /*Basic Values Änderungen AKT*/
        private void txtAttackeBaisAKT_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        private void txtParadeBasisAKT_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        private void txtFernkampfBasisAKT_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        private void txtInitativeBasisAKT_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        private void txtBeherschungswertAKT_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        private void txtArtefaktkontrolleAKT_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        private void txtWundschwelleAKT_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        private void txtEntrückungAKT_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        private void txtGeschwindigkeitAKT_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }




        /*Vasiv Values Änderungen AKT ENDE*/
    }
}
