namespace Inventori.Contractor.Forms
{
    partial class FormMasterGudang
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
            System.Windows.Forms.Label gudangNameLabel;
            System.Windows.Forms.Label gudangIdLabel;
            this.gudangNameTextBox = new System.Windows.Forms.TextBox();
            this.gudangIdLabel1 = new System.Windows.Forms.Label();
            gudangNameLabel = new System.Windows.Forms.Label();
            gudangIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MGudang);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(gudangIdLabel);
            this.groupBox1.Controls.Add(this.gudangIdLabel1);
            this.groupBox1.Controls.Add(gudangNameLabel);
            this.groupBox1.Controls.Add(this.gudangNameTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 86);
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.gudangNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(gudangNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.gudangIdLabel1, 0);
            this.groupBox1.Controls.SetChildIndex(gudangIdLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 86;
            // 
            // gudangNameLabel
            // 
            gudangNameLabel.AutoSize = true;
            gudangNameLabel.Location = new System.Drawing.Point(15, 55);
            gudangNameLabel.Name = "gudangNameLabel";
            gudangNameLabel.Size = new System.Drawing.Size(82, 13);
            gudangNameLabel.TabIndex = 3;
            gudangNameLabel.Text = "Nama Gudang :";
            // 
            // gudangNameTextBox
            // 
            this.gudangNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "GudangName", true));
            this.gudangNameTextBox.Location = new System.Drawing.Point(100, 52);
            this.gudangNameTextBox.Name = "gudangNameTextBox";
            this.gudangNameTextBox.Size = new System.Drawing.Size(179, 20);
            this.gudangNameTextBox.TabIndex = 4;
            this.gudangNameTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.detailControl_KeyDown);
            // 
            // gudangIdLabel
            // 
            gudangIdLabel.AutoSize = true;
            gudangIdLabel.Location = new System.Drawing.Point(15, 27);
            gudangIdLabel.Name = "gudangIdLabel";
            gudangIdLabel.Size = new System.Drawing.Size(79, 13);
            gudangIdLabel.TabIndex = 4;
            gudangIdLabel.Text = "Kode Gudang :";
            // 
            // gudangIdLabel1
            // 
            this.gudangIdLabel1.AutoSize = true;
            this.gudangIdLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "GudangId", true));
            this.gudangIdLabel1.Location = new System.Drawing.Point(97, 27);
            this.gudangIdLabel1.Name = "gudangIdLabel1";
            this.gudangIdLabel1.Size = new System.Drawing.Size(57, 13);
            this.gudangIdLabel1.TabIndex = 5;
            this.gudangIdLabel1.Text = "Gudang Id";
            // 
            // FormMasterGudang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterGudang";
            this.TabText = "Master Gudang";
            this.Text = "Master Gudang";
            this.Load += new System.EventHandler(this.FormMasterGudang_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gudangNameTextBox;
        private System.Windows.Forms.Label gudangIdLabel1;
    }
}