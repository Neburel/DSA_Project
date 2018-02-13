namespace DSA_Project
{
    partial class CreateFightingTalent
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
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.listViewDiverate = new System.Windows.Forms.ListView();
            this.DiverateListName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DiverateListTaW = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddDiverate = new System.Windows.Forms.Button();
            this.txtDiverateTaW = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiverateName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTalentName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxParade = new System.Windows.Forms.ComboBox();
            this.Be = new System.Windows.Forms.Label();
            this.txtBE = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(12, 190);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(156, 20);
            this.btnClear.TabIndex = 35;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 216);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(156, 20);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // listViewDiverate
            // 
            this.listViewDiverate.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DiverateListName,
            this.DiverateListTaW});
            this.listViewDiverate.Location = new System.Drawing.Point(246, 115);
            this.listViewDiverate.Name = "listViewDiverate";
            this.listViewDiverate.Size = new System.Drawing.Size(226, 69);
            this.listViewDiverate.TabIndex = 33;
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
            // btnAddDiverate
            // 
            this.btnAddDiverate.Location = new System.Drawing.Point(81, 164);
            this.btnAddDiverate.Name = "btnAddDiverate";
            this.btnAddDiverate.Size = new System.Drawing.Size(156, 20);
            this.btnAddDiverate.TabIndex = 32;
            this.btnAddDiverate.Text = "ADD";
            this.btnAddDiverate.UseVisualStyleBackColor = true;
            this.btnAddDiverate.Click += new System.EventHandler(this.btnAddDiverate_Click);
            // 
            // txtDiverateTaW
            // 
            this.txtDiverateTaW.Location = new System.Drawing.Point(192, 138);
            this.txtDiverateTaW.Name = "txtDiverateTaW";
            this.txtDiverateTaW.Size = new System.Drawing.Size(45, 20);
            this.txtDiverateTaW.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(84, 141);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "BenötigterTaWWert";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(51, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Ableitung";
            // 
            // txtDiverateName
            // 
            this.txtDiverateName.Location = new System.Drawing.Point(84, 112);
            this.txtDiverateName.Name = "txtDiverateName";
            this.txtDiverateName.Size = new System.Drawing.Size(153, 20);
            this.txtDiverateName.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "TalentType";
            // 
            // comboBoxType
            // 
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(84, 32);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(153, 21);
            this.comboBoxType.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "TalentName";
            // 
            // txtTalentName
            // 
            this.txtTalentName.Location = new System.Drawing.Point(84, 6);
            this.txtTalentName.Name = "txtTalentName";
            this.txtTalentName.Size = new System.Drawing.Size(153, 20);
            this.txtTalentName.TabIndex = 24;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Parade";
            // 
            // comboBoxParade
            // 
            this.comboBoxParade.FormattingEnabled = true;
            this.comboBoxParade.Location = new System.Drawing.Point(84, 59);
            this.comboBoxParade.Name = "comboBoxParade";
            this.comboBoxParade.Size = new System.Drawing.Size(153, 21);
            this.comboBoxParade.TabIndex = 36;
            // 
            // Be
            // 
            this.Be.AutoSize = true;
            this.Be.Location = new System.Drawing.Point(12, 89);
            this.Be.Name = "Be";
            this.Be.Size = new System.Drawing.Size(21, 13);
            this.Be.TabIndex = 39;
            this.Be.Text = "BE";
            // 
            // txtBE
            // 
            this.txtBE.Location = new System.Drawing.Point(84, 86);
            this.txtBE.Name = "txtBE";
            this.txtBE.Size = new System.Drawing.Size(153, 20);
            this.txtBE.TabIndex = 38;
            // 
            // CreateFightingTalent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 240);
            this.Controls.Add(this.Be);
            this.Controls.Add(this.txtBE);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBoxParade);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.listViewDiverate);
            this.Controls.Add(this.btnAddDiverate);
            this.Controls.Add(this.txtDiverateTaW);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtDiverateName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTalentName);
            this.Name = "CreateFightingTalent";
            this.Text = "CreateFightingTalent";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ListView listViewDiverate;
        private System.Windows.Forms.ColumnHeader DiverateListName;
        private System.Windows.Forms.ColumnHeader DiverateListTaW;
        private System.Windows.Forms.Button btnAddDiverate;
        private System.Windows.Forms.TextBox txtDiverateTaW;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiverateName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTalentName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxParade;
        private System.Windows.Forms.Label Be;
        private System.Windows.Forms.TextBox txtBE;
    }
}