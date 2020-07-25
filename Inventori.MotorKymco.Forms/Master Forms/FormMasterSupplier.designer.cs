namespace Inventori.MotorKymco.Forms
{
    partial class FormMasterSupplier
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
            System.Windows.Forms.Label supplierAddressLabel;
            System.Windows.Forms.Label supplierContactPhoneLabel;
            System.Windows.Forms.Label supplierContactLabel;
            System.Windows.Forms.Label supplierPhoneLabel;
            System.Windows.Forms.Label supplierNameLabel;
            System.Windows.Forms.Label supplierIdLabel;
            System.Windows.Forms.Label supplierNpwpLabel;
            System.Windows.Forms.Label supplierFaxLabel;
            this.supplierContactDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierAddressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierContactPhoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.supplierAddressTextBox = new System.Windows.Forms.TextBox();
            this.supplierContactPhoneTextBox = new System.Windows.Forms.TextBox();
            this.supplierContactTextBox = new System.Windows.Forms.TextBox();
            this.supplierPhoneTextBox = new System.Windows.Forms.TextBox();
            this.supplierNameTextBox = new System.Windows.Forms.TextBox();
            this.supplierIdTextBox = new System.Windows.Forms.TextBox();
            this.supplierNpwpTextBox = new System.Windows.Forms.TextBox();
            this.supplierFaxTextBox = new System.Windows.Forms.TextBox();
            supplierAddressLabel = new System.Windows.Forms.Label();
            supplierContactPhoneLabel = new System.Windows.Forms.Label();
            supplierContactLabel = new System.Windows.Forms.Label();
            supplierPhoneLabel = new System.Windows.Forms.Label();
            supplierNameLabel = new System.Windows.Forms.Label();
            supplierIdLabel = new System.Windows.Forms.Label();
            supplierNpwpLabel = new System.Windows.Forms.Label();
            supplierFaxLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MSupplier);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(supplierFaxLabel);
            this.groupBox1.Controls.Add(this.supplierFaxTextBox);
            this.groupBox1.Controls.Add(supplierNpwpLabel);
            this.groupBox1.Controls.Add(this.supplierNpwpTextBox);
            this.groupBox1.Controls.Add(supplierContactPhoneLabel);
            this.groupBox1.Controls.Add(supplierAddressLabel);
            this.groupBox1.Controls.Add(this.supplierAddressTextBox);
            this.groupBox1.Controls.Add(this.supplierContactPhoneTextBox);
            this.groupBox1.Controls.Add(supplierContactLabel);
            this.groupBox1.Controls.Add(this.supplierContactTextBox);
            this.groupBox1.Controls.Add(supplierPhoneLabel);
            this.groupBox1.Controls.Add(this.supplierPhoneTextBox);
            this.groupBox1.Controls.Add(supplierNameLabel);
            this.groupBox1.Controls.Add(this.supplierNameTextBox);
            this.groupBox1.Controls.Add(supplierIdLabel);
            this.groupBox1.Controls.Add(this.supplierIdTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 288);
            this.groupBox1.Text = "Master Detail Supplier";
            this.groupBox1.Controls.SetChildIndex(this.supplierIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(supplierIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.supplierNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(supplierNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.supplierPhoneTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(supplierPhoneLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.supplierContactTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(supplierContactLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.supplierContactPhoneTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.supplierAddressTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(supplierAddressLabel, 0);
            this.groupBox1.Controls.SetChildIndex(supplierContactPhoneLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.supplierNpwpTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(supplierNpwpLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.supplierFaxTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(supplierFaxLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 288;
            // 
            // supplierAddressLabel
            // 
            supplierAddressLabel.AutoSize = true;
            supplierAddressLabel.Location = new System.Drawing.Point(17, 207);
            supplierAddressLabel.Name = "supplierAddressLabel";
            supplierAddressLabel.Size = new System.Drawing.Size(83, 13);
            supplierAddressLabel.TabIndex = 22;
            supplierAddressLabel.Text = "Alamat Supplier:";
            // 
            // supplierContactPhoneLabel
            // 
            supplierContactPhoneLabel.AutoSize = true;
            supplierContactPhoneLabel.Location = new System.Drawing.Point(15, 181);
            supplierContactPhoneLabel.Name = "supplierContactPhoneLabel";
            supplierContactPhoneLabel.Size = new System.Drawing.Size(85, 13);
            supplierContactPhoneLabel.TabIndex = 20;
            supplierContactPhoneLabel.Text = "No Telp Kontak:";
            // 
            // supplierContactLabel
            // 
            supplierContactLabel.AutoSize = true;
            supplierContactLabel.Location = new System.Drawing.Point(15, 155);
            supplierContactLabel.Name = "supplierContactLabel";
            supplierContactLabel.Size = new System.Drawing.Size(85, 13);
            supplierContactLabel.TabIndex = 18;
            supplierContactLabel.Text = "Kontak Supplier:";
            // 
            // supplierPhoneLabel
            // 
            supplierPhoneLabel.AutoSize = true;
            supplierPhoneLabel.Location = new System.Drawing.Point(17, 103);
            supplierPhoneLabel.Name = "supplierPhoneLabel";
            supplierPhoneLabel.Size = new System.Drawing.Size(72, 13);
            supplierPhoneLabel.TabIndex = 16;
            supplierPhoneLabel.Text = "Telp Supplier:";
            // 
            // supplierNameLabel
            // 
            supplierNameLabel.AutoSize = true;
            supplierNameLabel.Location = new System.Drawing.Point(17, 51);
            supplierNameLabel.Name = "supplierNameLabel";
            supplierNameLabel.Size = new System.Drawing.Size(79, 13);
            supplierNameLabel.TabIndex = 14;
            supplierNameLabel.Text = "Nama Supplier:";
            // 
            // supplierIdLabel
            // 
            supplierIdLabel.AutoSize = true;
            supplierIdLabel.Location = new System.Drawing.Point(17, 25);
            supplierIdLabel.Name = "supplierIdLabel";
            supplierIdLabel.Size = new System.Drawing.Size(76, 13);
            supplierIdLabel.TabIndex = 12;
            supplierIdLabel.Text = "Kode Supplier:";
            // 
            // supplierContactDataGridViewTextBoxColumn
            // 
            this.supplierContactDataGridViewTextBoxColumn.DataPropertyName = "SupplierContact";
            this.supplierContactDataGridViewTextBoxColumn.HeaderText = "SupplierContact";
            this.supplierContactDataGridViewTextBoxColumn.Name = "supplierContactDataGridViewTextBoxColumn";
            this.supplierContactDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierPhoneDataGridViewTextBoxColumn
            // 
            this.supplierPhoneDataGridViewTextBoxColumn.DataPropertyName = "SupplierPhone";
            this.supplierPhoneDataGridViewTextBoxColumn.HeaderText = "SupplierPhone";
            this.supplierPhoneDataGridViewTextBoxColumn.Name = "supplierPhoneDataGridViewTextBoxColumn";
            this.supplierPhoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierAddressDataGridViewTextBoxColumn
            // 
            this.supplierAddressDataGridViewTextBoxColumn.DataPropertyName = "SupplierAddress";
            this.supplierAddressDataGridViewTextBoxColumn.HeaderText = "SupplierAddress";
            this.supplierAddressDataGridViewTextBoxColumn.Name = "supplierAddressDataGridViewTextBoxColumn";
            this.supplierAddressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierIdDataGridViewTextBoxColumn
            // 
            this.supplierIdDataGridViewTextBoxColumn.DataPropertyName = "SupplierId";
            this.supplierIdDataGridViewTextBoxColumn.HeaderText = "SupplierId";
            this.supplierIdDataGridViewTextBoxColumn.Name = "supplierIdDataGridViewTextBoxColumn";
            this.supplierIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierNameDataGridViewTextBoxColumn
            // 
            this.supplierNameDataGridViewTextBoxColumn.DataPropertyName = "SupplierName";
            this.supplierNameDataGridViewTextBoxColumn.HeaderText = "SupplierName";
            this.supplierNameDataGridViewTextBoxColumn.Name = "supplierNameDataGridViewTextBoxColumn";
            this.supplierNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierContactPhoneDataGridViewTextBoxColumn
            // 
            this.supplierContactPhoneDataGridViewTextBoxColumn.DataPropertyName = "SupplierContactPhone";
            this.supplierContactPhoneDataGridViewTextBoxColumn.HeaderText = "SupplierContactPhone";
            this.supplierContactPhoneDataGridViewTextBoxColumn.Name = "supplierContactPhoneDataGridViewTextBoxColumn";
            this.supplierContactPhoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // supplierAddressTextBox
            // 
            this.supplierAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SupplierAddress", true));
            this.supplierAddressTextBox.Location = new System.Drawing.Point(113, 204);
            this.supplierAddressTextBox.Multiline = true;
            this.supplierAddressTextBox.Name = "supplierAddressTextBox";
            this.supplierAddressTextBox.Size = new System.Drawing.Size(258, 64);
            this.supplierAddressTextBox.TabIndex = 23;
            this.supplierAddressTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // supplierContactPhoneTextBox
            // 
            this.supplierContactPhoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SupplierContactPhone", true));
            this.supplierContactPhoneTextBox.Location = new System.Drawing.Point(113, 178);
            this.supplierContactPhoneTextBox.Name = "supplierContactPhoneTextBox";
            this.supplierContactPhoneTextBox.Size = new System.Drawing.Size(142, 20);
            this.supplierContactPhoneTextBox.TabIndex = 21;
            this.supplierContactPhoneTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // supplierContactTextBox
            // 
            this.supplierContactTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SupplierContact", true));
            this.supplierContactTextBox.Location = new System.Drawing.Point(113, 152);
            this.supplierContactTextBox.Name = "supplierContactTextBox";
            this.supplierContactTextBox.Size = new System.Drawing.Size(191, 20);
            this.supplierContactTextBox.TabIndex = 19;
            this.supplierContactTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // supplierPhoneTextBox
            // 
            this.supplierPhoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SupplierPhone", true));
            this.supplierPhoneTextBox.Location = new System.Drawing.Point(113, 100);
            this.supplierPhoneTextBox.Name = "supplierPhoneTextBox";
            this.supplierPhoneTextBox.Size = new System.Drawing.Size(142, 20);
            this.supplierPhoneTextBox.TabIndex = 17;
            this.supplierPhoneTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // supplierNameTextBox
            // 
            this.supplierNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SupplierName", true));
            this.supplierNameTextBox.Location = new System.Drawing.Point(113, 48);
            this.supplierNameTextBox.Name = "supplierNameTextBox";
            this.supplierNameTextBox.Size = new System.Drawing.Size(191, 20);
            this.supplierNameTextBox.TabIndex = 15;
            this.supplierNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // supplierIdTextBox
            // 
            this.supplierIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SupplierId", true));
            this.supplierIdTextBox.Location = new System.Drawing.Point(113, 22);
            this.supplierIdTextBox.Name = "supplierIdTextBox";
            this.supplierIdTextBox.Size = new System.Drawing.Size(100, 20);
            this.supplierIdTextBox.TabIndex = 13;
            this.supplierIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // supplierNpwpLabel
            // 
            supplierNpwpLabel.AutoSize = true;
            supplierNpwpLabel.Location = new System.Drawing.Point(17, 77);
            supplierNpwpLabel.Name = "supplierNpwpLabel";
            supplierNpwpLabel.Size = new System.Drawing.Size(46, 13);
            supplierNpwpLabel.TabIndex = 23;
            supplierNpwpLabel.Text = "NPWP :";
            // 
            // supplierNpwpTextBox
            // 
            this.supplierNpwpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SupplierNpwp", true));
            this.supplierNpwpTextBox.Location = new System.Drawing.Point(113, 74);
            this.supplierNpwpTextBox.Name = "supplierNpwpTextBox";
            this.supplierNpwpTextBox.Size = new System.Drawing.Size(142, 20);
            this.supplierNpwpTextBox.TabIndex = 24;
            // 
            // supplierFaxLabel
            // 
            supplierFaxLabel.AutoSize = true;
            supplierFaxLabel.Location = new System.Drawing.Point(17, 129);
            supplierFaxLabel.Name = "supplierFaxLabel";
            supplierFaxLabel.Size = new System.Drawing.Size(47, 13);
            supplierFaxLabel.TabIndex = 24;
            supplierFaxLabel.Text = "No Fax :";
            // 
            // supplierFaxTextBox
            // 
            this.supplierFaxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SupplierFax", true));
            this.supplierFaxTextBox.Location = new System.Drawing.Point(113, 126);
            this.supplierFaxTextBox.Name = "supplierFaxTextBox";
            this.supplierFaxTextBox.Size = new System.Drawing.Size(142, 20);
            this.supplierFaxTextBox.TabIndex = 25;
            // 
            // FormMasterSupplier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterSupplier";
            this.TabText = "Master Supplier";
            this.Text = "Master Supplier";
            this.Load += new System.EventHandler(this.FormMasterSupplier_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn supplierContactDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierAddressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierContactPhoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox supplierAddressTextBox;
        private System.Windows.Forms.TextBox supplierContactPhoneTextBox;
        private System.Windows.Forms.TextBox supplierContactTextBox;
        private System.Windows.Forms.TextBox supplierPhoneTextBox;
        private System.Windows.Forms.TextBox supplierNameTextBox;
        private System.Windows.Forms.TextBox supplierIdTextBox;
        private System.Windows.Forms.TextBox supplierNpwpTextBox;
        private System.Windows.Forms.TextBox supplierFaxTextBox;
    }
}
