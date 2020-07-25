namespace Inventori.Apotek.Forms
{
    partial class FormMasterCommission
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
            System.Windows.Forms.Label commissionStatusLabel;
            System.Windows.Forms.Label commissionDescLabel;
            System.Windows.Forms.Label commissionValueLabel;
            System.Windows.Forms.Label label1;
            this.mCommissionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.commissionStatusComboBox = new System.Windows.Forms.ComboBox();
            this.commissionDescTextBox = new System.Windows.Forms.TextBox();
            this.commissionValueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox_CommissionShare = new System.Windows.Forms.GroupBox();
            this.tabControl_CommissionShare = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.shareDescLabel = new System.Windows.Forms.Label();
            this.shareDescTextBox = new System.Windows.Forms.TextBox();
            this.mCommissionShareBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.shareValueLabel = new System.Windows.Forms.Label();
            this.shareValueNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.shareToLabel = new System.Windows.Forms.Label();
            this.shareToLabel1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            commissionStatusLabel = new System.Windows.Forms.Label();
            commissionDescLabel = new System.Windows.Forms.Label();
            commissionValueLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mCommissionBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.commissionValueNumericUpDown)).BeginInit();
            this.groupBox_CommissionShare.SuspendLayout();
            this.tabControl_CommissionShare.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mCommissionShareBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shareValueNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_UserName
            // 
            this.lbl_UserName.Location = new System.Drawing.Point(2, 0);
            // 
            // commissionStatusLabel
            // 
            commissionStatusLabel.AutoSize = true;
            commissionStatusLabel.Location = new System.Drawing.Point(21, 23);
            commissionStatusLabel.Name = "commissionStatusLabel";
            commissionStatusLabel.Size = new System.Drawing.Size(87, 13);
            commissionStatusLabel.TabIndex = 2;
            commissionStatusLabel.Text = "Kategori Tuslah :";
            // 
            // commissionDescLabel
            // 
            commissionDescLabel.AutoSize = true;
            commissionDescLabel.Location = new System.Drawing.Point(21, 76);
            commissionDescLabel.Name = "commissionDescLabel";
            commissionDescLabel.Size = new System.Drawing.Size(68, 13);
            commissionDescLabel.TabIndex = 3;
            commissionDescLabel.Text = "Keterangan :";
            // 
            // commissionValueLabel
            // 
            commissionValueLabel.AutoSize = true;
            commissionValueLabel.Location = new System.Drawing.Point(21, 49);
            commissionValueLabel.Name = "commissionValueLabel";
            commissionValueLabel.Size = new System.Drawing.Size(68, 13);
            commissionValueLabel.TabIndex = 5;
            commissionValueLabel.Text = "Nilai Tuslah :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(122, 49);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(24, 13);
            label1.TabIndex = 8;
            label1.Text = "Rp.";
            // 
            // mCommissionBindingSource
            // 
            this.mCommissionBindingSource.DataSource = typeof(Inventori.Data.MCommission);
            // 
            // commissionStatusComboBox
            // 
            this.commissionStatusComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mCommissionBindingSource, "CommissionStatus", true));
            this.commissionStatusComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.commissionStatusComboBox.FormattingEnabled = true;
            this.commissionStatusComboBox.Location = new System.Drawing.Point(125, 20);
            this.commissionStatusComboBox.Name = "commissionStatusComboBox";
            this.commissionStatusComboBox.Size = new System.Drawing.Size(121, 21);
            this.commissionStatusComboBox.TabIndex = 3;
            this.commissionStatusComboBox.SelectedIndexChanged += new System.EventHandler(this.commissionStatusComboBox_SelectedIndexChanged);
            // 
            // commissionDescTextBox
            // 
            this.commissionDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mCommissionBindingSource, "CommissionDesc", true));
            this.commissionDescTextBox.Location = new System.Drawing.Point(125, 73);
            this.commissionDescTextBox.Multiline = true;
            this.commissionDescTextBox.Name = "commissionDescTextBox";
            this.commissionDescTextBox.Size = new System.Drawing.Size(203, 87);
            this.commissionDescTextBox.TabIndex = 4;
            // 
            // commissionValueNumericUpDown
            // 
            this.commissionValueNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.mCommissionBindingSource, "CommissionValue", true));
            this.commissionValueNumericUpDown.Location = new System.Drawing.Point(151, 47);
            this.commissionValueNumericUpDown.Name = "commissionValueNumericUpDown";
            this.commissionValueNumericUpDown.Size = new System.Drawing.Size(95, 20);
            this.commissionValueNumericUpDown.TabIndex = 6;
            // 
            // groupBox_CommissionShare
            // 
            this.groupBox_CommissionShare.Controls.Add(this.tabControl_CommissionShare);
            this.groupBox_CommissionShare.Location = new System.Drawing.Point(24, 172);
            this.groupBox_CommissionShare.Name = "groupBox_CommissionShare";
            this.groupBox_CommissionShare.Size = new System.Drawing.Size(337, 206);
            this.groupBox_CommissionShare.TabIndex = 7;
            this.groupBox_CommissionShare.TabStop = false;
            this.groupBox_CommissionShare.Text = "Pembagian Tuslah (%)";
            // 
            // tabControl_CommissionShare
            // 
            this.tabControl_CommissionShare.Controls.Add(this.tabPage1);
            this.tabControl_CommissionShare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_CommissionShare.Location = new System.Drawing.Point(3, 16);
            this.tabControl_CommissionShare.Name = "tabControl_CommissionShare";
            this.tabControl_CommissionShare.SelectedIndex = 0;
            this.tabControl_CommissionShare.Size = new System.Drawing.Size(331, 187);
            this.tabControl_CommissionShare.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.shareDescLabel);
            this.tabPage1.Controls.Add(this.shareDescTextBox);
            this.tabPage1.Controls.Add(this.shareValueLabel);
            this.tabPage1.Controls.Add(this.shareValueNumericUpDown);
            this.tabPage1.Controls.Add(this.shareToLabel);
            this.tabPage1.Controls.Add(this.shareToLabel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(323, 161);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // shareDescLabel
            // 
            this.shareDescLabel.AutoSize = true;
            this.shareDescLabel.Location = new System.Drawing.Point(12, 65);
            this.shareDescLabel.Name = "shareDescLabel";
            this.shareDescLabel.Size = new System.Drawing.Size(68, 13);
            this.shareDescLabel.TabIndex = 4;
            this.shareDescLabel.Text = "Keterangan :";
            // 
            // shareDescTextBox
            // 
            this.shareDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mCommissionShareBindingSource, "ShareDesc", true));
            this.shareDescTextBox.Location = new System.Drawing.Point(92, 62);
            this.shareDescTextBox.Multiline = true;
            this.shareDescTextBox.Name = "shareDescTextBox";
            this.shareDescTextBox.Size = new System.Drawing.Size(228, 78);
            this.shareDescTextBox.TabIndex = 5;
            // 
            // mCommissionShareBindingSource
            // 
            this.mCommissionShareBindingSource.DataSource = typeof(Inventori.Data.MCommissionShare);
            // 
            // shareValueLabel
            // 
            this.shareValueLabel.AutoSize = true;
            this.shareValueLabel.Location = new System.Drawing.Point(12, 38);
            this.shareValueLabel.Name = "shareValueLabel";
            this.shareValueLabel.Size = new System.Drawing.Size(50, 13);
            this.shareValueLabel.TabIndex = 2;
            this.shareValueLabel.Text = "Nilai (%) :";
            // 
            // shareValueNumericUpDown
            // 
            this.shareValueNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.mCommissionShareBindingSource, "ShareValue", true));
            this.shareValueNumericUpDown.Location = new System.Drawing.Point(92, 36);
            this.shareValueNumericUpDown.Name = "shareValueNumericUpDown";
            this.shareValueNumericUpDown.Size = new System.Drawing.Size(61, 20);
            this.shareValueNumericUpDown.TabIndex = 3;
            // 
            // shareToLabel
            // 
            this.shareToLabel.AutoSize = true;
            this.shareToLabel.Location = new System.Drawing.Point(12, 17);
            this.shareToLabel.Name = "shareToLabel";
            this.shareToLabel.Size = new System.Drawing.Size(77, 13);
            this.shareToLabel.TabIndex = 0;
            this.shareToLabel.Text = "Dibagikan Ke :";
            // 
            // shareToLabel1
            // 
            this.shareToLabel1.AutoSize = true;
            this.shareToLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mCommissionShareBindingSource, "ShareTo", true));
            this.shareToLabel1.Location = new System.Drawing.Point(89, 17);
            this.shareToLabel1.Name = "shareToLabel1";
            this.shareToLabel1.Size = new System.Drawing.Size(48, 13);
            this.shareToLabel1.TabIndex = 1;
            this.shareToLabel1.Text = "ShareTo";
            // 
            // button1
            // 
            this.button1.Image = global::Inventori.Apotek.Forms.Properties.Resources.save;
            this.button1.Location = new System.Drawing.Point(133, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "Simpan";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormMasterCommission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(382, 426);
            this.Controls.Add(this.button1);
            this.Controls.Add(label1);
            this.Controls.Add(this.groupBox_CommissionShare);
            this.Controls.Add(commissionValueLabel);
            this.Controls.Add(this.commissionValueNumericUpDown);
            this.Controls.Add(commissionDescLabel);
            this.Controls.Add(this.commissionDescTextBox);
            this.Controls.Add(commissionStatusLabel);
            this.Controls.Add(this.commissionStatusComboBox);
            this.Name = "FormMasterCommission";
            this.TabText = "Master Tuslah";
            this.Text = "Master Tuslah";
            this.Load += new System.EventHandler(this.FormMasterCommission_Load);
            this.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.Controls.SetChildIndex(this.commissionStatusComboBox, 0);
            this.Controls.SetChildIndex(commissionStatusLabel, 0);
            this.Controls.SetChildIndex(this.commissionDescTextBox, 0);
            this.Controls.SetChildIndex(commissionDescLabel, 0);
            this.Controls.SetChildIndex(this.commissionValueNumericUpDown, 0);
            this.Controls.SetChildIndex(commissionValueLabel, 0);
            this.Controls.SetChildIndex(this.groupBox_CommissionShare, 0);
            this.Controls.SetChildIndex(label1, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.mCommissionBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.commissionValueNumericUpDown)).EndInit();
            this.groupBox_CommissionShare.ResumeLayout(false);
            this.tabControl_CommissionShare.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mCommissionShareBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shareValueNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource mCommissionBindingSource;
        private System.Windows.Forms.ComboBox commissionStatusComboBox;
        private System.Windows.Forms.TextBox commissionDescTextBox;
        private System.Windows.Forms.NumericUpDown commissionValueNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox_CommissionShare;
        private System.Windows.Forms.TabControl tabControl_CommissionShare;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox shareDescTextBox;
        private System.Windows.Forms.BindingSource mCommissionShareBindingSource;
        private System.Windows.Forms.NumericUpDown shareValueNumericUpDown;
        private System.Windows.Forms.Label shareToLabel1;
        private System.Windows.Forms.Label shareDescLabel;
        private System.Windows.Forms.Label shareValueLabel;
        private System.Windows.Forms.Label shareToLabel;
        private System.Windows.Forms.Button button1;
    }
}