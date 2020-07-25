namespace Inventori.Billiard.Forms
{
    partial class FormBilliardSetting
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
            System.Windows.Forms.Label label4;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label fullfillPriceLabel;
            System.Windows.Forms.Label minimumPlayLabel;
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label quitTimeoutLabel;
            System.Windows.Forms.Label biliardItemPriceLabel;
            System.Windows.Forms.Label biliardItemPriceVipLabel;
            System.Windows.Forms.Label biliardItemPriceMiniLabel;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label refereeBonusLabel;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label11;
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.fullfillPriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.tBilliardSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.biliardItemPriceMiniNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.biliardItemPriceVipNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.biliardItemPriceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minimumPlayNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.quitTimeoutNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.refereeBonusNumericUpDown = new System.Windows.Forms.NumericUpDown();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            fullfillPriceLabel = new System.Windows.Forms.Label();
            minimumPlayLabel = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            quitTimeoutLabel = new System.Windows.Forms.Label();
            biliardItemPriceLabel = new System.Windows.Forms.Label();
            biliardItemPriceVipLabel = new System.Windows.Forms.Label();
            biliardItemPriceMiniLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            refereeBonusLabel = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mSettingBindingSource)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturNoLengthNumericUpDown)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullfillPriceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBilliardSettingBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.biliardItemPriceMiniNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.biliardItemPriceVipNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.biliardItemPriceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumPlayNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quitTimeoutNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.refereeBonusNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Controls.SetChildIndex(this.tabPage3, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage2, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyAddressTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyCityTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyTelpTextBox, 0);
            // 
            // companyTelpTextBox
            // 
            this.companyTelpTextBox.TabIndex = 3;
            // 
            // companyCityTextBox
            // 
            this.companyCityTextBox.TabIndex = 2;
            // 
            // companyAddressTextBox
            // 
            this.companyAddressTextBox.TabIndex = 1;
            // 
            // companyNameTextBox
            // 
            this.companyNameTextBox.TabIndex = 0;
            this.tabPage2.Controls.SetChildIndex(this.autoPrintSalesCheckBox, 0);
            this.tabPage2.Controls.SetChildIndex(this.autoBackupCheckBox, 0);
            this.tabPage2.Controls.SetChildIndex(this.backupDirTextBox, 0);
            this.tabPage2.Controls.SetChildIndex(this.btn_Browse, 0);
            this.tabPage2.Controls.SetChildIndex(this.facturNoFormatTextBox, 0);
            this.tabPage2.Controls.SetChildIndex(this.facturNoLengthNumericUpDown, 0);
            // 
            // facturNoLengthNumericUpDown
            // 
            this.facturNoLengthNumericUpDown.TabIndex = 5;
            // 
            // facturNoFormatTextBox
            // 
            this.facturNoFormatTextBox.TabIndex = 4;
            // 
            // btn_Browse
            // 
            this.btn_Browse.TabIndex = 3;
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // backupDirTextBox
            // 
            this.backupDirTextBox.TabIndex = 2;
            // 
            // autoBackupCheckBox
            // 
            this.autoBackupCheckBox.TabIndex = 1;
            this.autoBackupCheckBox.CheckedChanged += new System.EventHandler(this.autoBackupCheckBox_CheckedChanged);
            // 
            // autoPrintSalesCheckBox
            // 
            this.autoPrintSalesCheckBox.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(253, 150);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(32, 13);
            label4.TabIndex = 27;
            label4.Text = "menit";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(204, 177);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(24, 13);
            label3.TabIndex = 6;
            label3.Text = "Rp.";
            // 
            // fullfillPriceLabel
            // 
            fullfillPriceLabel.AutoSize = true;
            fullfillPriceLabel.Location = new System.Drawing.Point(18, 177);
            fullfillPriceLabel.Name = "fullfillPriceLabel";
            fullfillPriceLabel.Size = new System.Drawing.Size(183, 13);
            fullfillPriceLabel.TabIndex = 24;
            fullfillPriceLabel.Text = "Pembulatan Harga Rental dan Wasit:";
            // 
            // minimumPlayLabel
            // 
            minimumPlayLabel.AutoSize = true;
            minimumPlayLabel.Location = new System.Drawing.Point(18, 150);
            minimumPlayLabel.Name = "minimumPlayLabel";
            minimumPlayLabel.Size = new System.Drawing.Size(106, 13);
            minimumPlayLabel.TabIndex = 22;
            minimumPlayLabel.Text = "Waktu Main Minimal:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(253, 124);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(32, 13);
            label2.TabIndex = 21;
            label2.Text = "menit";
            // 
            // quitTimeoutLabel
            // 
            quitTimeoutLabel.AutoSize = true;
            quitTimeoutLabel.Location = new System.Drawing.Point(18, 124);
            quitTimeoutLabel.Name = "quitTimeoutLabel";
            quitTimeoutLabel.Size = new System.Drawing.Size(131, 13);
            quitTimeoutLabel.TabIndex = 19;
            quitTimeoutLabel.Text = "Batas Waktu Pembatalan:";
            // 
            // biliardItemPriceLabel
            // 
            biliardItemPriceLabel.AutoSize = true;
            biliardItemPriceLabel.Location = new System.Drawing.Point(18, 20);
            biliardItemPriceLabel.Name = "biliardItemPriceLabel";
            biliardItemPriceLabel.Size = new System.Drawing.Size(128, 13);
            biliardItemPriceLabel.TabIndex = 0;
            biliardItemPriceLabel.Text = "Harga Rental Meja Biasa:";
            // 
            // biliardItemPriceVipLabel
            // 
            biliardItemPriceVipLabel.AutoSize = true;
            biliardItemPriceVipLabel.Location = new System.Drawing.Point(18, 46);
            biliardItemPriceVipLabel.Name = "biliardItemPriceVipLabel";
            biliardItemPriceVipLabel.Size = new System.Drawing.Size(119, 13);
            biliardItemPriceVipLabel.TabIndex = 30;
            biliardItemPriceVipLabel.Text = "Harga Rental Meja VIP:";
            // 
            // biliardItemPriceMiniLabel
            // 
            biliardItemPriceMiniLabel.AutoSize = true;
            biliardItemPriceMiniLabel.Location = new System.Drawing.Point(18, 72);
            biliardItemPriceMiniLabel.Name = "biliardItemPriceMiniLabel";
            biliardItemPriceMiniLabel.Size = new System.Drawing.Size(121, 13);
            biliardItemPriceMiniLabel.TabIndex = 31;
            biliardItemPriceMiniLabel.Text = "Harga Rental Meja Mini:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(204, 72);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(24, 13);
            label1.TabIndex = 33;
            label1.Text = "Rp.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(204, 46);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(24, 13);
            label5.TabIndex = 34;
            label5.Text = "Rp.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(204, 20);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(24, 13);
            label6.TabIndex = 35;
            label6.Text = "Rp.";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(label11);
            this.tabPage3.Controls.Add(label10);
            this.tabPage3.Controls.Add(label9);
            this.tabPage3.Controls.Add(label8);
            this.tabPage3.Controls.Add(label7);
            this.tabPage3.Controls.Add(refereeBonusLabel);
            this.tabPage3.Controls.Add(this.refereeBonusNumericUpDown);
            this.tabPage3.Controls.Add(label6);
            this.tabPage3.Controls.Add(label5);
            this.tabPage3.Controls.Add(label1);
            this.tabPage3.Controls.Add(this.fullfillPriceNumericUpDown);
            this.tabPage3.Controls.Add(biliardItemPriceMiniLabel);
            this.tabPage3.Controls.Add(this.biliardItemPriceMiniNumericUpDown);
            this.tabPage3.Controls.Add(biliardItemPriceVipLabel);
            this.tabPage3.Controls.Add(this.biliardItemPriceVipNumericUpDown);
            this.tabPage3.Controls.Add(biliardItemPriceLabel);
            this.tabPage3.Controls.Add(this.biliardItemPriceNumericUpDown);
            this.tabPage3.Controls.Add(label4);
            this.tabPage3.Controls.Add(label3);
            this.tabPage3.Controls.Add(fullfillPriceLabel);
            this.tabPage3.Controls.Add(minimumPlayLabel);
            this.tabPage3.Controls.Add(this.minimumPlayNumericUpDown);
            this.tabPage3.Controls.Add(label2);
            this.tabPage3.Controls.Add(quitTimeoutLabel);
            this.tabPage3.Controls.Add(this.quitTimeoutNumericUpDown);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(579, 360);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Billiard";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // fullfillPriceNumericUpDown
            // 
            this.fullfillPriceNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tBilliardSettingBindingSource, "FullfillPrice", true));
            this.fullfillPriceNumericUpDown.Location = new System.Drawing.Point(231, 175);
            this.fullfillPriceNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.fullfillPriceNumericUpDown.Name = "fullfillPriceNumericUpDown";
            this.fullfillPriceNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.fullfillPriceNumericUpDown.TabIndex = 6;
            this.fullfillPriceNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fullfillPriceNumericUpDown.ThousandsSeparator = true;
            // 
            // tBilliardSettingBindingSource
            // 
            this.tBilliardSettingBindingSource.DataSource = typeof(Inventori.Billiard.Data.TBilliardSetting);
            // 
            // biliardItemPriceMiniNumericUpDown
            // 
            this.biliardItemPriceMiniNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tBilliardSettingBindingSource, "BiliardItemPriceMini", true));
            this.biliardItemPriceMiniNumericUpDown.Location = new System.Drawing.Point(231, 70);
            this.biliardItemPriceMiniNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.biliardItemPriceMiniNumericUpDown.Name = "biliardItemPriceMiniNumericUpDown";
            this.biliardItemPriceMiniNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.biliardItemPriceMiniNumericUpDown.TabIndex = 2;
            this.biliardItemPriceMiniNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.biliardItemPriceMiniNumericUpDown.ThousandsSeparator = true;
            // 
            // biliardItemPriceVipNumericUpDown
            // 
            this.biliardItemPriceVipNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tBilliardSettingBindingSource, "BiliardItemPriceVip", true));
            this.biliardItemPriceVipNumericUpDown.Location = new System.Drawing.Point(231, 44);
            this.biliardItemPriceVipNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.biliardItemPriceVipNumericUpDown.Name = "biliardItemPriceVipNumericUpDown";
            this.biliardItemPriceVipNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.biliardItemPriceVipNumericUpDown.TabIndex = 1;
            this.biliardItemPriceVipNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.biliardItemPriceVipNumericUpDown.ThousandsSeparator = true;
            // 
            // biliardItemPriceNumericUpDown
            // 
            this.biliardItemPriceNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tBilliardSettingBindingSource, "BiliardItemPrice", true));
            this.biliardItemPriceNumericUpDown.Location = new System.Drawing.Point(231, 18);
            this.biliardItemPriceNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.biliardItemPriceNumericUpDown.Name = "biliardItemPriceNumericUpDown";
            this.biliardItemPriceNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.biliardItemPriceNumericUpDown.TabIndex = 0;
            this.biliardItemPriceNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.biliardItemPriceNumericUpDown.ThousandsSeparator = true;
            // 
            // minimumPlayNumericUpDown
            // 
            this.minimumPlayNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tBilliardSettingBindingSource, "MinimumPlay", true));
            this.minimumPlayNumericUpDown.Location = new System.Drawing.Point(207, 148);
            this.minimumPlayNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.minimumPlayNumericUpDown.Name = "minimumPlayNumericUpDown";
            this.minimumPlayNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.minimumPlayNumericUpDown.TabIndex = 5;
            this.minimumPlayNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.minimumPlayNumericUpDown.ThousandsSeparator = true;
            // 
            // quitTimeoutNumericUpDown
            // 
            this.quitTimeoutNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tBilliardSettingBindingSource, "QuitTimeout", true));
            this.quitTimeoutNumericUpDown.Location = new System.Drawing.Point(207, 122);
            this.quitTimeoutNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.quitTimeoutNumericUpDown.Name = "quitTimeoutNumericUpDown";
            this.quitTimeoutNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.quitTimeoutNumericUpDown.TabIndex = 4;
            this.quitTimeoutNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.quitTimeoutNumericUpDown.ThousandsSeparator = true;
            // 
            // refereeBonusLabel
            // 
            refereeBonusLabel.AutoSize = true;
            refereeBonusLabel.Location = new System.Drawing.Point(18, 98);
            refereeBonusLabel.Name = "refereeBonusLabel";
            refereeBonusLabel.Size = new System.Drawing.Size(70, 13);
            refereeBonusLabel.TabIndex = 35;
            refereeBonusLabel.Text = "Bonus Wasit:";
            // 
            // refereeBonusNumericUpDown
            // 
            this.refereeBonusNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.tBilliardSettingBindingSource, "RefereeBonus", true));
            this.refereeBonusNumericUpDown.Location = new System.Drawing.Point(231, 96);
            this.refereeBonusNumericUpDown.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.refereeBonusNumericUpDown.Name = "refereeBonusNumericUpDown";
            this.refereeBonusNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.refereeBonusNumericUpDown.TabIndex = 3;
            this.refereeBonusNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.refereeBonusNumericUpDown.ThousandsSeparator = true;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new System.Drawing.Point(204, 98);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(24, 13);
            label7.TabIndex = 37;
            label7.Text = "Rp.";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new System.Drawing.Point(357, 20);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(41, 13);
            label8.TabIndex = 38;
            label8.Text = "per jam";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new System.Drawing.Point(357, 46);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(41, 13);
            label9.TabIndex = 39;
            label9.Text = "per jam";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new System.Drawing.Point(357, 72);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(41, 13);
            label10.TabIndex = 40;
            label10.Text = "per jam";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new System.Drawing.Point(357, 98);
            label11.Name = "label11";
            label11.Size = new System.Drawing.Size(41, 13);
            label11.TabIndex = 41;
            label11.Text = "per jam";
            // 
            // FormBilliardSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(587, 437);
            this.Name = "FormBilliardSetting";
            this.Load += new System.EventHandler(this.FormBilliardSetting_Load);
            this.tabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mSettingBindingSource)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturNoLengthNumericUpDown)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fullfillPriceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tBilliardSettingBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.biliardItemPriceMiniNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.biliardItemPriceVipNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.biliardItemPriceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minimumPlayNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quitTimeoutNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.refereeBonusNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.NumericUpDown minimumPlayNumericUpDown;
        private System.Windows.Forms.NumericUpDown quitTimeoutNumericUpDown;
        private System.Windows.Forms.BindingSource tBilliardSettingBindingSource;
        private System.Windows.Forms.NumericUpDown biliardItemPriceMiniNumericUpDown;
        private System.Windows.Forms.NumericUpDown biliardItemPriceVipNumericUpDown;
        private System.Windows.Forms.NumericUpDown biliardItemPriceNumericUpDown;
        private System.Windows.Forms.NumericUpDown fullfillPriceNumericUpDown;
        private System.Windows.Forms.NumericUpDown refereeBonusNumericUpDown;
    }
}
