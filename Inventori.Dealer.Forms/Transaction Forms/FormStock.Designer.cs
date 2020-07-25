namespace Inventori.Dealer.Forms
{
    partial class FormStock
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
            System.Windows.Forms.Label stockDesc1Label;
            System.Windows.Forms.Label stockDesc2Label;
            System.Windows.Forms.Label stockDesc3Label;
            System.Windows.Forms.Label stockIdLabel;
            System.Windows.Forms.Label itemIdLabel;
            this.stockDesc1ComboBox = new System.Windows.Forms.ComboBox();
            this.stockDesc2TextBox = new System.Windows.Forms.TextBox();
            this.stockDesc3TextBox = new System.Windows.Forms.TextBox();
            this.stockIdLabel1 = new System.Windows.Forms.Label();
            this.itemIdComboBox = new System.Windows.Forms.ComboBox();
            stockDesc1Label = new System.Windows.Forms.Label();
            stockDesc2Label = new System.Windows.Forms.Label();
            stockDesc3Label = new System.Windows.Forms.Label();
            stockIdLabel = new System.Windows.Forms.Label();
            itemIdLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingSource_Master
            // 
            this.bindingSource_Master.DataSource = typeof(Inventori.Data.TStock);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(itemIdLabel);
            this.groupBox1.Controls.Add(this.itemIdComboBox);
            this.groupBox1.Controls.Add(stockIdLabel);
            this.groupBox1.Controls.Add(this.stockIdLabel1);
            this.groupBox1.Controls.Add(stockDesc1Label);
            this.groupBox1.Controls.Add(this.stockDesc1ComboBox);
            this.groupBox1.Controls.Add(stockDesc2Label);
            this.groupBox1.Controls.Add(this.stockDesc2TextBox);
            this.groupBox1.Controls.Add(stockDesc3Label);
            this.groupBox1.Controls.Add(this.stockDesc3TextBox);
            this.groupBox1.Size = new System.Drawing.Size(788, 188);
            this.groupBox1.Text = "Master Detail Stok Unit";
            this.groupBox1.Controls.SetChildIndex(this.lbl_UserName, 0);
            this.groupBox1.Controls.SetChildIndex(this.stockDesc3TextBox, 0);
            this.groupBox1.Controls.SetChildIndex(stockDesc3Label, 0);
            this.groupBox1.Controls.SetChildIndex(this.stockDesc2TextBox, 0);
            this.groupBox1.Controls.SetChildIndex(stockDesc2Label, 0);
            this.groupBox1.Controls.SetChildIndex(this.stockDesc1ComboBox, 0);
            this.groupBox1.Controls.SetChildIndex(stockDesc1Label, 0);
            this.groupBox1.Controls.SetChildIndex(this.stockIdLabel1, 0);
            this.groupBox1.Controls.SetChildIndex(stockIdLabel, 0);
            this.groupBox1.Controls.SetChildIndex(this.itemIdComboBox, 0);
            this.groupBox1.Controls.SetChildIndex(itemIdLabel, 0);
            // 
            // splitContainer1
            // 
            this.splitContainer1.SplitterDistance = 188;
            // 
            // stockDesc1Label
            // 
            stockDesc1Label.AutoSize = true;
            stockDesc1Label.Location = new System.Drawing.Point(10, 74);
            stockDesc1Label.Name = "stockDesc1Label";
            stockDesc1Label.Size = new System.Drawing.Size(45, 13);
            stockDesc1Label.TabIndex = 1;
            stockDesc1Label.Text = "Warna :";
            // 
            // stockDesc2Label
            // 
            stockDesc2Label.AutoSize = true;
            stockDesc2Label.Location = new System.Drawing.Point(10, 101);
            stockDesc2Label.Name = "stockDesc2Label";
            stockDesc2Label.Size = new System.Drawing.Size(68, 13);
            stockDesc2Label.TabIndex = 3;
            stockDesc2Label.Text = "No Rangka :";
            // 
            // stockDesc3Label
            // 
            stockDesc3Label.AutoSize = true;
            stockDesc3Label.Location = new System.Drawing.Point(10, 127);
            stockDesc3Label.Name = "stockDesc3Label";
            stockDesc3Label.Size = new System.Drawing.Size(58, 13);
            stockDesc3Label.TabIndex = 5;
            stockDesc3Label.Text = "No Mesin :";
            // 
            // stockIdLabel
            // 
            stockIdLabel.AutoSize = true;
            stockIdLabel.Location = new System.Drawing.Point(10, 26);
            stockIdLabel.Name = "stockIdLabel";
            stockIdLabel.Size = new System.Drawing.Size(63, 13);
            stockIdLabel.TabIndex = 9;
            stockIdLabel.Text = "Kode Stok :";
            // 
            // stockDesc1ComboBox
            // 
            this.stockDesc1ComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource_Master, "StockDesc1", true));
            this.stockDesc1ComboBox.FormattingEnabled = true;
            this.stockDesc1ComboBox.Location = new System.Drawing.Point(88, 71);
            this.stockDesc1ComboBox.Name = "stockDesc1ComboBox";
            this.stockDesc1ComboBox.Size = new System.Drawing.Size(201, 21);
            this.stockDesc1ComboBox.TabIndex = 2;
            // 
            // stockDesc2TextBox
            // 
            this.stockDesc2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "StockDesc2", true));
            this.stockDesc2TextBox.Location = new System.Drawing.Point(88, 98);
            this.stockDesc2TextBox.Name = "stockDesc2TextBox";
            this.stockDesc2TextBox.Size = new System.Drawing.Size(201, 20);
            this.stockDesc2TextBox.TabIndex = 4;
            // 
            // stockDesc3TextBox
            // 
            this.stockDesc3TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "StockDesc3", true));
            this.stockDesc3TextBox.Location = new System.Drawing.Point(88, 124);
            this.stockDesc3TextBox.Name = "stockDesc3TextBox";
            this.stockDesc3TextBox.Size = new System.Drawing.Size(201, 20);
            this.stockDesc3TextBox.TabIndex = 6;
            // 
            // stockIdLabel1
            // 
            this.stockIdLabel1.AutoSize = true;
            this.stockIdLabel1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource_Master, "StockId", true));
            this.stockIdLabel1.Location = new System.Drawing.Point(85, 26);
            this.stockIdLabel1.Name = "stockIdLabel1";
            this.stockIdLabel1.Size = new System.Drawing.Size(27, 13);
            this.stockIdLabel1.TabIndex = 10;
            this.stockIdLabel1.Text = "stok";
            // 
            // itemIdLabel
            // 
            itemIdLabel.AutoSize = true;
            itemIdLabel.Location = new System.Drawing.Point(10, 47);
            itemIdLabel.Name = "itemIdLabel";
            itemIdLabel.Size = new System.Drawing.Size(59, 13);
            itemIdLabel.TabIndex = 10;
            itemIdLabel.Text = "Type Unit :";
            // 
            // itemIdComboBox
            // 
            this.itemIdComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.bindingSource_Master, "ItemId", true));
            this.itemIdComboBox.FormattingEnabled = true;
            this.itemIdComboBox.Location = new System.Drawing.Point(88, 44);
            this.itemIdComboBox.Name = "itemIdComboBox";
            this.itemIdComboBox.Size = new System.Drawing.Size(201, 21);
            this.itemIdComboBox.TabIndex = 11;
            // 
            // FormStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Name = "FormStock";
            this.TabText = "Daftar Stok Unit";
            this.Text = "Daftar Stok Unit";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_Master)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox stockDesc1ComboBox;
        private System.Windows.Forms.TextBox stockDesc2TextBox;
        private System.Windows.Forms.TextBox stockDesc3TextBox;
        private System.Windows.Forms.Label stockIdLabel1;
        private System.Windows.Forms.ComboBox itemIdComboBox;
    }
}