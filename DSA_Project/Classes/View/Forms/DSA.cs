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

//toDO:     Zeitverlust durch Aufruf change wenn Projekt diesen Change (nicht von Außen) vornimmt

namespace DSA_Project
{
    public partial class DSA : Form
    {
        int SUpportedTalentCOunt = 30;
        int supportedRewardBoxes = 25;

        List<GroupBox> talentGroupBoxes;
        List<Label> talentNameLabels;
        List<TextBox> talentProbeTextBoxs;
        List<TextBox> talentWürfeTextBoxs;
        List<TextBox> talentTaWTextBoxes;
        List<TextBox> talentBeTextBoxes;
        List<TextBox> talentBilligerTextBoxes;
        List<TextBox> talentSpezialisierungTextBoxes;
        List<TextBox> talentAnforderungsTextBoxes;
        List<TextBox> talentAbleitungTextBoxes;
        List<TextBox> talentATTextBoxes;
        List<TextBox> talentPATextBoxes;

        List<TextBox> rewardNameBoxes;
        List<TextBox> rewadDescriptionBoxes;

        List<RadioButton> RadioListTalents;
        Dictionary<RadioButton, DSA_FIGHTINGTALENTS> fightTalentDiconary;
        Dictionary<RadioButton, DSA_GENERALTALENTS> generalTalentDiconary;

        List<TextBox> featureAdvantagesNameBox;
        List<TextBox> featureDisdvantagesNameBox;
        List<TextBox> featureAdvantagesDescriptionBox;
        List<TextBox> featureDisAdvantagesDescriptionBox;
        List<TextBox> featureAdvantagesGPBox;
        List<TextBox> featureDisAdvantagesGPBox;
        List<TextBox> featureAdvantagesValueBox;
        List<TextBox> featureDisAdvantagesValueBox;

        ControllClass controll;

        public DSA()
        {
            controll = new ControllClass(this);
            InitializeComponent();

            talentNameLabels                = new List<Label>   { PTName1, PTName2, PTName3, PTName4, PTName5, PTName6, PTName7, PTName8, PTName9, PTName10, PTName11, PTName12, PTName13, PTName14, PTName15,
                                                                    PTName16, PTName17, PTName18 , PTName19, PTName20 , PTName21, PTName22, PTName23, PTName24, PTName25, PTName26, PTName27, PTName28, PTName29, PTName30 };
            talentProbeTextBoxs             = new List<TextBox> { PTProbe1, PTProbe2, PTProbe3, PTProbe4, PTProbe5, PTProbe6, PTProbe7, PTProbe8, PTProbe9, PTProbe10, PTProbe11, PTProbe12, PTProbe13, PTProbe14, PTProbe15,
                                                                    PTProbe16, PTProbe17, PTProbe18 , PTProbe19, PTProbe20 , PTProbe21, PTProbe22, PTProbe23, PTProbe24, PTProbe25, PTProbe26, PTProbe27, PTProbe28, PTProbe29, PTProbe30 };
            talentWürfeTextBoxs             = new List<TextBox> { PTWürfe1, PTWürfe2, PTWürfe3, PTWürfe4, PTWürfe5, PTWürfe6, PTWürfe7, PTWürfe8, PTWürfe9, PTWürfe10, PTWürfe11, PTWürfe12, PTWürfe13, PTWürfe14, PTWürfe15,
                                                                    PTWürfe16, PTWürfe17, PTWürfe18 , PTWürfe19, PTWürfe20, PTWürfe21, PTWürfe22, PTWürfe23, PTWürfe24, PTWürfe25, PTWürfe26, PTWürfe27, PTWürfe28, PTWürfe29, PTWürfe30 };
            talentTaWTextBoxes              = new List<TextBox>  { PTTaw1, PTTaw2, PTTaw3, PTTaw4, PTTaw5, PTTaw6, PTTaw7, PTTaw8, PTTaw9, PTTaw10, PTTaw11, PTTaw12, PTTaw13, PTTaw14, PTTaw15,
                                                                    PTTaw16, PTTaw17, PTTaw18 , PTTaw19, PTTaw20, PTTaw21, PTTaw22, PTTaw23, PTTaw24, PTTaw25, PTTaw26, PTTaw27, PTTaw28, PTTaw29, PTTaw30 };
            talentBeTextBoxes               = new List<TextBox> { PTBe1, PTBe2, PTBe3, PTBe4, PTBe5, PTBe6, PTBe7, PTBe8, PTBe9, PTBe10, PTBe11, PTBe12, PTBe13, PTBe14, PTBe15,
                                                                    PTBe16, PTBe17, PTBe18 , PTBe19, PTBe20, PTBe21, PTBe22, PTBe23, PTBe24, PTBe25, PTBe26, PTBe27, PTBe28, PTBe29, PTBe30 };
            talentBilligerTextBoxes         = new List<TextBox> { PTBilliger1, PTBilliger2, PTBilliger3, PTBilliger4, PTBilliger5, PTBilliger6, PTBilliger7, PTBilliger8, PTBilliger9, PTBilliger10, PTBilliger11, PTBilliger12, PTBilliger13, PTBilliger14, PTBilliger15,
                                                                    PTBilliger16, PTBilliger17, PTBilliger18 , PTBilliger19, PTBilliger20, PTBilliger21, PTBilliger22, PTBilliger23, PTBilliger24, PTBilliger25, PTBilliger26, PTBilliger27, PTBilliger28, PTBilliger29, PTBilliger30 };
            talentSpezialisierungTextBoxes  = new List<TextBox> { PTSpezialisierung1, PTSpezialisierung2, PTSpezialisierung3, PTSpezialisierung4, PTSpezialisierung5, PTSpezialisierung6, PTSpezialisierung7, PTSpezialisierung8, PTSpezialisierung9, PTSpezialisierung10, PTSpezialisierung11, PTSpezialisierung12, PTSpezialisierung13, PTSpezialisierung14, PTSpezialisierung15,
                                                                    PTSpezialisierung16, PTSpezialisierung17, PTSpezialisierung18 , PTSpezialisierung19, PTSpezialisierung20, PTSpezialisierung21, PTSpezialisierung22, PTSpezialisierung23, PTSpezialisierung24, PTSpezialisierung25, PTSpezialisierung26, PTSpezialisierung27, PTSpezialisierung28, PTSpezialisierung29, PTSpezialisierung30 };
            talentAnforderungsTextBoxes     = new List<TextBox> { PTAnforderungen1, PTAnforderungen2, PTAnforderungen3, PTAnforderungen4, PTAnforderungen5, PTAnforderungen6, PTAnforderungen7, PTAnforderungen8, PTAnforderungen9, PTAnforderungen10, PTAnforderungen11, PTAnforderungen12, PTAnforderungen13, PTAnforderungen14, PTAnforderungen15,
                                                                    PTAnforderungen16, PTAnforderungen17, PTAnforderungen18 , PTAnforderungen19, PTAnforderungen20, PTAnforderungen21, PTAnforderungen22, PTAnforderungen23, PTAnforderungen24, PTAnforderungen25, PTAnforderungen26, PTAnforderungen27, PTAnforderungen28, PTAnforderungen29, PTAnforderungen30 };
            talentAbleitungTextBoxes        = new List<TextBox> { PTAbleiten1, PTAbleiten2, PTAbleiten3, PTAbleiten4, PTAbleiten5, PTAbleiten6, PTAbleiten7, PTAbleiten8, PTAbleiten9, PTAbleiten10, PTAbleiten11, PTAbleiten12, PTAbleiten13, PTAbleiten14, PTAbleiten15,
                                                                    PTAbleiten16, PTAbleiten17, PTAbleiten18 , PTAbleiten19, PTAbleiten20, PTAbleiten21, PTAbleiten22, PTAbleiten23, PTAbleiten24, PTAbleiten25, PTAbleiten26, PTAbleiten27, PTAbleiten28, PTAbleiten29, PTAbleiten30 };
            talentATTextBoxes               = new List<TextBox> { PTAT1, PTAT2, PTAT3, PTAT4, PTAT5, PTAT6, PTAT7, PTAT8, PTAT9, PTAT10, PTAT11, PTAT12, PTAT13, PTAT14, PTAT15,
                                                                    PTAT16, PTAT17, PTAT18 , PTAT19, PTAT20, PTAT21, PTAT22, PTAT23, PTAT24, PTAT25, PTAT26, PTAT27, PTAT28, PTAT29, PTAT30 };
            talentPATextBoxes               = new List<TextBox> { PTPA1, PTPA2, PTPA3, PTPA4, PTPA5, PTPA6, PTPA7, PTPA8, PTPA9, PTPA10, PTPA11, PTPA12, PTPA13, PTPA14, PTPA15,
                                                                    PTPA16, PTPA17, PTPA18 , PTPA19, PTPA20, PTPA21, PTPA22, PTPA23, PTPA24, PTPA25, PTPA26, PTPA27, PTPA28, PTPA29, PTPA30 };
            talentGroupBoxes                = new List<GroupBox> { groupBoxTalentName, groupBoxProbe, groupBoxTaW, groupBoxAnforderungen, groupBoxAbleiten, groupBoxBe, groupBoxKampf, groupBoxSpezialisierung, groupBoxBilliger };

            txtTalentLetterCurrentPage.Text = "1";
            RadioListTalents = new List<RadioButton> { radioKörperlicheTalente, radioSozialTalente, radioNaturTalente, radioKnowldageTalente, radioCraftingTalent, radioButtonWeaponless, radioButtonWeaponless, radioButtonClose };

            generalTalentDiconary = new Dictionary<RadioButton, DSA_GENERALTALENTS>();
            generalTalentDiconary.Add(radioKörperlicheTalente, DSA_GENERALTALENTS.PHYSICAL);
            generalTalentDiconary.Add(radioKnowldageTalente, DSA_GENERALTALENTS.KNOWLDAGE);
            generalTalentDiconary.Add(radioNaturTalente, DSA_GENERALTALENTS.NATURE);
            generalTalentDiconary.Add(radioCraftingTalent, DSA_GENERALTALENTS.CRAFTING);
            generalTalentDiconary.Add(radioSozialTalente, DSA_GENERALTALENTS.SOCIAL);

            fightTalentDiconary = new Dictionary<RadioButton, DSA_FIGHTINGTALENTS>();
            fightTalentDiconary.Add(radioButtonWeaponless, DSA_FIGHTINGTALENTS.WEAPONLESS);
            fightTalentDiconary.Add(radioButtonClose, DSA_FIGHTINGTALENTS.CLOSE);
            fightTalentDiconary.Add(radioButtonRange, DSA_FIGHTINGTALENTS.RANGE);

            setUPFeatureLists();
            setUPRewards();
            load();
            refreshHeroPage();
            refreshTalentPage();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            radioCraftingTalent.Checked = false;
            radioCraftingTalent.Checked = true;
        }        
        public void load()
        {
            txtName.Text = (controll.BasicValue(DSA_BASICVALUES.NAME));
            txtAlter.Text = (controll.BasicValue(DSA_BASICVALUES.ALTER));
            txtGeschlecht.Text = (controll.BasicValue(DSA_BASICVALUES.GESCHLECHT));
            txtGröße.Text = (controll.BasicValue(DSA_BASICVALUES.GRÖSE));
            txtGewicht.Text = (controll.BasicValue(DSA_BASICVALUES.GEWICHT));
            txtAugenfarbe.Text = (controll.BasicValue(DSA_BASICVALUES.AUGENFARBE));
            txtHaarfarbe.Text = (controll.BasicValue(DSA_BASICVALUES.HAARFARBE));
            txtHautfarbe.Text = (controll.BasicValue(DSA_BASICVALUES.HAUTFARBE));
            txtFamulienstand.Text = (controll.BasicValue(DSA_BASICVALUES.FAMILIENSTAND));
            txtAnrede.Text = (controll.BasicValue(DSA_BASICVALUES.ANREDE));
            txtGottheit.Text = (controll.BasicValue(DSA_BASICVALUES.GOTTHEIT));
            txtRasse.Text = (controll.BasicValue(DSA_BASICVALUES.RASSE));
            txtKultur.Text = (controll.BasicValue(DSA_BASICVALUES.KULTUR));
            txtProfession.Text = (controll.BasicValue(DSA_BASICVALUES.PROFESSION));
            txtModifikation1.Text = controll.Moodifikator(1);
            txtModifikation2.Text = controll.Moodifikator(2);
            txtModifikation3.Text = controll.Moodifikator(3);
            txtGöttergeschenke1.Text = controll.Göttergeschenk(1);
            txtGöttergeschenke2.Text = controll.Göttergeschenk(2);
            txtGöttergeschenke3.Text = controll.Göttergeschenk(3);
            txtGöttergeschenke4.Text = controll.Göttergeschenk(4);


            txtMutAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.MU, "notNumeric").ToString();
            txtKlugheitAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.KL, "notNumeric").ToString();
            txtIntuitionAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.IN, "notNumeric").ToString();
            txtCharismaAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.CH, "notNumeric").ToString();
            txtFingerfertigkeitAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.FF, "notNumeric").ToString();
            textGewandheitAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.GE, "notNumeric").ToString();
            txtKonstitutionAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.KO, "notNumeric").ToString();
            txtKörperkraftAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.KK, "notNumeric").ToString();
            txtSozialstatusAKT.Text = controll.AttributeAKT(DSA_ATTRIBUTE.SO, "notNumeric").ToString();

            txtMutMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.MU, txtMutMOD.Text).ToString();
            txtKlugheitMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.KL, txtKlugheitMOD.Text).ToString();
            txtIntuitionMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.IN, txtIntuitionMOD.Text).ToString();
            txtCharismaMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.CH, txtCharismaMOD.Text).ToString();
            txtFingerfertigkeitMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.FF, txtFingerfertigkeitMOD.Text).ToString();
            textGewandheitMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.GE, textGewandheitMOD.Text).ToString();
            txtKonstitutionMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.KO, txtKonstitutionMOD.Text).ToString();
            txtKörperkraftMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.KK, txtKörperkraftMOD.Text).ToString();
            txtSozialstatusMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.SO, txtSozialstatusMOD.Text).ToString();

            //Doppelter Aufruf != Ursprüngliches Ergebnis --->Schrot!!!
            changeAttributMark(DSA_ATTRIBUTE.MU, lblMut, txtMutAKT, txtMutMOD, txtMutMAX);
            changeAttributMark(DSA_ATTRIBUTE.KL, lblKlugheit, txtKlugheitAKT, txtKlugheitMOD, txtKlugheitMAX);
            changeAttributMark(DSA_ATTRIBUTE.CH, lblCharisma, txtCharismaAKT, txtCharismaMOD, txtCharismaMAX);
            changeAttributMark(DSA_ATTRIBUTE.FF, lblFingerfertigkeit, txtFingerfertigkeitAKT, txtFingerfertigkeitMOD, txtFingerfertigkeitMAX);
            changeAttributMark(DSA_ATTRIBUTE.GE, lblGewandheit, textGewandheitAKT, textGewandheitMOD, textGewandheitMAX);
            changeAttributMark(DSA_ATTRIBUTE.KO, lblKonstitution, txtKonstitutionAKT, txtKonstitutionMOD, txtKonstitutionMAX);
            changeAttributMark(DSA_ATTRIBUTE.KK, lblKörperkraft, txtKörperkraftAKT, txtKörperkraftMOD, txtKörperkraftMAX);
            changeAttributMark(DSA_ATTRIBUTE.SO, lblSozialstatus, txtSozialstatusAKT, txtSozialstatusMOD, txtSozialstatusMAX);
            changeAttributMark(DSA_ATTRIBUTE.IN, lblIntuition, txtIntuitionAKT, txtIntuitionMOD, txtIntuitionMAX);

            changeAttributMark(DSA_ATTRIBUTE.MU, lblMut, txtMutAKT, txtMutMOD, txtMutMAX);
            changeAttributMark(DSA_ATTRIBUTE.KL, lblKlugheit, txtKlugheitAKT, txtKlugheitMOD, txtKlugheitMAX);
            changeAttributMark(DSA_ATTRIBUTE.CH, lblCharisma, txtCharismaAKT, txtCharismaMOD, txtCharismaMAX);
            changeAttributMark(DSA_ATTRIBUTE.FF, lblFingerfertigkeit, txtFingerfertigkeitAKT, txtFingerfertigkeitMOD, txtFingerfertigkeitMAX);
            changeAttributMark(DSA_ATTRIBUTE.GE, lblGewandheit, textGewandheitAKT, textGewandheitMOD, textGewandheitMAX);
            changeAttributMark(DSA_ATTRIBUTE.KO, lblKonstitution, txtKonstitutionAKT, txtKonstitutionMOD, txtKonstitutionMAX);
            changeAttributMark(DSA_ATTRIBUTE.KK, lblKörperkraft, txtKörperkraftAKT, txtKörperkraftMOD, txtKörperkraftMAX);
            changeAttributMark(DSA_ATTRIBUTE.SO, lblSozialstatus, txtSozialstatusAKT, txtSozialstatusMOD, txtSozialstatusMAX);
            changeAttributMark(DSA_ATTRIBUTE.IN, lblIntuition, txtIntuitionAKT, txtIntuitionMOD, txtIntuitionMAX);
            //Doppelter Aufruf != Ursprüngliches Ergebnis --->Schrot!!!


            txtAttackeBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
            txtParadeBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
            txtFernkampfBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
            txtInitativeBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
            txtBeherschungswertMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
            txtArtefaktkontrolleMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE).ToString();
            txtWundschwelleMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();
            txtEntrückungMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
            txtGeschwindigkeitMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();

            txtGeldD.Text = controll.Money(DSA_MONEY.D).ToString();
            txtGeldH.Text = controll.Money(DSA_MONEY.H).ToString();
            txtGeldS.Text = controll.Money(DSA_MONEY.S).ToString();
            txtGeldK.Text = controll.Money(DSA_MONEY.K).ToString();
            txtBank.Text = controll.Money(DSA_MONEY.BANK).ToString();

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

            txtAbenteuerpunkte.Text = controll.AdvanturePoints().ToString();

            loadRewards();
        }
        /// <summary> 
        /// Ist bei einer Werteänderung eine Neuberechnung nötig muss dies Ausgelöst werden
        /// </summary>
        public void refreshHeroPage()
        {
            txtMutMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.MU).ToString();
            txtKlugheitMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.KL).ToString();
            txtIntuitionMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.IN).ToString();
            txtCharismaMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.CH).ToString();
            txtFingerfertigkeitMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.FF).ToString();
            textGewandheitMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.GE).ToString();
            txtKonstitutionMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.KO).ToString();
            txtKörperkraftMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.KK).ToString();
            txtSozialstatusMAX.Text = controll.AttributeMAX(DSA_ATTRIBUTE.SO).ToString();

            txtAttackeBaisAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
            txtParadeBasisAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
            txtFernkampfBasisAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
            txtInitativeBasisAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
            txtBeherschungswertAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
            txtArtefaktkontrolleAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE).ToString();
            txtWundschwelleAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();
            txtEntrückungAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
            txtGeschwindigkeitAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();

            txtAttackeBaisMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
            txtParadeBasisMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
            txtFernkampfBasisMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
            txtInitativeBasisMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
            txtBeherschungswertMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
            txtArtefaktkontrolleMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE).ToString();
            txtWundschwelleMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();
            txtEntrückungMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
            txtGeschwindigkeitMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();

            txtGesamtAKT.Text = controll.getAttributeAKTSumme().ToString();
            txtGesamtMAX.Text = controll.getAttributeMAXSumme().ToString();

            txtLebensenergieVOR.Text = controll.EnergieVOR(DSA_ENERGIEN.LEBENSENERGIE).ToString();
            txtAusdauerVOR.Text = controll.EnergieVOR(DSA_ENERGIEN.AUSDAUER).ToString();
            txtKarmaenergieVOR.Text = controll.EnergieVOR(DSA_ENERGIEN.KARMAENERGIE).ToString();
            txtAstralenergieVOR.Text = controll.EnergieVOR(DSA_ENERGIEN.ASTRALENERGIE).ToString();
            txtMagieresistenzVOR.Text = controll.EnergieVOR(DSA_ENERGIEN.MAGIERESISTENZ).ToString();

            txtLebensenergiePERM.Text = controll.EnergiePERM(DSA_ENERGIEN.LEBENSENERGIE).ToString();
            txtAusdauerPERM.Text = controll.EnergiePERM(DSA_ENERGIEN.AUSDAUER).ToString();
            txtAstralenergiePERM.Text = controll.EnergiePERM(DSA_ENERGIEN.ASTRALENERGIE).ToString();
            txtKarmaenergiePERM.Text = controll.EnergiePERM(DSA_ENERGIEN.KARMAENERGIE).ToString();
            txtMagieresistenzPERM.Text = controll.EnergiePERM(DSA_ENERGIEN.MAGIERESISTENZ).ToString();

            txtLebensenergieMALI.Text = controll.EnergieMALI(DSA_ENERGIEN.LEBENSENERGIE).ToString();
            txtAusdauerMALI.Text = controll.EnergieMALI(DSA_ENERGIEN.AUSDAUER).ToString();
            txtAstralenergieMALI.Text = controll.EnergieMALI(DSA_ENERGIEN.ASTRALENERGIE).ToString();
            txtKarmaenergieMALI.Text = controll.EnergieMALI(DSA_ENERGIEN.KARMAENERGIE).ToString();
            txtMagieresistenzMALI.Text = controll.EnergieMALI(DSA_ENERGIEN.MAGIERESISTENZ).ToString();

            txtLebensenergieERG.Text = controll.EnergieMAX(DSA_ENERGIEN.LEBENSENERGIE).ToString();
            txtAusdauerERG.Text = controll.EnergieMAX(DSA_ENERGIEN.AUSDAUER).ToString();
            txtAstralenergieERG.Text = controll.EnergieMAX(DSA_ENERGIEN.ASTRALENERGIE).ToString();
            txtKarmaenergieERG.Text = controll.EnergieMAX(DSA_ENERGIEN.KARMAENERGIE).ToString();
            txtMagieresistenzERG.Text = controll.EnergieMAX(DSA_ENERGIEN.MAGIERESISTENZ).ToString();

            txtMutMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.MU).ToString();
            txtKlugheitMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.KL).ToString();
            txtIntuitionMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.IN).ToString();
            txtCharismaMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.CH).ToString();
            txtFingerfertigkeitMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.FF).ToString();
            textGewandheitMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.GE).ToString();
            txtKonstitutionMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.KO).ToString();
            txtKörperkraftMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.KK).ToString();
            txtSozialstatusMOD.Text = controll.AttributeMOD(DSA_ATTRIBUTE.SO).ToString();

            txtAttackeBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
            txtArtefaktkontrolleMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE).ToString();
            txtBeherschungswertMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
            txtEntrückungMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
            txtFernkampfBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
            txtGeschwindigkeitMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();
            txtInitativeBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
            txtParadeBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
            txtWundschwelleMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();

        }
        public void refreshTalentPage()
        {
            radioCraftingTalent.Checked = true;
            radioKörperlicheTalente.Checked = true;
        }

        private void setUPFeatureLists()
        {
            featureAdvantagesNameBox            = new List<TextBox>{ txtVorteil1Name,       txtVorteil2Name, txtVorteil3Name, txtVorteil4Name, txtVorteil5Name, txtVorteil6Name, txtVorteil7Name, txtVorteil8Name, txtVorteil9Name, txtVorteil10Name, txtVorteil11Name, txtVorteil12Name, txtVorteil13Name, txtVorteil14Name, txtVorteil15Name};
            featureDisdvantagesNameBox          = new List<TextBox>{ txtNachteil1Name, txtNachteil2Name, txtNachteil3Name, txtNachteil4Name, txtNachteil5Name, txtNachteil6Name, txtNachteil7Name, txtNachteil8Name, txtNachteil9Name, txtNachteil10Name, txtNachteil11Name, txtNachteil12Name, txtNachteil13Name, txtNachteil14Name, txtNachteil15Name};
            featureAdvantagesDescriptionBox     = new List<TextBox>{ txtVorteil1Beschreibung, txtVorteil2Beschreibung, txtVorteil3Beschreibung, txtVorteil4Beschreibung, txtVorteil5Beschreibung, txtVorteil6Beschreibung, txtVorteil7Beschreibung, txtVorteil8Beschreibung, txtVorteil9Beschreibung, txtVorteil10Beschreibung, txtVorteil11Beschreibung, txtVorteil12Beschreibung, txtVorteil13Beschreibung, txtVorteil14Beschreibung, txtVorteil15Beschreibung };
            featureDisAdvantagesDescriptionBox  = new List<TextBox>{ txtNachteil1Beschreibung, txtNachteil2Beschreibung, txtNachteil3Beschreibung, txtNachteil4Beschreibung, txtNachteil5Beschreibung, txtNachteil6Beschreibung, txtNachteil7Beschreibung, txtNachteil8Beschreibung, txtNachteil9Beschreibung, txtNachteil10Beschreibung, txtNachteil11Beschreibung, txtNachteil12Beschreibung, txtNachteil13Beschreibung, txtNachteil14Beschreibung, txtNachteil15Beschreibung };
            featureAdvantagesGPBox              = new List<TextBox>{ txtVorteil1GP, txtVorteil2GP, txtVorteil3GP, txtVorteil4GP, txtVorteil5GP, txtVorteil6GP, txtVorteil7GP, txtVorteil8GP, txtVorteil9GP, txtVorteil10GP, txtVorteil11GP, txtVorteil12GP, txtVorteil13GP, txtVorteil14GP, txtVorteil15GP };
            featureDisAdvantagesGPBox           = new List<TextBox>{ txtNachteil1GP, txtNachteil2GP, txtNachteil3GP, txtNachteil4GP, txtNachteil5GP, txtNachteil6GP, txtNachteil7GP, txtNachteil8GP, txtNachteil9GP, txtNachteil10GP, txtNachteil11GP, txtNachteil12GP, txtNachteil13GP, txtNachteil14GP, txtNachteil15GP };
            featureAdvantagesValueBox           = new List<TextBox>{ txtVorteil1Wert, txtVorteil2Wert, txtVorteil3Wert, txtVorteil4Wert, txtVorteil5Wert, txtVorteil6Wert, txtVorteil7Wert, txtVorteil8Wert, txtVorteil9Wert, txtVorteil10Wert, txtVorteil11Wert, txtVorteil12Wert, txtVorteil13Wert, txtVorteil14Wert, txtVorteil15Wert };
            featureDisAdvantagesValueBox        = new List<TextBox>{ txtNachteil1Wert, txtNachteil2Wert, txtNachteil3Wert, txtNachteil4Wert, txtNachteil5Wert, txtNachteil6Wert, txtNachteil7Wert, txtNachteil8Wert, txtNachteil9Wert, txtNachteil10Wert, txtNachteil11Wert, txtNachteil12Wert, txtNachteil13Wert, txtNachteil14Wert, txtNachteil15Wert };
        }
        private void setUPRewards()
        {
            rewardNameBoxes                     = new List<TextBox> { txtReward1, txtReward2, txtReward3, txtReward4, txtReward5, txtReward6, txtReward7, txtReward8, txtReward9, txtReward10, txtReward11, txtReward12, txtReward13, txtReward14, txtReward15, txtReward16, txtReward17, txtReward18, txtReward19, txtReward20, txtReward21, txtReward22, txtReward23, txtReward24, txtReward25 };
            rewadDescriptionBoxes               = new List<TextBox> { txtRewardDescription1, txtRewardDescription2, txtRewardDescription3, txtRewardDescription4, txtRewardDescription5, txtRewardDescription6, txtRewardDescription7, txtRewardDescription8, txtRewardDescription9, txtRewardDescription10, txtRewardDescription11, txtRewardDescription12, txtRewardDescription13, txtRewardDescription14, txtRewardDescription15, txtRewardDescription16, txtRewardDescription17, txtRewardDescription18, txtRewardDescription19, txtRewardDescription20, txtRewardDescription21, txtRewardDescription22, txtRewardDescription23, txtRewardDescription24, txtRewardDescription25 };

            for(int i=0; i < rewardNameBoxes.Count; i++)
            {
                rewardNameBoxes[i].Click += new EventHandler(setReward_DiscriptionBox);
            }

            txtRewardPage.Text = "1";
        }


        private void LoadFeature(TextBox name, TextBox description, TextBox value, TextBox gp, DSA_FEATURES type, int number)
        {
            Feature feature = controll.FeatureExisting(number, type);

            if (feature == null) { return; }

            name.Text = feature.getName();
            description.Text = feature.getDescription();
            value.Text = feature.getValue();
            gp.Text = feature.getGP();
        }
        private void loadRewards()
        {
            int page = 0;
            Int32.TryParse(txtRewardPage.Text, out page);

            int number = (SUpportedTalentCOunt * page);

            for (int i=0; i<supportedRewardBoxes; i++)
            {
                number = number + i;
                Feature feature = controll.FeatureExisting(number, DSA_FEATURES.VORTEIL);
                if (feature != null)
                {
                    rewardNameBoxes[i].Text = feature.getName();
                    rewadDescriptionBoxes[i].Text = feature.getDescription();
                }
            }
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
            refreshHeroPage();
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
            refreshHeroPage();
        }
        /*Attribut Änderungen MAX Ende*/
        /*Basic Values Änderungen AKT*/
        private void txtAttackeBaisAKT_TextChanged(object sender, EventArgs e)
        {
            refreshHeroPage();
        }
        private void txtParadeBasisAKT_TextChanged(object sender, EventArgs e)
        {
            refreshHeroPage();
        }
        private void txtFernkampfBasisAKT_TextChanged(object sender, EventArgs e)
        {
            refreshHeroPage();
        }
        private void txtInitativeBasisAKT_TextChanged(object sender, EventArgs e)
        {
            refreshHeroPage();
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
            int x;
            Int32.TryParse(txtAbenteuerpunkte.Text, out x);
            txtAbenteuerpunkte.Text = controll.AdvanturePoints(x).ToString();
        }
        private void txtAbenteuerpunkteInvestiert_TextChanged(object sender, EventArgs e)
        {

        }
        private void txtAbenteuerpunkteGuthaben_TextChanged(object sender, EventArgs e)
        {

        }

        private void CreateFeature(int number, DSA_FEATURES type)
        {   
            Feature feature = controll.Feature(number, type);
            number = number - 1;        //AUsgleich Nummerierung Echt / Programm    

            if (feature == null) return;

            switch (type)
            {
                case DSA_FEATURES.VORTEIL: 
                    featureAdvantagesNameBox[number].Text = feature.getName();
                    featureAdvantagesDescriptionBox[number].Text = feature.getDescription();
                    featureAdvantagesGPBox[number].Text = feature.getGP();
                    featureAdvantagesValueBox[number].Text = feature.getValue();
                    break;
                case DSA_FEATURES.NACHTEIL:
                    featureDisdvantagesNameBox[number].Text = feature.getName();
                    featureDisAdvantagesDescriptionBox[number].Text = feature.getDescription();
                    featureDisAdvantagesGPBox[number].Text = feature.getGP();
                    featureDisAdvantagesValueBox[number].Text = feature.getValue();
                    break;
            }
            this.refreshHeroPage();
        }

        private void txtVorteil1_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(1, DSA_FEATURES.VORTEIL);
        }
        private void txtVorteil2_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(2, DSA_FEATURES.VORTEIL);
        }
        private void txtVorteil3_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(3, DSA_FEATURES.VORTEIL);
        }
        private void txtVorteil4_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(4, DSA_FEATURES.VORTEIL);
        }
        private void txtVorteil5_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(5, DSA_FEATURES.VORTEIL);
        }
        private void txtVorteil6_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(6, DSA_FEATURES.VORTEIL);
        }
        private void txtVorteil7_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(7, DSA_FEATURES.VORTEIL);
        }
        private void txtVorteil8_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(8, DSA_FEATURES.VORTEIL);
        }
        private void txtVorteil9_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(9, DSA_FEATURES.VORTEIL);
        }
        private void txtVorteil10_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(10, DSA_FEATURES.VORTEIL);
        }
        private void txtVorteil11_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(11, DSA_FEATURES.VORTEIL);
        }
        private void txtVorteil12_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(12, DSA_FEATURES.VORTEIL);
        }
        private void txtVorteil13_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(13, DSA_FEATURES.VORTEIL);
        }
        private void txtVortei14_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(14, DSA_FEATURES.VORTEIL);
        }
        private void txtVorteil15_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(15, DSA_FEATURES.VORTEIL);
        }


        private void txtNachteil1_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(1, DSA_FEATURES.NACHTEIL);
        }
        private void txtNachteil2_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(2, DSA_FEATURES.NACHTEIL);
        }
        private void txtNachteil3_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(3, DSA_FEATURES.NACHTEIL);
        }
        private void txtNachteil4_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(4, DSA_FEATURES.NACHTEIL);
        }
        private void txtNachteil5_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(5, DSA_FEATURES.NACHTEIL);
        }
        private void txtNachteil6_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(6, DSA_FEATURES.NACHTEIL);
        }
        private void txtNachteil7_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(7, DSA_FEATURES.NACHTEIL);
        }
        private void txtNachteil8_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(8, DSA_FEATURES.NACHTEIL);
        }
        private void txtNachteil9_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(9, DSA_FEATURES.NACHTEIL);
        }
        private void txtNachteil10_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(10, DSA_FEATURES.NACHTEIL);
        }
        private void txtNachteil11_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(11, DSA_FEATURES.NACHTEIL);
        }
        private void txtNachteil12_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(12, DSA_FEATURES.NACHTEIL);
        }
        private void txtNachteil13_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(13, DSA_FEATURES.NACHTEIL);
        }
        private void txtNachteil14_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(14, DSA_FEATURES.NACHTEIL);
        }
        private void txtNachteil15_ValueChanged(object sender, EventArgs e)
        {
            CreateFeature(15, DSA_FEATURES.NACHTEIL);
        }


        private int getTalentPage()
        {
            String page = txtTalentLetterCurrentPage.Text;
            int x;
            Int32.TryParse(page, out x);

            return x;
        }
        private int calculateTalentNumber(int boxnumber)
        {
            return (getTalentPage()-1)*SUpportedTalentCOunt + (boxnumber-1);
        }
        private void setUPTalentBoxesZero(int number)
        {
            for (int i=number; i < SUpportedTalentCOunt; i++)
            {
                talentNameLabels[i].Text = "             ";
                talentProbeTextBoxs[i].Text = "";
                talentWürfeTextBoxs[i].Text = "";
                talentTaWTextBoxes[i].Text = "";
                talentBeTextBoxes[i].Text = "";
                talentBeTextBoxes[i].Text = "";
                talentSpezialisierungTextBoxes[i].Text = "";
                talentAbleitungTextBoxes[i].Text = "";
                talentAnforderungsTextBoxes[i].Text = "";
                talentATTextBoxes[i].Text = "";
                talentPATextBoxes[i].Text = "";
            }
        }
    
        private int setUPGeneralTalents(DSA_GENERALTALENTS type)
        {
            int i = 0;
            groupBoxAnforderungen.Visible = true;
            groupBoxKampf.Visible = false;

            for (i=0; i< SUpportedTalentCOunt; i++)
            {
                GeneralTalent GeneralTalent = (GeneralTalent)controll.getTalent(type, (getTalentPage() - 1)*SUpportedTalentCOunt + i);
                if (GeneralTalent == null) { break; } 
                talentNameLabels[i].Text    = GeneralTalent.getName();
                talentProbeTextBoxs[i].Text = GeneralTalent.getProbeStringOne();
                talentWürfeTextBoxs[i].Text = GeneralTalent.getProbeStringTwo();
                talentTaWTextBoxes[i].Text  = GeneralTalent.getTaW().ToString();
                talentBeTextBoxes[i].Text   = GeneralTalent.getBe().ToString();
                talentSpezialisierungTextBoxes[i].Text = "";
                talentAbleitungTextBoxes[i].Text = GeneralTalent.getAbleitenString();
                talentAnforderungsTextBoxes[i].Text = GeneralTalent.getRequirementString();
            }

            groupBoxProbe.Left              = groupBoxTalentName.Right + 5;
            groupBoxTaW.Left                = groupBoxProbe.Right + 5;
            groupBoxBe.Left                 = groupBoxTaW.Right + 5;
            groupBoxBilliger.Left           = groupBoxBe.Right + 5;
            groupBoxSpezialisierung.Left    = groupBoxBilliger.Right + 5;
            groupBoxAnforderungen.Left      = groupBoxSpezialisierung.Right + 5;
            groupBoxAbleiten.Left           = groupBoxAnforderungen.Right + 5;
            
            return i;
        }
        private int setUPFightingTalents(DSA_FIGHTINGTALENTS type)
        {
            String page = txtTalentLetterCurrentPage.Text;
            int x;
            int i = 0;
            Int32.TryParse(page, out x);

            groupBoxAnforderungen.Visible = false;
            groupBoxKampf.Visible = true;

            for (i = 0; i < SUpportedTalentCOunt; i++)
            {
                FightTalent FightingTalent = (FightTalent)controll.getTalent(type, (x - 1) * SUpportedTalentCOunt + i);
                if (FightingTalent == null) { break ; }
                talentNameLabels[i].Text = FightingTalent.getName();
                talentProbeTextBoxs[i].Text = FightingTalent.getProbeStringOne();
                talentWürfeTextBoxs[i].Text = FightingTalent.getProbeStringTwo();
                talentTaWTextBoxes[i].Text = FightingTalent.getTaW().ToString();
                talentBeTextBoxes[i].Text = FightingTalent.getBe().ToString();
                talentSpezialisierungTextBoxes[i].Text = "";
                talentAbleitungTextBoxes[i].Text = FightingTalent.getAbleitenString();
                

                talentATTextBoxes[i].Text = FightingTalent.getAT().ToString();
                talentPATextBoxes[i].Text = FightingTalent.getPA().ToString();
            }
            groupBoxProbe.Left = groupBoxTalentName.Right + 5;
            groupBoxTaW.Left = groupBoxProbe.Right + 5;
            groupBoxKampf.Left = groupBoxTaW.Right + 5;
            groupBoxBe.Left = groupBoxKampf.Right + 5;
            groupBoxBilliger.Left = groupBoxBe.Right + 5;
            groupBoxSpezialisierung.Left = groupBoxBilliger.Right + 5;
            groupBoxAbleiten.Left = groupBoxSpezialisierung.Right + 5;

            return i;
        }
        

        private InterfaceTalent getTalent(int number, int type)
        {
            List<RadioButton> generalDictonaryListKeys = new List<RadioButton>(generalTalentDiconary.Keys);
            List<RadioButton> fightDictonaryListKeys = new List<RadioButton>(fightTalentDiconary.Keys);

            InterfaceTalent talent = null;

            if (type == 0 || type == 1)
            {
                for (int i = 0; i < generalDictonaryListKeys.Count; i++)
                {
                    if (generalDictonaryListKeys[i].Checked)
                    {
                        DSA_GENERALTALENTS talenttype;
                        generalTalentDiconary.TryGetValue(generalDictonaryListKeys[i], out talenttype);
                        talent = controll.getTalent(talenttype, number);
                    }
                }
            }
            if(type == 0 || type == 2)
            {
                for(int i=0; i < fightDictonaryListKeys.Count; i++){
                    if (fightDictonaryListKeys[i].Checked)
                    {
                        DSA_FIGHTINGTALENTS talenttype;
                        fightTalentDiconary.TryGetValue(fightDictonaryListKeys[i], out talenttype);
                        talent = controll.getTalent(talenttype, number);
                    }
                }
            }

            return talent;
        }
        private InterfaceTalent getTalent(int number)
        {
            return getTalent(number, 0);
        }
        private FightTalent getFightingTalent(int number)
        {
            return (FightTalent)getTalent(number, 2);
        }

        private void TAWChange(object sender, EventArgs e)
        {
            int BoxNumber;
            TextBox box = (TextBox)sender;
            String BasicString = "PTTaw";
            String NameString = box.Name;
            String number = NameString.Substring(BasicString.Length, NameString.Length - BasicString.Length);
            Int32.TryParse(number, out BoxNumber);

            InterfaceTalent talent =getTalent(calculateTalentNumber(BoxNumber));
            
            if (talent == null) return;

            talent.setTaw(box.Text);
            box.Text = talent.getTaW().ToString();
            talentProbeTextBoxs[BoxNumber-1].Text = talent.getProbeStringOne();
        }
        private void ATChanged(object sender, EventArgs e)
        {            
            TextBox box = (TextBox)sender;
            if (box.Visible == false) return;

            int BoxNumber = 0;
            String BasicString = "PTAT";
            String NameString = box.Name;
            String Boxnumber = NameString.Substring(BasicString.Length, NameString.Length - BasicString.Length);
            Int32.TryParse(Boxnumber, out BoxNumber);

            FightTalent talent = (FightTalent)getTalent(calculateTalentNumber(BoxNumber));
            if (talent == null) return;

            int result;
            Int32.TryParse(box.Text, out result);

            talent.setAT(result);
            box.Text = talent.getAT().ToString();

            talentProbeTextBoxs[BoxNumber-1].Text = talent.getProbeStringOne();            
        }
        private void PAChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Visible == false) return;

            int BoxNumber = 0;
            String BasicString = "PTPA";
            String NameString = box.Name;
            String Boxnumber = NameString.Substring(BasicString.Length, NameString.Length - BasicString.Length);
            Int32.TryParse(Boxnumber, out BoxNumber);

            FightTalent talent = (FightTalent)getTalent(calculateTalentNumber(BoxNumber));
            if (talent == null) return;

            int result;
            Int32.TryParse(box.Text, out result);

            talent.setPA(result);
            box.Text = talent.getPA().ToString();

            talentWürfeTextBoxs[BoxNumber-1].Text = talent.getProbeStringTwo();
        }
        
        private void radioKörperlicheTalente_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;
            int i = setUPGeneralTalents(DSA_GENERALTALENTS.PHYSICAL);
            setUPTalentBoxesZero(i);
        }
        private void radioSozialTalente_CheckedChanged(object sender, EventArgs e)
        {           
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;
            int i = setUPGeneralTalents(DSA_GENERALTALENTS.SOCIAL);
            setUPTalentBoxesZero(i);

        }
        private void radioNaturTalente_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;
            int i = setUPGeneralTalents(DSA_GENERALTALENTS.NATURE);
            setUPTalentBoxesZero(i);

        }
        private void radioKnowldageTalente_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;
            int i = setUPGeneralTalents(DSA_GENERALTALENTS.KNOWLDAGE);
            setUPTalentBoxesZero(i);

        }
        private void radioCraftingTalent_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;
            int i = setUPGeneralTalents(DSA_GENERALTALENTS.CRAFTING);
            setUPTalentBoxesZero(i);

        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;
            
        }
        private void radioButtonWeaponless_ChecedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;

            int i = setUPFightingTalents(DSA_FIGHTINGTALENTS.WEAPONLESS);
            setUPTalentBoxesZero(i);
        }
        private void radioButton1_CheckedChanged_1(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;

            int i = setUPFightingTalents(DSA_FIGHTINGTALENTS.CLOSE);
            setUPTalentBoxesZero(i);
        }
        private void radioButtonRange_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;

            int i = setUPFightingTalents(DSA_FIGHTINGTALENTS.RANGE);
            setUPTalentBoxesZero(i);
        }

        private void TabControl_MouseClick(object sender, MouseEventArgs e)
        {
            TabControl control = (TabControl)sender;
            TabPage page = control.SelectedTab;

            if(0 == String.Compare(page.Name, "Talente"))
            {

            }
        }
        private void btnCreateTalent_Click(object sender, EventArgs e)
        {
            CreateTalent createTalent = new CreateTalent();
            createTalent.ShowDialog();
        }
        private void btncreateFightingTalent_Click(object sender, EventArgs e)
        {
            CreateFightingTalent talent = new CreateFightingTalent();
            talent.ShowDialog();
        }
        private void btnTalentLetterNext_Click(object sender, EventArgs e)
        {
            String page = txtTalentLetterCurrentPage.Text;
            int x;
            Int32.TryParse(page, out x);
            x++;
            txtTalentLetterCurrentPage.Text = x.ToString();

            for(int i=0; i< RadioListTalents.Count; i++)
            {
                if(RadioListTalents[i].Checked == true)
                {
                    RadioListTalents[i].Checked = false;
                    RadioListTalents[i].Checked = true;
                    break;
                }
            }
        }
        private void btnTalentLetterLast_Click(object sender, EventArgs e)
        {
            String page = txtTalentLetterCurrentPage.Text;
            int x;
            Int32.TryParse(page, out x);
            if ((x-1) > 0)
            {
                x--;
            }
            txtTalentLetterCurrentPage.Text = x.ToString();
            for (int i = 0; i < RadioListTalents.Count; i++)
            {
                if (RadioListTalents[i].Checked == true)
                {
                    RadioListTalents[i].Checked = false;
                    RadioListTalents[i].Checked = true;
                    break;
                }
            }
        }

        private void talents_Click(object sender, EventArgs e)
        {

        }


        private void changeAttributMark(DSA_ATTRIBUTE att, Label lblAttribut, TextBox txtAKT, TextBox txtMOD, TextBox txtMax)
        {
            bool x = controll.getMarkedAttribut(att);

            if (x)
            {
                lblAttribut.ForeColor = Color.Black;
                lblAttribut.Font = new Font(lblAttribut.Font, FontStyle.Regular);

                txtAKT.BackColor = Color.White;
                txtMOD.BackColor = SystemColors.InactiveCaption;
                txtMax.BackColor = SystemColors.InactiveCaption;

                x = false;
            } else
            {
                lblAttribut.ForeColor    = Color.Red;

                txtAKT.BackColor = Color.Yellow;
                txtMOD.BackColor = Color.GreenYellow;
                txtMax.BackColor = Color.GreenYellow;

                x = true;
            }
            controll.setMarkedAttribut(att, x);
        }

        private void lblMut_Click(object sender, EventArgs e)
        {
            changeAttributMark(DSA_ATTRIBUTE.MU, lblMut, txtMutAKT, txtMutMOD, txtMutMAX);
        }
        private void lblKlugheit_Click(object sender, EventArgs e)
        {
            changeAttributMark(DSA_ATTRIBUTE.KL, lblKlugheit, txtKlugheitAKT, txtKlugheitMOD, txtKlugheitMAX);
        }
        private void lblCharisma_Click(object sender, EventArgs e)
        {
            changeAttributMark(DSA_ATTRIBUTE.CH, lblCharisma, txtCharismaAKT, txtCharismaMOD, txtCharismaMAX);
        }
        private void lblFingerfertigkeit_Click(object sender, EventArgs e)
        {
            changeAttributMark(DSA_ATTRIBUTE.FF, lblFingerfertigkeit, txtFingerfertigkeitAKT, txtFingerfertigkeitMOD, txtFingerfertigkeitMAX);
        }
        private void lblGewandheit_Click(object sender, EventArgs e)
        {
            changeAttributMark(DSA_ATTRIBUTE.GE, lblGewandheit, textGewandheitAKT, textGewandheitMOD, textGewandheitMAX);
        }
        private void lblKonstitution_Click(object sender, EventArgs e)
        {
            changeAttributMark(DSA_ATTRIBUTE.KO, lblKonstitution, txtKonstitutionAKT, txtKonstitutionMOD, txtKonstitutionMAX);
        }
        private void lblKörperkraft_Click(object sender, EventArgs e)
        {
            changeAttributMark(DSA_ATTRIBUTE.KK, lblKörperkraft, txtKörperkraftAKT, txtKörperkraftMOD, txtKörperkraftMAX);
        }
        private void lblSozialstatus_Click(object sender, EventArgs e)
        {
            changeAttributMark(DSA_ATTRIBUTE.SO, lblSozialstatus, txtSozialstatusAKT, txtSozialstatusMOD, txtSozialstatusMAX);
        }
        private void lblIntuition_Click(object sender, EventArgs e)
        {
            changeAttributMark(DSA_ATTRIBUTE.IN, lblIntuition, txtIntuitionAKT, txtIntuitionMOD, txtIntuitionMAX);
        }

        private int getBoxNumber(String BasicString, String NameString)
        {
            int BoxNumber = 0;
            String number = NameString.Substring(BasicString.Length, NameString.Length - BasicString.Length);
            Int32.TryParse(number, out BoxNumber);
            return BoxNumber;
        }

        //Aktuell Kolidieren Reward und Advantages -> Rewards sind Advantages
        private void CreateReward(int rewardNumber, int boxNumber, DSA_FEATURES type)
        {
            Feature feature = controll.Feature(rewardNumber, type);

            if (feature == null) return;
            
            rewardNameBoxes[boxNumber].Text = feature.getName();
            rewadDescriptionBoxes[boxNumber].Text = feature.getDescription();
            
            this.refreshHeroPage();
             
        }
        private void setReward_DiscriptionBox(Object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            int BoxNumber = getBoxNumber("txtReward", ((TextBox)sender).Name);
            BoxNumber = BoxNumber - 1;

            int number = 0;
            int page = 0;
            Int32.TryParse(txtRewardPage.Text, out page);

            number = (SUpportedTalentCOunt * page) + BoxNumber;

            CreateReward(number, BoxNumber, DSA_FEATURES.VORTEIL);

            Console.WriteLine(BoxNumber);
        }
    }
}
