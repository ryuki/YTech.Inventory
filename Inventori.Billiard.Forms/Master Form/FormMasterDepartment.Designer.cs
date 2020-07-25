namespace Inventori.Billiard.Forms
{
    partial class FormMasterDepartment
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
            System.Windows.Forms.Label depIdLabel;
            System.Windows.Forms.Label depStatusLabel;
            this.depNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depIdTextBox = new System.Windows.Forms.TextBox();
            this.depStatusTextBox = new System.Windows.Forms.TextBox();
            depIdLabel = new System.Windows.Forms.Label();
            depStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MDep);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(depIdLabel);
            this.groupBox1.Controls.Add(this.depIdTextBox);
            this.groupBox1.Controls.Add(depStatusLabel);
            this.groupBox1.Controls.Add(this.depStatusTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 92);
            this.groupBox1.Text = "Master Detail Bagian";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.depStatusTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(depStatusLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.depIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(depIdLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 92;
            // 
            // depIdLabel
            // 
            depIdLabel.AutoSize = true;
            depIdLabel.Location = new System.Drawing.Point(15, 28);
            depIdLabel.Name = "depIdLabel";
            depIdLabel.Size = new System.Drawing.Size(43, 13);
            depIdLabel.TabIndex = 1;
            depIdLabel.Text = "Bagian:";
            // 
            // depStatusLabel
            // 
            depStatusLabel.AutoSize = true;
            depStatusLabel.Location = new System.Drawing.Point(15, 54);
            depStatusLabel.Name = "depStatusLabel";
            depStatusLabel.Size = new System.Drawing.Size(40, 13);
            depStatusLabel.TabIndex = 3;
            depStatusLabel.Text = "Status:";
            // 
            // depNameDataGridViewTextBoxColumn
            // 
            this.depNameDataGridViewTextBoxColumn.DataPropertyName = "DepName";
            this.depNameDataGridViewTextBoxColumn.HeaderText = "DepName";
            this.depNameDataGridViewTextBoxColumn.Name = "depNameDataGridViewTextBoxColumn";
            this.depNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // depIdDataGridViewTextBoxColumn
            // 
            this.depIdDataGridViewTextBoxColumn.DataPropertyName = "DepId";
            this.depIdDataGridViewTextBoxColumn.HeaderText = "DepId";
            this.depIdDataGridViewTextBoxColumn.Name = "depIdDataGridViewTextBoxColumn";
            this.depIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // depStatusDataGridViewTextBoxColumn
            // 
            this.depStatusDataGridViewTextBoxColumn.DataPropertyName = "DepStatus";
            this.depStatusDataGridViewTextBoxColumn.HeaderText = "DepStatus";
            this.depStatusDataGridViewTextBoxColumn.Name = "depStatusDataGridViewTextBoxColumn";
            this.depStatusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // depIdTextBox
            // 
            this.depIdTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.depIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "DepId", true));
            this.depIdTextBox.Location = new System.Drawing.Point(84, 25);
            this.depIdTextBox.Name = "depIdTextBox";
            this.depIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.depIdTextBox.TabIndex = 2;
            // 
            // depStatusTextBox
            // 
            this.depStatusTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.depStatusTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "DepStatus", true));
            this.depStatusTextBox.Location = new System.Drawing.Point(84, 51);
            this.depStatusTextBox.Name = "depStatusTextBox";
            this.depStatusTextBox.Size = new System.Drawing.Size(100, 20);
            this.depStatusTextBox.TabIndex = 4;
            // 
            // FormMasterDepartment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterDepartment";
            this.TabText = "Master Bagian";
            this.Text = "Master Bagian";
            this.Load += new System.EventHandler(this.FormMasterDepartment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn depNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn depIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn depStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox depIdTextBox;
        private System.Windows.Forms.TextBox depStatusTextBox;
    }
}
