namespace Inventori.Contractor.Forms
{
    partial class FormSettingForContractor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSettingForContractor));
            System.Windows.Forms.Label giroDeletePinLabel;
            System.Windows.Forms.Label poDeletePinLabel;
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label_CompanyName = new System.Windows.Forms.Label();
            this.button_Font = new System.Windows.Forms.Button();
            //this.button_ChangeLogo = new System.Windows.Forms.Button();
            this.giroDeletePinTextBox = new System.Windows.Forms.TextBox();
            this.poDeletePinTextBox = new System.Windows.Forms.TextBox();
            this.tContractorSettingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            giroDeletePinLabel = new System.Windows.Forms.Label();
            poDeletePinLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturNoLengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyLogoPictureBox)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tContractorSettingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(237, 485);
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Size = new System.Drawing.Size(587, 467);
            this.tabControl1.Controls.SetChildIndex(this.tabPage3, 0);
            this.tabControl1.Controls.SetChildIndex(this.tabPage2, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Size = new System.Drawing.Size(573, 435);
            this.groupBox1.Controls.SetChildIndex(this.button_ChangeLogo, 0);
            this.groupBox1.Controls.SetChildIndex(this.label_ImageLogoLocation, 0);
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
            this.groupBox1.Controls.SetChildIndex(this.companyNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyAddressTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyCityTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.companyTelpTextBox, 0);
            // 
            // tabPage2
            // 
            this.tabPage2.Size = new System.Drawing.Size(676, 441);
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
            // autoPrintSalesCheckBox
            // 
            this.autoPrintSalesCheckBox.Visible = false;
            // 
            // lbl_Desc
            // 
            this.lbl_Desc.Size = new System.Drawing.Size(338, 195);
            this.lbl_Desc.Text = resources.GetString("lbl_Desc.Text");
            // 
            // facturNoFormatLabel
            // 
            this.facturNoFormatLabel.Size = new System.Drawing.Size(158, 13);
            this.facturNoFormatLabel.Text = "Format Nomor Faktur Transaksi:";
            // 
            // giroDeletePinLabel
            // 
            giroDeletePinLabel.AutoSize = true;
            giroDeletePinLabel.Location = new System.Drawing.Point(20, 18);
            giroDeletePinLabel.Name = "giroDeletePinLabel";
            giroDeletePinLabel.Size = new System.Drawing.Size(84, 13);
            giroDeletePinLabel.TabIndex = 0;
            giroDeletePinLabel.Text = "Pin Hapus Giro :";
            // 
            // poDeletePinLabel
            // 
            poDeletePinLabel.AutoSize = true;
            poDeletePinLabel.Location = new System.Drawing.Point(20, 44);
            poDeletePinLabel.Name = "poDeletePinLabel";
            poDeletePinLabel.Size = new System.Drawing.Size(111, 13);
            poDeletePinLabel.TabIndex = 2;
            poDeletePinLabel.Text = "Pin Hapus Transaksi :";
            poDeletePinLabel.Click += new System.EventHandler(this.poDeletePinLabel_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.SupportMultiDottedExtensions = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label_CompanyName);
            this.tabPage3.Controls.Add(this.button_Font);
            this.tabPage3.Controls.Add(giroDeletePinLabel);
            this.tabPage3.Controls.Add(this.giroDeletePinTextBox);
            this.tabPage3.Controls.Add(poDeletePinLabel);
            this.tabPage3.Controls.Add(this.poDeletePinTextBox);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(579, 441);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Kontraktor";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label_CompanyName
            // 
            this.label_CompanyName.AutoSize = true;
            this.label_CompanyName.Location = new System.Drawing.Point(236, 94);
            this.label_CompanyName.Name = "label_CompanyName";
            this.label_CompanyName.Size = new System.Drawing.Size(107, 13);
            this.label_CompanyName.TabIndex = 19;
            this.label_CompanyName.Text = "label_CompanyName";
            // 
            // button_Font
            // 
            this.button_Font.Location = new System.Drawing.Point(252, 139);
            this.button_Font.Name = "button_Font";
            this.button_Font.Size = new System.Drawing.Size(75, 23);
            this.button_Font.TabIndex = 18;
            this.button_Font.Text = "Ganti Huruf";
            this.button_Font.UseVisualStyleBackColor = true;
            // 
            // giroDeletePinTextBox
            // 
            this.giroDeletePinTextBox.Location = new System.Drawing.Point(145, 15);
            this.giroDeletePinTextBox.Name = "giroDeletePinTextBox";
            this.giroDeletePinTextBox.Size = new System.Drawing.Size(188, 20);
            this.giroDeletePinTextBox.TabIndex = 1;
            // 
            // poDeletePinTextBox
            // 
            this.poDeletePinTextBox.Location = new System.Drawing.Point(145, 41);
            this.poDeletePinTextBox.Name = "poDeletePinTextBox";
            this.poDeletePinTextBox.Size = new System.Drawing.Size(188, 20);
            this.poDeletePinTextBox.TabIndex = 3;
            // 
            // tContractorSettingBindingSource
            // 
            this.tContractorSettingBindingSource.DataSource = typeof(Inventori.Contractor.Data.TContractorSetting);
            // 
            // fontDialog1
            // 
            this.fontDialog1.AllowScriptChange = false;
            this.fontDialog1.AllowSimulations = false;
            this.fontDialog1.AllowVectorFonts = false;
            this.fontDialog1.AllowVerticalFonts = false;
            this.fontDialog1.ShowColor = true;
            // 
            // FormSettingForContractor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 528);
            this.Name = "FormSettingForContractor";
            this.TabText = "Konfigurasi Program";
            this.Text = "Konfigurasi Program";
            this.Load += new System.EventHandler(this.FormSettingForContractor_Load);
            this.tabControl1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturNoLengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.companyLogoPictureBox)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tContractorSettingBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TextBox giroDeletePinTextBox;
        private System.Windows.Forms.TextBox poDeletePinTextBox;
        //private System.Windows.Forms.Button button_ChangeLogo;
        private System.Windows.Forms.BindingSource tContractorSettingBindingSource;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.Label label_CompanyName;
        private System.Windows.Forms.Button button_Font;
    }
}