namespace Inventori.PointOfSales.Forms
{
    partial class FormMasterEkspedission
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
            System.Windows.Forms.Label ekspedissionAddressLabel;
            System.Windows.Forms.Label ekspedissionDescLabel;
            System.Windows.Forms.Label ekspedissionFaxLabel;
            System.Windows.Forms.Label ekspedissionIdLabel;
            System.Windows.Forms.Label ekspedissionNameLabel;
            System.Windows.Forms.Label ekspedissionNpwpLabel;
            System.Windows.Forms.Label ekspedissionPhoneLabel;
            this.ekspedissionAddressTextBox = new System.Windows.Forms.TextBox();
            this.ekspedissionDescTextBox = new System.Windows.Forms.TextBox();
            this.ekspedissionFaxTextBox = new System.Windows.Forms.TextBox();
            this.ekspedissionIdTextBox = new System.Windows.Forms.TextBox();
            this.ekspedissionNameTextBox = new System.Windows.Forms.TextBox();
            this.ekspedissionNpwpTextBox = new System.Windows.Forms.TextBox();
            this.ekspedissionPhoneTextBox = new System.Windows.Forms.TextBox();
            ekspedissionAddressLabel = new System.Windows.Forms.Label();
            ekspedissionDescLabel = new System.Windows.Forms.Label();
            ekspedissionFaxLabel = new System.Windows.Forms.Label();
            ekspedissionIdLabel = new System.Windows.Forms.Label();
            ekspedissionNameLabel = new System.Windows.Forms.Label();
            ekspedissionNpwpLabel = new System.Windows.Forms.Label();
            ekspedissionPhoneLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MEkspedission);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(ekspedissionAddressLabel);
            this.groupBox1.Controls.Add(this.ekspedissionAddressTextBox);
            this.groupBox1.Controls.Add(ekspedissionDescLabel);
            this.groupBox1.Controls.Add(this.ekspedissionDescTextBox);
            this.groupBox1.Controls.Add(ekspedissionFaxLabel);
            this.groupBox1.Controls.Add(this.ekspedissionFaxTextBox);
            this.groupBox1.Controls.Add(ekspedissionIdLabel);
            this.groupBox1.Controls.Add(this.ekspedissionIdTextBox);
            this.groupBox1.Controls.Add(ekspedissionNameLabel);
            this.groupBox1.Controls.Add(this.ekspedissionNameTextBox);
            this.groupBox1.Controls.Add(ekspedissionNpwpLabel);
            this.groupBox1.Controls.Add(this.ekspedissionNpwpTextBox);
            this.groupBox1.Controls.Add(ekspedissionPhoneLabel);
            this.groupBox1.Controls.Add(this.ekspedissionPhoneTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 304);
            this.groupBox1.Text = "Master Detail Ekspedisi";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.ekspedissionPhoneTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(ekspedissionPhoneLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.ekspedissionNpwpTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(ekspedissionNpwpLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.ekspedissionNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(ekspedissionNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.ekspedissionIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(ekspedissionIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.ekspedissionFaxTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(ekspedissionFaxLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.ekspedissionDescTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(ekspedissionDescLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.ekspedissionAddressTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(ekspedissionAddressLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 304;
            // 
            // ekspedissionAddressLabel
            // 
            ekspedissionAddressLabel.AutoSize = true;
            ekspedissionAddressLabel.Location = new System.Drawing.Point(17, 82);
            ekspedissionAddressLabel.Name = "ekspedissionAddressLabel";
            ekspedissionAddressLabel.Size = new System.Drawing.Size(45, 13);
            ekspedissionAddressLabel.TabIndex = 1;
            ekspedissionAddressLabel.Text = "Alamat :";
            // 
            // ekspedissionDescLabel
            // 
            ekspedissionDescLabel.AutoSize = true;
            ekspedissionDescLabel.Location = new System.Drawing.Point(17, 229);
            ekspedissionDescLabel.Name = "ekspedissionDescLabel";
            ekspedissionDescLabel.Size = new System.Drawing.Size(68, 13);
            ekspedissionDescLabel.TabIndex = 3;
            ekspedissionDescLabel.Text = "Keterangan :";
            // 
            // ekspedissionFaxLabel
            // 
            ekspedissionFaxLabel.AutoSize = true;
            ekspedissionFaxLabel.Location = new System.Drawing.Point(17, 177);
            ekspedissionFaxLabel.Name = "ekspedissionFaxLabel";
            ekspedissionFaxLabel.Size = new System.Drawing.Size(47, 13);
            ekspedissionFaxLabel.TabIndex = 5;
            ekspedissionFaxLabel.Text = "No Fax :";
            // 
            // ekspedissionIdLabel
            // 
            ekspedissionIdLabel.AutoSize = true;
            ekspedissionIdLabel.Location = new System.Drawing.Point(17, 30);
            ekspedissionIdLabel.Name = "ekspedissionIdLabel";
            ekspedissionIdLabel.Size = new System.Drawing.Size(86, 13);
            ekspedissionIdLabel.TabIndex = 7;
            ekspedissionIdLabel.Text = "Kode Ekspedisi :";
            // 
            // ekspedissionNameLabel
            // 
            ekspedissionNameLabel.AutoSize = true;
            ekspedissionNameLabel.Location = new System.Drawing.Point(17, 56);
            ekspedissionNameLabel.Name = "ekspedissionNameLabel";
            ekspedissionNameLabel.Size = new System.Drawing.Size(89, 13);
            ekspedissionNameLabel.TabIndex = 9;
            ekspedissionNameLabel.Text = "Nama Ekspedisi :";
            // 
            // ekspedissionNpwpLabel
            // 
            ekspedissionNpwpLabel.AutoSize = true;
            ekspedissionNpwpLabel.Location = new System.Drawing.Point(17, 203);
            ekspedissionNpwpLabel.Name = "ekspedissionNpwpLabel";
            ekspedissionNpwpLabel.Size = new System.Drawing.Size(46, 13);
            ekspedissionNpwpLabel.TabIndex = 11;
            ekspedissionNpwpLabel.Text = "NPWP :";
            // 
            // ekspedissionPhoneLabel
            // 
            ekspedissionPhoneLabel.AutoSize = true;
            ekspedissionPhoneLabel.Location = new System.Drawing.Point(17, 151);
            ekspedissionPhoneLabel.Name = "ekspedissionPhoneLabel";
            ekspedissionPhoneLabel.Size = new System.Drawing.Size(69, 13);
            ekspedissionPhoneLabel.TabIndex = 13;
            ekspedissionPhoneLabel.Text = "No Telepon :";
            // 
            // ekspedissionAddressTextBox
            // 
            this.ekspedissionAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "EkspedissionAddress", true));
            this.ekspedissionAddressTextBox.Location = new System.Drawing.Point(136, 79);
            this.ekspedissionAddressTextBox.Multiline = true;
            this.ekspedissionAddressTextBox.Name = "ekspedissionAddressTextBox";
            this.ekspedissionAddressTextBox.Size = new System.Drawing.Size(222, 63);
            this.ekspedissionAddressTextBox.TabIndex = 2;
            this.ekspedissionAddressTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // ekspedissionDescTextBox
            // 
            this.ekspedissionDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "EkspedissionDesc", true));
            this.ekspedissionDescTextBox.Location = new System.Drawing.Point(136, 226);
            this.ekspedissionDescTextBox.Multiline = true;
            this.ekspedissionDescTextBox.Name = "ekspedissionDescTextBox";
            this.ekspedissionDescTextBox.Size = new System.Drawing.Size(222, 67);
            this.ekspedissionDescTextBox.TabIndex = 4;
            this.ekspedissionDescTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // ekspedissionFaxTextBox
            // 
            this.ekspedissionFaxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "EkspedissionFax", true));
            this.ekspedissionFaxTextBox.Location = new System.Drawing.Point(136, 174);
            this.ekspedissionFaxTextBox.Name = "ekspedissionFaxTextBox";
            this.ekspedissionFaxTextBox.Size = new System.Drawing.Size(143, 20);
            this.ekspedissionFaxTextBox.TabIndex = 6;
            this.ekspedissionFaxTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // ekspedissionIdTextBox
            // 
            this.ekspedissionIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "EkspedissionId", true));
            this.ekspedissionIdTextBox.Location = new System.Drawing.Point(136, 27);
            this.ekspedissionIdTextBox.Name = "ekspedissionIdTextBox";
            this.ekspedissionIdTextBox.Size = new System.Drawing.Size(154, 20);
            this.ekspedissionIdTextBox.TabIndex = 8;
            this.ekspedissionIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // ekspedissionNameTextBox
            // 
            this.ekspedissionNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "EkspedissionName", true));
            this.ekspedissionNameTextBox.Location = new System.Drawing.Point(136, 53);
            this.ekspedissionNameTextBox.Name = "ekspedissionNameTextBox";
            this.ekspedissionNameTextBox.Size = new System.Drawing.Size(200, 20);
            this.ekspedissionNameTextBox.TabIndex = 10;
            this.ekspedissionNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // ekspedissionNpwpTextBox
            // 
            this.ekspedissionNpwpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "EkspedissionNpwp", true));
            this.ekspedissionNpwpTextBox.Location = new System.Drawing.Point(136, 200);
            this.ekspedissionNpwpTextBox.Name = "ekspedissionNpwpTextBox";
            this.ekspedissionNpwpTextBox.Size = new System.Drawing.Size(143, 20);
            this.ekspedissionNpwpTextBox.TabIndex = 12;
            this.ekspedissionNpwpTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // ekspedissionPhoneTextBox
            // 
            this.ekspedissionPhoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "EkspedissionPhone", true));
            this.ekspedissionPhoneTextBox.Location = new System.Drawing.Point(136, 148);
            this.ekspedissionPhoneTextBox.Name = "ekspedissionPhoneTextBox";
            this.ekspedissionPhoneTextBox.Size = new System.Drawing.Size(143, 20);
            this.ekspedissionPhoneTextBox.TabIndex = 14;
            this.ekspedissionPhoneTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // FormMasterEkspedission
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterEkspedission";
            this.TabText = "Master Ekspedisi";
            this.Text = "Master Ekspedisi";
            this.Load += new System.EventHandler(this.FormMasterEkspedission_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ekspedissionAddressTextBox;
        private System.Windows.Forms.TextBox ekspedissionDescTextBox;
        private System.Windows.Forms.TextBox ekspedissionFaxTextBox;
        private System.Windows.Forms.TextBox ekspedissionIdTextBox;
        private System.Windows.Forms.TextBox ekspedissionNameTextBox;
        private System.Windows.Forms.TextBox ekspedissionNpwpTextBox;
        private System.Windows.Forms.TextBox ekspedissionPhoneTextBox;
    }
}