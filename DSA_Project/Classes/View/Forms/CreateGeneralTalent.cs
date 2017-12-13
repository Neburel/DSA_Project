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
    public partial class CreateTalent : Form
    {
        private String GeneralTalentFileSystemLocation;

        public CreateTalent(String GeneralTalentFileSystemLocation)
        {
            this.GeneralTalentFileSystemLocation = GeneralTalentFileSystemLocation;

            InitializeComponent();
            comboBoxType.DataSource = Enum.GetValues(typeof(DSA_GENERALTALENTS));
            comboBoxProbe.DataSource = Enum.GetValues(typeof(DSA_ATTRIBUTE));

            constructViewBoxes();
        }
        public void constructViewBoxes()
        {
            listViewDiverate.Clear();
            listProbeView.Clear();
            listRequirement.Clear();

            listProbeView.Columns.Add(new ColumnHeader().Text = "Attribut");

            listRequirement.Columns.Add(new ColumnHeader().Text = "Name");
            listRequirement.Columns.Add(new ColumnHeader().Text = "BTaW");
            listRequirement.Columns.Add(new ColumnHeader().Text = "TawAb");

            listViewDiverate.Columns.Add(new ColumnHeader().Text = "Name");
            listViewDiverate.Columns.Add(new ColumnHeader().Text = "TaW");
        }
        private void addProbe_Click(object sender, EventArgs e)
        {
            DSA_ATTRIBUTE attribute;
            Enum.TryParse<DSA_ATTRIBUTE>(comboBoxProbe.SelectedValue.ToString(), out attribute);

            ListViewItem lvi = new ListViewItem();
            lvi.Text = attribute.ToString();

            listProbeView.Items.Add(lvi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String RequirementName  = txtRequirementName.Text;
            String RequirementTaw   = txtRequiremantTaw.Text;
            String RequirementTaWab = txtRequirementTaWab.Text;

            ListViewItem lvi = new ListViewItem();
            lvi.Text = RequirementName;
            lvi.SubItems.Add(RequirementTaw);
            lvi.SubItems.Add(RequirementTaWab);

            listRequirement.Items.Add(lvi);
        }

        private void btnAddDiverate_Click(object sender, EventArgs e)
        {
            String DiverateName = txtDiverateName.Text;
            String DiverateTaW = txtDiverateTaW.Text;

            ListViewItem lvi = new ListViewItem();
            lvi.Text = DiverateName;
            lvi.SubItems.Add(DiverateTaW);

            listViewDiverate.Items.Add(lvi);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            List<ListViewItem> probe = new List<ListViewItem>();
            List<ListViewItem> diverate = new List<ListViewItem>();
            List<ListViewItem> requirement = new List<ListViewItem>();

            DSA_GENERALTALENTS type;
            Enum.TryParse<DSA_GENERALTALENTS>(comboBoxType.Text, out type);
                
            foreach(ListViewItem item in listProbeView.Items)
            {
                probe.Add(item);
            }
            foreach (ListViewItem item in listViewDiverate.Items)
            {
                diverate.Add(item);
            }
            foreach (ListViewItem item in listRequirement.Items)
            {
                requirement.Add(item);
            }


            SaveXMLTalent.saveXMLTalent(GeneralTalentFileSystemLocation, txtTalentName.Text, type, probe, requirement, diverate, txtBE.Text);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            listViewDiverate.Clear();
            listProbeView.Clear();
            listRequirement.Clear();

            constructViewBoxes();
        }
    }
}
