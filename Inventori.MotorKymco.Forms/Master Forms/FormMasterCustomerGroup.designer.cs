namespace Inventori.MotorKymco.Forms
{
    partial class FormMasterCustomerGroup
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
            System.Windows.Forms.Label customerGroupDescLabel;
            System.Windows.Forms.Label customerGroupIdLabel;
            System.Windows.Forms.Label customerGroupNameLabel;
            System.Windows.Forms.Label customerGroupPercentageLabel;
            System.Windows.Forms.Label label1;
            this.customerGroupDescTextBox = new System.Windows.Forms.TextBox();
            this.customerGroupIdTextBox = new System.Windows.Forms.TextBox();
            this.customerGroupNameTextBox = new System.Windows.Forms.TextBox();
            this.customerGroupPercentageNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.customerGroupUsePercentageCheckBox = new System.Windows.Forms.CheckBox();
            customerGroupDescLabel = new System.Windows.Forms.Label();
            customerGroupIdLabel = new System.Windows.Forms.Label();
            customerGroupNameLabel = new System.Windows.Forms.Label();
            customerGroupPercentageLabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.customerGroupPercentageNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MCustomerGroup);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.customerGroupUsePercentageCheckBox);
            this.groupBox1.Controls.Add(label1);
            this.groupBox1.Controls.Add(customerGroupDescLabel);
            this.groupBox1.Controls.Add(this.customerGroupDescTextBox);
            this.groupBox1.Controls.Add(customerGroupIdLabel);
            this.groupBox1.Controls.Add(this.customerGroupIdTextBox);
            this.groupBox1.Controls.Add(customerGroupNameLabel);
            this.groupBox1.Controls.Add(this.customerGroupNameTextBox);
            this.groupBox1.Controls.Add(customerGroupPercentageLabel);
            this.groupBox1.Controls.Add(this.customerGroupPercentageNumericUpDown);
            this.groupBox1.Size = new System.Drawing.Size(788, 243);
            this.groupBox1.Text = "Master Detail Golongan Pelanggan";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.customerGroupPercentageNumericUpDown, 0);
            this.groupBox1.Controls.SetChildIndex(customerGroupPercentageLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.customerGroupNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(customerGroupNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.customerGroupIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(customerGroupIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.customerGroupDescTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(customerGroupDescLabel, 0);
            this.groupBox1.Controls.SetChildIndex(label1, 0);
            this.groupBox1.Controls.SetChildIndex(this.customerGroupUsePercentageCheckBox, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 243;
            // 
            // customerGroupDescLabel
            // 
            customerGroupDescLabel.AutoSize = true;
            customerGroupDescLabel.Location = new System.Drawing.Point(9, 100);
            customerGroupDescLabel.Name = "customerGroupDescLabel";
            customerGroupDescLabel.Size = new System.Drawing.Size(68, 13);
            customerGroupDescLabel.TabIndex = 1;
            customerGroupDescLabel.Text = "Keterangan :";
            // 
            // customerGroupIdLabel
            // 
            customerGroupIdLabel.AutoSize = true;
            customerGroupIdLabel.Location = new System.Drawing.Point(9, 22);
            customerGroupIdLabel.Name = "customerGroupIdLabel";
            customerGroupIdLabel.Size = new System.Drawing.Size(141, 13);
            customerGroupIdLabel.TabIndex = 3;
            customerGroupIdLabel.Text = "Kode Golongan Pelanggan :";
            // 
            // customerGroupNameLabel
            // 
            customerGroupNameLabel.AutoSize = true;
            customerGroupNameLabel.Location = new System.Drawing.Point(9, 48);
            customerGroupNameLabel.Name = "customerGroupNameLabel";
            customerGroupNameLabel.Size = new System.Drawing.Size(144, 13);
            customerGroupNameLabel.TabIndex = 5;
            customerGroupNameLabel.Text = "Nama Golongan Pelanggan :";
            // 
            // customerGroupPercentageLabel
            // 
            customerGroupPercentageLabel.AutoSize = true;
            customerGroupPercentageLabel.Location = new System.Drawing.Point(9, 71);
            customerGroupPercentageLabel.Name = "customerGroupPercentageLabel";
            customerGroupPercentageLabel.Size = new System.Drawing.Size(156, 13);
            customerGroupPercentageLabel.TabIndex = 7;
            customerGroupPercentageLabel.Text = "Persentase Diskon Harga Jual :";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(241, 74);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(15, 13);
            label1.TabIndex = 9;
            label1.Text = "%";
            // 
            // customerGroupDescTextBox
            // 
            this.customerGroupDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "CustomerGroupDesc", true));
            this.customerGroupDescTextBox.Location = new System.Drawing.Point(176, 97);
            this.customerGroupDescTextBox.Multiline = true;
            this.customerGroupDescTextBox.Name = "customerGroupDescTextBox";
            this.customerGroupDescTextBox.Size = new System.Drawing.Size(230, 97);
            this.customerGroupDescTextBox.TabIndex = 2;
            // 
            // customerGroupIdTextBox
            // 
            this.customerGroupIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "CustomerGroupId", true));
            this.customerGroupIdTextBox.Location = new System.Drawing.Point(176, 19);
            this.customerGroupIdTextBox.Name = "customerGroupIdTextBox";
            this.customerGroupIdTextBox.Size = new System.Drawing.Size(120, 20);
            this.customerGroupIdTextBox.TabIndex = 4;
            // 
            // customerGroupNameTextBox
            // 
            this.customerGroupNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "CustomerGroupName", true));
            this.customerGroupNameTextBox.Location = new System.Drawing.Point(176, 45);
            this.customerGroupNameTextBox.Name = "customerGroupNameTextBox";
            this.customerGroupNameTextBox.Size = new System.Drawing.Size(120, 20);
            this.customerGroupNameTextBox.TabIndex = 6;
            // 
            // customerGroupPercentageNumericUpDown
            // 
            this.customerGroupPercentageNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource_Master, "CustomerGroupPercentage", true));
            this.customerGroupPercentageNumericUpDown.Location = new System.Drawing.Point(176, 71);
            this.customerGroupPercentageNumericUpDown.Name = "customerGroupPercentageNumericUpDown";
            this.customerGroupPercentageNumericUpDown.Size = new System.Drawing.Size(61, 20);
            this.customerGroupPercentageNumericUpDown.TabIndex = 8;
            // 
            // customerGroupUsePercentageCheckBox
            // 
            this.customerGroupUsePercentageCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bindingSource_Master, "CustomerGroupUsePercentage", true));
            this.customerGroupUsePercentageCheckBox.Location = new System.Drawing.Point(262, 69);
            this.customerGroupUsePercentageCheckBox.Name = "customerGroupUsePercentageCheckBox";
            this.customerGroupUsePercentageCheckBox.Size = new System.Drawing.Size(104, 24);
            this.customerGroupUsePercentageCheckBox.TabIndex = 11;
            this.customerGroupUsePercentageCheckBox.Text = "Gunakan diskon";
            this.customerGroupUsePercentageCheckBox.CheckedChanged += new System.EventHandler(this.customerGroupUsePercentageCheckBox_CheckedChanged);
            // 
            // FormMasterCustomerGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterCustomerGroup";
            this.TabText = "Master Golongan Pelanggan";
            this.Text = "Master Golongan Pelanggan";
            this.Load += new System.EventHandler(this.FormMasterCustomerGroup_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.customerGroupPercentageNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox customerGroupDescTextBox;
        private System.Windows.Forms.TextBox customerGroupIdTextBox;
        private System.Windows.Forms.TextBox customerGroupNameTextBox;
        private System.Windows.Forms.NumericUpDown customerGroupPercentageNumericUpDown;
        private System.Windows.Forms.CheckBox customerGroupUsePercentageCheckBox;
    }
}