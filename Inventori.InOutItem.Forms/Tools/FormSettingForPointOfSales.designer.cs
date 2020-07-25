namespace Inventori.InOutItem.Forms
{
    partial class FormSettingForInOutItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettingForInOutItem));
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturNoLengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(237, 506);
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Size = new System.Drawing.Size(587, 500);
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
            this.tabPage2.Size = new System.Drawing.Size(676, 474);
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
            // FormSettingForInOutItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 616);
            this.Name = "FormSettingForInOutItem";
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    }
}