namespace Inventori.Dealer.Forms
{
    partial class FormMasterChannel
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
            System.Windows.Forms.Label channelIdLabel;
            System.Windows.Forms.Label channelNameLabel;
            System.Windows.Forms.Label channelPhoneLabel;
            System.Windows.Forms.Label channelFaxLabel;
            System.Windows.Forms.Label channelAddressLabel;
            this.channelIdTextBox = new System.Windows.Forms.TextBox();
            this.channelNameTextBox = new System.Windows.Forms.TextBox();
            this.channelPhoneTextBox = new System.Windows.Forms.TextBox();
            this.channelFaxTextBox = new System.Windows.Forms.TextBox();
            this.channelAddressTextBox = new System.Windows.Forms.TextBox();
            channelIdLabel = new System.Windows.Forms.Label();
            channelNameLabel = new System.Windows.Forms.Label();
            channelPhoneLabel = new System.Windows.Forms.Label();
            channelFaxLabel = new System.Windows.Forms.Label();
            channelAddressLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MChannel);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(channelAddressLabel);
            this.groupBox1.Controls.Add(this.channelAddressTextBox);
            this.groupBox1.Controls.Add(channelFaxLabel);
            this.groupBox1.Controls.Add(this.channelFaxTextBox);
            this.groupBox1.Controls.Add(channelPhoneLabel);
            this.groupBox1.Controls.Add(this.channelPhoneTextBox);
            this.groupBox1.Controls.Add(channelNameLabel);
            this.groupBox1.Controls.Add(this.channelNameTextBox);
            this.groupBox1.Controls.Add(channelIdLabel);
            this.groupBox1.Controls.Add(this.channelIdTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 230);
            this.groupBox1.Text = "Master Detail Channel";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.channelIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(channelIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.channelNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(channelNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.channelPhoneTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(channelPhoneLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.channelFaxTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(channelFaxLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.channelAddressTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(channelAddressLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 230;
            // 
            // channelIdLabel
            // 
            channelIdLabel.AutoSize = true;
            channelIdLabel.Location = new System.Drawing.Point(17, 22);
            channelIdLabel.Name = "channelIdLabel";
            channelIdLabel.Size = new System.Drawing.Size(80, 13);
            channelIdLabel.TabIndex = 1;
            channelIdLabel.Text = "Kode Channel :";
            // 
            // channelNameLabel
            // 
            channelNameLabel.AutoSize = true;
            channelNameLabel.Location = new System.Drawing.Point(17, 48);
            channelNameLabel.Name = "channelNameLabel";
            channelNameLabel.Size = new System.Drawing.Size(83, 13);
            channelNameLabel.TabIndex = 3;
            channelNameLabel.Text = "Nama Channel :";
            // 
            // channelPhoneLabel
            // 
            channelPhoneLabel.AutoSize = true;
            channelPhoneLabel.Location = new System.Drawing.Point(17, 74);
            channelPhoneLabel.Name = "channelPhoneLabel";
            channelPhoneLabel.Size = new System.Drawing.Size(34, 13);
            channelPhoneLabel.TabIndex = 5;
            channelPhoneLabel.Text = "Telp :";
            // 
            // channelFaxLabel
            // 
            channelFaxLabel.AutoSize = true;
            channelFaxLabel.Location = new System.Drawing.Point(17, 100);
            channelFaxLabel.Name = "channelFaxLabel";
            channelFaxLabel.Size = new System.Drawing.Size(30, 13);
            channelFaxLabel.TabIndex = 7;
            channelFaxLabel.Text = "Fax :";
            // 
            // channelAddressLabel
            // 
            channelAddressLabel.AutoSize = true;
            channelAddressLabel.Location = new System.Drawing.Point(17, 126);
            channelAddressLabel.Name = "channelAddressLabel";
            channelAddressLabel.Size = new System.Drawing.Size(45, 13);
            channelAddressLabel.TabIndex = 9;
            channelAddressLabel.Text = "Alamat :";
            // 
            // channelIdTextBox
            // 
            this.channelIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ChannelId", true));
            this.channelIdTextBox.Location = new System.Drawing.Point(121, 19);
            this.channelIdTextBox.Name = "channelIdTextBox";
            this.channelIdTextBox.Size = new System.Drawing.Size(144, 20);
            this.channelIdTextBox.TabIndex = 2;
            // 
            // channelNameTextBox
            // 
            this.channelNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ChannelName", true));
            this.channelNameTextBox.Location = new System.Drawing.Point(121, 45);
            this.channelNameTextBox.Name = "channelNameTextBox";
            this.channelNameTextBox.Size = new System.Drawing.Size(144, 20);
            this.channelNameTextBox.TabIndex = 4;
            // 
            // channelPhoneTextBox
            // 
            this.channelPhoneTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ChannelPhone", true));
            this.channelPhoneTextBox.Location = new System.Drawing.Point(121, 71);
            this.channelPhoneTextBox.Name = "channelPhoneTextBox";
            this.channelPhoneTextBox.Size = new System.Drawing.Size(144, 20);
            this.channelPhoneTextBox.TabIndex = 6;
            // 
            // channelFaxTextBox
            // 
            this.channelFaxTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ChannelFax", true));
            this.channelFaxTextBox.Location = new System.Drawing.Point(121, 97);
            this.channelFaxTextBox.Name = "channelFaxTextBox";
            this.channelFaxTextBox.Size = new System.Drawing.Size(144, 20);
            this.channelFaxTextBox.TabIndex = 8;
            // 
            // channelAddressTextBox
            // 
            this.channelAddressTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ChannelAddress", true));
            this.channelAddressTextBox.Location = new System.Drawing.Point(121, 123);
            this.channelAddressTextBox.Multiline = true;
            this.channelAddressTextBox.Name = "channelAddressTextBox";
            this.channelAddressTextBox.Size = new System.Drawing.Size(223, 96);
            this.channelAddressTextBox.TabIndex = 10;
            // 
            // FormMasterChannel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterChannel";
            this.TabText = "Master Channel";
            this.Text = "Master Channel";
            this.Load += new System.EventHandler(this.FormMasterChannel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox channelNameTextBox;
        private System.Windows.Forms.TextBox channelIdTextBox;
        private System.Windows.Forms.TextBox channelFaxTextBox;
        private System.Windows.Forms.TextBox channelPhoneTextBox;
        private System.Windows.Forms.TextBox channelAddressTextBox;
    }
}