namespace Inventori.Apotek.Forms
{
    partial class FormMasterBank
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
            System.Windows.Forms.Label bankAddressLabel;
            System.Windows.Forms.Label bankIdLabel;
            System.Windows.Forms.Label bankLimitGiroPerMonthLabel;
            System.Windows.Forms.Label bankNameLabel;
            this.bankAddressTextBox = new System.Windows.Forms.TextBox();
            this.bankIdTextBox = new System.Windows.Forms.TextBox();
            this.bankLimitGiroPerMonthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.bankNameTextBox = new System.Windows.Forms.TextBox();
            bankAddressLabel = new System.Windows.Forms.Label();
            bankIdLabel = new System.Windows.Forms.Label();
            bankLimitGiroPerMonthLabel = new System.Windows.Forms.Label();
            bankNameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bankLimitGiroPerMonthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MBank);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(bankAddressLabel);
            this.groupBox1.Controls.Add(this.bankAddressTextBox);
            this.groupBox1.Controls.Add(bankIdLabel);
            this.groupBox1.Controls.Add(this.bankIdTextBox);
            this.groupBox1.Controls.Add(bankLimitGiroPerMonthLabel);
            this.groupBox1.Controls.Add(this.bankLimitGiroPerMonthNumericUpDown);
            this.groupBox1.Controls.Add(bankNameLabel);
            this.groupBox1.Controls.Add(this.bankNameTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 129);
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.bankNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(bankNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.bankLimitGiroPerMonthNumericUpDown, 0);
            this.groupBox1.Controls.SetChildIndex(bankLimitGiroPerMonthLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.bankIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(bankIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.bankAddressTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(bankAddressLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 129;
            // 
            // bankAddressLabel
            // 
            bankAddressLabel.AutoSize = true;
            bankAddressLabel.Location = new System.Drawing.Point(8, 74);
            bankAddressLabel.Name = "bankAddressLabel";
            bankAddressLabel.Size = new System.Drawing.Size(73, 13);
            bankAddressLabel.TabIndex = 1;
            bankAddressLabel.Text = "Alamat Bank :";
            // 
            // bankIdLabel
            // 
            bankIdLabel.AutoSize = true;
            bankIdLabel.Location = new System.Drawing.Point(8, 22);
            bankIdLabel.Name = "bankIdLabel";
            bankIdLabel.Size = new System.Drawing.Size(66, 13);
            bankIdLabel.TabIndex = 3;
            bankIdLabel.Text = "Kode Bank :";
            // 
            // bankLimitGiroPerMonthLabel
            // 
            bankLimitGiroPerMonthLabel.AutoSize = true;
            bankLimitGiroPerMonthLabel.Location = new System.Drawing.Point(341, 41);
            bankLimitGiroPerMonthLabel.Name = "bankLimitGiroPerMonthLabel";
            bankLimitGiroPerMonthLabel.Size = new System.Drawing.Size(133, 13);
            bankLimitGiroPerMonthLabel.TabIndex = 5;
            bankLimitGiroPerMonthLabel.Text = "Bank Limit Giro Per Month:";
            bankLimitGiroPerMonthLabel.Visible = false;
            // 
            // bankNameLabel
            // 
            bankNameLabel.AutoSize = true;
            bankNameLabel.Location = new System.Drawing.Point(8, 48);
            bankNameLabel.Name = "bankNameLabel";
            bankNameLabel.Size = new System.Drawing.Size(69, 13);
            bankNameLabel.TabIndex = 7;
            bankNameLabel.Text = "Nama Bank :";
            // 
            // bankAddressTextBox
            // 
            this.bankAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "BankAddress", true));
            this.bankAddressTextBox.Location = new System.Drawing.Point(147, 71);
            this.bankAddressTextBox.Multiline = true;
            this.bankAddressTextBox.Name = "bankAddressTextBox";
            this.bankAddressTextBox.Size = new System.Drawing.Size(231, 52);
            this.bankAddressTextBox.TabIndex = 2;
            this.bankAddressTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // bankIdTextBox
            // 
            this.bankIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "BankId", true));
            this.bankIdTextBox.Location = new System.Drawing.Point(147, 19);
            this.bankIdTextBox.Name = "bankIdTextBox";
            this.bankIdTextBox.Size = new System.Drawing.Size(158, 20);
            this.bankIdTextBox.TabIndex = 4;
            this.bankIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // bankLimitGiroPerMonthNumericUpDown
            // 
            this.bankLimitGiroPerMonthNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource_Master, "BankLimitGiroPerMonth", true));
            this.bankLimitGiroPerMonthNumericUpDown.Location = new System.Drawing.Point(480, 41);
            this.bankLimitGiroPerMonthNumericUpDown.Name = "bankLimitGiroPerMonthNumericUpDown";
            this.bankLimitGiroPerMonthNumericUpDown.Size = new System.Drawing.Size(158, 20);
            this.bankLimitGiroPerMonthNumericUpDown.TabIndex = 6;
            this.bankLimitGiroPerMonthNumericUpDown.Visible = false;
            // 
            // bankNameTextBox
            // 
            this.bankNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "BankName", true));
            this.bankNameTextBox.Location = new System.Drawing.Point(147, 45);
            this.bankNameTextBox.Name = "bankNameTextBox";
            this.bankNameTextBox.Size = new System.Drawing.Size(158, 20);
            this.bankNameTextBox.TabIndex = 8;
            this.bankNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // FormMasterBank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterBank";
            this.Text = "FormMasterBank";
            this.Load += new System.EventHandler(this.FormMasterBank_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bankLimitGiroPerMonthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox bankAddressTextBox;
        private System.Windows.Forms.TextBox bankIdTextBox;
        private System.Windows.Forms.NumericUpDown bankLimitGiroPerMonthNumericUpDown;
        private System.Windows.Forms.TextBox bankNameTextBox;
    }
}