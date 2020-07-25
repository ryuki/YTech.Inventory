namespace Inventori.Cafe.Forms
{
    partial class FormMasterGroup
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
            System.Windows.Forms.Label groupIdLabel;
            System.Windows.Forms.Label groupNameLabel;
            System.Windows.Forms.Label printOrderLabel;
            System.Windows.Forms.Label printerNameLabel;
            this.groupNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupIdLabel1 = new System.Windows.Forms.Label();
            this.groupNameTextBox = new System.Windows.Forms.TextBox();
            this.printOrderCheckBox = new System.Windows.Forms.CheckBox();
            this.printerNameComboBox = new System.Windows.Forms.ComboBox();
            groupIdLabel = new System.Windows.Forms.Label();
            groupNameLabel = new System.Windows.Forms.Label();
            printOrderLabel = new System.Windows.Forms.Label();
            printerNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Cafe.Data.MGroup);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(printerNameLabel);
            this.groupBox1.Controls.Add(this.printerNameComboBox);
            this.groupBox1.Controls.Add(printOrderLabel);
            this.groupBox1.Controls.Add(this.printOrderCheckBox);
            this.groupBox1.Controls.Add(groupIdLabel);
            this.groupBox1.Controls.Add(this.groupIdLabel1);
            this.groupBox1.Controls.Add(groupNameLabel);
            this.groupBox1.Controls.Add(this.groupNameTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 161);
            this.groupBox1.Text = "Master Detail Master Golongan Item";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.groupNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(groupNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.groupIdLabel1, 0);
            this.groupBox1.Controls.SetChildIndex(groupIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.printOrderCheckBox, 0);
            this.groupBox1.Controls.SetChildIndex(printOrderLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.printerNameComboBox, 0);
            this.groupBox1.Controls.SetChildIndex(printerNameLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 161;
            // 
            // groupIdLabel
            // 
            groupIdLabel.AutoSize = true;
            groupIdLabel.Location = new System.Drawing.Point(16, 25);
            groupIdLabel.Name = "groupIdLabel";
            groupIdLabel.Size = new System.Drawing.Size(107, 13);
            groupIdLabel.TabIndex = 1;
            groupIdLabel.Text = "Kode Golongan Item:";
            // 
            // groupNameLabel
            // 
            groupNameLabel.AutoSize = true;
            groupNameLabel.Location = new System.Drawing.Point(16, 54);
            groupNameLabel.Name = "groupNameLabel";
            groupNameLabel.Size = new System.Drawing.Size(110, 13);
            groupNameLabel.TabIndex = 3;
            groupNameLabel.Text = "Nama Golongan Item:";
            // 
            // groupNameDataGridViewTextBoxColumn
            // 
            this.groupNameDataGridViewTextBoxColumn.DataPropertyName = "GroupName";
            this.groupNameDataGridViewTextBoxColumn.HeaderText = "GroupName";
            this.groupNameDataGridViewTextBoxColumn.Name = "groupNameDataGridViewTextBoxColumn";
            this.groupNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupIdDataGridViewTextBoxColumn
            // 
            this.groupIdDataGridViewTextBoxColumn.DataPropertyName = "GroupId";
            this.groupIdDataGridViewTextBoxColumn.HeaderText = "GroupId";
            this.groupIdDataGridViewTextBoxColumn.Name = "groupIdDataGridViewTextBoxColumn";
            this.groupIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // groupIdLabel1
            // 
            this.groupIdLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "GroupId", true));
            this.groupIdLabel1.Location = new System.Drawing.Point(132, 25);
            this.groupIdLabel1.Name = "groupIdLabel1";
            this.groupIdLabel1.Size = new System.Drawing.Size(100, 23);
            this.groupIdLabel1.TabIndex = 2;
            // 
            // groupNameTextBox
            // 
            this.groupNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "GroupName", true));
            this.groupNameTextBox.Location = new System.Drawing.Point(132, 51);
            this.groupNameTextBox.Name = "groupNameTextBox";
            this.groupNameTextBox.Size = new System.Drawing.Size(216, 20);
            this.groupNameTextBox.TabIndex = 4;
            this.groupNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // printOrderLabel
            // 
            printOrderLabel.AutoSize = true;
            printOrderLabel.Location = new System.Drawing.Point(16, 82);
            printOrderLabel.Name = "printOrderLabel";
            printOrderLabel.Size = new System.Drawing.Size(70, 13);
            printOrderLabel.TabIndex = 5;
            printOrderLabel.Text = "Cetak Order :";
            // 
            // printOrderCheckBox
            // 
            this.printOrderCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.bindingSource_Master, "PrintOrder", true));
            this.printOrderCheckBox.Location = new System.Drawing.Point(132, 77);
            this.printOrderCheckBox.Name = "printOrderCheckBox";
            this.printOrderCheckBox.Size = new System.Drawing.Size(104, 24);
            this.printOrderCheckBox.TabIndex = 6;
            this.printOrderCheckBox.Text = "Ya / Tidak";
            this.printOrderCheckBox.UseVisualStyleBackColor = true;
            // 
            // printerNameLabel
            // 
            printerNameLabel.AutoSize = true;
            printerNameLabel.Location = new System.Drawing.Point(16, 110);
            printerNameLabel.Name = "printerNameLabel";
            printerNameLabel.Size = new System.Drawing.Size(43, 13);
            printerNameLabel.TabIndex = 7;
            printerNameLabel.Text = "Printer :";
            // 
            // printerNameComboBox
            // 
            this.printerNameComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "PrinterName", true));
            this.printerNameComboBox.FormattingEnabled = true;
            this.printerNameComboBox.Location = new System.Drawing.Point(132, 107);
            this.printerNameComboBox.Name = "printerNameComboBox";
            this.printerNameComboBox.Size = new System.Drawing.Size(216, 21);
            this.printerNameComboBox.TabIndex = 8;
            // 
            // FormMasterGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterGroup";
            this.TabText = "Master Golongan Item";
            this.Text = "Master Golongan Item";
            this.Load += new System.EventHandler(this.FormMasterGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn groupNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label groupIdLabel1;
        private System.Windows.Forms.TextBox groupNameTextBox;
        private System.Windows.Forms.ComboBox printerNameComboBox;
        private System.Windows.Forms.CheckBox printOrderCheckBox;
    }
}
