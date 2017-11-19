﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Project
{
    public partial class CreateFeature : Form
    {
        Feature Feature;

        public CreateFeature()
        {
            setUP();

            txtName.Text            = "";
            txtDescription.Text     = "";
            txtGP.Text              = "";
            txtValue.Text           = "";

            String zero = (0).ToString();

            txtCharisma.Text            = zero;
            txtFingerfertigkeit.Text    = zero;
            txtGewandheit.Text          = zero;
            txtIntuition.Text           = zero;
            txtKlugheit.Text            = zero;
            txtKonstitution.Text        = zero;
            txtKörperkraft.Text         = zero;
            txtMut.Text                 = zero;
            txtSozialstatus.Text        = zero;

            txtAstralenergie.Text       = zero;
            txtAusdauer.Text            = zero;
            txtKarmaenergie.Text        = zero;
            txtLebensenergie.Text       = zero;
            txtMagieresistenz.Text      = zero;

            txtAttacke.Text             = zero;
            txtParade.Text              = zero;
            txtFernkampf.Text           = zero;
            txtInitiative.Text          = zero;
            txtBeherschungswert.Text    = zero;
            txtArtefaktKontrolle.Text   = zero;
            txtWundschwelle.Text        = zero;
            txtEntrückung.Text          = zero;
            txtGeschwindigkeit.Text     = zero;            
        }
        public CreateFeature(Feature feature)
        {
            setUP();
            Feature = feature;

            txtName.Text = feature.getName();
            txtDescription.Text = feature.getSimpleDescription();
            txtGP.Text = feature.getGP();
            txtValue.Text = feature.getValue();
                        
            txtCharisma.Text = feature.getAttributeBonus(DSA_ATTRIBUTE.CH).ToString();
            txtFingerfertigkeit.Text = feature.getAttributeBonus(DSA_ATTRIBUTE.FF).ToString();
            txtGewandheit.Text      = feature.getAttributeBonus(DSA_ATTRIBUTE.GE).ToString();
            txtIntuition.Text       = feature.getAttributeBonus(DSA_ATTRIBUTE.IN).ToString();
            txtKlugheit.Text        = feature.getAttributeBonus(DSA_ATTRIBUTE.KL).ToString();
            txtKonstitution.Text    = feature.getAttributeBonus(DSA_ATTRIBUTE.KO).ToString();
            txtKörperkraft.Text     = feature.getAttributeBonus(DSA_ATTRIBUTE.KK).ToString();
            txtMut.Text             = feature.getAttributeBonus(DSA_ATTRIBUTE.MU).ToString();
            txtSozialstatus.Text    = feature.getAttributeBonus(DSA_ATTRIBUTE.SO).ToString();

            txtAstralenergie.Text   = feature.getEnergieBonus(DSA_ENERGIEN.ASTRALENERGIE).ToString();
            txtAusdauer.Text        = feature.getEnergieBonus(DSA_ENERGIEN.AUSDAUER).ToString();
            txtKarmaenergie.Text    = feature.getEnergieBonus(DSA_ENERGIEN.KARMAENERGIE).ToString();
            txtLebensenergie.Text   = feature.getEnergieBonus(DSA_ENERGIEN.LEBENSENERGIE).ToString();
            txtMagieresistenz.Text  = feature.getEnergieBonus(DSA_ENERGIEN.MAGIERESISTENZ).ToString();
        }
        private void setUP()
        {
            InitializeComponent();
            
            Feature = null;

            List<String> talente = new List<string>();
            talente.Add("A");
            talente.Add("B");
            talente.Add("C");

            ListTalente.Columns.Add("Name");
            ListTalente.Columns.Add("Bonus");
            ListTalente.Columns[0].Width = 120;
        }
        public Feature feature()
        {
            return Feature;
        }

        private int convertToInt(String value)
        {
            var isNumeric = int.TryParse(value, out var wert_int);
            if (isNumeric == true)
            {
                return wert_int;
            }
            return 0;
        }

        private Feature createFeature()
        {
            Feature newFeature = new Feature(txtName.Text, txtDescription.Text, txtValue.Text, txtGP.Text);

            newFeature.setAttributeBonus(DSA_ATTRIBUTE.MU, convertToInt(txtMut.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.KL, convertToInt(txtKlugheit.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.IN, convertToInt(txtIntuition.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.CH, convertToInt(txtCharisma.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.FF, convertToInt(txtFingerfertigkeit.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.GE, convertToInt(txtGewandheit.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.KO, convertToInt(txtKonstitution.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.KK, convertToInt(txtKörperkraft.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.SO, convertToInt(txtSozialstatus.Text));

            newFeature.setEnergieBonus(DSA_ENERGIEN.ASTRALENERGIE, convertToInt(txtAstralenergie.Text));
            newFeature.setEnergieBonus(DSA_ENERGIEN.AUSDAUER, convertToInt(txtAusdauer.Text));
            newFeature.setEnergieBonus(DSA_ENERGIEN.KARMAENERGIE, convertToInt(txtKarmaenergie.Text));
            newFeature.setEnergieBonus(DSA_ENERGIEN.LEBENSENERGIE, convertToInt(txtLebensenergie.Text));
            newFeature.setEnergieBonus(DSA_ENERGIEN.MAGIERESISTENZ, convertToInt(txtMagieresistenz.Text));

            newFeature.setAdvancedValues(DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE, convertToInt(txtArtefaktKontrolle.Text));
            newFeature.setAdvancedValues(DSA_ADVANCEDVALUES.ATTACKE_BASIS, convertToInt(txtAttacke.Text));
            newFeature.setAdvancedValues(DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT, convertToInt(txtBeherschungswert.Text));
            newFeature.setAdvancedValues(DSA_ADVANCEDVALUES.ENTRÜCKUNG, convertToInt(txtEntrückung.Text));
            newFeature.setAdvancedValues(DSA_ADVANCEDVALUES.FERNKAMPF_BASIS, convertToInt(txtFernkampf.Text));
            newFeature.setAdvancedValues(DSA_ADVANCEDVALUES.GESCHWINDIGKEIT, convertToInt(txtGeschwindigkeit.Text));
            newFeature.setAdvancedValues(DSA_ADVANCEDVALUES.INITATIVE_BASIS, convertToInt(txtInitiative.Text));
            newFeature.setAdvancedValues(DSA_ADVANCEDVALUES.PARADE_BASIS, convertToInt(txtParade.Text));
            newFeature.setAdvancedValues(DSA_ADVANCEDVALUES.WUNDSCHWELLE, convertToInt(txtWundschwelle.Text));

            return newFeature;
        }
        
        private void btADD_Click(object sender, EventArgs e)
        {
            

        }

        private void btnFertig_Click(object sender, EventArgs e)
        {
            Feature = createFeature();
            this.Close();
        }

        private void txtGP_TextChanged(object sender, EventArgs e)
        {
            txtGP.Text = convertToInt(txtGP.Text).ToString();
        }
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            if (txtValue.Text.ToUpper() == "X")
            {
                txtValue.Text = "X";
            } else
            {
                txtValue.Text = convertToInt(txtValue.Text).ToString();
            }
        }
        private void txtMut_TextChanged(object sender, EventArgs e)
        {
            txtMut.Text = convertToInt(txtMut.Text).ToString();
        }
        private void txtKlugheit_TextChanged(object sender, EventArgs e)
        {
            txtKlugheit.Text = convertToInt(txtKlugheit.Text).ToString();
        }
        private void txtIntuition_TextChanged(object sender, EventArgs e)
        {
            txtIntuition.Text = convertToInt(txtIntuition.Text).ToString();
        }
        private void txtCharisma_TextChanged(object sender, EventArgs e)
        {
            txtCharisma.Text = convertToInt(txtCharisma.Text).ToString();
        }
        private void txtFingerfertigkeit_TextChanged(object sender, EventArgs e)
        {
            txtFingerfertigkeit.Text = convertToInt(txtFingerfertigkeit.Text).ToString();
        }
        private void txtGewandheit_TextChanged(object sender, EventArgs e)
        {
            txtGewandheit.Text = convertToInt(txtGewandheit.Text).ToString();
        }
        private void txtKonstitution_TextChanged(object sender, EventArgs e)
        {
            txtKonstitution.Text = convertToInt(txtKonstitution.Text).ToString();
        }
        private void txtKörperkraft_TextChanged(object sender, EventArgs e)
        {
            txtKörperkraft.Text = convertToInt(txtKörperkraft.Text).ToString();
        }
        private void txtSozialstatus_TextChanged(object sender, EventArgs e)
        {
            txtSozialstatus.Text = convertToInt(txtSozialstatus.Text).ToString();
        }


        private void txtLebensenergie_TextChanged(object sender, EventArgs e)
        {
            txtLebensenergie.Text = convertToInt(txtLebensenergie.Text).ToString();
        }
        private void txtAusdauer_TextChanged(object sender, EventArgs e)
        {
            txtAusdauer.Text = convertToInt(txtAusdauer.Text).ToString();
        }
        private void txtAstralenergie_TextChanged(object sender, EventArgs e)
        {
            txtAstralenergie.Text = convertToInt(txtAstralenergie.Text).ToString();
        }
        private void txtKarmaenergie_TextChanged(object sender, EventArgs e)
        {
            txtKarmaenergie.Text = convertToInt(txtKarmaenergie.Text).ToString();
        }
        private void txtMagieresistenz_TextChanged(object sender, EventArgs e)
        {
            txtMagieresistenz.Text = convertToInt(txtMagieresistenz.Text).ToString();
        }

        private void CreateFeature_Load(object sender, EventArgs e)
        {

        }

        private void txtAttacke_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtParade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFernkampf_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInitiative_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBeherschungswert_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtArtefaktKontrolle_TextChanged(object sender, EventArgs e)
        {

        }

        private void Wundschwelle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEntrückung_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGeschwindigkeit_TextChanged(object sender, EventArgs e)
        {

        }
    }
}