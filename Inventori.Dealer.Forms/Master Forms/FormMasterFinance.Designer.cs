namespace Inventori.Dealer.Forms
{
    partial class FormMasterFinance
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
            System.Windows.Forms.Label financeIdLabel;
            System.Windows.Forms.Label financeNameLabel;
            System.Windows.Forms.Label financeNpwpLabel;
            System.Windows.Forms.Label financePhoneLabel;
            System.Windows.Forms.Label financeFaxLabel;
            System.Windows.Forms.Label financeAddressLabel;
            this.financeIdTextBox = new System.Windows.Forms.TextBox();
            this.financeNameTextBox = new System.Windows.Forms.TextBox();
            this.financeNpwpTextBox = new System.Windows.Forms.TextBox();
            this.financePhoneTextBox = new System.Windows.Forms.TextBox();
            this.financeFaxTextBox = new System.Windows.Forms.TextBox();
            this.financeAddressTextBox = new System.Windows.Forms.TextBox();
            financeIdLabel = new System.Windows.Forms.Label();
            financeNameLabel = new System.Windows.Forms.Label();
            financeNpwpLabel = new System.Windows.Forms.Label();
            financePhoneLabel = new System.Windows.Forms.Label();
            financeFaxLabel = new System.Windows.Forms.Label();
            financeAddressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MFinance);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(financeAddressLabel);
            this.groupBox1.Controls.Add(this.financeAddressTextBox);
            this.groupBox1.Controls.Add(financeFaxLabel);
            this.groupBox1.Controls.Add(this.financeFaxTextBox);
            this.groupBox1.Controls.Add(financePhoneLabel);
            this.groupBox1.Controls.Add(this.financePhoneTextBox);
            this.groupBox1.Controls.Add(financeNpwpLabel);
            this.groupBox1.Controls.Add(this.financeNpwpTextBox);
            this.groupBox1.Controls.Add(financeNameLabel);
            this.groupBox1.Controls.Add(this.financeNameTextBox);
            this.groupBox1.Controls.Add(financeIdLabel);
            this.groupBox1.Controls.Add(this.financeIdTextBox);
            this.groupBox1.Text = "Master Detail Finance";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.financeIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(financeIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.financeNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(financeNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.financeNpwpTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(financeNpwpLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.financePhoneTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(financePhoneLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.financeFaxTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(financeFaxLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.financeAddressTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(financeAddressLabel, 0);
            // 
            // splitContainer1
            // 
            // 
            // financeIdLabel
            // 
            financeIdLabel.AutoSize = true;
            financeIdLabel.Location = new System.Drawing.Point(16, 28);
            financeIdLabel.Name = "financeIdLabel";
            financeIdLabel.Size = new System.Drawing.Size(79, 13);
            financeIdLabel.TabIndex = 1;
            financeIdLabel.Text = "Kode Finance :";
            // 
            // financeNameLabel
            // 
            financeNameLabel.AutoSize = true;
            financeNameLabel.Location = new System.Drawing.Point(16, 54);
            financeNameLabel.Name = "financeNameLabel";
            financeNameLabel.Size = new System.Drawing.Size(82, 13);
            financeNameLabel.TabIndex = 3;
            financeNameLabel.Text = "Nama Finance :";
            // 
            // financeNpwpLabel
            // 
            financeNpwpLabel.AutoSize = true;
            financeNpwpLabel.Location = new System.Drawing.Point(16, 80);
            financeNpwpLabel.Name = "financeNpwpLabel";
            financeNpwpLabel.Size = new System.Drawing.Size(46, 13);
            financeNpwpLabel.TabIndex = 5;
            financeNpwpLabel.Text = "NPWP :";
            // 
            // financePhoneLabel
            // 
            financePhoneLabel.AutoSize = true;
            financePhoneLabel.Location = new System.Drawing.Point(16, 106);
            financePhoneLabel.Name = "financePhoneLabel";
            financePhoneLabel.Size = new System.Drawing.Size(52, 13);
            financePhoneLabel.TabIndex = 7;
            financePhoneLabel.Text = "Telepon :";
            // 
            // financeFaxLabel
            // 
            financeFaxLabel.AutoSize = true;
            financeFaxLabel.Location = new System.Drawing.Point(16, 132);
            financeFaxLabel.Name = "financeFaxLabel";
            financeFaxLabel.Size = new System.Drawing.Size(30, 13);
            financeFaxLabel.TabIndex = 9;
            financeFaxLabel.Text = "Fax :";
            // 
            // financeAddressLabel
            // 
            financeAddressLabel.AutoSize = true;
            financeAddressLabel.Location = new System.Drawing.Point(16, 158);
            financeAddressLabel.Name = "financeAddressLabel";
            financeAddressLabel.Size = new System.Drawing.Size(45, 13);
            financeAddressLabel.TabIndex = 11;
            financeAddressLabel.Text = "Alamat :";
            // 
            // financeIdTextBox
            // 
            this.financeIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "FinanceId", true));
            this.financeIdTextBox.Location = new System.Drawing.Point(125, 25);
            this.financeIdTextBox.Name = "financeIdTextBox";
            this.financeIdTextBox.Size = new System.Drawing.Size(173, 20);
            this.financeIdTextBox.TabIndex = 2;
            // 
            // financeNameTextBox
            // 
            this.financeNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "FinanceName", true));
            this.financeNameTextBox.Location = new System.Drawing.Point(125, 51);
            this.financeNameTextBox.Name = "financeNameTextBox";
            this.financeNameTextBox.Size = new System.Drawing.Size(173, 20);
            this.financeNameTextBox.TabIndex = 4;
            // 
            // financeNpwpTextBox
            // 
            this.financeNpwpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "FinanceNpwp", true));
            this.financeNpwpTextBox.Location = new System.Drawing.Point(125, 77);
            this.financeNpwpTextBox.Name = "financeNpwpTextBox";
            this.financeNpwpTextBox.Size = new System.Drawing.Size(173, 20);
            this.financeNpwpTextBox.TabIndex = 6;
            // 
            // financePhoneTextBox
            // 
            this.financePhoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "FinancePhone", true));
            this.financePhoneTextBox.Location = new System.Drawing.Point(125, 103);
            this.financePhoneTextBox.Name = "financePhoneTextBox";
            this.financePhoneTextBox.Size = new System.Drawing.Size(173, 20);
            this.financePhoneTextBox.TabIndex = 8;
            // 
            // financeFaxTextBox
            // 
            this.financeFaxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "FinanceFax", true));
            this.financeFaxTextBox.Location = new System.Drawing.Point(125, 129);
            this.financeFaxTextBox.Name = "financeFaxTextBox";
            this.financeFaxTextBox.Size = new System.Drawing.Size(173, 20);
            this.financeFaxTextBox.TabIndex = 10;
            // 
            // financeAddressTextBox
            // 
            this.financeAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "FinanceDesc", true));
            this.financeAddressTextBox.Location = new System.Drawing.Point(125, 155);
            this.financeAddressTextBox.Multiline = true;
            this.financeAddressTextBox.Name = "financeAddressTextBox";
            this.financeAddressTextBox.Size = new System.Drawing.Size(255, 88);
            this.financeAddressTextBox.TabIndex = 12;
            // 
            // FormMasterFinance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterFinance";
            this.TabText = "Master Finance";
            this.Text = "Master Finance";
            this.Load += new System.EventHandler(this.FormMasterFinance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox financeIdTextBox;
        private System.Windows.Forms.TextBox financeNpwpTextBox;
        private System.Windows.Forms.TextBox financeNameTextBox;
        private System.Windows.Forms.TextBox financeFaxTextBox;
        private System.Windows.Forms.TextBox financePhoneTextBox;
        private System.Windows.Forms.TextBox financeAddressTextBox;
    }
}