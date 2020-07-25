namespace Inventori.Dealer.Forms
{
    partial class FormMasterColour
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
            System.Windows.Forms.Label colourIdLabel;
            System.Windows.Forms.Label colourDescLabel;
            this.colourIdTextBox = new System.Windows.Forms.TextBox();
            this.colourDescTextBox = new System.Windows.Forms.TextBox();
            colourIdLabel = new System.Windows.Forms.Label();
            colourDescLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MColour);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(colourDescLabel);
            this.groupBox1.Controls.Add(this.colourDescTextBox);
            this.groupBox1.Controls.Add(colourIdLabel);
            this.groupBox1.Controls.Add(this.colourIdTextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 79);
            this.groupBox1.Text = "Master Detail Warna";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.colourIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(colourIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.colourDescTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(colourDescLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 79;
            // 
            // colourIdLabel
            // 
            colourIdLabel.AutoSize = true;
            colourIdLabel.Location = new System.Drawing.Point(22, 22);
            colourIdLabel.Name = "colourIdLabel";
            colourIdLabel.Size = new System.Drawing.Size(73, 13);
            colourIdLabel.TabIndex = 1;
            colourIdLabel.Text = "Kode Warna :";
            // 
            // colourDescLabel
            // 
            colourDescLabel.AutoSize = true;
            colourDescLabel.Location = new System.Drawing.Point(22, 48);
            colourDescLabel.Name = "colourDescLabel";
            colourDescLabel.Size = new System.Drawing.Size(45, 13);
            colourDescLabel.TabIndex = 3;
            colourDescLabel.Text = "Warna :";
            // 
            // colourIdTextBox
            // 
            this.colourIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ColourId", true));
            this.colourIdTextBox.Location = new System.Drawing.Point(98, 19);
            this.colourIdTextBox.Name = "colourIdTextBox";
            this.colourIdTextBox.Size = new System.Drawing.Size(167, 20);
            this.colourIdTextBox.TabIndex = 2;
            // 
            // colourDescTextBox
            // 
            this.colourDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ColourDesc", true));
            this.colourDescTextBox.Location = new System.Drawing.Point(98, 45);
            this.colourDescTextBox.Name = "colourDescTextBox";
            this.colourDescTextBox.Size = new System.Drawing.Size(208, 20);
            this.colourDescTextBox.TabIndex = 4;
            this.colourDescTextBox.TextChanged += new System.EventHandler(this.colourDescTextBox_TextChanged);
            // 
            // FormMasterColour
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterColour";
            this.TabText = "Master Warna";
            this.Text = "Master Warna";
            this.Load += new System.EventHandler(this.FormMasterColour_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox colourIdTextBox;
        private System.Windows.Forms.TextBox colourDescTextBox;
    }
}