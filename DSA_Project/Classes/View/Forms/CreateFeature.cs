using System;
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
        Dictionary<DSA_ATTRIBUTE, int> attributeBonus;
        Feature Feature;

        public CreateFeature()
        {
            setUP();
        }
        public CreateFeature(Feature feature)
        {
            setUP();
            Feature = feature;

            txtName.Text = feature.getName();
            txtDescription.Text = feature.getSimpleDescription();
            txtGP.Text = feature.getGP();
            txtValue.Text = feature.getValue();

            
            txtCharisma.Text = feature.getAttributeBonus(DSA_ATTRIBUTE.CHARISMA).ToString();
            txtFingerfertigkeit.Text = feature.getAttributeBonus(DSA_ATTRIBUTE.FINGERFERTIGKEIT).ToString();
            txtGewandheit.Text      = feature.getAttributeBonus(DSA_ATTRIBUTE.GEWANDHEIT).ToString();
            txtIntuition.Text       = feature.getAttributeBonus(DSA_ATTRIBUTE.INTUITION).ToString();
            txtKlugheit.Text        = feature.getAttributeBonus(DSA_ATTRIBUTE.KLUGHEIT).ToString();
            txtKonstitution.Text    = feature.getAttributeBonus(DSA_ATTRIBUTE.KONSTITUTION).ToString();
            txtKörperkraft.Text     = feature.getAttributeBonus(DSA_ATTRIBUTE.KÖRPERKRAFT).ToString();
            txtMut.Text             = feature.getAttributeBonus(DSA_ATTRIBUTE.MUT).ToString();
            txtSozialstatus.Text    = feature.getAttributeBonus(DSA_ATTRIBUTE.SOZAILSTATUS).ToString();

            txtAstralenergie.Text   = feature.getEnergieBonus(DSA_ENERGIEN.ASTRALENERGIE).ToString();
            txtAusdauer.Text        = feature.getEnergieBonus(DSA_ENERGIEN.AUSDAUER).ToString();
            txtKarmaenergie.Text    = feature.getEnergieBonus(DSA_ENERGIEN.KARMAENERGIE).ToString();
            txtLebensenergie.Text   = feature.getEnergieBonus(DSA_ENERGIEN.LEBENSENERGIE).ToString();
            txtMagieresistenz.Text  = feature.getEnergieBonus(DSA_ENERGIEN.MAGIERESISTENZ).ToString();
        }
        private void setUP()
        {
            InitializeComponent();
            
            attributeBonus = new Dictionary<DSA_ATTRIBUTE, int>();
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

            newFeature.setAttributeBonus(DSA_ATTRIBUTE.MUT, convertToInt(txtMut.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.KLUGHEIT, convertToInt(txtKlugheit.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.INTUITION, convertToInt(txtIntuition.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.CHARISMA, convertToInt(txtCharisma.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.FINGERFERTIGKEIT, convertToInt(txtFingerfertigkeit.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.GEWANDHEIT, convertToInt(txtGewandheit.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.KONSTITUTION, convertToInt(txtKonstitution.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.KÖRPERKRAFT, convertToInt(txtKörperkraft.Text));
            newFeature.setAttributeBonus(DSA_ATTRIBUTE.SOZAILSTATUS, convertToInt(txtSozialstatus.Text));

            newFeature.setEnergieBonus(DSA_ENERGIEN.ASTRALENERGIE, convertToInt(txtAstralenergie.Text));
            newFeature.setEnergieBonus(DSA_ENERGIEN.AUSDAUER, convertToInt(txtAusdauer.Text));
            newFeature.setEnergieBonus(DSA_ENERGIEN.KARMAENERGIE, convertToInt(txtKarmaenergie.Text));
            newFeature.setEnergieBonus(DSA_ENERGIEN.LEBENSENERGIE, convertToInt(txtLebensenergie.Text));
            newFeature.setEnergieBonus(DSA_ENERGIEN.MAGIERESISTENZ, convertToInt(txtMagieresistenz.Text));

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
    }
}
