namespace Inventori.Contractor.Forms
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
            System.Windows.Forms.Label depNameLabel;
            this.depNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depIdTextBox = new System.Windows.Forms.TextBox();
            this.depNameTextBox = new System.Windows.Forms.TextBox();
            depIdLabel = new System.Windows.Forms.Label();
            depNameLabel = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(depNameLabel);
            this.groupBox1.Controls.Add(this.depNameTextBox);
            this.groupBox1.Controls.Add(depIdLabel);
            this.groupBox1.Controls.Add(this.depIdTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 79);
            this.groupBox1.Text = "Master Detail Bagian";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.depIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(depIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.depNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(depNameLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 79;
            // 
            // depIdLabel
            // 
            depIdLabel.AutoSize = true;
            depIdLabel.Location = new System.Drawing.Point(15, 28);
            depIdLabel.Name = "depIdLabel";
            depIdLabel.Size = new System.Drawing.Size(74, 13);
            depIdLabel.TabIndex = 1;
            depIdLabel.Text = "Kode Bagian :";
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
            this.depIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "DepId", true));
            this.depIdTextBox.Location = new System.Drawing.Point(95, 25);
            this.depIdTextBox.Name = "depIdTextBox";
            this.depIdTextBox.Size = new System.Drawing.Size(147, 20);
            this.depIdTextBox.TabIndex = 2;
            this.depIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // depNameLabel
            // 
            depNameLabel.AutoSize = true;
            depNameLabel.Location = new System.Drawing.Point(17, 54);
            depNameLabel.Name = "depNameLabel";
            depNameLabel.Size = new System.Drawing.Size(77, 13);
            depNameLabel.TabIndex = 3;
            depNameLabel.Text = "Nama Bagian :";
            // 
            // depNameTextBox
            // 
            this.depNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "DepName", true));
            this.depNameTextBox.Location = new System.Drawing.Point(95, 51);
            this.depNameTextBox.Name = "depNameTextBox";
            this.depNameTextBox.Size = new System.Drawing.Size(147, 20);
            this.depNameTextBox.TabIndex = 4;
            this.depNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
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
        private System.Windows.Forms.TextBox depNameTextBox;
    }
}
