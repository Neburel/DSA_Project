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
    public partial class CreateFightingTalent : Form
    {
        public CreateFightingTalent()
        {
            InitializeComponent();

            comboBoxType.DataSource = Enum.GetValues(typeof(DSA_FIGHTINGTALENTS));
            comboBoxParade.DataSource = new List<Boolean> { true, false };

            createViews();
        }

        public void createViews()
        {
            listViewDiverate.Clear();

            listViewDiverate.Columns.Add(new ColumnHeader().Text = "Name");
            listViewDiverate.Columns.Add(new ColumnHeader().Text = "TaW");
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
            List<ListViewItem> diverate = new List<ListViewItem>();

            DSA_FIGHTINGTALENTS type;
            Enum.TryParse<DSA_FIGHTINGTALENTS>(comboBoxType.Text, out type);
           
            foreach (ListViewItem item in listViewDiverate.Items)
            {
                diverate.Add(item);
            }

            Boolean boolean = (Boolean)comboBoxParade.SelectedValue;

            SaveXMLTalent.saveXMLTalent(txtTalentName.Text, type, diverate, txtBE.Text, boolean);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            createViews();
        }
    }
}
