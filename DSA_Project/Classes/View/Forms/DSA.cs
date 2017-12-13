using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

//toDO:     Zeitverlust durch Aufruf change wenn Projekt diesen Change (nicht von Außen) vornimmt

namespace DSA_Project
{
    public partial class DSA : Form
    {
        private ControllClass controll;

        public DSA()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            
            InitializeComponent();

            SetUPForm();
            
            load();
            refreshHeroPage();
            refreshTalentPage();
        }
        //#########################################################################################################################################################################
        //Tools
        private void SetUPForm()
        {
            setUPtoolPage();
            setUPHeroPageBasicValues();
            setUPHeroPageAttribute();
            setUPHeroPageAdvanced();
            setUPHeroPageMoney();
            setUPHeroPageEnergien();
            setUPFeatureLists();

            controll = (ControllClass)new ControllClassDSA(this);

            setUPTalentBox();
            setUPTalentPage();
            setUPRewards();
        }
        public void load()
        {
            txtAbenteuerpunkte.Text = controll.AdvanturePoints().ToString();

            setUPTalentBox();

            loadHeroPageBasicValues();
            loadHeroPageAttributMark();
            loadHeroPageMoney();
            loadFeature();
            loadRewards();

            refreshHeroPageAdvancedValues();
        }
        public void refreshHeroPage()
        {
            refreshHeroPageAttributValues();
            refreshHeroPageAdvancedValues();
            refreshHeroPageEnergie();
        }
        private int getBoxNumber(String BasicString, String NameString)
        {
            int BoxNumber = 0;
            String number = NameString.Substring(BasicString.Length, NameString.Length - BasicString.Length);
            Int32.TryParse(number, out BoxNumber);
            return BoxNumber;
        }
        //#########################################################################################################################################################################
        //ToolPage
        private void setUPtoolPage()
        {
            List<Button> toolPageButtons = new List<Button> { btnLoadCharacter, btnSaveCharacter, btnToolChangeDSA_PNP, btnCreateTalent, btncreateFightingTalent};
            btnLoadCharacter.Click += new EventHandler(btnLoadCharacter_Click);
            btnSaveCharacter.Click += new EventHandler(btnSaveCharacter_Click);
            btnToolChangeDSA_PNP.Click += new EventHandler(btnToolChangeDSA_PNP_Click);
            btnCreateTalent.Click += new EventHandler(btnCreateTalent_Click);
            btncreateFightingTalent.Click += new EventHandler(btncreateFightingTalent_Click);
        }
        private void btnLoadCharacter_Click(object sender, EventArgs e)
        {
            controll.load();
        }
        private void btnSaveCharacter_Click(object sender, EventArgs e)
        {
            controll.save();
        }
        private void btnToolChangeDSA_PNP_Click(object sender, EventArgs e)
        {
            Type classa = controll.GetType();
            Type classb = new ControllClassDSA(this).GetType();

            if (classa.Equals(classb))
            {
                controll = new ControllClassPNP(this);
                this.Name = "PNP";
                this.Text = "PNP";
            } else
            {
                controll = new ControllClassDSA(this);
                this.Name = "DSA";
                this.Text = "DSA";
            }
            this.load();
        }
        private void btnCreateTalent_Click(object sender, EventArgs e)
        {
            //CreateTalent createTalent = new CreateTalent();
            //createTalent.ShowDialog();
        }
        private void btncreateFightingTalent_Click(object sender, EventArgs e)
        {
            //CreateFightingTalent talent = new CreateFightingTalent();
            //talent.ShowDialog();
        }
        //#########################################################################################################################################################################
        //HeroPage Attribute
        private List<Label> HeroPageAttributLabels;
        private List<TextBox> HeroPageAttributAKTBoxes;
        private List<TextBox> HeroPageAttributMODBoxes;
        private List<TextBox> HeroPageAttributMAXBoxes;
        private void setUPHeroPageAttribute()
        {
            HeroPageAttributLabels = new List<Label> { lblMut, lblKlugheit, lblIntuition, lblCharisma, lblFingerfertigkeit, lblGewandheit, lblKonstitution, lblKörperkraft, lblSozialstatus };
            HeroPageAttributAKTBoxes = new List<TextBox> { txtMutAKT, txtKlugheitAKT, txtIntuitionAKT, txtCharismaAKT, txtFingerfertigkeitAKT, txtGewandheitAKT, txtKonstitutionAKT, txtKörperkraftAKT, txtSozialstatusAKT };
            HeroPageAttributMODBoxes = new List<TextBox> { txtMutMOD, txtKlugheitMOD, txtIntuitionMOD, txtCharismaMOD, txtFingerfertigkeitMOD, txtGewandheitMOD, txtKonstitutionMOD, txtKörperkraftMOD, txtSozialstatusMOD };
            HeroPageAttributMAXBoxes = new List<TextBox> { txtMutMAX, txtKlugheitMAX, txtIntuitionMAX, txtCharismaMAX, txtFingerfertigkeitMAX, txtGewandheitMAX, txtKonstitutionMAX, txtKörperkraftMAX, txtSozialstatusMAX };


            lblMut.Tag = txtMutAKT.Tag = txtMutMOD.Tag = txtMutMAX.Tag = DSA_ATTRIBUTE.MU;
            lblKlugheit.Tag = txtKlugheitAKT.Tag = txtKlugheitMOD.Tag = txtKlugheitMAX.Tag = DSA_ATTRIBUTE.KL;
            lblIntuition.Tag = txtIntuitionAKT.Tag = txtIntuitionMOD.Tag = txtIntuitionMAX.Tag = DSA_ATTRIBUTE.IN;
            lblCharisma.Tag = txtCharismaAKT.Tag = txtCharismaMOD.Tag = txtCharismaMAX.Tag = DSA_ATTRIBUTE.CH;
            lblFingerfertigkeit.Tag = txtFingerfertigkeitAKT.Tag = txtFingerfertigkeitMOD.Tag = txtFingerfertigkeitMAX.Tag = DSA_ATTRIBUTE.FF;
            lblGewandheit.Tag = txtGewandheitAKT.Tag = txtGewandheitMOD.Tag = txtGewandheitMAX.Tag = DSA_ATTRIBUTE.GE;
            lblKonstitution.Tag = txtKonstitutionAKT.Tag = txtKonstitutionMOD.Tag = txtKonstitutionMAX.Tag = DSA_ATTRIBUTE.KO;
            lblKörperkraft.Tag = txtKörperkraftAKT.Tag = txtKörperkraftMOD.Tag = txtKörperkraftMAX.Tag = DSA_ATTRIBUTE.KK;
            lblSozialstatus.Tag = txtSozialstatusAKT.Tag = txtSozialstatusMOD.Tag = txtSozialstatusMAX.Tag = DSA_ATTRIBUTE.SO;

            for (int i = 0; i < HeroPageAttributAKTBoxes.Count; i++)
            {
                HeroPageAttributLabels[i].Click     += new EventHandler(AttributeLabel_Click);
                HeroPageAttributAKTBoxes[i].KeyUp   += new KeyEventHandler(AttributAKT_KeyUp);
                HeroPageAttributMODBoxes[i].KeyUp   += new KeyEventHandler(AttributMOD_KeyUp);
                HeroPageAttributMAXBoxes[i].KeyUp   += new KeyEventHandler(AttributMAX_KeyUp);

                HeroPageAttributAKTBoxes[i].BackColor = ManagmentForm.activeColor;
                HeroPageAttributMODBoxes[i].BackColor = ManagmentForm.inactiveColor;
                HeroPageAttributMAXBoxes[i].BackColor = ManagmentForm.inactiveColor;
            }
        }
        private void refreshHeroPageAttributValues()
        {
            for (int i = 0; i < HeroPageAttributLabels.Count; i++)
            {
                HeroPageAttributAKTBoxes[i].Text = controll.AttributeAKT((DSA_ATTRIBUTE)HeroPageAttributAKTBoxes[i].Tag).ToString();
                HeroPageAttributMODBoxes[i].Text = controll.AttributeMOD((DSA_ATTRIBUTE)HeroPageAttributMODBoxes[i].Tag).ToString();
                HeroPageAttributMAXBoxes[i].Text = controll.AttributeMAX((DSA_ATTRIBUTE)HeroPageAttributMAXBoxes[i].Tag).ToString();
            }

            txtGesamtAKT.Text = controll.getAttributeAKTSumme().ToString();
            txtGesamtMAX.Text = controll.getAttributeMAXSumme().ToString();
        }
        public void loadHeroPageAttributMark()
        {
            //Doppelter Aufruf != Ursprüngliches Ergebnis --->Schrot!!! ---> Wiederspricht neuer Structur von Kontroll, ZU ÜBERARBEITEN
            controll.changeAttributMark(DSA_ATTRIBUTE.MU, lblMut, txtMutAKT, txtMutMOD, txtMutMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.KL, lblKlugheit, txtKlugheitAKT, txtKlugheitMOD, txtKlugheitMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.CH, lblCharisma, txtCharismaAKT, txtCharismaMOD, txtCharismaMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.FF, lblFingerfertigkeit, txtFingerfertigkeitAKT, txtFingerfertigkeitMOD, txtFingerfertigkeitMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.GE, lblGewandheit, txtGewandheitAKT, txtGewandheitMOD, txtGewandheitMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.KO, lblKonstitution, txtKonstitutionAKT, txtKonstitutionMOD, txtKonstitutionMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.KK, lblKörperkraft, txtKörperkraftAKT, txtKörperkraftMOD, txtKörperkraftMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.SO, lblSozialstatus, txtSozialstatusAKT, txtSozialstatusMOD, txtSozialstatusMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.IN, lblIntuition, txtIntuitionAKT, txtIntuitionMOD, txtIntuitionMAX);

            controll.changeAttributMark(DSA_ATTRIBUTE.MU, lblMut, txtMutAKT, txtMutMOD, txtMutMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.KL, lblKlugheit, txtKlugheitAKT, txtKlugheitMOD, txtKlugheitMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.CH, lblCharisma, txtCharismaAKT, txtCharismaMOD, txtCharismaMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.FF, lblFingerfertigkeit, txtFingerfertigkeitAKT, txtFingerfertigkeitMOD, txtFingerfertigkeitMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.GE, lblGewandheit, txtGewandheitAKT, txtGewandheitMOD, txtGewandheitMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.KO, lblKonstitution, txtKonstitutionAKT, txtKonstitutionMOD, txtKonstitutionMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.KK, lblKörperkraft, txtKörperkraftAKT, txtKörperkraftMOD, txtKörperkraftMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.SO, lblSozialstatus, txtSozialstatusAKT, txtSozialstatusMOD, txtSozialstatusMAX);
            controll.changeAttributMark(DSA_ATTRIBUTE.IN, lblIntuition, txtIntuitionAKT, txtIntuitionMOD, txtIntuitionMAX);
            //Doppelter Aufruf != Ursprüngliches Ergebnis --->Schrot!!!
        }
        private void AttributAKT_KeyUp(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            box.Text = controll.AttributeAKT((DSA_ATTRIBUTE)box.Tag, box.Text).ToString();
        }
        private void AttributMOD_KeyUp(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            box.Text = controll.AttributeMOD((DSA_ATTRIBUTE)box.Tag, box.Text).ToString();
        }
        private void AttributMAX_KeyUp(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            box.Text = controll.AttributeMAX((DSA_ATTRIBUTE)box.Tag, box.Text).ToString();
        }
        private void AttributeLabel_Click(object sender, EventArgs e)
        {
            Label lbl = (Label)sender;
            int x = (int)(DSA_ATTRIBUTE)lbl.Tag;
            controll.changeAttributMark((DSA_ATTRIBUTE)lbl.Tag, HeroPageAttributLabels[x], HeroPageAttributAKTBoxes[x], HeroPageAttributMODBoxes[x], HeroPageAttributMAXBoxes[x]);
        }
        //#########################################################################################################################################################################
        //HeroPage AdvancedValues
        private List<TextBox> HeroPageAdvancedAKTBoxes;
        private List<TextBox> HeroPageAdvancedMODBoxes;
        private List<TextBox> HeroPageAdvancedMAXBoxes;
        private void setUPHeroPageAdvanced()
        {
            HeroPageAdvancedAKTBoxes = new List<TextBox> { txtAttackeBaisAKT, txtParadeBasisAKT, txtFernkampfBasisAKT, txtInitativeBasisAKT, txtBeherschungswertAKT, txtArtefaktkontrolleAKT, txtWundschwelleAKT, txtEntrückungAKT, txtGeschwindigkeitAKT };
            HeroPageAdvancedMODBoxes = new List<TextBox> { txtAttackeBasisMOD, txtParadeBasisMOD, txtFernkampfBasisMOD, txtInitativeBasisMOD, txtBeherschungswertMOD, txtArtefaktkontrolleMOD, txtWundschwelleMOD, txtEntrückungMOD, txtGeschwindigkeitMOD };
            HeroPageAdvancedMAXBoxes = new List<TextBox> { txtAttackeBaisMAX, txtParadeBasisMAX, txtFernkampfBasisMAX, txtInitativeBasisMAX, txtBeherschungswertMAX, txtArtefaktkontrolleMAX, txtWundschwelleMAX, txtEntrückungMAX, txtGeschwindigkeitMAX };

            txtAttackeBaisAKT.Tag = txtAttackeBasisMOD.Tag = txtAttackeBaisMAX.Tag = DSA_ADVANCEDVALUES.ATTACKE_BASIS;
            txtParadeBasisAKT.Tag = txtParadeBasisMOD.Tag = txtParadeBasisMAX.Tag = DSA_ADVANCEDVALUES.PARADE_BASIS;
            txtFernkampfBasisAKT.Tag = txtFernkampfBasisMOD.Tag = txtFernkampfBasisMAX.Tag = DSA_ADVANCEDVALUES.FERNKAMPF_BASIS;
            txtInitativeBasisAKT.Tag = txtInitativeBasisMOD.Tag = txtInitativeBasisMAX.Tag = DSA_ADVANCEDVALUES.INITATIVE_BASIS;
            txtBeherschungswertAKT.Tag = txtBeherschungswertMOD.Tag = txtBeherschungswertMAX.Tag = DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT;
            txtArtefaktkontrolleAKT.Tag = txtArtefaktkontrolleMOD.Tag = txtArtefaktkontrolleMAX.Tag = DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE;
            txtWundschwelleAKT.Tag = txtWundschwelleMOD.Tag = txtWundschwelleMAX.Tag = DSA_ADVANCEDVALUES.WUNDSCHWELLE;
            txtEntrückungAKT.Tag = txtEntrückungMOD.Tag = txtEntrückungMAX.Tag = DSA_ADVANCEDVALUES.ENTRÜCKUNG;
            txtGeschwindigkeitAKT.Tag = txtGeschwindigkeitMOD.Tag = txtGeschwindigkeitMAX.Tag = DSA_ADVANCEDVALUES.GESCHWINDIGKEIT;

            for (int i = 0; i < HeroPageAdvancedAKTBoxes.Count; i++)
            {
                HeroPageAdvancedAKTBoxes[i].TextChanged += new EventHandler(txtAdvancedValueAKT_TextChanged);
                HeroPageAdvancedMODBoxes[i].TextChanged += new EventHandler(txtAdvancedValueMOD_TextChanged);
                HeroPageAdvancedMAXBoxes[i].TextChanged += new EventHandler(txtAdvancedValueMAX_TextChanged);
            }
        }
        public void refreshHeroPageAdvancedValues()
        {
            txtAttackeBaisAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
            txtParadeBasisAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
            txtFernkampfBasisAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
            txtInitativeBasisAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
            txtBeherschungswertAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
            txtArtefaktkontrolleAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE).ToString();
            txtWundschwelleAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();
            txtEntrückungAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
            txtGeschwindigkeitAKT.Text = controll.AdvancedValueAKT(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();

            txtAttackeBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
            txtArtefaktkontrolleMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE).ToString();
            txtBeherschungswertMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
            txtEntrückungMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
            txtFernkampfBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
            txtGeschwindigkeitMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();
            txtInitativeBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
            txtParadeBasisMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
            txtWundschwelleMOD.Text = controll.AdvancedValueMOD(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();

            txtAttackeBaisMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.ATTACKE_BASIS).ToString();
            txtParadeBasisMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.PARADE_BASIS).ToString();
            txtFernkampfBasisMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS).ToString();
            txtInitativeBasisMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.INITATIVE_BASIS).ToString();
            txtBeherschungswertMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT).ToString();
            txtArtefaktkontrolleMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE).ToString();
            txtWundschwelleMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.WUNDSCHWELLE).ToString();
            txtEntrückungMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.ENTRÜCKUNG).ToString();
            txtGeschwindigkeitMAX.Text = controll.AdvancedValueMAX(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT).ToString();
        }
        private void txtAdvancedValueAKT_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = controll.AdvancedValueAKT((DSA_ADVANCEDVALUES)textBox.Tag, textBox.Text).ToString();
        }
        private void txtAdvancedValueMOD_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = controll.AdvancedValueMOD((DSA_ADVANCEDVALUES)textBox.Tag).ToString();
        }
        private void txtAdvancedValueMAX_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Text = controll.AdvancedValueMAX((DSA_ADVANCEDVALUES)textBox.Tag).ToString();
        }
        //#########################################################################################################################################################################
        //HeroPage Energien
        private List<TextBox> HeroPageEnergienAKTBoxes;
        private List<TextBox> HeroPageEnergienPERBoxes;
        private List<TextBox> HeroPageEnergienMALBoxes;
        private List<TextBox> HeroPageEnergienERGBoxes;
        private void setUPHeroPageEnergien()
        {
            HeroPageEnergienAKTBoxes = new List<TextBox> { txtLebensenergieVOR, txtAusdauerVOR, txtAstralenergieVOR, txtKarmaenergieVOR, txtMagieresistenzVOR };
            HeroPageEnergienPERBoxes = new List<TextBox> { txtLebensenergiePERM, txtAusdauerPERM, txtAstralenergiePERM, txtKarmaenergiePERM, txtMagieresistenzPERM };
            HeroPageEnergienMALBoxes = new List<TextBox> { txtLebensenergieMALI, txtAusdauerMALI, txtAstralenergieMALI, txtKarmaenergieMALI, txtMagieresistenzMALI };
            HeroPageEnergienERGBoxes = new List<TextBox> { txtLebensenergieERG, txtAusdauerERG, txtAstralenergieERG, txtKarmaenergieERG, txtMagieresistenzERG };

            txtLebensenergieVOR.Tag = txtLebensenergiePERM.Tag = txtLebensenergieMALI.Tag = txtLebensenergieERG.Tag = DSA_ENERGIEN.LEBENSENERGIE;
            txtAusdauerVOR.Tag = txtAusdauerPERM.Tag = txtAusdauerMALI.Tag = txtAusdauerERG.Tag = DSA_ENERGIEN.AUSDAUER;
            txtAstralenergieVOR.Tag = txtAstralenergiePERM.Tag = txtAstralenergieMALI.Tag = txtAstralenergieERG.Tag = DSA_ENERGIEN.ASTRALENERGIE;
            txtKarmaenergieVOR.Tag = txtKarmaenergiePERM.Tag = txtKarmaenergieMALI.Tag = txtKarmaenergieERG.Tag = DSA_ENERGIEN.KARMAENERGIE;
            txtMagieresistenzVOR.Tag = txtMagieresistenzPERM.Tag = txtMagieresistenzMALI.Tag = txtMagieresistenzERG.Tag = DSA_ENERGIEN.MAGIERESISTENZ;


            for (int i = 0; i < HeroPageEnergienAKTBoxes.Count; i++)
            {
                HeroPageEnergienAKTBoxes[i].TextChanged += new EventHandler(txtEnergienVOR_TextChanged);
                HeroPageEnergienPERBoxes[i].TextChanged += new EventHandler(txtEnergienPER_TextChanged);
                HeroPageEnergienMALBoxes[i].TextChanged += new EventHandler(txtEnergienMALI_TextChanged);
                HeroPageEnergienERGBoxes[i].TextChanged += new EventHandler(txtEnergienERG_TextChanged);
            }
        }
        public void refreshHeroPageEnergie()
        {
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
        }
        private void txtEnergienVOR_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            box.Text = controll.EnergieVOR((DSA_ENERGIEN)box.Tag).ToString();
        }
        private void txtEnergienPER_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            box.Text = controll.EnergiePERM((DSA_ENERGIEN)box.Tag).ToString();
        }
        private void txtEnergienMALI_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            box.Text = controll.EnergieMALI((DSA_ENERGIEN)box.Tag).ToString();
        }
        private void txtEnergienERG_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            box.Text = controll.EnergieMAX((DSA_ENERGIEN)box.Tag).ToString();
        }
        //#########################################################################################################################################################################
        //HeroPage BasicValues
        private List<TextBox> HeroPageBasicValueBoxes;
        private void setUPHeroPageBasicValues()
        {
            HeroPageBasicValueBoxes = new List<TextBox> { txtName, txtAugenfarbe, txtRasse, txtKultur, txtProfession, txtAlter, txtHaarfarbe, txtGottheit, txtGewicht, txtFamulienstand, txtGeschlecht, txtGröße, txtHautfarbe };

            txtName.Tag = DSA_BASICVALUES.NAME;
            txtAugenfarbe.Tag = DSA_BASICVALUES.AUGENFARBE;
            txtAnrede.Tag = DSA_BASICVALUES.ANREDE;
            txtRasse.Tag = DSA_BASICVALUES.RASSE;
            txtKultur.Tag = DSA_BASICVALUES.KULTUR;
            txtProfession.Tag = DSA_BASICVALUES.PROFESSION;
            txtAlter.Tag = DSA_BASICVALUES.ALTER;
            txtGottheit.Tag = DSA_BASICVALUES.GOTTHEIT;
            txtGewicht.Tag = DSA_BASICVALUES.GEWICHT;
            txtFamulienstand.Tag = DSA_BASICVALUES.FAMILIENSTAND;
            txtGeschlecht.Tag = DSA_BASICVALUES.GESCHLECHT;
            txtGröße.Tag = DSA_BASICVALUES.GRÖSE;
            txtHautfarbe.Tag = DSA_BASICVALUES.HAUTFARBE;
            txtHaarfarbe.Tag = DSA_BASICVALUES.HAARFARBE;

            for (int i = 0; i < HeroPageBasicValueBoxes.Count; i++)
            {
                HeroPageBasicValueBoxes[i].TextChanged += new EventHandler(txtBasicValues_TextChanged);
            }
        }
        public void loadHeroPageBasicValues()
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
        }
        private void txtBasicValues_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            box.Text = controll.BasicValue((DSA_BASICVALUES)box.Tag, box.Text).ToString();
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
        //#########################################################################################################################################################################
        //HeroPage Andere
        private List<TextBox> HeroPageMoneyBoxes;
        private List<ComboBox> talentBoxComboBoxChose;
        private List<TextBox> talentBoxComboBoxChoseProbeA;
        private List<TextBox> talentBoxComboBoxChoseProbeB;
        private void setUPHeroPageMoney()
        {
            HeroPageMoneyBoxes = new List<TextBox> { txtGeldD, txtGeldH, txtGeldK, txtGeldS, txtBank };
            txtGeldD.Tag = DSA_MONEY.D;
            txtGeldH.Tag = DSA_MONEY.H;
            txtGeldK.Tag = DSA_MONEY.K;
            txtGeldS.Tag = DSA_MONEY.S;
            txtBank.Tag = DSA_MONEY.BANK;

            for (int i = 0; i < HeroPageMoneyBoxes.Count; i++)
            {
                HeroPageMoneyBoxes[i].TextChanged += new EventHandler(txtMoney_TextChanged);
            }

        }
        private void setUPTalentBox()
        {
            talentBoxComboBoxChose = new List<ComboBox> { HPcompoBoxTalent1, HPcompoBoxTalent2, HPcompoBoxTalent3, HPcompoBoxTalent4, HPcompoBoxTalent5 };
            talentBoxComboBoxChoseProbeA = new List<TextBox> { HPcompoBoxTalentProbeA1, HPcompoBoxTalentProbeA2, HPcompoBoxTalentProbeA3, HPcompoBoxTalentProbeA4, HPcompoBoxTalentProbeA5 };
            talentBoxComboBoxChoseProbeB = new List<TextBox> { HPcompoBoxTalentProbeB1, HPcompoBoxTalentProbeB2, HPcompoBoxTalentProbeB3, HPcompoBoxTalentProbeB4, HPcompoBoxTalentProbeB5 };

            for (int i = 0; i < talentBoxComboBoxChose.Count; i++)
            {
                talentBoxComboBoxChose[i].DataSource = controll.getTalent();
                talentBoxComboBoxChose[i].AutoCompleteMode = AutoCompleteMode.Suggest;
                talentBoxComboBoxChose[i].TextChanged += new EventHandler(setTalentBoxChose);
            }

        }
        public void loadHeroPageMoney()
        {
            txtGeldD.Text = controll.Money(DSA_MONEY.D).ToString() + DSA_MONEY.D.ToString();
            txtGeldH.Text = controll.Money(DSA_MONEY.H).ToString() + DSA_MONEY.H.ToString(); ;
            txtGeldS.Text = controll.Money(DSA_MONEY.S).ToString() + DSA_MONEY.S.ToString(); ;
            txtGeldK.Text = controll.Money(DSA_MONEY.K).ToString() + DSA_MONEY.K.ToString(); ;
            txtBank.Text = controll.Money(DSA_MONEY.BANK).ToString();
        }
        private void txtMoney_TextChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;

            DSA_MONEY type = ((DSA_MONEY)box.Tag);
            String trim = type.ToString();
            char t;

            if (Char.TryParse(trim, out t))
            {
                box.Text = controll.Money(type, txtGeldD.Text.TrimEnd(t)).ToString() + t;
                return;
            }
            box.Text = controll.Money(type).ToString();

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
        private void setTalentBoxChose(Object sender, EventArgs e)
        {
            ComboBox box = (ComboBox)sender;
            int boxNumber = getBoxNumber("HPcompoBoxTalent", box.Name);
            InterfaceTalent talent = (InterfaceTalent)box.SelectedValue;

            if (talent == null)
            {
                return;
            }
            talentBoxComboBoxChoseProbeA[boxNumber - 1].Text = talent.getProbeStringOne();
            talentBoxComboBoxChoseProbeB[boxNumber - 1].Text = talent.getProbeStringTwo();

            try
            {
                int x;
                FightTalent ftalent = (FightTalent)box.SelectedValue;

                if (!Int32.TryParse(ftalent.getPA(), out x))
                {
                    talentBoxComboBoxChoseProbeB[boxNumber - 1].Text = ftalent.getPA();
                }
            }
            catch (Exception) { }
        }
        //#########################################################################################################################################################################
        //HeroPage Feature
        private int HeroPageSupportedAdvantagesDisadvantagesBoxes = 15;
        private List<TextBox> featureAdvantagesNameBox;
        private List<TextBox> featureDisdvantagesNameBox;
        private List<TextBox> featureAdvantagesDescriptionBox;
        private List<TextBox> featureDisAdvantagesDescriptionBox;
        private List<TextBox> featureAdvantagesGPBox;
        private List<TextBox> featureDisAdvantagesGPBox;
        private List<TextBox> featureAdvantagesValueBox;
        private List<TextBox> featureDisAdvantagesValueBox;
        private void setUPFeatureLists()
        {
            featureAdvantagesNameBox = new List<TextBox> { txtVorteil1Name, txtVorteil2Name, txtVorteil3Name, txtVorteil4Name, txtVorteil5Name, txtVorteil6Name, txtVorteil7Name, txtVorteil8Name, txtVorteil9Name, txtVorteil10Name, txtVorteil11Name, txtVorteil12Name, txtVorteil13Name, txtVorteil14Name, txtVorteil15Name };
            featureDisdvantagesNameBox = new List<TextBox> { txtNachteil1Name, txtNachteil2Name, txtNachteil3Name, txtNachteil4Name, txtNachteil5Name, txtNachteil6Name, txtNachteil7Name, txtNachteil8Name, txtNachteil9Name, txtNachteil10Name, txtNachteil11Name, txtNachteil12Name, txtNachteil13Name, txtNachteil14Name, txtNachteil15Name };
            featureAdvantagesDescriptionBox = new List<TextBox> { txtVorteil1Beschreibung, txtVorteil2Beschreibung, txtVorteil3Beschreibung, txtVorteil4Beschreibung, txtVorteil5Beschreibung, txtVorteil6Beschreibung, txtVorteil7Beschreibung, txtVorteil8Beschreibung, txtVorteil9Beschreibung, txtVorteil10Beschreibung, txtVorteil11Beschreibung, txtVorteil12Beschreibung, txtVorteil13Beschreibung, txtVorteil14Beschreibung, txtVorteil15Beschreibung };
            featureDisAdvantagesDescriptionBox = new List<TextBox> { txtNachteil1Beschreibung, txtNachteil2Beschreibung, txtNachteil3Beschreibung, txtNachteil4Beschreibung, txtNachteil5Beschreibung, txtNachteil6Beschreibung, txtNachteil7Beschreibung, txtNachteil8Beschreibung, txtNachteil9Beschreibung, txtNachteil10Beschreibung, txtNachteil11Beschreibung, txtNachteil12Beschreibung, txtNachteil13Beschreibung, txtNachteil14Beschreibung, txtNachteil15Beschreibung };
            featureAdvantagesGPBox = new List<TextBox> { txtVorteil1GP, txtVorteil2GP, txtVorteil3GP, txtVorteil4GP, txtVorteil5GP, txtVorteil6GP, txtVorteil7GP, txtVorteil8GP, txtVorteil9GP, txtVorteil10GP, txtVorteil11GP, txtVorteil12GP, txtVorteil13GP, txtVorteil14GP, txtVorteil15GP };
            featureDisAdvantagesGPBox = new List<TextBox> { txtNachteil1GP, txtNachteil2GP, txtNachteil3GP, txtNachteil4GP, txtNachteil5GP, txtNachteil6GP, txtNachteil7GP, txtNachteil8GP, txtNachteil9GP, txtNachteil10GP, txtNachteil11GP, txtNachteil12GP, txtNachteil13GP, txtNachteil14GP, txtNachteil15GP };
            featureAdvantagesValueBox = new List<TextBox> { txtVorteil1Wert, txtVorteil2Wert, txtVorteil3Wert, txtVorteil4Wert, txtVorteil5Wert, txtVorteil6Wert, txtVorteil7Wert, txtVorteil8Wert, txtVorteil9Wert, txtVorteil10Wert, txtVorteil11Wert, txtVorteil12Wert, txtVorteil13Wert, txtVorteil14Wert, txtVorteil15Wert };
            featureDisAdvantagesValueBox = new List<TextBox> { txtNachteil1Wert, txtNachteil2Wert, txtNachteil3Wert, txtNachteil4Wert, txtNachteil5Wert, txtNachteil6Wert, txtNachteil7Wert, txtNachteil8Wert, txtNachteil9Wert, txtNachteil10Wert, txtNachteil11Wert, txtNachteil12Wert, txtNachteil13Wert, txtNachteil14Wert, txtNachteil15Wert };

            for (int i = 0; i < featureAdvantagesNameBox.Count; i++)
            {
                featureAdvantagesNameBox[i].Tag = featureAdvantagesDescriptionBox[i].Tag = featureAdvantagesGPBox[i].Tag = featureAdvantagesValueBox[i].Tag = new HeroPageFeatureTag(DSA_FEATURES.VORTEIL, i + 1);
                featureDisdvantagesNameBox[i].Tag = featureDisAdvantagesDescriptionBox[i].Tag = featureDisAdvantagesGPBox[i].Tag = featureDisAdvantagesValueBox[i].Tag = new HeroPageFeatureTag(DSA_FEATURES.NACHTEIL, i + 1);

                featureAdvantagesNameBox[i].Click += new EventHandler(txtFeatureBox_Clicked);
                featureAdvantagesDescriptionBox[i].Click += new EventHandler(txtFeatureBox_Clicked);
                featureAdvantagesGPBox[i].Click += new EventHandler(txtFeatureBox_Clicked);
                featureAdvantagesValueBox[i].Click += new EventHandler(txtFeatureBox_Clicked);

                featureDisdvantagesNameBox[i].Click += new EventHandler(txtFeatureBox_Clicked);
                featureDisAdvantagesDescriptionBox[i].Click += new EventHandler(txtFeatureBox_Clicked);
                featureDisAdvantagesGPBox[i].Click += new EventHandler(txtFeatureBox_Clicked);
                featureDisAdvantagesValueBox[i].Click += new EventHandler(txtFeatureBox_Clicked);
            }
        }
        private void txtFeatureBox_Clicked(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            HeroPageFeatureTag s = (HeroPageFeatureTag)box.Tag;

            CreateFeature(s.number, s.type);
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
        private void loadFeature()
        {
            for (int i = 0; i < HeroPageSupportedAdvantagesDisadvantagesBoxes; i++)
            {
                LoadFeature(featureAdvantagesNameBox[i], featureAdvantagesDescriptionBox[i], featureAdvantagesValueBox[i], featureAdvantagesGPBox[i], DSA_FEATURES.VORTEIL, i + 1);
                LoadFeature(featureDisdvantagesNameBox[i], featureDisAdvantagesDescriptionBox[i], featureDisAdvantagesValueBox[i], featureDisAdvantagesGPBox[i], DSA_FEATURES.NACHTEIL, i + 1);
            }
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
        //#########################################################################################################################################################################
        //TalentPage 
        private int SUpportedTalentCOunt = 30;
        private List<Label> talentNameLabels;
        private List<GroupBox> talentGroupBoxes;
        private List<TextBox> talentProbeTextBoxs;
        private List<TextBox> talentWürfeTextBoxs;
        private List<TextBox> talentTaWTextBoxes;
        private List<TextBox> talentBeTextBoxes;
        private List<TextBox> talentBilligerTextBoxes;
        private List<TextBox> talentSpezialisierungTextBoxes;
        private List<TextBox> talentAnforderungsTextBoxes;
        private List<TextBox> talentAbleitungTextBoxes;
        private List<TextBox> talentATTextBoxes;
        private List<TextBox> talentPATextBoxes;
        private List<RadioButton> TalentPageRadioButtonsGeneralTalents;
        private List<RadioButton> TalentPageRadioButtonsFightingTalents;
        private void setUPTalentPage()
        {
            txtTalentLetterCurrentPage.Text = "1";

            talentNameLabels = new List<Label> { PTName1, PTName2, PTName3, PTName4, PTName5, PTName6, PTName7, PTName8, PTName9, PTName10, PTName11, PTName12, PTName13, PTName14, PTName15, PTName16, PTName17, PTName18, PTName19, PTName20, PTName21, PTName22, PTName23, PTName24, PTName25, PTName26, PTName27, PTName28, PTName29, PTName30 };
            talentProbeTextBoxs = new List<TextBox> { PTProbe1, PTProbe2, PTProbe3, PTProbe4, PTProbe5, PTProbe6, PTProbe7, PTProbe8, PTProbe9, PTProbe10, PTProbe11, PTProbe12, PTProbe13, PTProbe14, PTProbe15, PTProbe16, PTProbe17, PTProbe18, PTProbe19, PTProbe20, PTProbe21, PTProbe22, PTProbe23, PTProbe24, PTProbe25, PTProbe26, PTProbe27, PTProbe28, PTProbe29, PTProbe30 };
            talentWürfeTextBoxs = new List<TextBox> { PTWürfe1, PTWürfe2, PTWürfe3, PTWürfe4, PTWürfe5, PTWürfe6, PTWürfe7, PTWürfe8, PTWürfe9, PTWürfe10, PTWürfe11, PTWürfe12, PTWürfe13, PTWürfe14, PTWürfe15, PTWürfe16, PTWürfe17, PTWürfe18, PTWürfe19, PTWürfe20, PTWürfe21, PTWürfe22, PTWürfe23, PTWürfe24, PTWürfe25, PTWürfe26, PTWürfe27, PTWürfe28, PTWürfe29, PTWürfe30 };
            talentTaWTextBoxes = new List<TextBox> { PTTaw1, PTTaw2, PTTaw3, PTTaw4, PTTaw5, PTTaw6, PTTaw7, PTTaw8, PTTaw9, PTTaw10, PTTaw11, PTTaw12, PTTaw13, PTTaw14, PTTaw15, PTTaw16, PTTaw17, PTTaw18, PTTaw19, PTTaw20, PTTaw21, PTTaw22, PTTaw23, PTTaw24, PTTaw25, PTTaw26, PTTaw27, PTTaw28, PTTaw29, PTTaw30 };
            talentBeTextBoxes = new List<TextBox> { PTBe1, PTBe2, PTBe3, PTBe4, PTBe5, PTBe6, PTBe7, PTBe8, PTBe9, PTBe10, PTBe11, PTBe12, PTBe13, PTBe14, PTBe15, PTBe16, PTBe17, PTBe18, PTBe19, PTBe20, PTBe21, PTBe22, PTBe23, PTBe24, PTBe25, PTBe26, PTBe27, PTBe28, PTBe29, PTBe30 };
            talentBilligerTextBoxes = new List<TextBox> { PTBilliger1, PTBilliger2, PTBilliger3, PTBilliger4, PTBilliger5, PTBilliger6, PTBilliger7, PTBilliger8, PTBilliger9, PTBilliger10, PTBilliger11, PTBilliger12, PTBilliger13, PTBilliger14, PTBilliger15, PTBilliger16, PTBilliger17, PTBilliger18, PTBilliger19, PTBilliger20, PTBilliger21, PTBilliger22, PTBilliger23, PTBilliger24, PTBilliger25, PTBilliger26, PTBilliger27, PTBilliger28, PTBilliger29, PTBilliger30 };
            talentSpezialisierungTextBoxes = new List<TextBox> { PTSpezialisierung1, PTSpezialisierung2, PTSpezialisierung3, PTSpezialisierung4, PTSpezialisierung5, PTSpezialisierung6, PTSpezialisierung7, PTSpezialisierung8, PTSpezialisierung9, PTSpezialisierung10, PTSpezialisierung11, PTSpezialisierung12, PTSpezialisierung13, PTSpezialisierung14, PTSpezialisierung15, PTSpezialisierung16, PTSpezialisierung17, PTSpezialisierung18, PTSpezialisierung19, PTSpezialisierung20, PTSpezialisierung21, PTSpezialisierung22, PTSpezialisierung23, PTSpezialisierung24, PTSpezialisierung25, PTSpezialisierung26, PTSpezialisierung27, PTSpezialisierung28, PTSpezialisierung29, PTSpezialisierung30 };
            talentAnforderungsTextBoxes = new List<TextBox> { PTAnforderungen1, PTAnforderungen2, PTAnforderungen3, PTAnforderungen4, PTAnforderungen5, PTAnforderungen6, PTAnforderungen7, PTAnforderungen8, PTAnforderungen9, PTAnforderungen10, PTAnforderungen11, PTAnforderungen12, PTAnforderungen13, PTAnforderungen14, PTAnforderungen15, PTAnforderungen16, PTAnforderungen17, PTAnforderungen18, PTAnforderungen19, PTAnforderungen20, PTAnforderungen21, PTAnforderungen22, PTAnforderungen23, PTAnforderungen24, PTAnforderungen25, PTAnforderungen26, PTAnforderungen27, PTAnforderungen28, PTAnforderungen29, PTAnforderungen30 };
            talentAbleitungTextBoxes = new List<TextBox> { PTAbleiten1, PTAbleiten2, PTAbleiten3, PTAbleiten4, PTAbleiten5, PTAbleiten6, PTAbleiten7, PTAbleiten8, PTAbleiten9, PTAbleiten10, PTAbleiten11, PTAbleiten12, PTAbleiten13, PTAbleiten14, PTAbleiten15, PTAbleiten16, PTAbleiten17, PTAbleiten18, PTAbleiten19, PTAbleiten20, PTAbleiten21, PTAbleiten22, PTAbleiten23, PTAbleiten24, PTAbleiten25, PTAbleiten26, PTAbleiten27, PTAbleiten28, PTAbleiten29, PTAbleiten30 };
            talentATTextBoxes = new List<TextBox> { PTAT1, PTAT2, PTAT3, PTAT4, PTAT5, PTAT6, PTAT7, PTAT8, PTAT9, PTAT10, PTAT11, PTAT12, PTAT13, PTAT14, PTAT15, PTAT16, PTAT17, PTAT18, PTAT19, PTAT20, PTAT21, PTAT22, PTAT23, PTAT24, PTAT25, PTAT26, PTAT27, PTAT28, PTAT29, PTAT30 };
            talentPATextBoxes = new List<TextBox> { PTPA1, PTPA2, PTPA3, PTPA4, PTPA5, PTPA6, PTPA7, PTPA8, PTPA9, PTPA10, PTPA11, PTPA12, PTPA13, PTPA14, PTPA15, PTPA16, PTPA17, PTPA18, PTPA19, PTPA20, PTPA21, PTPA22, PTPA23, PTPA24, PTPA25, PTPA26, PTPA27, PTPA28, PTPA29, PTPA30 };
            talentGroupBoxes = new List<GroupBox> { groupBoxTalentName, groupBoxProbe, groupBoxTaW, groupBoxAnforderungen, groupBoxAbleiten, groupBoxBe, groupBoxKampf, groupBoxSpezialisierung, groupBoxBilliger };

            TalentPageRadioButtonsGeneralTalents = new List<RadioButton> { radioKörperlicheTalente, radioSozialTalente, radioNaturTalente, radioKnowldageTalente, radioCraftingTalent };
            TalentPageRadioButtonsFightingTalents = new List<RadioButton> { radioButtonWeaponless, radioButtonClose, radioButtonRange };

            radioKörperlicheTalente.Tag = DSA_GENERALTALENTS.PHYSICAL;
            radioSozialTalente.Tag = DSA_GENERALTALENTS.SOCIAL;
            radioNaturTalente.Tag = DSA_GENERALTALENTS.NATURE;
            radioKnowldageTalente.Tag = DSA_GENERALTALENTS.KNOWLDAGE;
            radioCraftingTalent.Tag = DSA_GENERALTALENTS.CRAFTING;

            radioButtonWeaponless.Tag = DSA_FIGHTINGTALENTS.WEAPONLESS;
            radioButtonClose.Tag = DSA_FIGHTINGTALENTS.CLOSE;
            radioButtonRange.Tag = DSA_FIGHTINGTALENTS.RANGE;

            btnTalentLetterNext.Tag = "+";
            btnTalentLetterLast.Tag = "-";

            btnTalentLetterNext.Click += new EventHandler(btnTalentLetterPage_Click);
            btnTalentLetterLast.Click += new EventHandler(btnTalentLetterPage_Click);

            for (int i = 0; i < TalentPageRadioButtonsGeneralTalents.Count; i++)
            {
                TalentPageRadioButtonsGeneralTalents[i].CheckedChanged += new EventHandler(TalentPageGeneralTalentRadioButtonChanged);
            }
            for (int i = 0; i < TalentPageRadioButtonsFightingTalents.Count; i++)
            {
                TalentPageRadioButtonsFightingTalents[i].CheckedChanged += new EventHandler(TalentPageFightingTalentsRadioButtonChanged);
            }
        }
        public void refreshTalentPage()
        {
            radioCraftingTalent.Checked = true;
            radioKörperlicheTalente.Checked = true;
        }
        private void setTalentBoxeZero(int number)
        {
            for (int i = number; i < SUpportedTalentCOunt; i++)
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
        private int TalentPagegetTalentNumberForBox(int boxnumber)
        {
            String page = txtTalentLetterCurrentPage.Text;
            int x = 0;
            Int32.TryParse(page, out x);

            return (x - 1) * SUpportedTalentCOunt + (boxnumber - 1);
        }
        private InterfaceTalent getTalent(int number)
        {
            InterfaceTalent talent = null;

            for (int i = 0; i < TalentPageRadioButtonsGeneralTalents.Count; i++)
            {
                if (TalentPageRadioButtonsGeneralTalents[i].Checked)
                {
                    DSA_GENERALTALENTS talenttype = (DSA_GENERALTALENTS)TalentPageRadioButtonsGeneralTalents[i].Tag;
                    talent = controll.getTalent(talenttype, number);
                    return talent;
                }
            }

            for (int i = 0; i < TalentPageRadioButtonsFightingTalents.Count; i++)
            {
                if (TalentPageRadioButtonsFightingTalents[i].Checked)
                {
                    DSA_FIGHTINGTALENTS talenttype = (DSA_FIGHTINGTALENTS)TalentPageRadioButtonsFightingTalents[i].Tag;
                    talent = controll.getTalent(talenttype, number);
                    return talent;
                }
            }
            return talent;
        }
        private void btnTalentLetterPage_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            String page = txtTalentLetterCurrentPage.Text;

            int x;
            Int32.TryParse(page, out x);

            if (0 == String.Compare((String)btn.Tag, "+"))
            {
                x++;
            }
            else
            if (0 == String.Compare((String)btn.Tag, "-"))
            {
                if ((x - 1) > 0)
                {
                    x--;
                }
            }
            txtTalentLetterCurrentPage.Text = x.ToString();

            List<RadioButton> rButtonsTotal = new List<RadioButton>();
            rButtonsTotal.AddRange(TalentPageRadioButtonsGeneralTalents);
            rButtonsTotal.AddRange(TalentPageRadioButtonsFightingTalents);

            for (int i = 0; i < rButtonsTotal.Count; i++)
            {
                if (rButtonsTotal[i].Checked == true)
                {
                    rButtonsTotal[i].Checked = false;
                    rButtonsTotal[i].Checked = true;
                    break;
                }
            }
        }
        private void TalentPageGeneralTalentRadioButtonChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;

            DSA_GENERALTALENTS type = (DSA_GENERALTALENTS)button.Tag;

            int i = 0;
            groupBoxAnforderungen.Visible = true;
            groupBoxKampf.Visible = false;

            for (i = 0; i < SUpportedTalentCOunt; i++)
            {
                GeneralTalent GeneralTalent = (GeneralTalent)controll.getTalent(type, TalentPagegetTalentNumberForBox(i + 1));
                if (GeneralTalent == null) { break; }
                talentNameLabels[i].Text = GeneralTalent.getName();
                talentProbeTextBoxs[i].Text = GeneralTalent.getProbeStringOne();
                talentWürfeTextBoxs[i].Text = GeneralTalent.getProbeStringTwo();
                talentTaWTextBoxes[i].Text = GeneralTalent.getTaW().ToString();
                talentBeTextBoxes[i].Text = GeneralTalent.getBe().ToString();
                talentSpezialisierungTextBoxes[i].Text = "";
                talentAbleitungTextBoxes[i].Text = GeneralTalent.getAbleitenString();
                talentAnforderungsTextBoxes[i].Text = GeneralTalent.getRequirementString();
            }

            groupBoxProbe.Left = groupBoxTalentName.Right + 5;
            groupBoxTaW.Left = groupBoxProbe.Right + 5;
            groupBoxBe.Left = groupBoxTaW.Right + 5;
            groupBoxBilliger.Left = groupBoxBe.Right + 5;
            groupBoxSpezialisierung.Left = groupBoxBilliger.Right + 5;
            groupBoxAnforderungen.Left = groupBoxSpezialisierung.Right + 5;
            groupBoxAbleiten.Left = groupBoxAnforderungen.Right + 5;

            setTalentBoxeZero(i);
            return;
        }
        private void TalentPageFightingTalentsRadioButtonChanged(object sender, EventArgs e)
        {
            int i = 0;
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;

            DSA_FIGHTINGTALENTS type = (DSA_FIGHTINGTALENTS)button.Tag;

            groupBoxAnforderungen.Visible = false;
            groupBoxKampf.Visible = true;

            for (i = 0; i < SUpportedTalentCOunt; i++)
            {
                int x = 0;
                FightTalent FightingTalent = (FightTalent)controll.getTalent(type, TalentPagegetTalentNumberForBox(i + 1));
                if (FightingTalent == null) { break; }
                talentNameLabels[i].Text = FightingTalent.getName();
                talentProbeTextBoxs[i].Text = FightingTalent.getProbeStringOne();
                talentWürfeTextBoxs[i].Text = FightingTalent.getProbeStringTwo();
                talentTaWTextBoxes[i].Text = FightingTalent.getTaW().ToString();
                talentBeTextBoxes[i].Text = FightingTalent.getBe().ToString();
                talentSpezialisierungTextBoxes[i].Text = "";
                talentAbleitungTextBoxes[i].Text = FightingTalent.getAbleitenString();
                talentATTextBoxes[i].Text = FightingTalent.getAT().ToString();
                talentPATextBoxes[i].Text = FightingTalent.getPA().ToString();

                if (!Int32.TryParse(FightingTalent.getPA(), out x))
                {
                    talentWürfeTextBoxs[i].Text = FightingTalent.getPA();
                }

            }
            groupBoxProbe.Left = groupBoxTalentName.Right + 5;
            groupBoxTaW.Left = groupBoxProbe.Right + 5;
            groupBoxKampf.Left = groupBoxTaW.Right + 5;
            groupBoxBe.Left = groupBoxKampf.Right + 5;
            groupBoxBilliger.Left = groupBoxBe.Right + 5;
            groupBoxSpezialisierung.Left = groupBoxBilliger.Right + 5;
            groupBoxAbleiten.Left = groupBoxSpezialisierung.Right + 5;

            setTalentBoxeZero(i);
            return;
        }
        private void TAWChange(object sender, EventArgs e)
        {
            int BoxNumber;
            TextBox box = (TextBox)sender;
            String BasicString = "PTTaw";
            String NameString = box.Name;
            String number = NameString.Substring(BasicString.Length, NameString.Length - BasicString.Length);
            Int32.TryParse(number, out BoxNumber);

            InterfaceTalent talent = getTalent(TalentPagegetTalentNumberForBox(BoxNumber));

            if (talent == null) return;

            talent.setTaw(box.Text);
            box.Text = talent.getTaW().ToString();
            talentProbeTextBoxs[BoxNumber - 1].Text = talent.getProbeStringOne();
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

            FightTalent talent = (FightTalent)getTalent(TalentPagegetTalentNumberForBox(BoxNumber));
            if (talent == null) return;

            int result;
            Int32.TryParse(box.Text, out result);

            talent.setAT(result);
            box.Text = talent.getAT().ToString();

            talentProbeTextBoxs[BoxNumber - 1].Text = talent.getProbeStringOne();
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

            FightTalent talent = (FightTalent)getTalent(TalentPagegetTalentNumberForBox(BoxNumber));
            if (talent == null) return;

            int result;
            Int32.TryParse(box.Text, out result);

            talent.setPA(result);
            box.Text = talent.getPA().ToString();

            talentWürfeTextBoxs[BoxNumber - 1].Text = talent.getProbeStringTwo();
        }
        //#########################################################################################################################################################################
        //RewardPage 
        private int supportedRewardBoxes = 25;
        private List<TextBox> rewardNameBoxes;
        private List<TextBox> rewadDescriptionBoxes;
        private void setUPRewards()
        {
            rewardNameBoxes = new List<TextBox> { txtReward1, txtReward2, txtReward3, txtReward4, txtReward5, txtReward6, txtReward7, txtReward8, txtReward9, txtReward10, txtReward11, txtReward12, txtReward13, txtReward14, txtReward15, txtReward16, txtReward17, txtReward18, txtReward19, txtReward20, txtReward21, txtReward22, txtReward23, txtReward24, txtReward25 };
            rewadDescriptionBoxes = new List<TextBox> { txtRewardDescription1, txtRewardDescription2, txtRewardDescription3, txtRewardDescription4, txtRewardDescription5, txtRewardDescription6, txtRewardDescription7, txtRewardDescription8, txtRewardDescription9, txtRewardDescription10, txtRewardDescription11, txtRewardDescription12, txtRewardDescription13, txtRewardDescription14, txtRewardDescription15, txtRewardDescription16, txtRewardDescription17, txtRewardDescription18, txtRewardDescription19, txtRewardDescription20, txtRewardDescription21, txtRewardDescription22, txtRewardDescription23, txtRewardDescription24, txtRewardDescription25 };

            for (int i = 0; i < rewardNameBoxes.Count; i++)
            {
                rewardNameBoxes[i].Click += new EventHandler(setReward_DiscriptionBox);
            }

            txtRewardPage.Text = "1";
        }
        private void CreateReward(int rewardNumber, int boxNumber, DSA_FEATURES type)
        {
            Feature feature = controll.Feature(rewardNumber, type);

            if (feature == null) return;

            rewardNameBoxes[boxNumber].Text = feature.getName();
            rewadDescriptionBoxes[boxNumber].Text = feature.getDescription();

            this.refreshHeroPage();

        }
        private void loadRewards()
        {
            int page = 0;
            Int32.TryParse(txtRewardPage.Text, out page);

            int number = (SUpportedTalentCOunt * page);

            for (int i = 0; i < supportedRewardBoxes; i++)
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
        //#########################################################################################################################################################################
    }
}
