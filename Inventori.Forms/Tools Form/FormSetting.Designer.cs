namespace Inventori.Forms
{
    partial class FormSetting
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
            System.Windows.Forms.Label companyAddressLabel;
            System.Windows.Forms.Label companyNameLabel;
            System.Windows.Forms.Label facturNoLengthLabel;
            System.Windows.Forms.Label backupDirLabel;
            System.Windows.Forms.Label companyLogoLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetting));
            this.companyTelpLabel = new System.Windows.Forms.Label();
            this.companyCityLabel = new System.Windows.Forms.Label();
            this.facturNoFormatLabel = new System.Windows.Forms.Label();
            this.lbl_Desc = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonOK = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_ImageLogoLocation = new System.Windows.Forms.Label();
            this.button_ChangeLogo = new System.Windows.Forms.Button();
            this.companyLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.companyPkpDateLabel = new System.Windows.Forms.Label();
            this.companyPkpDateDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.companyNpwpLabel = new System.Windows.Forms.Label();
            this.companyNpwpTextBox = new System.Windows.Forms.TextBox();
            this.companyAddress2TextBox = new System.Windows.Forms.TextBox();
            this.companyFaxLabel = new System.Windows.Forms.Label();
            this.companyFaxTextBox = new System.Windows.Forms.TextBox();
            this.companyTelpTextBox = new System.Windows.Forms.TextBox();
            this.companyCityTextBox = new System.Windows.Forms.TextBox();
            this.companyAddressTextBox = new System.Windows.Forms.TextBox();
            this.companyNameTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.facturNoLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.facturNoFormatTextBox = new System.Windows.Forms.TextBox();
            this.btn_Browse = new System.Windows.Forms.Button();
            this.backupDirTextBox = new System.Windows.Forms.TextBox();
            this.autoBackupCheckBox = new System.Windows.Forms.CheckBox();
            this.autoPrintSalesCheckBox = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            companyAddressLabel = new System.Windows.Forms.Label();
            companyNameLabel = new System.Windows.Forms.Label();
            facturNoLengthLabel = new System.Windows.Forms.Label();
            backupDirLabel = new System.Windows.Forms.Label();
            companyLogoLabel = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.companyLogoPictureBox)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturNoLengthNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // companyAddressLabel
            // 
            companyAddressLabel.AutoSize = true;
            companyAddressLabel.Location = new System.Drawing.Point(43, 47);
            companyAddressLabel.Name = "companyAddressLabel";
            companyAddressLabel.Size = new System.Drawing.Size(42, 13);
            companyAddressLabel.TabIndex = 2;
            companyAddressLabel.Text = "Alamat:";
            // 
            // companyNameLabel
            // 
            companyNameLabel.AutoSize = true;
            companyNameLabel.Location = new System.Drawing.Point(43, 21);
            companyNameLabel.Name = "companyNameLabel";
            companyNameLabel.Size = new System.Drawing.Size(98, 13);
            companyNameLabel.TabIndex = 0;
            companyNameLabel.Text = "Nama Perusahaan:";
            // 
            // facturNoLengthLabel
            // 
            facturNoLengthLabel.AutoSize = true;
            facturNoLengthLabel.Location = new System.Drawing.Point(15, 198);
            facturNoLengthLabel.Name = "facturNoLengthLabel";
            facturNoLengthLabel.Size = new System.Drawing.Size(106, 13);
            facturNoLengthLabel.TabIndex = 8;
            facturNoLengthLabel.Text = "Panjang Nomor Urut:";
            // 
            // backupDirLabel
            // 
            backupDirLabel.AutoSize = true;
            backupDirLabel.Location = new System.Drawing.Point(19, 95);
            backupDirLabel.Name = "backupDirLabel";
            backupDirLabel.Size = new System.Drawing.Size(130, 13);
            backupDirLabel.TabIndex = 3;
            backupDirLabel.Text = "Lokasi Backup Database:";
            // 
            // companyLogoLabel
            // 
            companyLogoLabel.AutoSize = true;
            companyLogoLabel.Location = new System.Drawing.Point(465, 21);
            companyLogoLabel.Name = "companyLogoLabel";
            companyLogoLabel.Size = new System.Drawing.Size(37, 13);
            companyLogoLabel.TabIndex = 15;
            companyLogoLabel.Text = "Logo :";
            // 
            // companyTelpLabel
            // 
            this.companyTelpLabel.AutoSize = true;
            this.companyTelpLabel.Location = new System.Drawing.Point(43, 125);
            this.companyTelpLabel.Name = "companyTelpLabel";
            this.companyTelpLabel.Size = new System.Drawing.Size(31, 13);
            this.companyTelpLabel.TabIndex = 6;
            this.companyTelpLabel.Text = "Telp:";
            // 
            // companyCityLabel
            // 
            this.companyCityLabel.AutoSize = true;
            this.companyCityLabel.Location = new System.Drawing.Point(43, 99);
            this.companyCityLabel.Name = "companyCityLabel";
            this.companyCityLabel.Size = new System.Drawing.Size(32, 13);
            this.companyCityLabel.TabIndex = 4;
            this.companyCityLabel.Text = "Kota:";
            // 
            // facturNoFormatLabel
            // 
            this.facturNoFormatLabel.AutoSize = true;
            this.facturNoFormatLabel.Location = new System.Drawing.Point(15, 175);
            this.facturNoFormatLabel.Name = "facturNoFormatLabel";
            this.facturNoFormatLabel.Size = new System.Drawing.Size(159, 13);
            this.facturNoFormatLabel.TabIndex = 5;
            this.facturNoFormatLabel.Text = "Format Nomor Faktur Penjualan:";
            // 
            // lbl_Desc
            // 
            this.lbl_Desc.AutoSize = true;
            this.lbl_Desc.Location = new System.Drawing.Point(200, 221);
            this.lbl_Desc.Name = "lbl_Desc";
            this.lbl_Desc.Size = new System.Drawing.Size(200, 117);
            this.lbl_Desc.TabIndex = 7;
            this.lbl_Desc.Text = resources.GetString("lbl_Desc.Text");
            // 
            // buttonOK
            // 
            this.buttonOK.Image = global::Inventori.Forms.Properties.Resources.save;
            this.buttonOK.Location = new System.Drawing.Point(235, 394);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(90, 31);
            this.buttonOK.TabIndex = 17;
            this.buttonOK.Text = "Simpan";
            this.buttonOK.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(684, 386);
            this.tabControl1.TabIndex = 16;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(676, 360);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data Perusahaan";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_ImageLogoLocation);
            this.groupBox1.Controls.Add(this.button_ChangeLogo);
            this.groupBox1.Controls.Add(companyLogoLabel);
            this.groupBox1.Controls.Add(this.companyLogoPictureBox);
            this.groupBox1.Controls.Add(this.companyPkpDateLabel);
            this.groupBox1.Controls.Add(this.companyPkpDateDateTimePicker);
            this.groupBox1.Controls.Add(this.companyNpwpLabel);
            this.groupBox1.Controls.Add(this.companyNpwpTextBox);
            this.groupBox1.Controls.Add(this.companyAddress2TextBox);
            this.groupBox1.Controls.Add(this.companyFaxLabel);
            this.groupBox1.Controls.Add(this.companyFaxTextBox);
            this.groupBox1.Controls.Add(this.companyTelpLabel);
            this.groupBox1.Controls.Add(this.companyTelpTextBox);
            this.groupBox1.Controls.Add(this.companyCityLabel);
            this.groupBox1.Controls.Add(this.companyCityTextBox);
            this.groupBox1.Controls.Add(companyAddressLabel);
            this.groupBox1.Controls.Add(this.companyAddressTextBox);
            this.groupBox1.Controls.Add(companyNameLabel);
            this.groupBox1.Controls.Add(this.companyNameTextBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(670, 354);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label_ImageLogoLocation
            // 
            this.label_ImageLogoLocation.AutoSize = true;
            this.label_ImageLogoLocation.Location = new System.Drawing.Point(468, 229);
            this.label_ImageLogoLocation.Name = "label_ImageLogoLocation";
            this.label_ImageLogoLocation.Size = new System.Drawing.Size(129, 13);
            this.label_ImageLogoLocation.TabIndex = 18;
            this.label_ImageLogoLocation.Text = "label_ImageLogoLocation";
            this.label_ImageLogoLocation.Visible = false;
            // 
            // button_ChangeLogo
            // 
            this.button_ChangeLogo.Image = global::Inventori.Forms.Properties.Resources._0003_folder;
            this.button_ChangeLogo.Location = new System.Drawing.Point(499, 177);
            this.button_ChangeLogo.Name = "button_ChangeLogo";
            this.button_ChangeLogo.Size = new System.Drawing.Size(105, 43);
            this.button_ChangeLogo.TabIndex = 17;
            this.button_ChangeLogo.Text = "Ganti Logo";
            this.button_ChangeLogo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_ChangeLogo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button_ChangeLogo.UseVisualStyleBackColor = true;
            this.button_ChangeLogo.Click += new System.EventHandler(this.button_ChangeLogo_Click);
            // 
            // companyLogoPictureBox
            // 
            this.companyLogoPictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.companyLogoPictureBox.Location = new System.Drawing.Point(468, 40);
            this.companyLogoPictureBox.Name = "companyLogoPictureBox";
            this.companyLogoPictureBox.Size = new System.Drawing.Size(169, 128);
            this.companyLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.companyLogoPictureBox.TabIndex = 16;
            this.companyLogoPictureBox.TabStop = false;
            // 
            // companyPkpDateLabel
            // 
            this.companyPkpDateLabel.AutoSize = true;
            this.companyPkpDateLabel.Location = new System.Drawing.Point(43, 204);
            this.companyPkpDateLabel.Name = "companyPkpDateLabel";
            this.companyPkpDateLabel.Size = new System.Drawing.Size(76, 13);
            this.companyPkpDateLabel.TabIndex = 13;
            this.companyPkpDateLabel.Text = "Tanggal PKP :";
            // 
            // companyPkpDateDateTimePicker
            // 
            this.companyPkpDateDateTimePicker.Location = new System.Drawing.Point(158, 200);
            this.companyPkpDateDateTimePicker.Name = "companyPkpDateDateTimePicker";
            this.companyPkpDateDateTimePicker.Size = new System.Drawing.Size(125, 20);
            this.companyPkpDateDateTimePicker.TabIndex = 14;
            // 
            // companyNpwpLabel
            // 
            this.companyNpwpLabel.AutoSize = true;
            this.companyNpwpLabel.Location = new System.Drawing.Point(43, 177);
            this.companyNpwpLabel.Name = "companyNpwpLabel";
            this.companyNpwpLabel.Size = new System.Drawing.Size(46, 13);
            this.companyNpwpLabel.TabIndex = 11;
            this.companyNpwpLabel.Text = "NPWP :";
            // 
            // companyNpwpTextBox
            // 
            this.companyNpwpTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.companyNpwpTextBox.Location = new System.Drawing.Point(158, 174);
            this.companyNpwpTextBox.Name = "companyNpwpTextBox";
            this.companyNpwpTextBox.Size = new System.Drawing.Size(160, 20);
            this.companyNpwpTextBox.TabIndex = 12;
            // 
            // companyAddress2TextBox
            // 
            this.companyAddress2TextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.companyAddress2TextBox.Location = new System.Drawing.Point(158, 70);
            this.companyAddress2TextBox.Name = "companyAddress2TextBox";
            this.companyAddress2TextBox.Size = new System.Drawing.Size(238, 20);
            this.companyAddress2TextBox.TabIndex = 11;
            // 
            // companyFaxLabel
            // 
            this.companyFaxLabel.AutoSize = true;
            this.companyFaxLabel.Location = new System.Drawing.Point(43, 151);
            this.companyFaxLabel.Name = "companyFaxLabel";
            this.companyFaxLabel.Size = new System.Drawing.Size(30, 13);
            this.companyFaxLabel.TabIndex = 8;
            this.companyFaxLabel.Text = "Fax :";
            // 
            // companyFaxTextBox
            // 
            this.companyFaxTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.companyFaxTextBox.Location = new System.Drawing.Point(158, 148);
            this.companyFaxTextBox.Name = "companyFaxTextBox";
            this.companyFaxTextBox.Size = new System.Drawing.Size(135, 20);
            this.companyFaxTextBox.TabIndex = 9;
            // 
            // companyTelpTextBox
            // 
            this.companyTelpTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.companyTelpTextBox.Location = new System.Drawing.Point(158, 122);
            this.companyTelpTextBox.Name = "companyTelpTextBox";
            this.companyTelpTextBox.Size = new System.Drawing.Size(135, 20);
            this.companyTelpTextBox.TabIndex = 7;
            // 
            // companyCityTextBox
            // 
            this.companyCityTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.companyCityTextBox.Location = new System.Drawing.Point(158, 96);
            this.companyCityTextBox.Name = "companyCityTextBox";
            this.companyCityTextBox.Size = new System.Drawing.Size(181, 20);
            this.companyCityTextBox.TabIndex = 5;
            // 
            // companyAddressTextBox
            // 
            this.companyAddressTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.companyAddressTextBox.Location = new System.Drawing.Point(158, 44);
            this.companyAddressTextBox.Name = "companyAddressTextBox";
            this.companyAddressTextBox.Size = new System.Drawing.Size(238, 20);
            this.companyAddressTextBox.TabIndex = 3;
            // 
            // companyNameTextBox
            // 
            this.companyNameTextBox.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.companyNameTextBox.Location = new System.Drawing.Point(158, 18);
            this.companyNameTextBox.Name = "companyNameTextBox";
            this.companyNameTextBox.Size = new System.Drawing.Size(181, 20);
            this.companyNameTextBox.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(facturNoLengthLabel);
            this.tabPage2.Controls.Add(this.facturNoLengthNumericUpDown);
            this.tabPage2.Controls.Add(this.lbl_Desc);
            this.tabPage2.Controls.Add(this.facturNoFormatLabel);
            this.tabPage2.Controls.Add(this.facturNoFormatTextBox);
            this.tabPage2.Controls.Add(this.btn_Browse);
            this.tabPage2.Controls.Add(backupDirLabel);
            this.tabPage2.Controls.Add(this.backupDirTextBox);
            this.tabPage2.Controls.Add(this.autoBackupCheckBox);
            this.tabPage2.Controls.Add(this.autoPrintSalesCheckBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(676, 360);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Konfigurasi Program";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // facturNoLengthNumericUpDown
            // 
            this.facturNoLengthNumericUpDown.Location = new System.Drawing.Point(203, 198);
            this.facturNoLengthNumericUpDown.Name = "facturNoLengthNumericUpDown";
            this.facturNoLengthNumericUpDown.Size = new System.Drawing.Size(46, 20);
            this.facturNoLengthNumericUpDown.TabIndex = 9;
            // 
            // facturNoFormatTextBox
            // 
            this.facturNoFormatTextBox.Location = new System.Drawing.Point(203, 172);
            this.facturNoFormatTextBox.Name = "facturNoFormatTextBox";
            this.facturNoFormatTextBox.Size = new System.Drawing.Size(156, 20);
            this.facturNoFormatTextBox.TabIndex = 6;
            // 
            // btn_Browse
            // 
            this.btn_Browse.Image = global::Inventori.Forms.Properties.Resources._0003_folder;
            this.btn_Browse.Location = new System.Drawing.Point(329, 111);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(84, 32);
            this.btn_Browse.TabIndex = 5;
            this.btn_Browse.Text = "Browse ...";
            this.btn_Browse.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_Browse.UseVisualStyleBackColor = true;
            // 
            // backupDirTextBox
            // 
            this.backupDirTextBox.Location = new System.Drawing.Point(22, 118);
            this.backupDirTextBox.Name = "backupDirTextBox";
            this.backupDirTextBox.ReadOnly = true;
            this.backupDirTextBox.Size = new System.Drawing.Size(301, 20);
            this.backupDirTextBox.TabIndex = 4;
            // 
            // autoBackupCheckBox
            // 
            this.autoBackupCheckBox.Location = new System.Drawing.Point(18, 68);
            this.autoBackupCheckBox.Name = "autoBackupCheckBox";
            this.autoBackupCheckBox.Size = new System.Drawing.Size(290, 24);
            this.autoBackupCheckBox.TabIndex = 2;
            this.autoBackupCheckBox.Text = "Otomatis Backup Database Setiap Tutup Program";
            // 
            // autoPrintSalesCheckBox
            // 
            this.autoPrintSalesCheckBox.Location = new System.Drawing.Point(18, 18);
            this.autoPrintSalesCheckBox.Name = "autoPrintSalesCheckBox";
            this.autoPrintSalesCheckBox.Size = new System.Drawing.Size(318, 24);
            this.autoPrintSalesCheckBox.TabIndex = 1;
            this.autoPrintSalesCheckBox.Text = "Langsung cetak faktur setiap transaksi penjualan";
            // 
            // FormSetting
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(684, 437);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControl1);
            this.Name = "FormSetting";
            this.TabText = "Setting Program";
            this.Text = "Setting Program";
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.Controls.SetChildIndex(this.buttonOK, 0);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.companyLogoPictureBox)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.facturNoLengthNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        public System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TextBox companyTelpTextBox;
        public System.Windows.Forms.TextBox companyCityTextBox;
        public System.Windows.Forms.TextBox companyAddressTextBox;
        public System.Windows.Forms.TextBox companyNameTextBox;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.NumericUpDown facturNoLengthNumericUpDown;
        public System.Windows.Forms.TextBox facturNoFormatTextBox;
        public System.Windows.Forms.Button btn_Browse;
        public System.Windows.Forms.TextBox backupDirTextBox;
        public System.Windows.Forms.CheckBox autoBackupCheckBox;
        public System.Windows.Forms.CheckBox autoPrintSalesCheckBox;
        public System.Windows.Forms.Label lbl_Desc;
        public System.Windows.Forms.Label facturNoFormatLabel;
        public System.Windows.Forms.Label companyTelpLabel;
        public System.Windows.Forms.Label companyCityLabel;
        public System.Windows.Forms.Label companyPkpDateLabel;
        public System.Windows.Forms.Label companyNpwpLabel;
        public System.Windows.Forms.Label companyFaxLabel;
        public System.Windows.Forms.TextBox companyFaxTextBox;
        public System.Windows.Forms.DateTimePicker companyPkpDateDateTimePicker;
        public System.Windows.Forms.TextBox companyNpwpTextBox;
        public System.Windows.Forms.TextBox companyAddress2TextBox;
        public System.Windows.Forms.PictureBox companyLogoPictureBox;
        public System.Windows.Forms.Button button_ChangeLogo;
        public System.Windows.Forms.Label label_ImageLogoLocation;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}
