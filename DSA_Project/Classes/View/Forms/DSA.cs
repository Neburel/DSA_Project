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
        ControllClass controll;
        DSA_TALENTS lastUsedTalentType;

        public DSA()
        {
            controll = new ControllClass(this);
            InitializeComponent();

            load();
            refreshHeroPage();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);

            groupBoxTalentName.AutoSize = true;
            groupBoxTalentName.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBoxProbe.AutoSize = true;
            groupBoxProbe.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBoxTaW.AutoSize = true;
            groupBoxTaW.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBoxBilliger.AutoSize = true;
            groupBoxBilliger.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBoxBe.AutoSize = true;
            groupBoxBe.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBoxAbleiten.AutoSize = true;
            groupBoxAbleiten.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBoxAnforderungen.AutoSize = true;
            groupBoxAnforderungen.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBoxSpezialisierung.AutoSize = true;
            groupBoxSpezialisierung.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            groupBoxKampf.AutoSize = true;
            groupBoxKampf.AutoSizeMode = AutoSizeMode.GrowAndShrink;
        }
        private void setUPGeneralTalent(DSA_TALENTS type)
        {
            lastUsedTalentType = type;
            setUPTalentRowGeneral(1, controll.getTalent(type, 1), PTName1, PTProbe1, PTWürfe1, PTBe1, PTTaw1, PTBilliger1, PTSpezialisierung1, PTAnforderungen1, PTAbleiten1);
            setUPTalentRowGeneral(2, controll.getTalent(type, 2), PTName2, PTProbe2, PTWürfe2, PTBe2, PTTaw2, PTBilliger2, PTSpezialisierung2, PTAnforderungen2, PTAbleiten2);
            setUPTalentRowGeneral(3, controll.getTalent(type, 3), PTName3, PTProbe3, PTWürfe3, PTBe3, PTTaw3, PTBilliger3, PTSpezialisierung3, PTAnforderungen3, PTAbleiten3);
            setUPTalentRowGeneral(4, controll.getTalent(type, 4), PTName4, PTProbe4, PTWürfe4, PTBe4, PTTaw4, PTBilliger4, PTSpezialisierung4, PTAnforderungen4, PTAbleiten4);
            setUPTalentRowGeneral(5, controll.getTalent(type, 5), PTName5, PTProbe5, PTWürfe5, PTBe5, PTTaw5, PTBilliger5, PTSpezialisierung5, PTAnforderungen5, PTAbleiten5);
            setUPTalentRowGeneral(6, controll.getTalent(type, 6), PTName6, PTProbe6, PTWürfe6, PTBe6, PTTaw6, PTBilliger6, PTSpezialisierung6, PTAnforderungen6, PTAbleiten6);
            setUPTalentRowGeneral(7, controll.getTalent(type, 7), PTName7, PTProbe7, PTWürfe7, PTBe7, PTTaw7, PTBilliger7, PTSpezialisierung7, PTAnforderungen7, PTAbleiten7);
            setUPTalentRowGeneral(8, controll.getTalent(type, 8), PTName8, PTProbe8, PTWürfe8, PTBe8, PTTaw8, PTBilliger8, PTSpezialisierung8, PTAnforderungen8, PTAbleiten8);
            setUPTalentRowGeneral(9, controll.getTalent(type, 9), PTName9, PTProbe9, PTWürfe9, PTBe9, PTTaw9, PTBilliger9, PTSpezialisierung9, PTAnforderungen9, PTAbleiten9);
            setUPTalentRowGeneral(10, controll.getTalent(type, 10), PTName10, PTProbe10, PTWürfe10, PTBe10, PTTaw10, PTBilliger10, PTSpezialisierung10, PTAnforderungen10, PTAbleiten10);
            setUPTalentRowGeneral(11, controll.getTalent(type, 11), PTName11, PTProbe11, PTWürfe11, PTBe11, PTTaw11, PTBilliger11, PTSpezialisierung11, PTAnforderungen11, PTAbleiten11);
            setUPTalentRowGeneral(12, controll.getTalent(type, 12), PTName12, PTProbe12, PTWürfe12, PTBe12, PTTaw12, PTBilliger12, PTSpezialisierung12, PTAnforderungen12, PTAbleiten12);
            setUPTalentRowGeneral(13, controll.getTalent(type, 13), PTName13, PTProbe13, PTWürfe13, PTBe13, PTTaw13, PTBilliger13, PTSpezialisierung13, PTAnforderungen13, PTAbleiten13);
            setUPTalentRowGeneral(14, controll.getTalent(type, 14), PTName14, PTProbe14, PTWürfe14, PTBe14, PTTaw14, PTBilliger14, PTSpezialisierung14, PTAnforderungen14, PTAbleiten14);
            setUPTalentRowGeneral(15, controll.getTalent(type, 15), PTName15, PTProbe15, PTWürfe15, PTBe15, PTTaw15, PTBilliger15, PTSpezialisierung15, PTAnforderungen15, PTAbleiten15);
            setUPTalentRowGeneral(16, controll.getTalent(type, 16), PTName16, PTProbe16, PTWürfe16, PTBe16, PTTaw16, PTBilliger16, PTSpezialisierung16, PTAnforderungen16, PTAbleiten16);
            setUPTalentRowGeneral(17, controll.getTalent(type, 17), PTName17, PTProbe17, PTWürfe17, PTBe17, PTTaw17, PTBilliger17, PTSpezialisierung17, PTAnforderungen17, PTAbleiten17);
            setUPTalentRowGeneral(18, controll.getTalent(type, 18), PTName18, PTProbe18, PTWürfe18, PTBe18, PTTaw18, PTBilliger18, PTSpezialisierung18, PTAnforderungen18, PTAbleiten18);
            setUPTalentRowGeneral(19, controll.getTalent(type, 19), PTName19, PTProbe19, PTWürfe19, PTBe19, PTTaw19, PTBilliger19, PTSpezialisierung19, PTAnforderungen19, PTAbleiten19);
            setUPTalentRowGeneral(20, controll.getTalent(type, 20), PTName20, PTProbe20, PTWürfe20, PTBe20, PTTaw20, PTBilliger20, PTSpezialisierung20, PTAnforderungen20, PTAbleiten20);
            setUPTalentRowGeneral(21, controll.getTalent(type, 21), PTName21, PTProbe21, PTWürfe21, PTBe21, PTTaw21, PTBilliger21, PTSpezialisierung21, PTAnforderungen21, PTAbleiten21);
            setUPTalentRowGeneral(22, controll.getTalent(type, 22), PTName22, PTProbe22, PTWürfe22, PTBe22, PTTaw22, PTBilliger22, PTSpezialisierung22, PTAnforderungen22, PTAbleiten22);
            setUPTalentRowGeneral(23, controll.getTalent(type, 23), PTName23, PTProbe23, PTWürfe23, PTBe23, PTTaw23, PTBilliger23, PTSpezialisierung23, PTAnforderungen23, PTAbleiten23);
            setUPTalentRowGeneral(24, controll.getTalent(type, 24), PTName24, PTProbe24, PTWürfe24, PTBe24, PTTaw24, PTBilliger24, PTSpezialisierung24, PTAnforderungen24, PTAbleiten24);
            setUPTalentRowGeneral(25, controll.getTalent(type, 25), PTName25, PTProbe25, PTWürfe25, PTBe25, PTTaw25, PTBilliger25, PTSpezialisierung25, PTAnforderungen25, PTAbleiten25);
            setUPTalentRowGeneral(26, controll.getTalent(type, 26), PTName26, PTProbe26, PTWürfe26, PTBe26, PTTaw26, PTBilliger26, PTSpezialisierung26, PTAnforderungen26, PTAbleiten26);
            setUPTalentRowGeneral(27, controll.getTalent(type, 27), PTName27, PTProbe27, PTWürfe27, PTBe27, PTTaw27, PTBilliger27, PTSpezialisierung27, PTAnforderungen27, PTAbleiten27);
            setUPTalentRowGeneral(28, controll.getTalent(type, 28), PTName28, PTProbe28, PTWürfe28, PTBe28, PTTaw28, PTBilliger28, PTSpezialisierung28, PTAnforderungen28, PTAbleiten28);
            setUPTalentRowGeneral(29, controll.getTalent(type, 29), PTName29, PTProbe29, PTWürfe29, PTBe29, PTTaw29, PTBilliger29, PTSpezialisierung29, PTAnforderungen29, PTAbleiten29);
            setUPTalentRowGeneral(30, controll.getTalent(type, 30), PTName30, PTProbe30, PTWürfe30, PTBe30, PTTaw30, PTBilliger30, PTSpezialisierung30, PTAnforderungen30, PTAbleiten30);

            groupBoxKampf.Visible = false;

            groupBoxProbe.Left = groupBoxTalentName.Right + 5;
            groupBoxTaW.Left = groupBoxProbe.Right + 5;
            groupBoxBilliger.Left = groupBoxTaW.Right + 5;
            groupBoxBe.Left = groupBoxBilliger.Right + 5;
            groupBoxAbleiten.Left = groupBoxBe.Right + 5;
            groupBoxAnforderungen.Left = groupBoxAbleiten.Right + 5;
            groupBoxSpezialisierung.Left = groupBoxAnforderungen.Right + 5;
        }
        private void setUPFightingTalent(DSA_TALENTS type)
        {
            lastUsedTalentType = type;
            setUPTalentRowFighting(1, controll.getTalent(type, 1), PTName1, PTProbe1, PTWürfe1, PTBe1, PTTaw1, PTBilliger1, PTSpezialisierung1, PTAnforderungen1, PTAbleiten1, PTAT1, PTPA1);
            setUPTalentRowFighting(2, controll.getTalent(type, 2), PTName2, PTProbe2, PTWürfe2, PTBe2, PTTaw2, PTBilliger2, PTSpezialisierung2, PTAnforderungen2, PTAbleiten2, PTAT2, PTPA2);
            setUPTalentRowFighting(3, controll.getTalent(type, 3), PTName3, PTProbe3, PTWürfe3, PTBe3, PTTaw3, PTBilliger3, PTSpezialisierung3, PTAnforderungen3, PTAbleiten3, PTAT3, PTPA3);
            setUPTalentRowFighting(4, controll.getTalent(type, 4), PTName4, PTProbe4, PTWürfe4, PTBe4, PTTaw4, PTBilliger4, PTSpezialisierung4, PTAnforderungen4, PTAbleiten4, PTAT4, PTPA4);
            setUPTalentRowFighting(5, controll.getTalent(type, 5), PTName5, PTProbe5, PTWürfe5, PTBe5, PTTaw5, PTBilliger5, PTSpezialisierung5, PTAnforderungen5, PTAbleiten5, PTAT5, PTPA5);
            setUPTalentRowFighting(6, controll.getTalent(type, 6), PTName6, PTProbe6, PTWürfe6, PTBe6, PTTaw6, PTBilliger6, PTSpezialisierung6, PTAnforderungen6, PTAbleiten6, PTAT6, PTPA6);
            setUPTalentRowFighting(7, controll.getTalent(type, 7), PTName7, PTProbe7, PTWürfe7, PTBe7, PTTaw7, PTBilliger7, PTSpezialisierung7, PTAnforderungen7, PTAbleiten7, PTAT7, PTPA7);
            setUPTalentRowFighting(8, controll.getTalent(type, 8), PTName8, PTProbe8, PTWürfe8, PTBe8, PTTaw8, PTBilliger8, PTSpezialisierung8, PTAnforderungen8, PTAbleiten8, PTAT8, PTPA8);
            setUPTalentRowFighting(9, controll.getTalent(type, 9), PTName9, PTProbe9, PTWürfe9, PTBe9, PTTaw9, PTBilliger9, PTSpezialisierung9, PTAnforderungen9, PTAbleiten9, PTAT9, PTPA9);
            setUPTalentRowFighting(10, controll.getTalent(type, 10), PTName10, PTProbe10, PTWürfe10, PTBe10, PTTaw10, PTBilliger10, PTSpezialisierung10, PTAnforderungen10, PTAbleiten10, PTAT10, PTPA10);
            setUPTalentRowFighting(11, controll.getTalent(type, 11), PTName11, PTProbe11, PTWürfe11, PTBe11, PTTaw11, PTBilliger11, PTSpezialisierung11, PTAnforderungen11, PTAbleiten11, PTAT11, PTPA11);
            setUPTalentRowFighting(12, controll.getTalent(type, 12), PTName12, PTProbe12, PTWürfe12, PTBe12, PTTaw12, PTBilliger12, PTSpezialisierung12, PTAnforderungen12, PTAbleiten12, PTAT12, PTPA12);
            setUPTalentRowFighting(13, controll.getTalent(type, 13), PTName13, PTProbe13, PTWürfe13, PTBe13, PTTaw13, PTBilliger13, PTSpezialisierung13, PTAnforderungen13, PTAbleiten13, PTAT13, PTPA13);
            setUPTalentRowFighting(14, controll.getTalent(type, 14), PTName14, PTProbe14, PTWürfe14, PTBe14, PTTaw14, PTBilliger14, PTSpezialisierung14, PTAnforderungen14, PTAbleiten14, PTAT14, PTPA14);
            setUPTalentRowFighting(15, controll.getTalent(type, 15), PTName15, PTProbe15, PTWürfe15, PTBe15, PTTaw15, PTBilliger15, PTSpezialisierung15, PTAnforderungen15, PTAbleiten15, PTAT15, PTPA15);
            setUPTalentRowFighting(16, controll.getTalent(type, 16), PTName16, PTProbe16, PTWürfe16, PTBe16, PTTaw16, PTBilliger16, PTSpezialisierung16, PTAnforderungen16, PTAbleiten16, PTAT16, PTPA16);
            setUPTalentRowFighting(17, controll.getTalent(type, 17), PTName17, PTProbe17, PTWürfe17, PTBe17, PTTaw17, PTBilliger17, PTSpezialisierung17, PTAnforderungen17, PTAbleiten17, PTAT17, PTPA17);
            setUPTalentRowFighting(18, controll.getTalent(type, 18), PTName18, PTProbe18, PTWürfe18, PTBe18, PTTaw18, PTBilliger18, PTSpezialisierung18, PTAnforderungen18, PTAbleiten18, PTAT18, PTPA18);
            setUPTalentRowFighting(19, controll.getTalent(type, 19), PTName19, PTProbe19, PTWürfe19, PTBe19, PTTaw19, PTBilliger19, PTSpezialisierung19, PTAnforderungen19, PTAbleiten19, PTAT19, PTPA19);
            setUPTalentRowFighting(20, controll.getTalent(type, 20), PTName20, PTProbe20, PTWürfe20, PTBe20, PTTaw20, PTBilliger20, PTSpezialisierung20, PTAnforderungen20, PTAbleiten20, PTAT20, PTPA20);
            setUPTalentRowFighting(21, controll.getTalent(type, 21), PTName21, PTProbe21, PTWürfe21, PTBe21, PTTaw21, PTBilliger21, PTSpezialisierung21, PTAnforderungen21, PTAbleiten21, PTAT21, PTPA21);
            setUPTalentRowFighting(22, controll.getTalent(type, 22), PTName22, PTProbe22, PTWürfe22, PTBe22, PTTaw22, PTBilliger22, PTSpezialisierung22, PTAnforderungen22, PTAbleiten22, PTAT22, PTPA22);
            setUPTalentRowFighting(23, controll.getTalent(type, 23), PTName23, PTProbe23, PTWürfe23, PTBe23, PTTaw23, PTBilliger23, PTSpezialisierung23, PTAnforderungen23, PTAbleiten23, PTAT23, PTPA23);
            setUPTalentRowFighting(24, controll.getTalent(type, 24), PTName24, PTProbe24, PTWürfe24, PTBe24, PTTaw24, PTBilliger24, PTSpezialisierung24, PTAnforderungen24, PTAbleiten24, PTAT24, PTPA24);
            setUPTalentRowFighting(25, controll.getTalent(type, 25), PTName25, PTProbe25, PTWürfe25, PTBe25, PTTaw25, PTBilliger25, PTSpezialisierung25, PTAnforderungen25, PTAbleiten25, PTAT25, PTPA25);
            setUPTalentRowFighting(26, controll.getTalent(type, 26), PTName26, PTProbe26, PTWürfe26, PTBe26, PTTaw26, PTBilliger26, PTSpezialisierung26, PTAnforderungen26, PTAbleiten26, PTAT26, PTPA26);
            setUPTalentRowFighting(27, controll.getTalent(type, 27), PTName27, PTProbe27, PTWürfe27, PTBe27, PTTaw27, PTBilliger27, PTSpezialisierung27, PTAnforderungen27, PTAbleiten27, PTAT27, PTPA27);
            setUPTalentRowFighting(28, controll.getTalent(type, 28), PTName28, PTProbe28, PTWürfe28, PTBe28, PTTaw28, PTBilliger28, PTSpezialisierung28, PTAnforderungen28, PTAbleiten28, PTAT28, PTPA28);
            setUPTalentRowFighting(29, controll.getTalent(type, 29), PTName29, PTProbe29, PTWürfe29, PTBe29, PTTaw29, PTBilliger29, PTSpezialisierung29, PTAnforderungen29, PTAbleiten29, PTAT29, PTPA29);
            setUPTalentRowFighting(30, controll.getTalent(type, 30), PTName30, PTProbe30, PTWürfe30, PTBe30, PTTaw30, PTBilliger30, PTSpezialisierung30, PTAnforderungen30, PTAbleiten30, PTAT30, PTPA30);

            groupBoxKampf.Visible = true;

            groupBoxProbe.Left = groupBoxTalentName.Right + 5;
            groupBoxTaW.Left = groupBoxProbe.Right + 5;
            groupBoxKampf.Left = groupBoxTaW.Right + 5;
            groupBoxBe.Left = groupBoxKampf.Right + 5;
            groupBoxBilliger.Left = groupBoxBe.Right + 5;
            groupBoxSpezialisierung.Left = groupBoxBilliger.Right + 5;
            groupBoxAbleiten.Left = groupBoxSpezialisierung.Right + 5;
        }
        private void setUPTalentRowGeneral(int number, InterfaceTalent talent, Label Name, TextBox Probe, TextBox wurfProbe, TextBox Be, TextBox Taw, TextBox Billiger, TextBox Spezialisierung, TextBox Anforderungen, TextBox Ableiten)
        {
            Boolean visible = false;
            if (talent == null)
            {
                visible = false;
            }
            else
            {
                GeneralTalent Talent = (GeneralTalent)talent;
                visible = true;
                Name.Text = Talent.getName();
                Probe.Text = Talent.getProbeStringOne().ToString();
                Taw.Text = Talent.getTaW().ToString();
                Be.Text = Talent.getBe().ToString();
                Billiger.Text = "";
                Spezialisierung.Text = "";
                Anforderungen.Text = Talent.getAnforderungen();
                Ableiten.Text = Talent.getAbleitenString();
                wurfProbe.Text = Talent.getProbeStringOne();
            }
            Name.Visible = visible;
            Probe.Visible = visible;
            Taw.Visible = visible;
            Be.Visible = visible;
            Billiger.Visible = visible;
            Spezialisierung.Visible = visible;
            Anforderungen.Visible = visible;
            wurfProbe.Visible = visible;
            Ableiten.Visible = visible;
        }
        private void setUPTalentRowFighting(int number, InterfaceTalent talent, Label Name, TextBox ProbeAT, TextBox ProbePA, TextBox Be, TextBox Taw, TextBox Billiger, TextBox Spezialisierung, TextBox Anforderungen, TextBox Ableiten, TextBox AT, TextBox PA)
        {
            Boolean visible = false;
            if (talent == null)
            {
                visible = false;
            }
            else
            {
                visible                 = true;
                FightTalent Talent      = (FightTalent)talent;

                Name.Text               = Talent.getName();
                Taw.Text                = Talent.getTaW().ToString();
                ProbeAT.Text            = Talent.getProbeValueAT().ToString();
                ProbePA.Text            = Talent.getProbeValuePA().ToString();                          
                Be.Text                 = Talent.getBe().ToString();
                Billiger.Text           = "";
                Spezialisierung.Text    = "";
                Ableiten.Text           = Talent.getAbleitenString();

                AT.Text                 = Talent.getAT().ToString();
                PA.Text                 = Talent.getPA().ToString();
            }

            Name.Visible = visible;
            ProbeAT.Visible = visible;
            Taw.Visible = visible;
            Be.Visible = visible;
            Billiger.Visible = visible;
            Spezialisierung.Visible = visible;
            Anforderungen.Visible = visible;
            ProbePA.Visible = visible;
            Ableiten.Visible = visible;
            AT.Visible = visible;
            PA.Visible = visible;
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
        }
        public void refreshTalentProbeBox(DSA_TALENTS type)
        {
            PTProbe1.Text = refreshTalentProbe(type, 1);
            PTProbe2.Text = refreshTalentProbe(type, 2);
            PTProbe3.Text = refreshTalentProbe(type, 3);
            PTProbe4.Text = refreshTalentProbe(type, 4);
            PTProbe5.Text = refreshTalentProbe(type, 5);
            PTProbe6.Text = refreshTalentProbe(type, 6);
            PTProbe7.Text = refreshTalentProbe(type, 7);
            PTProbe8.Text = refreshTalentProbe(type, 8);
            PTProbe9.Text = refreshTalentProbe(type, 9);
            PTProbe10.Text = refreshTalentProbe(type, 10);
            PTProbe11.Text = refreshTalentProbe(type, 11);
            PTProbe12.Text = refreshTalentProbe(type, 12);
            PTProbe13.Text = refreshTalentProbe(type, 13);
            PTProbe14.Text = refreshTalentProbe(type, 14);
            PTProbe15.Text = refreshTalentProbe(type, 15);
            PTProbe16.Text = refreshTalentProbe(type, 16);
            PTProbe17.Text = refreshTalentProbe(type, 17);
            PTProbe18.Text = refreshTalentProbe(type, 18);
            PTProbe19.Text = refreshTalentProbe(type, 19);
            PTProbe20.Text = refreshTalentProbe(type, 20);
            PTProbe21.Text = refreshTalentProbe(type, 21);
            PTProbe22.Text = refreshTalentProbe(type, 22);
            PTProbe23.Text = refreshTalentProbe(type, 23);
            PTProbe24.Text = refreshTalentProbe(type, 24);
            PTProbe25.Text = refreshTalentProbe(type, 25);
            PTProbe26.Text = refreshTalentProbe(type, 26);
            PTProbe27.Text = refreshTalentProbe(type, 27);
            PTProbe28.Text = refreshTalentProbe(type, 28);
            PTProbe29.Text = refreshTalentProbe(type, 29);
            PTProbe30.Text = refreshTalentProbe(type, 30);
        }
        public void refreshTalentProbeWürfeText(DSA_TALENTS type)
        {
            PTWürfe1.Text = refreshTalentWürfe(type, 1);
            PTWürfe2.Text = refreshTalentWürfe(type, 2);
            PTWürfe3.Text = refreshTalentWürfe(type, 3);
            PTWürfe4.Text = refreshTalentWürfe(type, 4);
            PTWürfe5.Text = refreshTalentWürfe(type, 5);
            PTWürfe6.Text = refreshTalentWürfe(type, 6);
            PTWürfe7.Text = refreshTalentWürfe(type, 7);
            PTWürfe8.Text = refreshTalentWürfe(type, 8);
            PTWürfe9.Text = refreshTalentWürfe(type, 9);
            PTWürfe10.Text = refreshTalentWürfe(type, 10);
            PTWürfe11.Text = refreshTalentWürfe(type, 11);
            PTWürfe12.Text = refreshTalentWürfe(type, 12);
            PTWürfe13.Text = refreshTalentWürfe(type, 13);
            PTWürfe14.Text = refreshTalentWürfe(type, 14);
            PTWürfe15.Text = refreshTalentWürfe(type, 15);
            PTWürfe16.Text = refreshTalentWürfe(type, 16);
            PTWürfe17.Text = refreshTalentWürfe(type, 17);
            PTWürfe18.Text = refreshTalentWürfe(type, 18);
            PTWürfe19.Text = refreshTalentWürfe(type, 19);
            PTWürfe20.Text = refreshTalentWürfe(type, 20);
            PTWürfe21.Text = refreshTalentWürfe(type, 21);
            PTWürfe22.Text = refreshTalentWürfe(type, 22);
            PTWürfe23.Text = refreshTalentWürfe(type, 23);
            PTWürfe24.Text = refreshTalentWürfe(type, 24);
            PTWürfe25.Text = refreshTalentWürfe(type, 25);
            PTWürfe26.Text = refreshTalentWürfe(type, 26);
            PTWürfe27.Text = refreshTalentWürfe(type, 27);
            PTWürfe28.Text = refreshTalentWürfe(type, 28);
            PTWürfe29.Text = refreshTalentWürfe(type, 29);
            PTWürfe30.Text = refreshTalentWürfe(type, 30);
        }
        private String refreshTalentProbe(DSA_TALENTS type, int number)
        {
            InterfaceTalent talent = controll.getTalent(type, number);
            if (talent == null)
            {
                return "";
            }
            return talent.getProbeStringOne().ToString();
        }
        private String refreshTalentWürfe(DSA_TALENTS type, int number)
        {
            InterfaceTalent talent = controll.getTalent(type, number);
            if (talent == null)
            {
                return "";
            }
            return talent.getProbeStringTwo();
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


        private void TAWChange(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            String BasicString = "PTTaw";
            String NameString = box.Name;
            String number = NameString.Substring(BasicString.Length, NameString.Length - BasicString.Length);

            InterfaceTalent talent = controll.getTalent(lastUsedTalentType, number);

            if (talent != null)
            {
                String Substring = box.Text;
                if (String.Equals(Substring, "-"))
                {
                    return;
                }

                talent.setTaw(box.Text);
                box.Text = talent.getTaW().ToString();
            }
            this.refreshTalentProbeBox(lastUsedTalentType);
        }
        private void ATChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Visible == false) return;

            String BasicString = "PTAT";
            String NameString = box.Name;
            String number = NameString.Substring(BasicString.Length, NameString.Length - BasicString.Length);
            FightTalent talent = (FightTalent)controll.getTalent(lastUsedTalentType, number);

            if (talent != null)
            {
                String Substring = box.Text;
                if (String.Equals(Substring, "-"))
                {
                    return;
                }
                int result;
                Int32.TryParse(box.Text, out result);

                talent.setAT(result);
                box.Text = talent.getAT().ToString();
            }
            this.refreshTalentProbeBox(lastUsedTalentType);
        }
        private void PAChanged(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            if (box.Visible == false) return;

            String BasicString = "PTPA";
            String NameString = box.Name;
            String number = NameString.Substring(BasicString.Length, NameString.Length - BasicString.Length);
            FightTalent talent = (FightTalent)controll.getTalent(lastUsedTalentType, number);

            if (talent != null)
            {
                String Substring = box.Text;
                if (String.Equals(Substring, "-"))
                {
                    return;
                }
                int result;
                Int32.TryParse(box.Text, out result);

                talent.setPA(result);
                box.Text = talent.getPA().ToString();
            }
            this.refreshTalentProbeWürfeText(lastUsedTalentType);
        }

        private void radioKörperlicheTalente_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;
            
            setUPGeneralTalent(DSA_TALENTS.PHYSICALLY);
        }
        private void radioSozialTalente_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;
            
            setUPGeneralTalent(DSA_TALENTS.SOCIAL);
        }
        private void radioNaturTalente_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;
            
            setUPGeneralTalent(DSA_TALENTS.NATURE);
        }
        private void radioKnowldageTalente_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;
            
            setUPGeneralTalent(DSA_TALENTS.KNOWLDAGE);
        }
        private void radioCraftingTalent_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;
            
            setUPGeneralTalent(DSA_TALENTS.CRAFTING);
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;
            
            setUPGeneralTalent(DSA_TALENTS.CRAFTING1);
        }
        private void radioButtonFigtingTalent_ChecedChanged(object sender, EventArgs e)
        {
            RadioButton button = (RadioButton)sender;
            if (button.Checked == false) return;
            
            setUPFightingTalent(DSA_TALENTS.WEAPONLESS);
        }
    }
}
