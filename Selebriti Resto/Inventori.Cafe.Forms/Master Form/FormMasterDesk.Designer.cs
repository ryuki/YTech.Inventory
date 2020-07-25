namespace Inventori.Cafe.Forms
{
    partial class FormMasterDesk
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
            System.Windows.Forms.Label bilOrderLabel;
            System.Windows.Forms.Label bilStatusLabel;
            System.Windows.Forms.Label bilDescLabel;
            System.Windows.Forms.Label bilIdLabel;
            this.bilOrderNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.bilStatusComboBox = new System.Windows.Forms.ComboBox();
            this.bilDescTextBox = new System.Windows.Forms.TextBox();
            this.bilIdTextBox = new System.Windows.Forms.TextBox();
            this.deskDescDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deskStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deskOrderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deskIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            bilOrderLabel = new System.Windows.Forms.Label();
            bilStatusLabel = new System.Windows.Forms.Label();
            bilDescLabel = new System.Windows.Forms.Label();
            bilIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bilOrderNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MDesk);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(bilOrderLabel);
            this.groupBox1.Controls.Add(this.bilOrderNumericUpDown);
            this.groupBox1.Controls.Add(bilStatusLabel);
            this.groupBox1.Controls.Add(this.bilStatusComboBox);
            this.groupBox1.Controls.Add(bilDescLabel);
            this.groupBox1.Controls.Add(this.bilDescTextBox);
            this.groupBox1.Controls.Add(bilIdLabel);
            this.groupBox1.Controls.Add(this.bilIdTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 194);
            this.groupBox1.Text = "Master Detail Meja";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.bilIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(bilIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.bilDescTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(bilDescLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.bilStatusComboBox, 0);
            this.groupBox1.Controls.SetChildIndex(bilStatusLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.bilOrderNumericUpDown, 0);
            this.groupBox1.Controls.SetChildIndex(bilOrderLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 194;
            // 
            // bilOrderLabel
            // 
            bilOrderLabel.AutoSize = true;
            bilOrderLabel.Location = new System.Drawing.Point(21, 80);
            bilOrderLabel.Name = "bilOrderLabel";
            bilOrderLabel.Size = new System.Drawing.Size(68, 13);
            bilOrderLabel.TabIndex = 13;
            bilOrderLabel.Text = "Urutan Meja:";
            // 
            // bilStatusLabel
            // 
            bilStatusLabel.AutoSize = true;
            bilStatusLabel.Location = new System.Drawing.Point(21, 54);
            bilStatusLabel.Name = "bilStatusLabel";
            bilStatusLabel.Size = new System.Drawing.Size(66, 13);
            bilStatusLabel.TabIndex = 12;
            bilStatusLabel.Text = "Status Meja:";
            // 
            // bilDescLabel
            // 
            bilDescLabel.AutoSize = true;
            bilDescLabel.Location = new System.Drawing.Point(21, 107);
            bilDescLabel.Name = "bilDescLabel";
            bilDescLabel.Size = new System.Drawing.Size(65, 13);
            bilDescLabel.TabIndex = 10;
            bilDescLabel.Text = "Keterangan:";
            // 
            // bilIdLabel
            // 
            bilIdLabel.AutoSize = true;
            bilIdLabel.Location = new System.Drawing.Point(21, 28);
            bilIdLabel.Name = "bilIdLabel";
            bilIdLabel.Size = new System.Drawing.Size(67, 13);
            bilIdLabel.TabIndex = 8;
            bilIdLabel.Text = "Nomor Meja:";
            // 
            // bilOrderNumericUpDown
            // 
            this.bilOrderNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource_Master, "DeskOrder", true));
            this.bilOrderNumericUpDown.Location = new System.Drawing.Point(92, 78);
            this.bilOrderNumericUpDown.Name = "bilOrderNumericUpDown";
            this.bilOrderNumericUpDown.Size = new System.Drawing.Size(47, 20);
            this.bilOrderNumericUpDown.TabIndex = 15;
            this.bilOrderNumericUpDown.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // bilStatusComboBox
            // 
            this.bilStatusComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedItem", this.bindingSource_Master, "DeskStatus", true));
            this.bilStatusComboBox.FormattingEnabled = true;
            this.bilStatusComboBox.Location = new System.Drawing.Point(92, 51);
            this.bilStatusComboBox.Name = "bilStatusComboBox";
            this.bilStatusComboBox.Size = new System.Drawing.Size(121, 21);
            this.bilStatusComboBox.TabIndex = 14;
            this.bilStatusComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // bilDescTextBox
            // 
            this.bilDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "DeskDesc", true));
            this.bilDescTextBox.Location = new System.Drawing.Point(92, 104);
            this.bilDescTextBox.Multiline = true;
            this.bilDescTextBox.Name = "bilDescTextBox";
            this.bilDescTextBox.Size = new System.Drawing.Size(183, 74);
            this.bilDescTextBox.TabIndex = 11;
            this.bilDescTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // bilIdTextBox
            // 
            this.bilIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "DeskId", true));
            this.bilIdTextBox.Location = new System.Drawing.Point(92, 25);
            this.bilIdTextBox.Name = "bilIdTextBox";
            this.bilIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.bilIdTextBox.TabIndex = 9;
            this.bilIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // deskDescDataGridViewTextBoxColumn
            // 
            this.deskDescDataGridViewTextBoxColumn.DataPropertyName = "DeskDesc";
            this.deskDescDataGridViewTextBoxColumn.HeaderText = "DeskDesc";
            this.deskDescDataGridViewTextBoxColumn.Name = "deskDescDataGridViewTextBoxColumn";
            this.deskDescDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deskStatusDataGridViewTextBoxColumn
            // 
            this.deskStatusDataGridViewTextBoxColumn.DataPropertyName = "DeskStatus";
            this.deskStatusDataGridViewTextBoxColumn.HeaderText = "DeskStatus";
            this.deskStatusDataGridViewTextBoxColumn.Name = "deskStatusDataGridViewTextBoxColumn";
            this.deskStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deskOrderDataGridViewTextBoxColumn
            // 
            this.deskOrderDataGridViewTextBoxColumn.DataPropertyName = "DeskOrder";
            this.deskOrderDataGridViewTextBoxColumn.HeaderText = "DeskOrder";
            this.deskOrderDataGridViewTextBoxColumn.Name = "deskOrderDataGridViewTextBoxColumn";
            this.deskOrderDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // deskIdDataGridViewTextBoxColumn
            // 
            this.deskIdDataGridViewTextBoxColumn.DataPropertyName = "DeskId";
            this.deskIdDataGridViewTextBoxColumn.HeaderText = "DeskId";
            this.deskIdDataGridViewTextBoxColumn.Name = "deskIdDataGridViewTextBoxColumn";
            this.deskIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FormMasterDesk
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterDesk";
            this.TabText = "Master Meja";
            this.Text = "Master Meja";
            this.Load += new System.EventHandler(this.FormMasterDesk_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bilOrderNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown bilOrderNumericUpDown;
        private System.Windows.Forms.ComboBox bilStatusComboBox;
        private System.Windows.Forms.TextBox bilDescTextBox;
        private System.Windows.Forms.TextBox bilIdTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn deskDescDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deskStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deskOrderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deskIdDataGridViewTextBoxColumn;
    }
}
