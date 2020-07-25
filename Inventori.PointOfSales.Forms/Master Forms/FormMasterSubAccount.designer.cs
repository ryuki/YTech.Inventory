namespace Inventori.PointOfSales.Forms
{
    partial class FormMasterSubAccount
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
            System.Windows.Forms.Label accountIdLabel;
            System.Windows.Forms.Label subAccountDescLabel;
            System.Windows.Forms.Label subAccountIdLabel;
            System.Windows.Forms.Label subAccountNameLabel;
            System.Windows.Forms.Label subAccountSaldoLabel;
            this.accountIdTextBox = new System.Windows.Forms.TextBox();
            this.subAccountDescTextBox = new System.Windows.Forms.TextBox();
            this.subAccountIdTextBox = new System.Windows.Forms.TextBox();
            this.subAccountNameTextBox = new System.Windows.Forms.TextBox();
            this.subAccountSaldoNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.accountNameTextBox = new System.Windows.Forms.TextBox();
            accountIdLabel = new System.Windows.Forms.Label();
            subAccountDescLabel = new System.Windows.Forms.Label();
            subAccountIdLabel = new System.Windows.Forms.Label();
            subAccountNameLabel = new System.Windows.Forms.Label();
            subAccountSaldoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.subAccountSaldoNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MSubAccount);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.accountNameTextBox);
            this.groupBox1.Controls.Add(accountIdLabel);
            this.groupBox1.Controls.Add(this.accountIdTextBox);
            this.groupBox1.Controls.Add(subAccountDescLabel);
            this.groupBox1.Controls.Add(this.subAccountDescTextBox);
            this.groupBox1.Controls.Add(subAccountIdLabel);
            this.groupBox1.Controls.Add(this.subAccountIdTextBox);
            this.groupBox1.Controls.Add(subAccountNameLabel);
            this.groupBox1.Controls.Add(this.subAccountNameTextBox);
            this.groupBox1.Controls.Add(subAccountSaldoLabel);
            this.groupBox1.Controls.Add(this.subAccountSaldoNumericUpDown);
            this.groupBox1.Size = new System.Drawing.Size(788, 217);
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.subAccountSaldoNumericUpDown, 0);
            this.groupBox1.Controls.SetChildIndex(subAccountSaldoLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.subAccountNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(subAccountNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.subAccountIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(subAccountIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.subAccountDescTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(subAccountDescLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.accountIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(accountIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.accountNameTextBox, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 217;
            // 
            // accountIdLabel
            // 
            accountIdLabel.AutoSize = true;
            accountIdLabel.Location = new System.Drawing.Point(6, 28);
            accountIdLabel.Name = "accountIdLabel";
            accountIdLabel.Size = new System.Drawing.Size(73, 13);
            accountIdLabel.TabIndex = 1;
            accountIdLabel.Text = "POS Neraca :";
            // 
            // subAccountDescLabel
            // 
            subAccountDescLabel.AutoSize = true;
            subAccountDescLabel.Location = new System.Drawing.Point(6, 158);
            subAccountDescLabel.Name = "subAccountDescLabel";
            subAccountDescLabel.Size = new System.Drawing.Size(68, 13);
            subAccountDescLabel.TabIndex = 3;
            subAccountDescLabel.Text = "Keterangan :";
            // 
            // subAccountIdLabel
            // 
            subAccountIdLabel.AutoSize = true;
            subAccountIdLabel.Location = new System.Drawing.Point(6, 80);
            subAccountIdLabel.Name = "subAccountIdLabel";
            subAccountIdLabel.Size = new System.Drawing.Size(87, 13);
            subAccountIdLabel.TabIndex = 5;
            subAccountIdLabel.Text = "Kode Rekening :";
            // 
            // subAccountNameLabel
            // 
            subAccountNameLabel.AutoSize = true;
            subAccountNameLabel.Location = new System.Drawing.Point(6, 106);
            subAccountNameLabel.Name = "subAccountNameLabel";
            subAccountNameLabel.Size = new System.Drawing.Size(90, 13);
            subAccountNameLabel.TabIndex = 7;
            subAccountNameLabel.Text = "Nama Rekening :";
            // 
            // subAccountSaldoLabel
            // 
            subAccountSaldoLabel.AutoSize = true;
            subAccountSaldoLabel.Location = new System.Drawing.Point(6, 129);
            subAccountSaldoLabel.Name = "subAccountSaldoLabel";
            subAccountSaldoLabel.Size = new System.Drawing.Size(40, 13);
            subAccountSaldoLabel.TabIndex = 9;
            subAccountSaldoLabel.Text = "Saldo :";
            // 
            // accountIdTextBox
            // 
            this.accountIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "AccountId", true));
            this.accountIdTextBox.Location = new System.Drawing.Point(115, 25);
            this.accountIdTextBox.Name = "accountIdTextBox";
            this.accountIdTextBox.Size = new System.Drawing.Size(64, 20);
            this.accountIdTextBox.TabIndex = 2;
            this.accountIdTextBox.Enter += new System.EventHandler(this.accountIdTextBox_Enter);
            this.accountIdTextBox.Leave += new System.EventHandler(this.accountIdTextBox_Leave);
            this.accountIdTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.accountIdTextBox_Validating);
            // 
            // subAccountDescTextBox
            // 
            this.subAccountDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SubAccountDesc", true));
            this.subAccountDescTextBox.Location = new System.Drawing.Point(115, 155);
            this.subAccountDescTextBox.Multiline = true;
            this.subAccountDescTextBox.Name = "subAccountDescTextBox";
            this.subAccountDescTextBox.Size = new System.Drawing.Size(202, 56);
            this.subAccountDescTextBox.TabIndex = 4;
            // 
            // subAccountIdTextBox
            // 
            this.subAccountIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SubAccountId", true));
            this.subAccountIdTextBox.Location = new System.Drawing.Point(115, 77);
            this.subAccountIdTextBox.Name = "subAccountIdTextBox";
            this.subAccountIdTextBox.Size = new System.Drawing.Size(120, 20);
            this.subAccountIdTextBox.TabIndex = 6;
            // 
            // subAccountNameTextBox
            // 
            this.subAccountNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "SubAccountName", true));
            this.subAccountNameTextBox.Location = new System.Drawing.Point(115, 103);
            this.subAccountNameTextBox.Name = "subAccountNameTextBox";
            this.subAccountNameTextBox.Size = new System.Drawing.Size(202, 20);
            this.subAccountNameTextBox.TabIndex = 8;
            // 
            // subAccountSaldoNumericUpDown
            // 
            this.subAccountSaldoNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource_Master, "SubAccountSaldo", true));
            this.subAccountSaldoNumericUpDown.Location = new System.Drawing.Point(115, 129);
            this.subAccountSaldoNumericUpDown.Name = "subAccountSaldoNumericUpDown";
            this.subAccountSaldoNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.subAccountSaldoNumericUpDown.TabIndex = 10;
            // 
            // accountNameTextBox
            // 
            this.accountNameTextBox.Location = new System.Drawing.Point(115, 51);
            this.accountNameTextBox.Name = "accountNameTextBox";
            this.accountNameTextBox.ReadOnly = true;
            this.accountNameTextBox.Size = new System.Drawing.Size(202, 20);
            this.accountNameTextBox.TabIndex = 11;
            // 
            // FormMasterSubAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterSubAccount";
            this.TabText = "Master Rekening";
            this.Text = "Master Rekening";
            this.Load += new System.EventHandler(this.FormMasterSubAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.subAccountSaldoNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox accountIdTextBox;
        private System.Windows.Forms.TextBox subAccountDescTextBox;
        private System.Windows.Forms.TextBox subAccountIdTextBox;
        private System.Windows.Forms.TextBox subAccountNameTextBox;
        private System.Windows.Forms.NumericUpDown subAccountSaldoNumericUpDown;
        private System.Windows.Forms.TextBox accountNameTextBox;
    }
}