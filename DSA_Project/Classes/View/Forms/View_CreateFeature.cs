using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DSA_Project
{
    [ExcludeFromCodeCoverage]
    public partial class View_CreateFeature : Form
    {
        private ControllView_CreateFeature controller;
        private List<TextBox> attributeTextBoxes;
        private List<TextBox> energieTextBoxes;
        private List<TextBox> advancedTextBoxes;

        public View_CreateFeature(ControllView_CreateFeature controller)
        {
            InitializeComponent();

            this.controller                     = controller;
            List<InterfaceTalent> talentList    = controller.getTalentList();
            cbTalente.DataSource                = talentList;

            ListTalente.Clear();

            ListTalente.Columns.Add(new ColumnHeader().Text = "Name");
            ListTalente.Columns.Add(new ColumnHeader().Text = "TaW");


            txtName.Text            = controller.FeatureName();
            txtDescription.Text     = controller.FeatureDescription();
            txtGP.Text              = controller.FeatureGP();
            txtValue.Text           = controller.FeatureValue();

            txtName.KeyUp           += txtName_TextChanged;
            txtDescription.KeyUp    += txtDescription_TextChanged;
            txtGP.KeyUp             += txtGP_TextChanged;
            txtValue.KeyUp          += txtValue_TextChanged;

            attributeTextBoxes      = new List<TextBox> { txtCharisma, txtFingerfertigkeit, txtGewandheit, txtIntuition, txtKonstitution, txtKörperkraft, txtKlugheit, txtMut, txtSozialstatus };
            txtCharisma.Tag         = DSA_ATTRIBUTE.CH;
            txtFingerfertigkeit.Tag = DSA_ATTRIBUTE.FF;
            txtGewandheit.Tag       = DSA_ATTRIBUTE.GE;
            txtIntuition.Tag        = DSA_ATTRIBUTE.IN;
            txtKörperkraft.Tag      = DSA_ATTRIBUTE.KK;
            txtKlugheit.Tag         = DSA_ATTRIBUTE.KL;
            txtKonstitution.Tag     = DSA_ATTRIBUTE.KO;
            txtMut.Tag              = DSA_ATTRIBUTE.MU;
            txtSozialstatus.Tag     = DSA_ATTRIBUTE.SO;

            for(int i=0; i<attributeTextBoxes.Count; i++)
            {
                DSA_ATTRIBUTE attr = (DSA_ATTRIBUTE)attributeTextBoxes[i].Tag;
                attributeTextBoxes[i].Text = controller.Attribute(attr);
                attributeTextBoxes[i].KeyUp += Attribute_Changed;
            }

            energieTextBoxes        = new List<TextBox> { txtAstralenergie, txtAusdauer, txtKarmaenergie, txtLebensenergie, txtMagieresistenz };
            txtAstralenergie.Tag    = DSA_ENERGIEN.ASTRALENERGIE;
            txtAusdauer.Tag         = DSA_ENERGIEN.AUSDAUER;
            txtKarmaenergie.Tag     = DSA_ENERGIEN.KARMAENERGIE;
            txtLebensenergie.Tag    = DSA_ENERGIEN.LEBENSENERGIE;
            txtMagieresistenz.Tag   = DSA_ENERGIEN.MAGIERESISTENZ;

            for (int i = 0; i < energieTextBoxes.Count; i++)
            {
                DSA_ENERGIEN energ = (DSA_ENERGIEN)energieTextBoxes[i].Tag;
                energieTextBoxes[i].Text = controller.Energie(energ);
                energieTextBoxes[i].KeyUp += Energie_Changed;
            }
            

            advancedTextBoxes           = new List<TextBox> { txtAttacke, txtParade, txtFernkampf, txtInitiative, txtBeherschungswert, txtArtefaktKontrolle, txtWundschwelle, txtEntrückung, txtGeschwindigkeit };
            txtAttacke.Tag              = DSA_ADVANCEDVALUES.ATTACKE_BASIS;
            txtParade.Tag               = DSA_ADVANCEDVALUES.PARADE_BASIS;
            txtFernkampf.Tag            = DSA_ADVANCEDVALUES.FERNKAMPF_BASIS;
            txtInitiative.Tag           = DSA_ADVANCEDVALUES.INITATIVE_BASIS;
            txtBeherschungswert.Tag     = DSA_ADVANCEDVALUES.BEHERSCHUNGSWERT;
            txtArtefaktKontrolle.Tag    = DSA_ADVANCEDVALUES.ARTEFAKTKONTROLLE;
            txtWundschwelle.Tag         = DSA_ADVANCEDVALUES.WUNDSCHWELLE;
            txtEntrückung.Tag           = DSA_ADVANCEDVALUES.ENTRÜCKUNG;
            txtGeschwindigkeit.Tag      = DSA_ADVANCEDVALUES.GESCHWINDIGKEIT;

            for (int i = 0; i < advancedTextBoxes.Count; i++)
            {
                DSA_ADVANCEDVALUES advanced = (DSA_ADVANCEDVALUES)advancedTextBoxes[i].Tag;
                advancedTextBoxes[i].Text = controller.Advanced(advanced);
                advancedTextBoxes[i].KeyUp += Advanced_Changed;

            }

            List<String> talenteWithBonus = controller.TalentewithBonus();
            foreach(String talent in talenteWithBonus)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = talent;
                lvi.SubItems.Add(controller.getTawBonus(talent).ToString());

                ListTalente.Items.Add(lvi);
            }
        }

        private void btADD_Click(object sender, EventArgs e)
        {
            //Entferne wenn bereits in der Liste Vorhanden
            for(int i=0; i<ListTalente.Items.Count; i++)
            {
                if(0 == String.Compare(ListTalente.Items[i].Text, cbTalente.SelectedValue.ToString()))
                {
                    ListTalente.Items[i].Remove();
                    break;
                }
            }

            //Füge der Liste Hinzu
            ListViewItem lvi = new ListViewItem();
            lvi.Text = cbTalente.SelectedValue.ToString();
            lvi.SubItems.Add(txtBonusTaW.Text);

            ListTalente.Items.Add(lvi);

            controller.setTawBonus(cbTalente.SelectedItem.ToString(), txtBonusTaW.Text);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = ListTalente.Items.Count - 1; i >= 0; i--)
            {
                ListViewItem lvi = ListTalente.Items[i];

                if (lvi.Selected)
                {
                    controller.removeTawBonus(lvi.Text);
                    lvi.Remove();
                    break;
                }                
            }
        }
        private void btnFertig_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtGP_TextChanged(object sender, EventArgs e)
        {
            txtGP.Text = controller.FeatureGP(txtGP.Text);
        }
        private void txtValue_TextChanged(object sender, EventArgs e)
        {
            txtValue.Text = controller.FeatureValue(txtValue.Text);
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            txtName.Text = controller.FeatureName(txtName.Text);
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            txtDescription.Text = controller.FeatureDescription(txtDescription.Text);
        }


        private void Attribute_Changed(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            DSA_ATTRIBUTE attr = (DSA_ATTRIBUTE)box.Tag;

            box.Text = controller.Attribute(attr, box.Text);
        }
        private void Energie_Changed(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            DSA_ENERGIEN energie = (DSA_ENERGIEN)box.Tag;

            box.Text = controller.Energie(energie, box.Text);
        }
        private void Advanced_Changed(object sender, EventArgs e)
        {
            TextBox box = (TextBox)sender;
            DSA_ADVANCEDVALUES advanced = (DSA_ADVANCEDVALUES)box.Tag;

            box.Text = controller.Advanced(advanced, box.Text);
        }
    }
}
