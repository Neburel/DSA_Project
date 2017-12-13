namespace DSA_Project
{
    partial class CreateTalent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTalentName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.comboBoxProbe = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.addProbe = new System.Windows.Forms.Button();
            this.listProbeView = new System.Windows.Forms.ListView();
            this.listProbeAttribut = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtRequirementName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRequiremantTaw = new System.Windows.Forms.TextBox();
            this.txtRequirementTaWab = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddRequirement = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiverateName = new System.Windows.Forms.TextBox();
            this.txtDiverateTaW = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAddDiverate = new System.Windows.Forms.Button();
            this.listRequirement = new System.Windows.Forms.ListView();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BTaW = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaWab = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewDiverate = new System.Windows.Forms.ListView();
            this.DiverateListName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DiverateListTaW = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBE = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtTalentName
            // 
            this.txtTalentName.Location = new System.Drawing.Point(84, 10);
            this.txtTalentName.Name = "txtTalentName";
            this.txtTalentName.Size = new System.Drawing.Size(153, 20);
            this.txtTalentName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "TalentName";
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(84, 36);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(153, 21);
            this.comboBoxType.TabIndex = 2;
            // 
            // comboBoxProbe
            // 
            this.comboBoxProbe.FormattingEnabled = true;
            this.comboBoxProbe.Location = new System.Drawing.Point(84, 89);
            this.comboBoxProbe.Name = "comboBoxProbe";
            this.comboBoxProbe.Size = new System.Drawing.Size(74, 21);
            this.comboBoxProbe.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "TalentType";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "TalentProbe";
            // 
            // addProbe
            // 
            this.addProbe.Location = new System.Drawing.Point(165, 90);
            this.addProbe.Name = "addProbe";
            this.addProbe.Size = new System.Drawing.Size(75, 20);
            this.addProbe.TabIndex = 6;
            this.addProbe.Text = "ADD";
            this.addProbe.UseVisualStyleBackColor = true;
            this.addProbe.Click += new System.EventHandler(this.addProbe_Click);
            // 
            // listProbeView
            // 
            this.listProbeView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.listProbeAttribut});
            this.listProbeView.Location = new System.Drawing.Point(246, 10);
            this.listProbeView.Name = "listProbeView";
            this.listProbeView.Size = new System.Drawing.Size(226, 100);
            this.listProbeView.TabIndex = 7;
            this.listProbeView.UseCompatibleStateImageBehavior = false;
            this.listProbeView.View = System.Windows.Forms.View.Details;
            // 
            // listProbeAttribut
            // 
            this.listProbeAttribut.Text = "Attribute";
            // 
            // txtRequirementName
            // 
            this.txtRequirementName.Location = new System.Drawing.Point(84, 116);
            this.txtRequirementName.Name = "txtRequirementName";
            this.txtRequirementName.Size = new System.Drawing.Size(153, 20);
            this.txtRequirementName.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Anforderung";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(84, 143);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "BenötigterTaW";
            // 
            // txtRequiremantTaw
            // 
            this.txtRequiremantTaw.Location = new System.Drawing.Point(175, 140);
            this.txtRequiremantTaw.Name = "txtRequiremantTaw";
            this.txtRequiremantTaw.Size = new System.Drawing.Size(62, 20);
            this.txtRequiremantTaw.TabIndex = 11;
            // 
            // txtRequirementTaWab
            // 
            this.txtRequirementTaWab.Location = new System.Drawing.Point(175, 166);
            this.txtRequirementTaWab.Name = "txtRequirementTaWab";
            this.txtRequirementTaWab.Size = new System.Drawing.Size(62, 20);
            this.txtRequirementTaWab.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(84, 169);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "BenötigtTaWAb";
            // 
            // btnAddRequirement
            // 
            this.btnAddRequirement.Location = new System.Drawing.Point(84, 192);
            this.btnAddRequirement.Name = "btnAddRequirement";
            this.btnAddRequirement.Size = new System.Drawing.Size(156, 20);
            this.btnAddRequirement.TabIndex = 14;
            this.btnAddRequirement.Text = "ADD";
            this.btnAddRequirement.UseVisualStyleBackColor = true;
            this.btnAddRequirement.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 221);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Ableitung";
            // 
            // txtDiverateName
            // 
            this.txtDiverateName.Location = new System.Drawing.Point(84, 218);
            this.txtDiverateName.Name = "txtDiverateName";
            this.txtDiverateName.Size = new System.Drawing.Size(153, 20);
            this.txtDiverateName.TabIndex = 15;
            // 
            // txtDiverateTaW
            // 
            this.txtDiverateTaW.Location = new System.Drawing.Point(192, 244);
            this.txtDiverateTaW.Name = "txtDiverateTaW";
            this.txtDiverateTaW.Size = new System.Drawing.Size(45, 20);
            this.txtDiverateTaW.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 247);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "BenötigterTaWWert";
            // 
            // btnAddDiverate
            // 
            this.btnAddDiverate.Location = new System.Drawing.Point(81, 270);
            this.btnAddDiverate.Name = "btnAddDiverate";
            this.btnAddDiverate.Size = new System.Drawing.Size(156, 20);
            this.btnAddDiverate.TabIndex = 19;
            this.btnAddDiverate.Text = "ADD";
            this.btnAddDiverate.UseVisualStyleBackColor = true;
            this.btnAddDiverate.Click += new System.EventHandler(this.btnAddDiverate_Click);
            // 
            // listRequirement
            // 
            this.listRequirement.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.BTaW,
            this.TaWab});
            this.listRequirement.Location = new System.Drawing.Point(246, 116);
            this.listRequirement.Name = "listRequirement";
            this.listRequirement.Size = new System.Drawing.Size(226, 96);
            this.listRequirement.TabIndex = 20;
            this.listRequirement.UseCompatibleStateImageBehavior = false;
            this.listRequirement.View = System.Windows.Forms.View.Details;
            // 
            // Name
            // 
            this.Name.Text = "Name";
            // 
            // BTaW
            // 
            this.BTaW.Text = "BTaW";
            // 
            // TaWab
            // 
            this.TaWab.Text = "TaWab";
            // 
            // listViewDiverate
            // 
            this.listViewDiverate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DiverateListName,
            this.DiverateListTaW});
            this.listViewDiverate.Location = new System.Drawing.Point(246, 221);
            this.listViewDiverate.Name = "listViewDiverate";
            this.listViewDiverate.Size = new System.Drawing.Size(226, 69);
            this.listViewDiverate.TabIndex = 21;
            this.listViewDiverate.UseCompatibleStateImageBehavior = false;
            this.listViewDiverate.View = System.Windows.Forms.View.Details;
            // 
            // DiverateListName
            // 
            this.DiverateListName.Text = "Name";
            // 
            // DiverateListTaW
            // 
            this.DiverateListTaW.Text = "DiverateListTaW";
            this.DiverateListTaW.Width = 131;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(478, 39);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 20);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(478, 13);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(156, 20);
            this.btnClear.TabIndex = 23;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 66);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 13);
            this.label9.TabIndex = 25;
            this.label9.Text = "Be";
            // 
            // txtBE
            // 
            this.txtBE.Location = new System.Drawing.Point(84, 63);
            this.txtBE.Name = "txtBE";
            this.txtBE.Size = new System.Drawing.Size(153, 20);
            this.txtBE.TabIndex = 24;
            // 
            // CreateTalent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(639, 297);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtBE);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listViewDiverate);
            this.Controls.Add(this.listRequirement);
            this.Controls.Add(this.btnAddDiverate);
            this.Controls.Add(this.txtDiverateTaW);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDiverateName);
            this.Controls.Add(this.btnAddRequirement);
            this.Controls.Add(this.txtRequirementTaWab);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtRequiremantTaw);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtRequirementName);
            this.Controls.Add(this.listProbeView);
            this.Controls.Add(this.addProbe);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxProbe);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTalentName);
            this.Text = "CreateTalent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTalentName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.ComboBox comboBoxProbe;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addProbe;
        private System.Windows.Forms.ListView listProbeView;
        private System.Windows.Forms.TextBox txtRequirementName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRequiremantTaw;
        private System.Windows.Forms.TextBox txtRequirementTaWab;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddRequirement;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiverateName;
        private System.Windows.Forms.TextBox txtDiverateTaW;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAddDiverate;
        private System.Windows.Forms.ColumnHeader listProbeAttribut;
        private System.Windows.Forms.ListView listRequirement;
        private System.Windows.Forms.ListView listViewDiverate;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader BTaW;
        private System.Windows.Forms.ColumnHeader TaWab;
        private System.Windows.Forms.ColumnHeader DiverateListName;
        private System.Windows.Forms.ColumnHeader DiverateListTaW;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBE;
    }
}