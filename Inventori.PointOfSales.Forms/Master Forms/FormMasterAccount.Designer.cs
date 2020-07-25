namespace Inventori.PointOfSales.Forms
{
    partial class FormMasterAccount
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
            System.Windows.Forms.Label accountDescLabel;
            System.Windows.Forms.Label accountIdLabel;
            System.Windows.Forms.Label accountNameLabel;
            System.Windows.Forms.Label accountSaldoLabel;
            System.Windows.Forms.Label accountStatusLabel;
            System.Windows.Forms.Label accountPositionLabel;
            this.accountDescTextBox = new System.Windows.Forms.TextBox();
            this.accountIdTextBox = new System.Windows.Forms.TextBox();
            this.accountNameTextBox = new System.Windows.Forms.TextBox();
            this.accountSaldoNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.accountStatusDebetRadioButton = new System.Windows.Forms.RadioButton();
            this.accountStatusKreditRadioButton = new System.Windows.Forms.RadioButton();
            this.accountPositionComboBox = new System.Windows.Forms.ComboBox();
            accountDescLabel = new System.Windows.Forms.Label();
            accountIdLabel = new System.Windows.Forms.Label();
            accountNameLabel = new System.Windows.Forms.Label();
            accountSaldoLabel = new System.Windows.Forms.Label();
            accountStatusLabel = new System.Windows.Forms.Label();
            accountPositionLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accountSaldoNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MAccount);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(accountPositionLabel);
            this.groupBox1.Controls.Add(this.accountPositionComboBox);
            this.groupBox1.Controls.Add(this.accountStatusKreditRadioButton);
            this.groupBox1.Controls.Add(accountDescLabel);
            this.groupBox1.Controls.Add(this.accountDescTextBox);
            this.groupBox1.Controls.Add(accountIdLabel);
            this.groupBox1.Controls.Add(this.accountIdTextBox);
            this.groupBox1.Controls.Add(accountNameLabel);
            this.groupBox1.Controls.Add(this.accountNameTextBox);
            this.groupBox1.Controls.Add(accountSaldoLabel);
            this.groupBox1.Controls.Add(this.accountSaldoNumericUpDown);
            this.groupBox1.Controls.Add(accountStatusLabel);
            this.groupBox1.Controls.Add(this.accountStatusDebetRadioButton);
            this.groupBox1.Size = new System.Drawing.Size(788, 234);
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.accountStatusDebetRadioButton, 0);
            this.groupBox1.Controls.SetChildIndex(accountStatusLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.accountSaldoNumericUpDown, 0);
            this.groupBox1.Controls.SetChildIndex(accountSaldoLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.accountNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(accountNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.accountIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(accountIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.accountDescTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(accountDescLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.accountStatusKreditRadioButton, 0);
            this.groupBox1.Controls.SetChildIndex(this.accountPositionComboBox, 0);
            this.groupBox1.Controls.SetChildIndex(accountPositionLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 234;
            // 
            // accountDescLabel
            // 
            accountDescLabel.AutoSize = true;
            accountDescLabel.Location = new System.Drawing.Point(15, 161);
            accountDescLabel.Name = "accountDescLabel";
            accountDescLabel.Size = new System.Drawing.Size(68, 13);
            accountDescLabel.TabIndex = 1;
            accountDescLabel.Text = "Keterangan :";
            // 
            // accountIdLabel
            // 
            accountIdLabel.AutoSize = true;
            accountIdLabel.Location = new System.Drawing.Point(15, 29);
            accountIdLabel.Name = "accountIdLabel";
            accountIdLabel.Size = new System.Drawing.Size(63, 13);
            accountIdLabel.TabIndex = 3;
            accountIdLabel.Text = "Kode POS :";
            // 
            // accountNameLabel
            // 
            accountNameLabel.AutoSize = true;
            accountNameLabel.Location = new System.Drawing.Point(15, 55);
            accountNameLabel.Name = "accountNameLabel";
            accountNameLabel.Size = new System.Drawing.Size(66, 13);
            accountNameLabel.TabIndex = 5;
            accountNameLabel.Text = "Nama POS :";
            // 
            // accountSaldoLabel
            // 
            accountSaldoLabel.AutoSize = true;
            accountSaldoLabel.Location = new System.Drawing.Point(15, 78);
            accountSaldoLabel.Name = "accountSaldoLabel";
            accountSaldoLabel.Size = new System.Drawing.Size(40, 13);
            accountSaldoLabel.TabIndex = 7;
            accountSaldoLabel.Text = "Saldo :";
            // 
            // accountStatusLabel
            // 
            accountStatusLabel.AutoSize = true;
            accountStatusLabel.Location = new System.Drawing.Point(15, 110);
            accountStatusLabel.Name = "accountStatusLabel";
            accountStatusLabel.Size = new System.Drawing.Size(43, 13);
            accountStatusLabel.TabIndex = 9;
            accountStatusLabel.Text = "Status :";
            // 
            // accountDescTextBox
            // 
            this.accountDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "AccountDesc", true));
            this.accountDescTextBox.Location = new System.Drawing.Point(104, 161);
            this.accountDescTextBox.Multiline = true;
            this.accountDescTextBox.Name = "accountDescTextBox";
            this.accountDescTextBox.Size = new System.Drawing.Size(226, 62);
            this.accountDescTextBox.TabIndex = 2;
            // 
            // accountIdTextBox
            // 
            this.accountIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "AccountId", true));
            this.accountIdTextBox.Location = new System.Drawing.Point(104, 26);
            this.accountIdTextBox.Name = "accountIdTextBox";
            this.accountIdTextBox.Size = new System.Drawing.Size(80, 20);
            this.accountIdTextBox.TabIndex = 4;
            // 
            // accountNameTextBox
            // 
            this.accountNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "AccountName", true));
            this.accountNameTextBox.Location = new System.Drawing.Point(104, 52);
            this.accountNameTextBox.Name = "accountNameTextBox";
            this.accountNameTextBox.Size = new System.Drawing.Size(151, 20);
            this.accountNameTextBox.TabIndex = 6;
            // 
            // accountSaldoNumericUpDown
            // 
            this.accountSaldoNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource_Master, "AccountSaldo", true));
            this.accountSaldoNumericUpDown.Location = new System.Drawing.Point(104, 78);
            this.accountSaldoNumericUpDown.Name = "accountSaldoNumericUpDown";
            this.accountSaldoNumericUpDown.Size = new System.Drawing.Size(151, 20);
            this.accountSaldoNumericUpDown.TabIndex = 8;
            // 
            // accountStatusDebetRadioButton
            // 
            this.accountStatusDebetRadioButton.Location = new System.Drawing.Point(104, 104);
            this.accountStatusDebetRadioButton.Name = "accountStatusDebetRadioButton";
            this.accountStatusDebetRadioButton.Size = new System.Drawing.Size(61, 24);
            this.accountStatusDebetRadioButton.TabIndex = 10;
            this.accountStatusDebetRadioButton.Text = "Debet";
            // 
            // accountStatusKreditRadioButton
            // 
            this.accountStatusKreditRadioButton.Location = new System.Drawing.Point(171, 104);
            this.accountStatusKreditRadioButton.Name = "accountStatusKreditRadioButton";
            this.accountStatusKreditRadioButton.Size = new System.Drawing.Size(61, 24);
            this.accountStatusKreditRadioButton.TabIndex = 11;
            this.accountStatusKreditRadioButton.Text = "Kredit";
            // 
            // accountPositionLabel
            // 
            accountPositionLabel.AutoSize = true;
            accountPositionLabel.Location = new System.Drawing.Point(15, 137);
            accountPositionLabel.Name = "accountPositionLabel";
            accountPositionLabel.Size = new System.Drawing.Size(40, 13);
            accountPositionLabel.TabIndex = 12;
            accountPositionLabel.Text = "Posisi :";
            // 
            // accountPositionComboBox
            // 
            this.accountPositionComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "AccountPosition", true));
            this.accountPositionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountPositionComboBox.FormattingEnabled = true;
            this.accountPositionComboBox.Location = new System.Drawing.Point(104, 134);
            this.accountPositionComboBox.Name = "accountPositionComboBox";
            this.accountPositionComboBox.Size = new System.Drawing.Size(140, 21);
            this.accountPositionComboBox.TabIndex = 13;
            // 
            // FormMasterAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterAccount";
            this.TabText = "Master POS Neraca";
            this.Text = "Master POS Neraca";
            this.Load += new System.EventHandler(this.FormMasterAccount_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accountSaldoNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox accountDescTextBox;
        private System.Windows.Forms.TextBox accountIdTextBox;
        private System.Windows.Forms.TextBox accountNameTextBox;
        private System.Windows.Forms.NumericUpDown accountSaldoNumericUpDown;
        private System.Windows.Forms.RadioButton accountStatusDebetRadioButton;
        private System.Windows.Forms.RadioButton accountStatusKreditRadioButton;
        private System.Windows.Forms.ComboBox accountPositionComboBox;

    }
}