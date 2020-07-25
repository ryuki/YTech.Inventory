namespace Inventori.Contractor.Forms
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label supplierAddressLabel;
            System.Windows.Forms.Label supplierContactPhoneLabel;
            System.Windows.Forms.Label supplierContactLabel;
            System.Windows.Forms.Label supplierPhoneLabel;
            System.Windows.Forms.Label supplierNameLabel;
            System.Windows.Forms.Label supplierIdLabel;
            System.Windows.Forms.Label bankIdLabel;
            System.Windows.Forms.Label supplierAccountNameLabel;
            System.Windows.Forms.Label supplierAccountNoLabel;
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
            this.bankIdComboBox = new System.Windows.Forms.ComboBox();
            this.mSupplierAccountBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supplierAccountNameTextBox = new System.Windows.Forms.TextBox();
            this.supplierAccountNoTextBox = new System.Windows.Forms.TextBox();
            this.tabControl_Account = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            supplierAddressLabel = new System.Windows.Forms.Label();
            supplierContactPhoneLabel = new System.Windows.Forms.Label();
            supplierContactLabel = new System.Windows.Forms.Label();
            supplierPhoneLabel = new System.Windows.Forms.Label();
            supplierNameLabel = new System.Windows.Forms.Label();
            supplierIdLabel = new System.Windows.Forms.Label();
            bankIdLabel = new System.Windows.Forms.Label();
            supplierAccountNameLabel = new System.Windows.Forms.Label();
            supplierAccountNoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mSupplierAccountBindingSource)).BeginInit();
            this.tabControl_Account.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MSupplier);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(supplierAddressLabel);
            this.groupBox1.Controls.Add(this.tabControl_Account);
            this.groupBox1.Controls.Add(this.supplierAddressTextBox);
            this.groupBox1.Controls.Add(supplierContactPhoneLabel);
            this.groupBox1.Controls.Add(this.supplierContactPhoneTextBox);
            this.groupBox1.Controls.Add(supplierContactLabel);
            this.groupBox1.Controls.Add(this.supplierContactTextBox);
            this.groupBox1.Controls.Add(supplierPhoneLabel);
            this.groupBox1.Controls.Add(this.supplierPhoneTextBox);
            this.groupBox1.Controls.Add(supplierNameLabel);
            this.groupBox1.Controls.Add(this.supplierNameTextBox);
            this.groupBox1.Controls.Add(supplierIdLabel);
            this.groupBox1.Controls.Add(this.supplierIdTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 229);
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
            this.groupBox1.Controls.SetChildIndex(supplierContactPhoneLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.supplierAddressTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.tabControl_Account, 0);
            this.groupBox1.Controls.SetChildIndex(supplierAddressLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 229;
            // 
            // supplierAddressLabel
            // 
            supplierAddressLabel.AutoSize = true;
            supplierAddressLabel.Location = new System.Drawing.Point(17, 77);
            supplierAddressLabel.Name = "supplierAddressLabel";
            supplierAddressLabel.Size = new System.Drawing.Size(83, 13);
            supplierAddressLabel.TabIndex = 22;
            supplierAddressLabel.Text = "Alamat Supplier:";
            // 
            // supplierContactPhoneLabel
            // 
            supplierContactPhoneLabel.AutoSize = true;
            supplierContactPhoneLabel.Location = new System.Drawing.Point(15, 199);
            supplierContactPhoneLabel.Name = "supplierContactPhoneLabel";
            supplierContactPhoneLabel.Size = new System.Drawing.Size(85, 13);
            supplierContactPhoneLabel.TabIndex = 20;
            supplierContactPhoneLabel.Text = "No Telp Kontak:";
            // 
            // supplierContactLabel
            // 
            supplierContactLabel.AutoSize = true;
            supplierContactLabel.Location = new System.Drawing.Point(15, 173);
            supplierContactLabel.Name = "supplierContactLabel";
            supplierContactLabel.Size = new System.Drawing.Size(85, 13);
            supplierContactLabel.TabIndex = 18;
            supplierContactLabel.Text = "Kontak Supplier:";
            // 
            // supplierPhoneLabel
            // 
            supplierPhoneLabel.AutoSize = true;
            supplierPhoneLabel.Location = new System.Drawing.Point(17, 147);
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
            // bankIdLabel
            // 
            bankIdLabel.AutoSize = true;
            bankIdLabel.Location = new System.Drawing.Point(11, 18);
            bankIdLabel.Name = "bankIdLabel";
            bankIdLabel.Size = new System.Drawing.Size(38, 13);
            bankIdLabel.TabIndex = 0;
            bankIdLabel.Text = "Bank :";
            // 
            // supplierAccountNameLabel
            // 
            supplierAccountNameLabel.AutoSize = true;
            supplierAccountNameLabel.Location = new System.Drawing.Point(11, 45);
            supplierAccountNameLabel.Name = "supplierAccountNameLabel";
            supplierAccountNameLabel.Size = new System.Drawing.Size(114, 13);
            supplierAccountNameLabel.TabIndex = 2;
            supplierAccountNameLabel.Text = "Rekening Atas Nama :";
            // 
            // supplierAccountNoLabel
            // 
            supplierAccountNoLabel.AutoSize = true;
            supplierAccountNoLabel.Location = new System.Drawing.Point(11, 71);
            supplierAccountNoLabel.Name = "supplierAccountNoLabel";
            supplierAccountNoLabel.Size = new System.Drawing.Size(93, 13);
            supplierAccountNoLabel.TabIndex = 4;
            supplierAccountNoLabel.Text = "Nomor Rekening :";
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
            this.supplierAddressTextBox.Location = new System.Drawing.Point(113, 74);
            this.supplierAddressTextBox.Multiline = true;
            this.supplierAddressTextBox.Name = "supplierAddressTextBox";
            this.supplierAddressTextBox.Size = new System.Drawing.Size(217, 64);
            this.supplierAddressTextBox.TabIndex = 23;
            this.supplierAddressTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // supplierContactPhoneTextBox
            // 
            this.supplierContactPhoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SupplierContactPhone", true));
            this.supplierContactPhoneTextBox.Location = new System.Drawing.Point(113, 196);
            this.supplierContactPhoneTextBox.Name = "supplierContactPhoneTextBox";
            this.supplierContactPhoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.supplierContactPhoneTextBox.TabIndex = 21;
            this.supplierContactPhoneTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // supplierContactTextBox
            // 
            this.supplierContactTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SupplierContact", true));
            this.supplierContactTextBox.Location = new System.Drawing.Point(113, 170);
            this.supplierContactTextBox.Name = "supplierContactTextBox";
            this.supplierContactTextBox.Size = new System.Drawing.Size(100, 20);
            this.supplierContactTextBox.TabIndex = 19;
            this.supplierContactTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // supplierPhoneTextBox
            // 
            this.supplierPhoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SupplierPhone", true));
            this.supplierPhoneTextBox.Location = new System.Drawing.Point(113, 144);
            this.supplierPhoneTextBox.Name = "supplierPhoneTextBox";
            this.supplierPhoneTextBox.Size = new System.Drawing.Size(100, 20);
            this.supplierPhoneTextBox.TabIndex = 17;
            this.supplierPhoneTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // supplierNameTextBox
            // 
            this.supplierNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SupplierName", true));
            this.supplierNameTextBox.Location = new System.Drawing.Point(113, 48);
            this.supplierNameTextBox.Name = "supplierNameTextBox";
            this.supplierNameTextBox.Size = new System.Drawing.Size(100, 20);
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
            // bankIdComboBox
            // 
            this.bankIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mSupplierAccountBindingSource, "BankId", true));
            this.bankIdComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bankIdComboBox.FormattingEnabled = true;
            this.bankIdComboBox.Location = new System.Drawing.Point(139, 15);
            this.bankIdComboBox.Name = "bankIdComboBox";
            this.bankIdComboBox.Size = new System.Drawing.Size(152, 21);
            this.bankIdComboBox.TabIndex = 1;
            this.bankIdComboBox.ValueMember = "BankId";
            this.bankIdComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // mSupplierAccountBindingSource
            // 
            this.mSupplierAccountBindingSource.DataSource = typeof(Inventori.Data.MSupplierAccount);
            // 
            // supplierAccountNameTextBox
            // 
            this.supplierAccountNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mSupplierAccountBindingSource, "SupplierAccountName", true));
            this.supplierAccountNameTextBox.Location = new System.Drawing.Point(139, 42);
            this.supplierAccountNameTextBox.Name = "supplierAccountNameTextBox";
            this.supplierAccountNameTextBox.Size = new System.Drawing.Size(152, 20);
            this.supplierAccountNameTextBox.TabIndex = 3;
            this.supplierAccountNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // supplierAccountNoTextBox
            // 
            this.supplierAccountNoTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mSupplierAccountBindingSource, "SupplierAccountNo", true));
            this.supplierAccountNoTextBox.Location = new System.Drawing.Point(139, 68);
            this.supplierAccountNoTextBox.Name = "supplierAccountNoTextBox";
            this.supplierAccountNoTextBox.Size = new System.Drawing.Size(152, 20);
            this.supplierAccountNoTextBox.TabIndex = 5;
            this.supplierAccountNoTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // tabControl_Account
            // 
            this.tabControl_Account.Controls.Add(this.tabPage2);
            this.tabControl_Account.Location = new System.Drawing.Point(348, 19);
            this.tabControl_Account.Name = "tabControl_Account";
            this.tabControl_Account.SelectedIndex = 0;
            this.tabControl_Account.Size = new System.Drawing.Size(319, 141);
            this.tabControl_Account.TabIndex = 25;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(bankIdLabel);
            this.tabPage2.Controls.Add(supplierAccountNoLabel);
            this.tabPage2.Controls.Add(this.bankIdComboBox);
            this.tabPage2.Controls.Add(this.supplierAccountNoTextBox);
            this.tabPage2.Controls.Add(supplierAccountNameLabel);
            this.tabPage2.Controls.Add(this.supplierAccountNameTextBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(311, 115);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.mSupplierAccountBindingSource)).EndInit();
            this.tabControl_Account.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
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
        private System.Windows.Forms.ComboBox bankIdComboBox;
        private System.Windows.Forms.BindingSource mSupplierAccountBindingSource;
        private System.Windows.Forms.TextBox supplierAccountNameTextBox;
        private System.Windows.Forms.TextBox supplierAccountNoTextBox;
        private System.Windows.Forms.TabControl tabControl_Account;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
