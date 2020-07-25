namespace Inventori.MotorKymco.Forms
{
    partial class FormSettingForKymco
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettingForKymco));
            System.Windows.Forms.Label defaultPiutangCreditLongLabel;
            System.Windows.Forms.Label discountPinLabel;
            System.Windows.Forms.Label label1;
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.discountPinTextBox = new System.Windows.Forms.TextBox();
            this.tMotorSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.defaultPiutangCreditLongNumericUpDown = new System.Windows.Forms.NumericUpDown();
            defaultPiutangCreditLongLabel = new System.Windows.Forms.Label();
            discountPinLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturNoLengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyLogoPictureBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tMotorSettingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultPiutangCreditLongNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(237, 506);
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Size = new System.Drawing.Size(587, 500);
            this.tabControl1.Controls.SetChildIndex(this.tabPage3, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage2, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(573, 468);
            this.groupBox1.Controls.SetChildIndex(this.companyCityLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyTelpLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyFaxTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyFaxLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyAddress2TextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyNpwpTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyNpwpLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyPkpDateDateTimePicker, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyPkpDateLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyLogoPictureBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.button_ChangeLogo, 0);
            this.groupBox1.Controls.SetChildIndex(this.label_ImageLogoLocation, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyAddressTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyCityTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyTelpTextBox, 0);
            // 
            // tabPage2
            // 
            this.tabPage2.Size = new System.Drawing.Size(579, 474);
            this.tabPage2.Controls.SetChildIndex(this.autoPrintSalesCheckBox, 0);
            this.tabPage2.Controls.SetChildIndex(this.autoBackupCheckBox, 0);
            this.tabPage2.Controls.SetChildIndex(this.backupDirTextBox, 0);
            this.tabPage2.Controls.SetChildIndex(this.btn_Browse, 0);
            this.tabPage2.Controls.SetChildIndex(this.facturNoFormatTextBox, 0);
            this.tabPage2.Controls.SetChildIndex(this.facturNoFormatLabel, 0);
            this.tabPage2.Controls.SetChildIndex(this.lbl_Desc, 0);
            this.tabPage2.Controls.SetChildIndex(this.facturNoLengthNumericUpDown, 0);
            // 
            // btn_Browse
            // 
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // autoBackupCheckBox
            // 
            this.autoBackupCheckBox.CheckedChanged += new System.EventHandler(this.autoBackupCheckBox_CheckedChanged);
            // 
            // autoPrintSalesCheckBox
            // 
            this.autoPrintSalesCheckBox.Visible = false;
            // 
            // lbl_Desc
            // 
            this.lbl_Desc.Size = new System.Drawing.Size(282, 195);
            this.lbl_Desc.Text = resources.GetString("lbl_Desc.Text");
            // 
            // facturNoFormatLabel
            // 
            this.facturNoFormatLabel.Size = new System.Drawing.Size(161, 13);
            this.facturNoFormatLabel.Text = "Format Nomor Faktur Transaksi :";
            // 
            // defaultPiutangCreditLongLabel
            // 
            defaultPiutangCreditLongLabel.AutoSize = true;
            defaultPiutangCreditLongLabel.Location = new System.Drawing.Point(21, 26);
            defaultPiutangCreditLongLabel.Name = "defaultPiutangCreditLongLabel";
            defaultPiutangCreditLongLabel.Size = new System.Drawing.Size(119, 13);
            defaultPiutangCreditLongLabel.TabIndex = 0;
            defaultPiutangCreditLongLabel.Text = "Lama Kredit Penjualan :";
            // 
            // discountPinLabel
            // 
            discountPinLabel.AutoSize = true;
            discountPinLabel.Location = new System.Drawing.Point(21, 53);
            discountPinLabel.Name = "discountPinLabel";
            discountPinLabel.Size = new System.Drawing.Size(114, 13);
            discountPinLabel.TabIndex = 2;
            discountPinLabel.Text = "Pin Diskon Penjualan :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(210, 26);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(24, 13);
            label1.TabIndex = 4;
            label1.Text = "hari";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(label1);
            this.tabPage3.Controls.Add(discountPinLabel);
            this.tabPage3.Controls.Add(this.discountPinTextBox);
            this.tabPage3.Controls.Add(defaultPiutangCreditLongLabel);
            this.tabPage3.Controls.Add(this.defaultPiutangCreditLongNumericUpDown);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(676, 474);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Kymco";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // discountPinTextBox
            // 
            this.discountPinTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tMotorSettingBindingSource, "DiscountPin", true));
            this.discountPinTextBox.Location = new System.Drawing.Point(146, 50);
            this.discountPinTextBox.Name = "discountPinTextBox";
            this.discountPinTextBox.Size = new System.Drawing.Size(141, 20);
            this.discountPinTextBox.TabIndex = 3;
            this.discountPinTextBox.UseSystemPasswordChar = true;
            // 
            // tMotorSettingBindingSource
            // 
            this.tMotorSettingBindingSource.DataSource = typeof(Inventori.MotorKymco.Data.TMotorSetting);
            // 
            // defaultPiutangCreditLongNumericUpDown
            // 
            this.defaultPiutangCreditLongNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tMotorSettingBindingSource, "DefaultPiutangCreditLong", true));
            this.defaultPiutangCreditLongNumericUpDown.Location = new System.Drawing.Point(146, 24);
            this.defaultPiutangCreditLongNumericUpDown.Name = "defaultPiutangCreditLongNumericUpDown";
            this.defaultPiutangCreditLongNumericUpDown.Size = new System.Drawing.Size(58, 20);
            this.defaultPiutangCreditLongNumericUpDown.TabIndex = 1;
            // 
            // FormSettingForKymco
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 616);
            this.Name = "FormSettingForKymco";
            this.TabText = "Konfigurasi Program";
            this.Text = "Konfigurasi Program";
            this.Load += new System.EventHandler(this.FormSettingForApotek_Load);
            this.tabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturNoLengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyLogoPictureBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tMotorSettingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.defaultPiutangCreditLongNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox discountPinTextBox;
        private System.Windows.Forms.BindingSource tMotorSettingBindingSource;
        private System.Windows.Forms.NumericUpDown defaultPiutangCreditLongNumericUpDown;

    }
}