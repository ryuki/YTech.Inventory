namespace Inventori.PointOfSales.Forms
{
    partial class FormMasterCustomer
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
            System.Windows.Forms.Label customerAddressLabel;
            System.Windows.Forms.Label customerIdLabel;
            System.Windows.Forms.Label customerNameLabel;
            System.Windows.Forms.Label customerPhoneLabel;
            System.Windows.Forms.Label customerFaxLabel;
            System.Windows.Forms.Label customerNpwpLabel;
            this.customerAddressTextBox = new System.Windows.Forms.TextBox();
            this.customerIdTextBox = new System.Windows.Forms.TextBox();
            this.customerNameTextBox = new System.Windows.Forms.TextBox();
            this.customerPhoneTextBox = new System.Windows.Forms.TextBox();
            this.customerFaxTextBox = new System.Windows.Forms.TextBox();
            this.customerNpwpTextBox = new System.Windows.Forms.TextBox();
            customerAddressLabel = new System.Windows.Forms.Label();
            customerIdLabel = new System.Windows.Forms.Label();
            customerNameLabel = new System.Windows.Forms.Label();
            customerPhoneLabel = new System.Windows.Forms.Label();
            customerFaxLabel = new System.Windows.Forms.Label();
            customerNpwpLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MCustomer);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(customerNpwpLabel);
            this.groupBox1.Controls.Add(this.customerNpwpTextBox);
            this.groupBox1.Controls.Add(customerFaxLabel);
            this.groupBox1.Controls.Add(this.customerFaxTextBox);
            this.groupBox1.Controls.Add(customerAddressLabel);
            this.groupBox1.Controls.Add(this.customerAddressTextBox);
            this.groupBox1.Controls.Add(customerIdLabel);
            this.groupBox1.Controls.Add(this.customerIdTextBox);
            this.groupBox1.Controls.Add(customerNameLabel);
            this.groupBox1.Controls.Add(this.customerNameTextBox);
            this.groupBox1.Controls.Add(this.customerPhoneTextBox);
            this.groupBox1.Controls.Add(customerPhoneLabel);
            this.groupBox1.Size = new System.Drawing.Size(788, 214);
            this.groupBox1.Text = "Master Detail Pelanggan";
            this.groupBox1.Controls.SetChildIndex(customerPhoneLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.customerPhoneTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.customerNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(customerNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.customerIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(customerIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.customerAddressTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(customerAddressLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.customerFaxTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(customerFaxLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.customerNpwpTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(customerNpwpLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 214;
            // 
            // customerAddressLabel
            // 
            customerAddressLabel.AutoSize = true;
            customerAddressLabel.Location = new System.Drawing.Point(12, 151);
            customerAddressLabel.Name = "customerAddressLabel";
            customerAddressLabel.Size = new System.Drawing.Size(96, 13);
            customerAddressLabel.TabIndex = 13;
            customerAddressLabel.Text = "Alamat Pelanggan:";
            // 
            // customerIdLabel
            // 
            customerIdLabel.AutoSize = true;
            customerIdLabel.Location = new System.Drawing.Point(12, 21);
            customerIdLabel.Name = "customerIdLabel";
            customerIdLabel.Size = new System.Drawing.Size(89, 13);
            customerIdLabel.TabIndex = 15;
            customerIdLabel.Text = "Kode Pelanggan:";
            // 
            // customerNameLabel
            // 
            customerNameLabel.AutoSize = true;
            customerNameLabel.Location = new System.Drawing.Point(12, 47);
            customerNameLabel.Name = "customerNameLabel";
            customerNameLabel.Size = new System.Drawing.Size(92, 13);
            customerNameLabel.TabIndex = 17;
            customerNameLabel.Text = "Nama Pelanggan:";
            // 
            // customerPhoneLabel
            // 
            customerPhoneLabel.AutoSize = true;
            customerPhoneLabel.Location = new System.Drawing.Point(12, 99);
            customerPhoneLabel.Name = "customerPhoneLabel";
            customerPhoneLabel.Size = new System.Drawing.Size(85, 13);
            customerPhoneLabel.TabIndex = 19;
            customerPhoneLabel.Text = "Telp Pelanggan:";
            // 
            // customerAddressTextBox
            // 
            this.customerAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "CustomerAddress", true));
            this.customerAddressTextBox.Location = new System.Drawing.Point(113, 148);
            this.customerAddressTextBox.Multiline = true;
            this.customerAddressTextBox.Name = "customerAddressTextBox";
            this.customerAddressTextBox.Size = new System.Drawing.Size(277, 54);
            this.customerAddressTextBox.TabIndex = 14;
            this.customerAddressTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // customerIdTextBox
            // 
            this.customerIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "CustomerId", true));
            this.customerIdTextBox.Location = new System.Drawing.Point(113, 18);
            this.customerIdTextBox.Name = "customerIdTextBox";
            this.customerIdTextBox.Size = new System.Drawing.Size(121, 20);
            this.customerIdTextBox.TabIndex = 16;
            this.customerIdTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // customerNameTextBox
            // 
            this.customerNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "CustomerName", true));
            this.customerNameTextBox.Location = new System.Drawing.Point(113, 44);
            this.customerNameTextBox.Name = "customerNameTextBox";
            this.customerNameTextBox.Size = new System.Drawing.Size(198, 20);
            this.customerNameTextBox.TabIndex = 18;
            this.customerNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // customerPhoneTextBox
            // 
            this.customerPhoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "CustomerPhone", true));
            this.customerPhoneTextBox.Location = new System.Drawing.Point(113, 96);
            this.customerPhoneTextBox.Name = "customerPhoneTextBox";
            this.customerPhoneTextBox.Size = new System.Drawing.Size(166, 20);
            this.customerPhoneTextBox.TabIndex = 20;
            this.customerPhoneTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // customerFaxLabel
            // 
            customerFaxLabel.AutoSize = true;
            customerFaxLabel.Location = new System.Drawing.Point(12, 125);
            customerFaxLabel.Name = "customerFaxLabel";
            customerFaxLabel.Size = new System.Drawing.Size(44, 13);
            customerFaxLabel.TabIndex = 20;
            customerFaxLabel.Text = "No Fax:";
            // 
            // customerFaxTextBox
            // 
            this.customerFaxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "CustomerFax", true));
            this.customerFaxTextBox.Location = new System.Drawing.Point(113, 122);
            this.customerFaxTextBox.Name = "customerFaxTextBox";
            this.customerFaxTextBox.Size = new System.Drawing.Size(166, 20);
            this.customerFaxTextBox.TabIndex = 21;
            // 
            // customerNpwpLabel
            // 
            customerNpwpLabel.AutoSize = true;
            customerNpwpLabel.Location = new System.Drawing.Point(12, 73);
            customerNpwpLabel.Name = "customerNpwpLabel";
            customerNpwpLabel.Size = new System.Drawing.Size(46, 13);
            customerNpwpLabel.TabIndex = 21;
            customerNpwpLabel.Text = "NPWP :";
            // 
            // customerNpwpTextBox
            // 
            this.customerNpwpTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "CustomerNpwp", true));
            this.customerNpwpTextBox.Location = new System.Drawing.Point(113, 70);
            this.customerNpwpTextBox.Name = "customerNpwpTextBox";
            this.customerNpwpTextBox.Size = new System.Drawing.Size(166, 20);
            this.customerNpwpTextBox.TabIndex = 22;
            // 
            // FormMasterCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterCustomer";
            this.TabText = "Master Pelanggan";
            this.Text = "Master Pelanggan";
            this.Load += new System.EventHandler(this.FormMasterCustomer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox customerAddressTextBox;
        private System.Windows.Forms.TextBox customerIdTextBox;
        private System.Windows.Forms.TextBox customerNameTextBox;
        private System.Windows.Forms.TextBox customerPhoneTextBox;
        private System.Windows.Forms.TextBox customerNpwpTextBox;
        private System.Windows.Forms.TextBox customerFaxTextBox;

    }
}