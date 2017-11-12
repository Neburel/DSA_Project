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
                
        public Form1()
        {
            controll = new ControllClass(this);
            InitializeComponent();
            
            load();
            refresh();
        }

        public void load()
        {
            txtName.Text                = (controll.BasicValue(DSA_BASICVALUES.NAME));
            txtAlter.Text               = (controll.BasicValue(DSA_BASICVALUES.ALTER));
            txtGeschlecht.Text          = (controll.BasicValue(DSA_BASICVALUES.GESCHLECHT));
            txtGröße.Text               = (controll.BasicValue(DSA_BASICVALUES.GRÖSE));
            txtGewicht.Text             = (controll.BasicValue(DSA_BASICVALUES.GEWICHT));
            txtAugenfarbe.Text          = (controll.BasicValue(DSA_BASICVALUES.AUGENFARBE));
            txtHaarfarbe.Text           = (controll.BasicValue(DSA_BASICVALUES.HAARFARBE));
            txtHautfarbe.Text           = (controll.BasicValue(DSA_BASICVALUES.HAUTFARBE));
            txtFamulienstand.Text       = (controll.BasicValue(DSA_BASICVALUES.FAMILIENSTAND));
            txtAnrede.Text              = (controll.BasicValue(DSA_BASICVALUES.ANREDE));
            txtGottheit.Text            = (controll.BasicValue(DSA_BASICVALUES.GOTTHEIT));
            txtRasse.Text               = (controll.BasicValue(DSA_BASICVALUES.RASSE));
            txtKultur.Text              = (controll.BasicValue(DSA_BASICVALUES.KULTUR));
            txtProfession.Text          = (controll.BasicValue(DSA_BASICVALUES.PROFESSION));
            txtModifikation1.Text       = controll.Moodifikator(1);
            txtModifikation2.Text       = controll.Moodifikator(2);
            txtModifikation3.Text       = controll.Moodifikator(3);
            txtGöttergeschenke1.Text    = controll.Göttergeschenk(1);
            txtGöttergeschenke2.Text    = controll.Göttergeschenk(2);
            txtGöttergeschenke3.Text    = controll.Göttergeschenk(3);
            txtGöttergeschenke4.Text    = controll.Göttergeschenk(4);


            txtMutAKT.Text              = controll.AttributeAKT(DSA_ATTRIBUTE.MU, "notNumeric").ToString();
            txtKlugheitAKT.Text         = controll.AttributeAKT(DSA_ATTRIBUTE.KL, "notNumeric").ToString();
            txtIntuitionAKT.Text        = controll.AttributeAKT(DSA_ATTRIBUTE.IN, "notNumeric").ToString();
            txtCharismaAKT.Text         = controll.AttributeAKT(DSA_ATTRIBUTE.CH, "notNumeric").ToString();
            txtFingerfertigkeitAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.FF, "notNumeric").ToString();
            textGewandheitAKT.Text      = controll.AttributeAKT(DSA_ATTRIBUTE.GE, "notNumeric").ToString();
            txtKonstitutionAKT.Text     = controll.AttributeAKT(DSA_ATTRIBUTE.KO, "notNumeric").ToString();
            txtKörperkraftAKT.Text      = controll.AttributeAKT(DSA_ATTRIBUTE.KK, "notNumeric").ToString();
            txtSozialstatusAKT.Text     = controll.AttributeAKT(DSA_ATTRIBUTE.SO, "notNumeric").ToString();

            txtMutMOD.Text              = controll.AttributeMOD(DSA_ATTRIBUTE.MU, txtMutMOD.Text).ToString();
            txtKlugheitMOD.Text         = controll.AttributeMOD(DSA_ATTRIBUTE.KL, txtKlugheitMOD.Text).ToString();
            txtIntuitionMOD.Text        = controll.AttributeMOD(DSA_ATTRIBUTE.IN, txtIntuitionMOD.Text).ToString();
            txtCharismaMOD.Text         = controll.AttributeMOD(DSA_ATTRIBUTE.CH, txtCharismaMOD.Text).ToString();
            txtFingerfertigkeitMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.FF, txtFingerfertigkeitMOD.Text).ToString();
            textGewandheitMOD.Text      = controll.AttributeMOD(DSA_ATTRIBUTE.GE, textGewandheitMOD.Text).ToString();
            txtKonstitutionMOD.Text     = controll.AttributeMOD(DSA_ATTRIBUTE.KO, txtKonstitutionMOD.Text).ToString();
            txtKörperkraftMOD.Text      = controll.AttributeMOD(DSA_ATTRIBUTE.KK, txtKörperkraftMOD.Text).ToString();
            txtSozialstatusMOD.Text     = controll.AttributeMOD(DSA_ATTRIBUTE.SO, txtSozialstatusMOD.Text).ToString();

            txtAttackeBasisMOD.Text     = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
            txtParadeBasisMOD.Text      = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
            txtFernkampfBasisMOD.Text   = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
            txtInitativeBasisMOD.Text   = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
            txtBeherschungswertMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
            txtArtefaktkontrolleMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE).ToString();
            txtWundschwelleMOD.Text     = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();
            txtEntrückungMOD.Text       = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
            txtGeschwindigkeitMOD.Text  = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();
            
            txtGeldD.Text               = controll.Money(DSA_MONEY.D).ToString();
            txtGeldH.Text               = controll.Money(DSA_MONEY.H).ToString();
            txtGeldS.Text               = controll.Money(DSA_MONEY.S).ToString();
            txtGeldK.Text               = controll.Money(DSA_MONEY.K).ToString();
            txtBank.Text                = controll.Money(DSA_MONEY.BANK).ToString();

            LoadFeature(txtVorteil1Name, txtVorteil1Beschreibung, txtVorteil1Wert, txtVorteil1GP, DSA_FEATURES.VORTEIL, 1);
            LoadFeature(txtVorteil2Name, txtVorteil2Beschreibung, txtVorteil2Wert, txtVorteil2GP, DSA_FEATURES.VORTEIL, 2);
            LoadFeature(txtVorteil3Name, txtVorteil3Beschreibung, txtVorteil3Wert, txtVorteil3GP, DSA_FEATURES.VORTEIL, 3);
            LoadFeature(txtVorteil4Name, txtVorteil4Beschreibung, txtVorteil4Wert, txtVorteil4GP, DSA_FEATURES.VORTEIL, 4);
            LoadFeature(txtVorteil5Name, txtVorteil5Beschreibung, txtVorteil5Wert, txtVorteil5GP, DSA_FEATURES.VORTEIL, 5);
            LoadFeature(txtVorteil6Name, txtVorteil6Beschreibung, txtVorteil6Wert, txtVorteil6GP, DSA_FEATURES.VORTEIL, 6);
            LoadFeature(txtVorteil7Name, txtVorteil7Beschreibung, txtVorteil7Wert, txtVorteil7GP, DSA_FEATURES.VORTEIL, 7);
            LoadFeature(txtVorteil8Name, txtVorteil8Beschreibung, txtVorteil8Wert, txtVorteil8GP, DSA_FEATURES.VORTEIL, 8);
            LoadFeature(txtVorteil9Name, txtVorteil9Beschreibung, txtVorteil9Wert, txtVorteil9GP, DSA_FEATURES.VORTEIL, 9);
            LoadFeature(txtVorteil10Name, txtVorteil10Beschreibung, txtVorteil10Wert, txtVorteil10GP, DSA_FEATURES.VORTEIL, 10);
            LoadFeature(txtVorteil11Name, txtVorteil11Beschreibung, txtVorteil11Wert, txtVorteil11GP, DSA_FEATURES.VORTEIL, 11);
            LoadFeature(txtVorteil12Name, txtVorteil12Beschreibung, txtVorteil12Wert, txtVorteil12GP, DSA_FEATURES.VORTEIL, 12);
            LoadFeature(txtVorteil13Name, txtVorteil13Beschreibung, txtVorteil13Wert, txtVorteil13GP, DSA_FEATURES.VORTEIL, 13);
            LoadFeature(txtVorteil14Name, txtVorteil14Beschreibung, txtVorteil14Wert, txtVorteil14GP, DSA_FEATURES.VORTEIL, 14);
            LoadFeature(txtVorteil15Name, txtVorteil15Beschreibung, txtVorteil15Wert, txtVorteil15GP, DSA_FEATURES.VORTEIL, 15);

            LoadFeature(txtNachteil1Name, txtNachteil1Beschreibung, txtNachteil1Wert, txtNachteil1GP, DSA_FEATURES.NACHTEIL, 1);
            LoadFeature(txtNachteil2Name, txtNachteil2Beschreibung, txtNachteil2Wert, txtNachteil2GP, DSA_FEATURES.NACHTEIL, 2);
            LoadFeature(txtNachteil3Name, txtNachteil3Beschreibung, txtNachteil3Wert, txtNachteil3GP, DSA_FEATURES.NACHTEIL, 3);
            LoadFeature(txtNachteil4Name, txtNachteil4Beschreibung, txtNachteil4Wert, txtNachteil4GP, DSA_FEATURES.NACHTEIL, 4);
            LoadFeature(txtNachteil5Name, txtNachteil5Beschreibung, txtNachteil5Wert, txtNachteil5GP, DSA_FEATURES.NACHTEIL, 5);
            LoadFeature(txtNachteil6Name, txtNachteil6Beschreibung, txtNachteil6Wert, txtNachteil6GP, DSA_FEATURES.NACHTEIL, 6);
            LoadFeature(txtNachteil7Name, txtNachteil7Beschreibung, txtNachteil7Wert, txtNachteil7GP, DSA_FEATURES.NACHTEIL, 7);
            LoadFeature(txtNachteil8Name, txtNachteil8Beschreibung, txtNachteil8Wert, txtNachteil8GP, DSA_FEATURES.NACHTEIL, 8);
            LoadFeature(txtNachteil9Name, txtNachteil9Beschreibung, txtNachteil9Wert, txtNachteil9GP, DSA_FEATURES.NACHTEIL, 9);
            LoadFeature(txtNachteil10Name, txtNachteil10Beschreibung, txtNachteil10Wert, txtNachteil10GP, DSA_FEATURES.NACHTEIL, 10);
            LoadFeature(txtNachteil11Name, txtNachteil11Beschreibung, txtNachteil11Wert, txtNachteil11GP, DSA_FEATURES.NACHTEIL, 11);
            LoadFeature(txtNachteil12Name, txtNachteil12Beschreibung, txtNachteil12Wert, txtNachteil12GP, DSA_FEATURES.NACHTEIL, 12);
            LoadFeature(txtNachteil13Name, txtNachteil13Beschreibung, txtNachteil13Wert, txtNachteil13GP, DSA_FEATURES.NACHTEIL, 13);
            LoadFeature(txtNachteil14Name, txtNachteil14Beschreibung, txtNachteil14Wert, txtNachteil14GP, DSA_FEATURES.NACHTEIL, 14);
            LoadFeature(txtNachteil15Name, txtNachteil15Beschreibung, txtNachteil15Wert, txtNachteil15GP, DSA_FEATURES.NACHTEIL, 15);
        }
        /// <summary> 
        /// Ist bei einer Werteänderung eine Neuberechnung nötig muss dies Ausgelöst werden
        /// </summary>
        public void refresh()
        {
            txtMutMAX.Text              = controll.AttributeMAX(DSA_ATTRIBUTE.MU).ToString();
            txtKlugheitMAX.Text         = controll.AttributeMAX(DSA_ATTRIBUTE.KL).ToString();
            txtIntuitionMAX.Text        = controll.AttributeMAX(DSA_ATTRIBUTE.IN).ToString();
            txtCharismaMAX.Text         = controll.AttributeMAX(DSA_ATTRIBUTE.CH).ToString();
            txtFingerfertigkeitMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.FF).ToString();
            textGewandheitMAX.Text      = controll.AttributeMAX(DSA_ATTRIBUTE.GE).ToString();
            txtKonstitutionMAX.Text     = controll.AttributeMAX(DSA_ATTRIBUTE.KO).ToString();
            txtKörperkraftMAX.Text      = controll.AttributeMAX(DSA_ATTRIBUTE.KK).ToString();
            txtSozialstatusMAX.Text     = controll.AttributeMAX(DSA_ATTRIBUTE.SO).ToString();
            
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

            txtGesamtAKT.Text           = controll.getAttributeAKTSumme().ToString();
            txtGesamtMAX.Text           = controll.getAttributeMAXSumme().ToString();

            txtLebensenergieVOR.Text    = controll.EnergieVOR(DSA_ENERGIEN.LEBENSENERGIE).ToString();
            txtAusdauerVOR.Text         = controll.EnergieVOR(DSA_ENERGIEN.AUSDAUER).ToString();
            txtKarmaenergieVOR.Text     = controll.EnergieVOR(DSA_ENERGIEN.KARMAENERGIE).ToString();
            txtAstralenergieVOR.Text    = controll.EnergieVOR(DSA_ENERGIEN.ASTRALENERGIE).ToString();
            txtMagieresistenzVOR.Text   = controll.EnergieVOR(DSA_ENERGIEN.MAGIERESISTENZ).ToString();

            txtLebensenergiePERM.Text   = controll.EnergiePERM(DSA_ENERGIEN.LEBENSENERGIE).ToString();
            txtAusdauerPERM.Text        = controll.EnergiePERM(DSA_ENERGIEN.AUSDAUER).ToString();
            txtAstralenergiePERM.Text   = controll.EnergiePERM(DSA_ENERGIEN.ASTRALENERGIE).ToString();
            txtKarmaenergiePERM.Text    = controll.EnergiePERM(DSA_ENERGIEN.KARMAENERGIE).ToString();
            txtMagieresistenzPERM.Text  = controll.EnergiePERM(DSA_ENERGIEN.MAGIERESISTENZ).ToString();

            txtLebensenergieMOD.Text    = controll.EnergieMOD(DSA_ENERGIEN.LEBENSENERGIE).ToString();
            txtAusdauerMOD.Text         = controll.EnergieMOD(DSA_ENERGIEN.AUSDAUER).ToString();
            txtKarmaenergieMOD.Text     = controll.EnergieMOD(DSA_ENERGIEN.KARMAENERGIE).ToString();
            txtAstralenergieMOD.Text    = controll.EnergieMOD(DSA_ENERGIEN.ASTRALENERGIE).ToString();
            txtMagieresistenzMOD.Text   = controll.EnergieMOD(DSA_ENERGIEN.MAGIERESISTENZ).ToString();

            txtLebensenergieMALI.Text   = controll.EnergieMALI(DSA_ENERGIEN.LEBENSENERGIE).ToString();
            txtAusdauerMALI.Text        = controll.EnergieMALI(DSA_ENERGIEN.AUSDAUER).ToString();
            txtAstralenergieMALI.Text   = controll.EnergieMALI(DSA_ENERGIEN.ASTRALENERGIE).ToString();
            txtKarmaenergieMALI.Text    = controll.EnergieMALI(DSA_ENERGIEN.KARMAENERGIE).ToString();
            txtMagieresistenzMALI.Text  = controll.EnergieMALI(DSA_ENERGIEN.MAGIERESISTENZ).ToString();

            txtLebensenergieERG.Text    = controll.EnergieMAX(DSA_ENERGIEN.LEBENSENERGIE).ToString();
            txtAusdauerERG.Text         = controll.EnergieMAX(DSA_ENERGIEN.AUSDAUER).ToString();
            txtAstralenergieERG.Text    = controll.EnergieMAX(DSA_ENERGIEN.ASTRALENERGIE).ToString();
            txtKarmaenergieERG.Text     = controll.EnergieMAX(DSA_ENERGIEN.KARMAENERGIE).ToString();
            txtMagieresistenzERG.Text   = controll.EnergieMAX(DSA_ENERGIEN.MAGIERESISTENZ).ToString();
        }
        private void LoadFeature(TextBox name, TextBox description, TextBox value, TextBox gp, DSA_FEATURES type, int number)
        {
            Feature feature = controll.FeatureExisting(number, type);

            if(feature == null) { return; }

            name.Text           = feature.getName();
            description.Text    = feature.getDescription();
            value.Text          = feature.getValue();
            gp.Text             = feature.getGP();

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
            txtMutAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.MU, txtMutAKT.Text).ToString();
        }
        private void txtKlugheitAKT_TextChanged(object sender, EventArgs e)
        {
            txtKlugheitAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.KL, txtKlugheitAKT.Text).ToString();
        }
        private void txtIntuitionAKT_TextChanged(object sender, EventArgs e)
        {
            txtIntuitionAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.IN, txtIntuitionAKT.Text).ToString();
        }
        private void txtCharismaAKT_TextChanged(object sender, EventArgs e)
        {
            txtCharismaAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.CH, txtCharismaAKT.Text).ToString();
        }
        private void txtFingerfertigkeitAKT_TextChanged(object sender, EventArgs e)
        {
            txtFingerfertigkeitAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.FF, txtFingerfertigkeitAKT.Text).ToString();
        }
        private void textGewandheitAKT_TextChanged(object sender, EventArgs e)
        {
            textGewandheitAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.GE, textGewandheitAKT.Text).ToString();
        }
        private void txtKonstitutionAKT_TextChanged(object sender, EventArgs e)
        {
            txtKonstitutionAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.KO, txtKonstitutionAKT.Text).ToString();
        }
        private void txtKörperkraftAKT_TextChanged(object sender, EventArgs e)
        {
            txtKörperkraftAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.KK, txtKörperkraftAKT.Text).ToString();
        }
        private void txtSozialstatusAKT_TextChanged(object sender, EventArgs e)
        {
            txtSozialstatusAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.SO, txtSozialstatusAKT.Text).ToString();
        }
        private void txtGesamtAKT_TextChanged(object sender, EventArgs e)
        {
            refresh();
        }
        /*Attribut Änderungen Aktuelle Werte Ende*/

        /*Attribut Änderungen Modifikatoren*/
        private void txtMutMOD_TextChanged(object sender, EventArgs e)
        {
            txtMutMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.MU, txtMutMOD.Text).ToString();
        }   
        private void txtKlugheitMOD_TextChanged(object sender, EventArgs e)
        {
            txtKlugheitMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.KL, txtKlugheitMOD.Text).ToString();
        }
        private void txtIntuitionMOD_TextChanged(object sender, EventArgs e)
        {
            txtIntuitionMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.IN, txtIntuitionMOD.Text).ToString();
        }
        private void txtCharismaMOD_TextChanged(object sender, EventArgs e)
        {
            txtCharismaMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.CH, txtCharismaMOD.Text).ToString();
        }
        private void txtFingerfertigkeitMOD_TextChanged(object sender, EventArgs e)
        {
            txtFingerfertigkeitMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.FF, txtFingerfertigkeitMOD.Text).ToString();
        }
        private void textGewandheitMOD_TextChanged(object sender, EventArgs e)
        {
            textGewandheitMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.GE, textGewandheitMOD.Text).ToString();
        }
        private void txtKonstitutionMOD_TextChanged(object sender, EventArgs e)
        {
            txtKonstitutionMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.KO, txtKonstitutionMOD.Text).ToString();
        }
        private void txtKörperkraftMOD_TextChanged(object sender, EventArgs e)
        {
            txtKörperkraftMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.KK, txtKörperkraftMOD.Text).ToString();
        }
        private void txtSozialstatusMOD_TextChanged(object sender, EventArgs e)
        {
            txtSozialstatusMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.SO, txtSozialstatusMOD.Text).ToString();
        }
        /*Attribut Änderungen Modifikatoren Ende*/
        /*Attribut Änderungen MAX*/
        private void txtMutMAX_TextChanged(object sender, EventArgs e)
        {
            txtMutMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.MU, txtMutMAX.Text).ToString();
        }
        private void txtKlugheitMAX_TextChanged(object sender, EventArgs e)
        {
            txtKlugheitMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.KL, txtKlugheitMAX.Text).ToString();
        }
        private void txtIntuitionMAX_TextChanged(object sender, EventArgs e)
        {
            txtIntuitionMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.IN, txtIntuitionMAX.Text).ToString();
        }
        private void txtCharismaMAX_TextChanged(object sender, EventArgs e)
        {
            txtCharismaMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.CH, txtCharismaMAX.Text).ToString();
        }
        private void txtFingerfertigkeitMAX_TextChanged(object sender, EventArgs e)
        {
            txtFingerfertigkeitMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.FF, txtFingerfertigkeitMAX.Text).ToString();
        }
        private void textGewandheitMAX_TextChanged(object sender, EventArgs e)
        {
            textGewandheitMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.GE, textGewandheitMAX.Text).ToString();
        }
        private void TxtKonstitutionMAX_TextChanged(object sender, EventArgs e)
        {
            txtKonstitutionMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.KO, txtKonstitutionMAX.Text).ToString();
        }
        private void txtKörperkraftMAX_TextChanged(object sender, EventArgs e)
        {
            txtKörperkraftMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.KK, txtKörperkraftMAX.Text).ToString();
        }
        private void txtSozialstatusMAX_TextChanged(object sender, EventArgs e)
        {
            txtSozialstatusMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.SO, txtSozialstatusMAX.Text).ToString();
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
            TextBox textBox = (TextBox)sender;
            textBox.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT, textBox.Text).ToString();
        }
        private void txtArtefaktkontrolleAKT_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE, textBox.Text).ToString();
        }
        private void txtWundschwelleAKT_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.WUNDSCHWELLE, textBox.Text).ToString(); ;
        }
        private void txtEntrückungAKT_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.ENTRÜCKUNG, textBox.Text).ToString();
        }
        private void txtGeschwindigkeitAKT_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT, textBox.Text).ToString();
        }
        /*Basiv Values Änderungen AKT ENDE*/


        /*BasivValue Änderungen*/
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName.Text = controll.BasicValue(DSA_BASICVALUES.NAME, txtName.Text);
        }
        private void txtAugenfarbe_TextChanged(object sender, EventArgs e)
        {
            txtAugenfarbe.Text = controll.BasicValue(DSA_BASICVALUES.AUGENFARBE, txtAugenfarbe.Text);
        }
        private void txtAnrede_TextChanged(object sender, EventArgs e)
        {
            txtAnrede.Text = controll.BasicValue(DSA_BASICVALUES.ANREDE, txtAnrede.Text);
        }
        private void txtRasse_TextChanged(object sender, EventArgs e)
        {
            txtRasse.Text = controll.BasicValue(DSA_BASICVALUES.RASSE, txtRasse.Text);
        }
        private void txtKultur_TextChanged(object sender, EventArgs e)
        {
            txtKultur.Text = controll.BasicValue(DSA_BASICVALUES.KULTUR, txtKultur.Text);
        }
        private void txtProfession_TextChanged(object sender, EventArgs e)
        {
            txtProfession.Name = controll.BasicValue(DSA_BASICVALUES.PROFESSION, txtProfession.Text);
        }
        private void txtAlter_TextChanged(object sender, EventArgs e)
        {
            txtAlter.Text = controll.BasicValue(DSA_BASICVALUES.ALTER, txtAlter.Text);
        }
        private void txtHaarfarbe_TextChanged(object sender, EventArgs e)
        {
            txtHaarfarbe.Text = controll.BasicValue(DSA_BASICVALUES.HAARFARBE, txtHaarfarbe.Text);
        }
        private void txtGottheit_TextChanged(object sender, EventArgs e)
        {
            txtGottheit.Text = controll.BasicValue(DSA_BASICVALUES.GOTTHEIT, txtGottheit.Text);
        }
        private void txtModifikation1_TextChanged(object sender, EventArgs e)
        {
            txtModifikation1.Text = controll.Moodifikator(1, txtModifikation1.Text);
        }
        private void txtModifikation2_TextChanged(object sender, EventArgs e)
        {
            txtModifikation2.Text = controll.Moodifikator(2, txtModifikation2.Text);
        }
        private void txtModifikation3_TextChanged(object sender, EventArgs e)
        {
            txtModifikation3.Text = controll.Moodifikator(3, txtModifikation3.Text);
        }
        private void txtGewicht_TextChanged(object sender, EventArgs e)
        {
            txtGewicht.Text = controll.BasicValue(DSA_BASICVALUES.GEWICHT, txtGewicht.Text);
        }
        private void txtFamulienstand_TextChanged(object sender, EventArgs e)
        {
            txtFamulienstand.Text = controll.BasicValue(DSA_BASICVALUES.FAMILIENSTAND, txtFamulienstand.Text);
        }
        private void txtGöttergeschenke1_TextChanged(object sender, EventArgs e)
        {
            txtGöttergeschenke1.Text = controll.Göttergeschenk(1, txtGöttergeschenke1.Text);
        }
        private void txtGöttergeschenke2_TextChanged(object sender, EventArgs e)
        {
            txtGöttergeschenke2.Text = controll.Göttergeschenk(2, txtGöttergeschenke2.Text);
        }
        private void txtGöttergeschenke3_TextChanged(object sender, EventArgs e)
        {
            txtGöttergeschenke3.Text = controll.Göttergeschenk(3, txtGöttergeschenke3.Text);
        }
        private void txtGöttergeschenke4_TextChanged(object sender, EventArgs e)
        {
            txtGöttergeschenke4.Text = controll.Göttergeschenk(4, txtGöttergeschenke4.Text);
        }
        private void txtGeschlecht_TextChanged(object sender, EventArgs e)
        {
            txtGeschlecht.Text = controll.BasicValue(DSA_BASICVALUES.GESCHLECHT, txtGeschlecht.Text);
        }
        private void txtGröße_TextChanged(object sender, EventArgs e)
        {
            txtGröße.Text = controll.BasicValue(DSA_BASICVALUES.GRÖSE, txtGröße.Text);
        }
        private void txtHautfarbe_TextChanged(object sender, EventArgs e)
        {
            txtHautfarbe.Text = controll.BasicValue(DSA_BASICVALUES.HAUTFARBE, txtHautfarbe.Text);
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


        private void txtLebensenergieVOR_TextChanged(object sender, EventArgs e)
        {
            txtLebensenergieVOR.Text = controll.EnergieVOR(DSA_ENERGIEN.LEBENSENERGIE).ToString();
        }
        private void txtAusdauerVOR_TextChanged(object sender, EventArgs e)
        {
            txtAusdauerVOR.Text = controll.EnergieVOR(DSA_ENERGIEN.AUSDAUER).ToString();
        }
        private void txtAstralenergieVOR_TextChanged(object sender, EventArgs e)
        {
            txtAstralenergieVOR.Text = controll.EnergieVOR(DSA_ENERGIEN.ASTRALENERGIE).ToString();
        }
        private void txtKarmaenergieVOR_TextChanged(object sender, EventArgs e)
        {
            txtKarmaenergieVOR.Text = controll.EnergieVOR(DSA_ENERGIEN.KARMAENERGIE).ToString();
        }
        private void txtMagieresistenzVOR_TextChanged(object sender, EventArgs e)
        {
            txtMagieresistenzVOR.Text = controll.EnergieVOR(DSA_ENERGIEN.MAGIERESISTENZ).ToString();
        }


        private void txtLebensenergiePERM_TextChanged(object sender, EventArgs e)
        {
            txtLebensenergiePERM.Text = controll.EnergiePERM(DSA_ENERGIEN.LEBENSENERGIE).ToString();
        }
        private void txtAusdauerPERM_TextChanged(object sender, EventArgs e)
        {
            txtAusdauerPERM.Text = controll.EnergiePERM(DSA_ENERGIEN.AUSDAUER).ToString();
        }
        private void txtAstralenergiePERM_TextChanged(object sender, EventArgs e)
        {
            txtAstralenergiePERM.Text = controll.EnergiePERM(DSA_ENERGIEN.ASTRALENERGIE).ToString();
        }
        private void txtKarmaenergiePERM_TextChanged(object sender, EventArgs e)
        {
            txtKarmaenergiePERM.Text = controll.EnergiePERM(DSA_ENERGIEN.KARMAENERGIE).ToString();
        }
        private void txtMagieresistenzPERM_TextChanged(object sender, EventArgs e)
        {
           txtMagieresistenzPERM.Text = controll.EnergiePERM(DSA_ENERGIEN.MAGIERESISTENZ).ToString();
        }


        private void txtLebensenergieMOD_TextChanged(object sender, EventArgs e)
        {
            txtLebensenergieMOD.Text = controll.EnergieMOD(DSA_ENERGIEN.LEBENSENERGIE).ToString();
        }
        private void txtAusdauerMOD_TextChanged(object sender, EventArgs e)
        {
            txtAusdauerMOD.Text = controll.EnergieMOD(DSA_ENERGIEN.AUSDAUER).ToString();
        }
        private void txtAstralenergieMOD_TextChanged(object sender, EventArgs e)
        {
            txtAstralenergieMOD.Text = controll.EnergieMOD(DSA_ENERGIEN.ASTRALENERGIE).ToString();
        }
        private void txtKarmaenergieMOD_TextChanged(object sender, EventArgs e)
        {
            txtKarmaenergieMOD.Text = controll.EnergieMOD(DSA_ENERGIEN.KARMAENERGIE).ToString();
        }
        private void txtMagieresistenzMOD_TextChanged(object sender, EventArgs e)
        {
            txtMagieresistenzMOD.Text = controll.EnergieMOD(DSA_ENERGIEN.MAGIERESISTENZ).ToString();
        }


        private void txtLebensenergieMALI_TextChanged(object sender, EventArgs e)
        {
            txtLebensenergieMALI.Text = controll.EnergieMALI(DSA_ENERGIEN.LEBENSENERGIE).ToString();
        }
        private void txtAusdauerMALI_TextChanged(object sender, EventArgs e)
        {
            txtAusdauerMALI.Text = controll.EnergieMALI(DSA_ENERGIEN.AUSDAUER).ToString();
        }
        private void txtAstralenergieMALI_TextChanged(object sender, EventArgs e)
        {
            txtAstralenergieMALI.Text = controll.EnergieMALI(DSA_ENERGIEN.ASTRALENERGIE).ToString();
        }
        private void txtKarmaenergieMALI_TextChanged(object sender, EventArgs e)
        {
            txtKarmaenergieMALI.Text = controll.EnergieMALI(DSA_ENERGIEN.KARMAENERGIE).ToString();
        }
        private void txtMagieresistenzMALI_TextChanged(object sender, EventArgs e)
        {
            txtMagieresistenzMALI.Text = controll.EnergieMALI(DSA_ENERGIEN.MAGIERESISTENZ).ToString();
        }


        private void txtLebensenergieERG_TextChanged(object sender, EventArgs e)
        {
            txtLebensenergieERG.Text = controll.EnergieMAX(DSA_ENERGIEN.LEBENSENERGIE).ToString();
        }
        private void txtAusdauerERG_TextChanged(object sender, EventArgs e)
        {
            txtAusdauerERG.Text = controll.EnergieMAX(DSA_ENERGIEN.AUSDAUER).ToString();
        }
        private void txtAstralenergieERG_TextChanged(object sender, EventArgs e)
        {
            txtAstralenergieERG.Text = controll.EnergieMAX(DSA_ENERGIEN.ASTRALENERGIE).ToString();
        }
        private void txtKarmaenergieERG_TextChanged(object sender, EventArgs e)
        {
            txtKarmaenergieERG.Text = controll.EnergieMAX(DSA_ENERGIEN.KARMAENERGIE).ToString();
        }
        private void txtMagieresistenzERG_TextChanged(object sender, EventArgs e)
        {
            txtMagieresistenzERG.Text = controll.EnergieMAX(DSA_ENERGIEN.MAGIERESISTENZ).ToString();
        }

       
        private void txtGeldD_TextChanged(object sender, EventArgs e)
        {  
            txtGeldD.Text = controll.Money(DSA_MONEY.D, txtGeldD.Text.TrimEnd('D')).ToString() + "D";
        }
        private void txtGeldS_TextChanged(object sender, EventArgs e)
        {
            txtGeldS.Text = controll.Money(DSA_MONEY.S, txtGeldS.Text.TrimEnd('S')).ToString() + "S";
        }
        private void txtGeldH_TextChanged(object sender, EventArgs e)
        {
            txtGeldH.Text = controll.Money(DSA_MONEY.H, txtGeldH.Text.TrimEnd('H')).ToString() + "H";
        }
        private void txtGeldK_TextChanged(object sender, EventArgs e)
        {
            txtGeldK.Text = controll.Money(DSA_MONEY.K, txtGeldK.Text.TrimEnd('K')).ToString() + "K";
        }
        private void txtBank_TextChanged(object sender, EventArgs e)
        {
            txtBank.Text = controll.Money(DSA_MONEY.BANK, txtBank.Text.TrimEnd('D')).ToString() + "D";
        }


        private void txtStufe_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtAbenteuerpunkte_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtAbenteuerpunkteInvestiert_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtAbenteuerpunkteGuthaben_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void txtVorteil1_ValueChanged(object sender, EventArgs e)
        {
            int number = 1;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil1Name.Text = feature.getName();
            txtVorteil1Beschreibung.Text = feature.getDescription();
            txtVorteil1GP.Text = feature.getGP();
            txtVorteil1Wert.Text = feature.getValue();
        }
        private void txtVorteil2_ValueChanged(object sender, EventArgs e)
        {
            int number = 2;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil2Name.Text = feature.getName();
            txtVorteil2Beschreibung.Text = feature.getDescription();
            txtVorteil2GP.Text = feature.getGP();
            txtVorteil2Wert.Text = feature.getValue();
        }
        private void txtVorteil3_ValueChanged(object sender, EventArgs e)
        {
            int number = 3;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil3Name.Text = feature.getName();
            txtVorteil3Beschreibung.Text = feature.getDescription();
            txtVorteil3GP.Text = feature.getGP();
            txtVorteil3Wert.Text = feature.getValue();
        }
        private void txtVorteil4_ValueChanged(object sender, EventArgs e)
        {
            int number = 4;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil4Name.Text = feature.getName();
            txtVorteil4Beschreibung.Text = feature.getDescription();
            txtVorteil4GP.Text = feature.getGP();
            txtVorteil4Wert.Text = feature.getValue();
        }
        private void txtVorteil5_ValueChanged(object sender, EventArgs e)
        {
            int number = 5;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil5Name.Text = feature.getName();
            txtVorteil5Beschreibung.Text = feature.getDescription();
            txtVorteil5GP.Text = feature.getGP();
            txtVorteil5Wert.Text = feature.getValue();
        }
        private void txtVorteil6_ValueChanged(object sender, EventArgs e)
        {
            int number = 6;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil6Name.Text = feature.getName();
            txtVorteil6Beschreibung.Text = feature.getDescription();
            txtVorteil6GP.Text = feature.getGP();
            txtVorteil6Wert.Text = feature.getValue();
        }
        private void txtVorteil7_ValueChanged(object sender, EventArgs e)
        {
            int number = 7;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil7Name.Text = feature.getName();
            txtVorteil7Beschreibung.Text = feature.getDescription();
            txtVorteil7GP.Text = feature.getGP();
            txtVorteil7Wert.Text = feature.getValue();
        }
        private void txtVorteil8_ValueChanged(object sender, EventArgs e)
        {
            int number = 8;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil8Name.Text = feature.getName();
            txtVorteil8Beschreibung.Text = feature.getDescription();
            txtVorteil8GP.Text = feature.getGP();
            txtVorteil8Wert.Text = feature.getValue();
        }
        private void txtVorteil9_ValueChanged(object sender, EventArgs e)
        {
            int number = 9;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil9Name.Text = feature.getName();
            txtVorteil9Beschreibung.Text = feature.getDescription();
            txtVorteil9GP.Text = feature.getGP();
            txtVorteil9Wert.Text = feature.getValue();
        }
        private void txtVorteil10_ValueChanged(object sender, EventArgs e)
        {
            int number = 10;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil10Name.Text = feature.getName();
            txtVorteil10Beschreibung.Text = feature.getDescription();
            txtVorteil10GP.Text = feature.getGP();
            txtVorteil10Wert.Text = feature.getValue();
        }
        private void txtVorteil11_ValueChanged(object sender, EventArgs e)
        {
            int number = 11;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil11Name.Text = feature.getName();
            txtVorteil11Beschreibung.Text = feature.getDescription();
            txtVorteil11GP.Text = feature.getGP();
            txtVorteil11Wert.Text = feature.getValue();
        }
        private void txtVorteil12_ValueChanged(object sender, EventArgs e)
        {
            int number = 12;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil12Name.Text = feature.getName();
            txtVorteil12Beschreibung.Text = feature.getDescription();
            txtVorteil12GP.Text = feature.getGP();
            txtVorteil12Wert.Text = feature.getValue();
        }
        private void txtVorteil13_ValueChanged(object sender, EventArgs e)
        {
            int number = 13;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil13Name.Text = feature.getName();
            txtVorteil13Beschreibung.Text = feature.getDescription();
            txtVorteil13GP.Text = feature.getGP();
            txtVorteil13Wert.Text = feature.getValue();
        }
        private void txtVortei14_ValueChanged(object sender, EventArgs e)
        {
            int number = 14;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil14Name.Text = feature.getName();
            txtVorteil14Beschreibung.Text = feature.getDescription();
            txtVorteil14GP.Text = feature.getGP();
            txtVorteil14Wert.Text = feature.getValue();
        }
        private void txtVorteil15_ValueChanged(object sender, EventArgs e)
        {
            int number = 15;
            Feature feature = controll.Feature(number, DSA_FEATURES.VORTEIL);

            txtVorteil15Name.Text = feature.getName();
            txtVorteil15Beschreibung.Text = feature.getDescription();
            txtVorteil15GP.Text = feature.getGP();
            txtVorteil15Wert.Text = feature.getValue();
        }


        private void txtNachteil1_ValueChanged(object sender, EventArgs e)
        {
            int number = 1;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil1Name.Text = feature.getName();
            txtNachteil1Beschreibung.Text = feature.getDescription();
            txtNachteil1GP.Text = feature.getGP();
            txtNachteil1Wert.Text = feature.getValue();
        }
        private void txtNachteil2_ValueChanged(object sender, EventArgs e)
        {
            int number = 2;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil2Name.Text = feature.getName();
            txtNachteil2Beschreibung.Text = feature.getDescription();
            txtNachteil2GP.Text = feature.getGP();
            txtNachteil2Wert.Text = feature.getValue();
        }
        private void txtNachteil3_ValueChanged(object sender, EventArgs e)
        {
            int number = 3;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil3Name.Text = feature.getName();
            txtNachteil3Beschreibung.Text = feature.getDescription();
            txtNachteil3GP.Text = feature.getGP();
            txtNachteil3Wert.Text = feature.getValue();
        }
        private void txtNachteil4_ValueChanged(object sender, EventArgs e)
        {
            int number = 4;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil4Name.Text = feature.getName();
            txtNachteil4Beschreibung.Text = feature.getDescription();
            txtNachteil4GP.Text = feature.getGP();
            txtNachteil4Wert.Text = feature.getValue();
        }
        private void txtNachteil5_ValueChanged(object sender, EventArgs e)
        {
            int number = 5;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil5Name.Text = feature.getName();
            txtNachteil5Beschreibung.Text = feature.getDescription();
            txtNachteil5GP.Text = feature.getGP();
            txtNachteil5Wert.Text = feature.getValue();
        }
        private void txtNachteil6_ValueChanged(object sender, EventArgs e)
        {
            int number = 6;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil6Name.Text = feature.getName();
            txtNachteil6Beschreibung.Text = feature.getDescription();
            txtNachteil6GP.Text = feature.getGP();
            txtNachteil6Wert.Text = feature.getValue();
        }
        private void txtNachteil7_ValueChanged(object sender, EventArgs e)
        {
            int number = 7;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil7Name.Text = feature.getName();
            txtNachteil7Beschreibung.Text = feature.getDescription();
            txtNachteil7GP.Text = feature.getGP();
            txtNachteil7Wert.Text = feature.getValue();
        }
        private void txtNachteil8_ValueChanged(object sender, EventArgs e)
        {
            int number = 8;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil8Name.Text = feature.getName();
            txtNachteil8Beschreibung.Text = feature.getDescription();
            txtNachteil8GP.Text = feature.getGP();
            txtNachteil8Wert.Text = feature.getValue();
        }
        private void txtNachteil9_ValueChanged(object sender, EventArgs e)
        {
            int number = 9;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil9Name.Text = feature.getName();
            txtNachteil9Beschreibung.Text = feature.getDescription();
            txtNachteil9GP.Text = feature.getGP();
            txtNachteil9Wert.Text = feature.getValue();
        }
        private void txtNachteil10_ValueChanged(object sender, EventArgs e)
        {
            int number = 10;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil10Name.Text = feature.getName();
            txtNachteil10Beschreibung.Text = feature.getDescription();
            txtNachteil10GP.Text = feature.getGP();
            txtNachteil10Wert.Text = feature.getValue();
        }
        private void txtNachteil11_ValueChanged(object sender, EventArgs e)
        {
            int number = 11;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil11Name.Text = feature.getName();
            txtNachteil11Beschreibung.Text = feature.getDescription();
            txtNachteil11GP.Text = feature.getGP();
            txtNachteil11Wert.Text = feature.getValue();
        }
        private void txtNachteil12_ValueChanged(object sender, EventArgs e)
        {
            int number = 12;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil12Name.Text = feature.getName();
            txtNachteil12Beschreibung.Text = feature.getDescription();
            txtNachteil12GP.Text = feature.getGP();
            txtNachteil12Wert.Text = feature.getValue();
        }
        private void txtNachteil13_ValueChanged(object sender, EventArgs e)
        {
            int number = 13;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil13Name.Text = feature.getName();
            txtNachteil13Beschreibung.Text = feature.getDescription();
            txtNachteil13GP.Text = feature.getGP();
            txtNachteil13Wert.Text = feature.getValue();
        }
        private void txtNachteil14_ValueChanged(object sender, EventArgs e)
        {
            int number = 14;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil14Name.Text = feature.getName();
            txtNachteil14Beschreibung.Text = feature.getDescription();
            txtNachteil14GP.Text = feature.getGP();
            txtNachteil14Wert.Text = feature.getValue();
        }
        private void txtNachteil15_ValueChanged(object sender, EventArgs e)
        {
            int number = 15;
            Feature feature = controll.Feature(number, DSA_FEATURES.NACHTEIL);

            txtNachteil15Name.Text = feature.getName();
            txtNachteil15Beschreibung.Text = feature.getDescription();
            txtNachteil15GP.Text = feature.getGP();
            txtNachteil15Wert.Text = feature.getValue();
        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        
    }
}
