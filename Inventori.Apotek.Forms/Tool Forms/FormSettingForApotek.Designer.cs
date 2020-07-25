namespace Inventori.Apotek.Forms
{
    partial class FormSettingForApotek
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettingForApotek));
            System.Windows.Forms.Label defaultPiutangCreditLongLabel;
            System.Windows.Forms.Label label1;
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.defaultPiutangCreditLongNumericUpDown = new System.Windows.Forms.NumericUpDown();
            defaultPiutangCreditLongLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturNoLengthNumericUpDown)).BeginInit();
            this.tabPage3.SuspendLayout();
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
            // tabPage3
            // 
            this.tabPage3.Controls.Add(label1);
            this.tabPage3.Controls.Add(defaultPiutangCreditLongLabel);
            this.tabPage3.Controls.Add(this.defaultPiutangCreditLongNumericUpDown);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(579, 474);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Apotek";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // defaultPiutangCreditLongLabel
            // 
            defaultPiutangCreditLongLabel.AutoSize = true;
            defaultPiutangCreditLongLabel.Location = new System.Drawing.Point(16, 28);
            defaultPiutangCreditLongLabel.Name = "defaultPiutangCreditLongLabel";
            defaultPiutangCreditLongLabel.Size = new System.Drawing.Size(119, 13);
            defaultPiutangCreditLongLabel.TabIndex = 0;
            defaultPiutangCreditLongLabel.Text = "Lama Kredit Penjualan :";
            // 
            // defaultPiutangCreditLongNumericUpDown
            // 
            this.defaultPiutangCreditLongNumericUpDown.Location = new System.Drawing.Point(141, 26);
            this.defaultPiutangCreditLongNumericUpDown.Name = "defaultPiutangCreditLongNumericUpDown";
            this.defaultPiutangCreditLongNumericUpDown.Size = new System.Drawing.Size(62, 20);
            this.defaultPiutangCreditLongNumericUpDown.TabIndex = 1;
            this.defaultPiutangCreditLongNumericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(207, 29);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(24, 13);
            label1.TabIndex = 2;
            label1.Text = "hari";
            // 
            // FormSettingForApotek
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 616);
            this.Name = "FormSettingForApotek";
            this.TabText = "Konfigurasi Program";
            this.Text = "Konfigurasi Program";
            this.Load += new System.EventHandler(this.FormSettingForApotek_Load);
            this.tabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturNoLengthNumericUpDown)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.defaultPiutangCreditLongNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.NumericUpDown defaultPiutangCreditLongNumericUpDown;
    }
}