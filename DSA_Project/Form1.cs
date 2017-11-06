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

            txtAttackeBasisMOD.Text     = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
            txtParadeBasisMOD.Text      = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
            txtFernkampfBasisMOD.Text   = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
            txtInitativeBasisMOD.Text   = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
            txtBeherschungswertMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
            txtArtefaktkontrolleMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE).ToString();
            txtWundschwelleMOD.Text     = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();
            txtEntrückungMOD.Text       = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
            txtGeschwindigkeitMOD.Text  = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();
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
            
            txtAttackeBaisAKT.Text      = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
            txtParadeBasisAKT.Text      = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
            txtFernkampfBasisAKT.Text   = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
            txtInitativeBasisAKT.Text   = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
            txtBeherschungswertAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
            txtArtefaktkontrolleAKT.Text= controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE).ToString();
            txtWundschwelleAKT.Text     = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();
            txtEntrückungAKT.Text       = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
            txtGeschwindigkeitAKT.Text  = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();

            txtAttackeBaisMAX.Text      = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
            txtParadeBasisMAX.Text      = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
            txtFernkampfBasisMAX.Text   = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
            txtInitativeBasisMAX.Text   = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
            txtBeherschungswertMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
            txtArtefaktkontrolleMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE).ToString();
            txtWundschwelleMAX.Text     = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();
            txtEntrückungMAX.Text       = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
            txtGeschwindigkeitMAX.Text  = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();

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
        /*Basiv Values Änderungen AKT ENDE*/


        /*BasivValue Änderungen*/
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName.Text = controll.BasicValue(DSA_BASICVALUES.NAME, txtName.Text)[0];
        }
        private void txtAugenfarbe_TextChanged(object sender, EventArgs e)
        {
            txtAugenfarbe.Text = controll.BasicValue(DSA_BASICVALUES.AUGENFARBE, txtAugenfarbe.Text)[0];
        }
        private void txtAnrede_TextChanged(object sender, EventArgs e)
        {
            txtAnrede.Text = controll.BasicValue(DSA_BASICVALUES.ANREDE, txtAnrede.Text)[0];
        }
        private void txtRasse_TextChanged(object sender, EventArgs e)
        {
            txtRasse.Text = controll.BasicValue(DSA_BASICVALUES.RASSE, txtRasse.Text)[0];
        }
        private void txtKultur_TextChanged(object sender, EventArgs e)
        {
            txtKultur.Text = controll.BasicValue(DSA_BASICVALUES.KULTUR, txtKultur.Text)[0];
        }
        private void txtProfession_TextChanged(object sender, EventArgs e)
        {
            txtProfession.Name = controll.BasicValue(DSA_BASICVALUES.PROFESSION, txtProfession.Text)[0];
        }
        private void txtAlter_TextChanged(object sender, EventArgs e)
        {
            txtAlter.Text = controll.BasicValue(DSA_BASICVALUES.ALTER, txtAlter.Text)[0];
        }
        private void txtHaarfarbe_TextChanged(object sender, EventArgs e)
        {
            txtHaarfarbe.Text = controll.BasicValue(DSA_BASICVALUES.HAARFARBE, txtHaarfarbe.Text)[0];
        }
        private void txtGottheit_TextChanged(object sender, EventArgs e)
        {
            txtGottheit.Text = controll.BasicValue(DSA_BASICVALUES.GOTTHEIT, txtGottheit.Text)[0];
        }
        private void txtModifikation1_TextChanged(object sender, EventArgs e)
        {
            txtModifikation1.Text = controll.BasicValue(DSA_BASICVALUES.MODIFIKATOREN, txtModifikation1.Text)[0];
        }
        private void txtModifikation2_TextChanged(object sender, EventArgs e)
        {
            txtModifikation2.Text = controll.BasicValue(DSA_BASICVALUES.MODIFIKATOREN, txtModifikation2.Text)[1];
        }
        private void txtModifikation3_TextChanged(object sender, EventArgs e)
        {
            txtModifikation3.Text = controll.BasicValue(DSA_BASICVALUES.MODIFIKATOREN, txtModifikation3.Text)[2];
        }
        private void txtGewicht_TextChanged(object sender, EventArgs e)
        {
            txtGewicht.Text = controll.BasicValue(DSA_BASICVALUES.GEWICHT, txtGewicht.Text)[0];
        }
        private void txtFamulienstand_TextChanged(object sender, EventArgs e)
        {
            txtFamulienstand.Text = controll.BasicValue(DSA_BASICVALUES.FAMILIENSTAND, txtFamulienstand.Text)[0];
        }
        private void txtGöttergeschenke1_TextChanged(object sender, EventArgs e)
        {
            txtGöttergeschenke1.Text = controll.BasicValue(DSA_BASICVALUES.GÖTTERGESCHENKE, txtGöttergeschenke1.Text)[0];
        }
        private void txtGöttergeschenke2_TextChanged(object sender, EventArgs e)
        {
            txtGöttergeschenke2.Text = controll.BasicValue(DSA_BASICVALUES.GÖTTERGESCHENKE, txtGöttergeschenke2.Text)[1];
        }
        private void txtGöttergeschenke3_TextChanged(object sender, EventArgs e)
        {
            txtGöttergeschenke3.Text = controll.BasicValue(DSA_BASICVALUES.GÖTTERGESCHENKE, txtGöttergeschenke3.Text)[2];
        }
        private void txtGöttergeschenke4_TextChanged(object sender, EventArgs e)
        {
            txtGöttergeschenke4.Text = controll.BasicValue(DSA_BASICVALUES.GÖTTERGESCHENKE, txtGöttergeschenke4.Text)[3];
        }
        private void txtGeschlecht_TextChanged(object sender, EventArgs e)
        {
            txtGeschlecht.Text = controll.BasicValue(DSA_BASICVALUES.GESCHLECHT, txtGeschlecht.Text)[0];
        }
        private void txtGröße_TextChanged(object sender, EventArgs e)
        {
            txtGröße.Text = controll.BasicValue(DSA_BASICVALUES.GRÖSE, txtGröße.Text)[0];
        }
        private void txtHautfarbe_TextChanged(object sender, EventArgs e)
        {
            txtHautfarbe.Text = controll.BasicValue(DSA_BASICVALUES.HAUTFARBE, txtHautfarbe.Text)[0];
        }


        private void txtAttackeBasisMOD_TextChanged(object sender, EventArgs e)
        {
            txtAttackeBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
        }
        private void txtParadeBasisMOD_TextChanged(object sender, EventArgs e)
        {
            txtParadeBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
        }
        private void txtFernkampfBasisMOD_TextChanged(object sender, EventArgs e)
        {
            txtParadeBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
        }
        private void txtInitativeBasisMOD_TextChanged(object sender, EventArgs e)
        {
            txtInitativeBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
        }
        private void txtBeherschungswertMOD_TextChanged(object sender, EventArgs e)
        {
            txtBeherschungswertMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
        }
        private void txtArtefaktkontrolleMOD_TextChanged(object sender, EventArgs e)
        {
            txtArtefaktkontrolleMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
        }
        private void txtWundschwelleMOD_TextChanged(object sender, EventArgs e)
        {
            txtWundschwelleMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();
        }
        private void txtEntrückungMOD_TextChanged(object sender, EventArgs e)
        {
            txtEntrückungMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
        }
        private void txtGeschwindigkeitMOD_TextChanged(object sender, EventArgs e)
        {
            txtGeschwindigkeitMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();
        }


        private void txtAttackeBaisMAX_TextChanged(object sender, EventArgs e)
        {
            txtAttackeBaisMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
        }

        private void txtParadeBasisMAX_TextChanged(object sender, EventArgs e)
        {
            txtParadeBasisMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
        }

        private void txtFernkampfBasisMAX_TextChanged(object sender, EventArgs e)
        {
            txtFernkampfBasisMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
        }

        private void txtInitativeBasisMAX_TextChanged(object sender, EventArgs e)
        {
            txtInitativeBasisMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
        }

        private void txtBeherschungswertMAX_TextChanged(object sender, EventArgs e)
        {
            txtBeherschungswertMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
        }

        private void txtArtefaktkontrolleMAX_TextChanged(object sender, EventArgs e)
        {
            txtArtefaktkontrolleMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE).ToString();
        }

        private void txtWundschwelleMAX_TextChanged(object sender, EventArgs e)
        {
            txtWundschwelleMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();
        }

        private void txtEntrückungMAX_TextChanged(object sender, EventArgs e)
        {
            txtEntrückungMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
        }

        private void txtGeschwindigkeitMAX_TextChanged(object sender, EventArgs e)
        {
            txtGeschwindigkeitMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();
        }
    }
}
