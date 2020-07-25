namespace Inventori.Cafe.Forms
{
    partial class FormSettingForCafe
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
            System.Windows.Forms.Label exportedDirLabel;
            System.Windows.Forms.Label discountPasswordLabel;
            System.Windows.Forms.Label telpNoSaranKritikLabel;
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.button_BrowseExport = new System.Windows.Forms.Button();
            this.discountPasswordTextBox = new System.Windows.Forms.TextBox();
            this.exportedDirTextBox = new System.Windows.Forms.TextBox();
            this.tCafeSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.telpNoSaranKritikTextBox = new System.Windows.Forms.TextBox();
            exportedDirLabel = new System.Windows.Forms.Label();
            discountPasswordLabel = new System.Windows.Forms.Label();
            telpNoSaranKritikLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturNoLengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyLogoPictureBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tCafeSettingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Size = new System.Drawing.Size(587, 386);
            this.tabControl1.Controls.SetChildIndex(this.tabPage3, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage2, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(telpNoSaranKritikLabel);
            this.groupBox1.Controls.Add(this.telpNoSaranKritikTextBox);
            this.groupBox1.Size = new System.Drawing.Size(573, 354);
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
            this.groupBox1.Controls.SetChildIndex(this.telpNoSaranKritikTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(telpNoSaranKritikLabel, 0);
            // 
            // companyTelpTextBox
            // 
            this.companyTelpTextBox.Location = new System.Drawing.Point(197, 97);
            // 
            // companyCityTextBox
            // 
            this.companyCityTextBox.Location = new System.Drawing.Point(197, 71);
            // 
            // companyAddressTextBox
            // 
            this.companyAddressTextBox.Location = new System.Drawing.Point(197, 45);
            // 
            // companyNameTextBox
            // 
            this.companyNameTextBox.Location = new System.Drawing.Point(197, 19);
            this.tabPage2.Controls.SetChildIndex(this.facturNoFormatLabel, 0);
            this.tabPage2.Controls.SetChildIndex(this.lbl_Desc, 0);
            this.tabPage2.Controls.SetChildIndex(this.autoPrintSalesCheckBox, 0);
            this.tabPage2.Controls.SetChildIndex(this.autoBackupCheckBox, 0);
            this.tabPage2.Controls.SetChildIndex(this.backupDirTextBox, 0);
            this.tabPage2.Controls.SetChildIndex(this.btn_Browse, 0);
            this.tabPage2.Controls.SetChildIndex(this.facturNoFormatTextBox, 0);
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
            // companyAddress2TextBox
            // 
            this.companyAddress2TextBox.Visible = false;
            // 
            // exportedDirLabel
            // 
            exportedDirLabel.AutoSize = true;
            exportedDirLabel.Location = new System.Drawing.Point(8, 35);
            exportedDirLabel.Name = "exportedDirLabel";
            exportedDirLabel.Size = new System.Drawing.Size(199, 13);
            exportedDirLabel.TabIndex = 0;
            exportedDirLabel.Text = "Direktori penyimpanan file tutup periode :";
            // 
            // discountPasswordLabel
            // 
            discountPasswordLabel.AutoSize = true;
            discountPasswordLabel.Location = new System.Drawing.Point(57, 61);
            discountPasswordLabel.Name = "discountPasswordLabel";
            discountPasswordLabel.Size = new System.Drawing.Size(150, 13);
            discountPasswordLabel.TabIndex = 2;
            discountPasswordLabel.Text = "Kata kunci pemberian diskon :";
            // 
            // telpNoSaranKritikLabel
            // 
            telpNoSaranKritikLabel.AutoSize = true;
            telpNoSaranKritikLabel.Location = new System.Drawing.Point(45, 126);
            telpNoSaranKritikLabel.Name = "telpNoSaranKritikLabel";
            telpNoSaranKritikLabel.Size = new System.Drawing.Size(128, 13);
            telpNoSaranKritikLabel.TabIndex = 8;
            telpNoSaranKritikLabel.Text = "No Telp Saran Dan Kritik:";
            // 
            // tabPage3
            // 
            this.tabPage3.AutoScroll = true;
            this.tabPage3.Controls.Add(this.button_BrowseExport);
            this.tabPage3.Controls.Add(discountPasswordLabel);
            this.tabPage3.Controls.Add(this.discountPasswordTextBox);
            this.tabPage3.Controls.Add(exportedDirLabel);
            this.tabPage3.Controls.Add(this.exportedDirTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(676, 360);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cafe";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // button_BrowseExport
            // 
            this.button_BrowseExport.Image = global::Inventori.Cafe.Forms.Properties.Resources._0003_folder;
            this.button_BrowseExport.Location = new System.Drawing.Point(484, 25);
            this.button_BrowseExport.Name = "button_BrowseExport";
            this.button_BrowseExport.Size = new System.Drawing.Size(87, 33);
            this.button_BrowseExport.TabIndex = 4;
            this.button_BrowseExport.Text = "Browse ...";
            this.button_BrowseExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_BrowseExport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_BrowseExport.UseVisualStyleBackColor = true;
            this.button_BrowseExport.Click += new System.EventHandler(this.button_BrowseExport_Click);
            // 
            // discountPasswordTextBox
            // 
            this.discountPasswordTextBox.Location = new System.Drawing.Point(213, 58);
            this.discountPasswordTextBox.Name = "discountPasswordTextBox";
            this.discountPasswordTextBox.Size = new System.Drawing.Size(107, 20);
            this.discountPasswordTextBox.TabIndex = 3;
            // 
            // exportedDirTextBox
            // 
            this.exportedDirTextBox.Location = new System.Drawing.Point(213, 32);
            this.exportedDirTextBox.Name = "exportedDirTextBox";
            this.exportedDirTextBox.ReadOnly = true;
            this.exportedDirTextBox.Size = new System.Drawing.Size(265, 20);
            this.exportedDirTextBox.TabIndex = 1;
            // 
            // tCafeSettingBindingSource
            // 
            this.tCafeSettingBindingSource.DataSource = typeof(Inventori.Cafe.Data.TCafeSetting);
            // 
            // telpNoSaranKritikTextBox
            // 
            this.telpNoSaranKritikTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.tCafeSettingBindingSource, "TelpNoSaranKritik", true));
            this.telpNoSaranKritikTextBox.Location = new System.Drawing.Point(197, 123);
            this.telpNoSaranKritikTextBox.Name = "telpNoSaranKritikTextBox";
            this.telpNoSaranKritikTextBox.Size = new System.Drawing.Size(181, 20);
            this.telpNoSaranKritikTextBox.TabIndex = 9;
            // 
            // FormSettingForCafe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(587, 437);
            this.Name = "FormSettingForCafe";
            this.Load += new System.EventHandler(this.FormSettingForCafe_Load);
            this.tabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturNoLengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyLogoPictureBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tCafeSettingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox exportedDirTextBox;
        private System.Windows.Forms.Button button_BrowseExport;
        private System.Windows.Forms.TextBox discountPasswordTextBox;
        private System.Windows.Forms.TextBox telpNoSaranKritikTextBox;
        private System.Windows.Forms.BindingSource tCafeSettingBindingSource;
    }
}
