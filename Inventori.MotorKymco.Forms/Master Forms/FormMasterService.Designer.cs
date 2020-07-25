namespace Inventori.MotorKymco.Forms
{
    partial class FormMasterService
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label itemPriceMaxLabel;
            System.Windows.Forms.Label itemNameLabel;
            System.Windows.Forms.Label itemIdLabel;
            System.Windows.Forms.Label itemDescLabel;
            this.itemPriceMaxNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.itemNameTextBox = new System.Windows.Forms.TextBox();
            this.itemIdTextBox = new System.Windows.Forms.TextBox();
            this.itemDescTextBox = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            itemPriceMaxLabel = new System.Windows.Forms.Label();
            itemNameLabel = new System.Windows.Forms.Label();
            itemIdLabel = new System.Windows.Forms.Label();
            itemDescLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itemPriceMaxNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.MItem);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(itemDescLabel);
            this.groupBox1.Controls.Add(this.itemDescTextBox);
            this.groupBox1.Controls.Add(label2);
            this.groupBox1.Controls.Add(itemPriceMaxLabel);
            this.groupBox1.Controls.Add(this.itemPriceMaxNumericUpDown);
            this.groupBox1.Controls.Add(this.itemNameTextBox);
            this.groupBox1.Controls.Add(itemNameLabel);
            this.groupBox1.Controls.Add(this.itemIdTextBox);
            this.groupBox1.Controls.Add(itemIdLabel);
            this.groupBox1.Size = new System.Drawing.Size(788, 226);
            this.groupBox1.Text = "Master Detail Jasa Service";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(itemIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemIdTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemNameLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemNameTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemPriceMaxNumericUpDown, 0);
            this.groupBox1.Controls.SetChildIndex(itemPriceMaxLabel, 0);
            this.groupBox1.Controls.SetChildIndex(label2, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemDescTextBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemDescLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 226;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(136, 87);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(24, 13);
            label2.TabIndex = 83;
            label2.Text = "Rp.";
            // 
            // itemPriceMaxLabel
            // 
            itemPriceMaxLabel.AutoSize = true;
            itemPriceMaxLabel.Location = new System.Drawing.Point(35, 87);
            itemPriceMaxLabel.Name = "itemPriceMaxLabel";
            itemPriceMaxLabel.Size = new System.Drawing.Size(64, 13);
            itemPriceMaxLabel.TabIndex = 81;
            itemPriceMaxLabel.Text = "Harga Jual :";
            // 
            // itemNameLabel
            // 
            itemNameLabel.AutoSize = true;
            itemNameLabel.Location = new System.Drawing.Point(35, 62);
            itemNameLabel.Name = "itemNameLabel";
            itemNameLabel.Size = new System.Drawing.Size(80, 13);
            itemNameLabel.TabIndex = 79;
            itemNameLabel.Text = "Nama Service :";
            // 
            // itemIdLabel
            // 
            itemIdLabel.AutoSize = true;
            itemIdLabel.Location = new System.Drawing.Point(35, 36);
            itemIdLabel.Name = "itemIdLabel";
            itemIdLabel.Size = new System.Drawing.Size(77, 13);
            itemIdLabel.TabIndex = 77;
            itemIdLabel.Text = "Kode Service :";
            // 
            // itemDescLabel
            // 
            itemDescLabel.AutoSize = true;
            itemDescLabel.Location = new System.Drawing.Point(35, 114);
            itemDescLabel.Name = "itemDescLabel";
            itemDescLabel.Size = new System.Drawing.Size(68, 13);
            itemDescLabel.TabIndex = 84;
            itemDescLabel.Text = "Keterangan :";
            // 
            // itemPriceMaxNumericUpDown
            // 
            this.itemPriceMaxNumericUpDown.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.bindingSource_Master, "ItemPriceMax", true));
            this.itemPriceMaxNumericUpDown.Location = new System.Drawing.Point(165, 85);
            this.itemPriceMaxNumericUpDown.Name = "itemPriceMaxNumericUpDown";
            this.itemPriceMaxNumericUpDown.Size = new System.Drawing.Size(140, 20);
            this.itemPriceMaxNumericUpDown.TabIndex = 82;
            // 
            // itemNameTextBox
            // 
            this.itemNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemName", true));
            this.itemNameTextBox.Location = new System.Drawing.Point(139, 59);
            this.itemNameTextBox.Name = "itemNameTextBox";
            this.itemNameTextBox.Size = new System.Drawing.Size(192, 20);
            this.itemNameTextBox.TabIndex = 80;
            // 
            // itemIdTextBox
            // 
            this.itemIdTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemId", true));
            this.itemIdTextBox.Location = new System.Drawing.Point(139, 33);
            this.itemIdTextBox.Name = "itemIdTextBox";
            this.itemIdTextBox.Size = new System.Drawing.Size(104, 20);
            this.itemIdTextBox.TabIndex = 78;
            // 
            // itemDescTextBox
            // 
            this.itemDescTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "ItemDesc", true));
            this.itemDescTextBox.Location = new System.Drawing.Point(139, 111);
            this.itemDescTextBox.Multiline = true;
            this.itemDescTextBox.Name = "itemDescTextBox";
            this.itemDescTextBox.Size = new System.Drawing.Size(208, 93);
            this.itemDescTextBox.TabIndex = 85;
            // 
            // FormMasterService
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormMasterService";
            this.TabText = "Master Jasa Service";
            this.Text = "Master Jasa Service";
            this.Load += new System.EventHandler(this.FormMasterService_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itemPriceMaxNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown itemPriceMaxNumericUpDown;
        private System.Windows.Forms.TextBox itemNameTextBox;
        private System.Windows.Forms.TextBox itemIdTextBox;
        private System.Windows.Forms.TextBox itemDescTextBox;
    }
}