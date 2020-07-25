namespace Inventori.Contractor.Forms
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
            this.groupNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupIdLabel1 = new System.Windows.Forms.Label();
            this.groupNameTextBox = new System.Windows.Forms.TextBox();
            groupIdLabel = new System.Windows.Forms.Label();
            groupNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MGroup);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(groupIdLabel);
            this.groupBox1.Controls.Add(this.groupIdLabel1);
            this.groupBox1.Controls.Add(groupNameLabel);
            this.groupBox1.Controls.Add(this.groupNameTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 86);
            this.groupBox1.Text = "Master Detail Master Golongan Item";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.groupNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(groupNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.groupIdLabel1, 0);
            this.groupBox1.Controls.SetChildIndex(groupIdLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 86;
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
    }
}
